using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public class IReservationItemRepositoryAsync : IGenericRepositoryAsync<ReservationItem>
    {
        public Task<ReservationItem> AddAsync(ReservationItem entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ReservationItem entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ReservationItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReservationItem> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ReservationItem>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ReservationItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
