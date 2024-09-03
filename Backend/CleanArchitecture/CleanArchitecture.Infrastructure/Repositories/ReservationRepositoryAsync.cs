using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ReservationRepositoryAsync : GenericRepositoryAsync<Reservation>, IReservationRepositoryAsync
    {
        private readonly DbSet<Reservation> _reservation;
        public ReservationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _reservation = dbContext.Set<Reservation>();
        }
        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _reservation
                                 .Include(r => r.Restaurant)
                                 .Include(r => r.Customer)
                                 .ToListAsync();
        }
    }
}
