using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IAddressRepositoryAsync : IGenericRepositoryAsync<Address>
    {
       /* Task<List<Address>> GetAllAddressesByUserNameAsync(string userName);*/
        Task<IReadOnlyList<Address>> GetAllAsync(Expression<Func<Address, bool>> predicate);

    }
}
