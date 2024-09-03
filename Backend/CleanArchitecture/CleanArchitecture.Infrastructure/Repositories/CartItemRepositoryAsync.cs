using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class CartItemRepositoryAsync : GenericRepositoryAsync<CartItem>, ICartItemRepositoryAsync
    {

        private readonly DbSet<CartItem> _cartItems;

        public CartItemRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _cartItems = dbContext.Set<CartItem>();
        }

        
    }
}
