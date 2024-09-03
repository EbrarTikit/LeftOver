using CleanArchitecture.Core;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Models;
using CleanArchitecture.WebApi.Extensions;
using CleanArchitecture.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add configurations
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true);

// Add services to the container
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddSwaggerExtension();
builder.Services.AddControllers();
builder.Services.AddApiVersioningExtension();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();


builder.Services.AddScoped<IRestaurantRepositoryAsync, RestaurantRepositoryAsync>();


// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Add session middleware
app.UseSession();


app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerExtension();
app.UseErrorHandlingMiddleware();
app.UseHealthChecks("/health");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Initialize Logger
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Seed Default Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await SeedDefaultDataAsync(userManager, roleManager);

        Log.Information("Finished Seeding Default Data");
        Log.Information("Application Starting");
    }
    catch (Exception ex)
    {
        Log.Warning(ex, "An error occurred seeding the DB");
    }
    finally
    {
        Log.CloseAndFlush();
    }
}

// SeedDefaultDataAsync method
 static async Task SeedDefaultDataAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
{
    await CleanArchitecture.Infrastructure.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
    await CleanArchitecture.Infrastructure.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
    await CleanArchitecture.Infrastructure.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);
}

// Start the application
app.Run();
