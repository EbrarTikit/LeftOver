using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Features.Address.Query.GetAddressById
{

    public class GetAddressByIdQuery : IRequest<Response<Entities.Address>>
    {
        public int Id { get; set; }
        public class GetAddresssByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, Response<Entities.Address>>
        {
            private readonly IAddressRepositoryAsync _addressRepository;
            public GetAddresssByIdQueryHandler(IAddressRepositoryAsync addressRepository)
            {
                _addressRepository = addressRepository;
            }
            public async Task<Response<Entities.Address>> Handle(GetAddressByIdQuery query, CancellationToken cancellationToken)
            {
                var address = await _addressRepository.GetByIdAsync(query.Id);
                if (address == null) throw new ApiException($"Address Not Found.");
                return new Response<Entities.Address>(address);
            }
        }

    }
}