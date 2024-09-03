using AutoMapper;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CleanArchitecture.Core.Features.Address.Query.GetAllAddresses;
using CleanArchitecture.Core.Wrappers;
using System.Linq;

namespace CleanArchitecture.Core.Features.Address.Query.GetAllAddresses
{

    public class GetAllAddressesQuery : IRequest<PagedResponse<IEnumerable<GetAllAddressesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string UserName { get; set; }
    }

    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, PagedResponse<IEnumerable<GetAllAddressesViewModel>>>
    {
        private readonly IAddressRepositoryAsync _addressRepository;

        public GetAllAddressesQueryHandler(IAddressRepositoryAsync addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<PagedResponse<IEnumerable<GetAllAddressesViewModel>>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetAllAsync(a => a.UserName == request.UserName);

            var viewModel = addresses
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(address => new GetAllAddressesViewModel
                {
                    Id = address.Id,
                    UserName = address.UserName,
                    AddressDefinition = address.AddressDefinition,
                    City = address.City,
                    Town = address.Town,
                    Neighbourhood = address.Neighbourhood,
                    BuildingNo = address.BuildingNo,
                    Floor = address.Floor,
                    AddressTitle = address.AddressTitle,
                    AdressDirection = address.AdressDirection
                });

            return new PagedResponse<IEnumerable<GetAllAddressesViewModel>>(viewModel, request.PageNumber, request.PageSize);
        }
    }
}

