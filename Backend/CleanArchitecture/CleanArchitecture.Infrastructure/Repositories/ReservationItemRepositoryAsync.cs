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
    public class ReservationItemRepositoryAsync : GenericRepositoryAsync<ReservationItem>
    {
        private readonly DbSet<ReservationItem> _reservationItems;

        public ReservationItemRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _reservationItems = dbContext.Set<ReservationItem>();
        }

    }
}
