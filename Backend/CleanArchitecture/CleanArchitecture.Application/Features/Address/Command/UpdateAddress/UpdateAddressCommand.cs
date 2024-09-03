using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CleanArchitecture.Core.Wrappers;

namespace CleanArchitecture.Core.Features.Address.Command.UpdateAddress
{


    public class UpdateAddressCommand : IRequest<Response<int>>
    {
        public int Id { get; set; } 
        public string UserName { get;  }
        public string AddressDefinition { get; set; } //avene street and other info
        public string City { get; set; }
        public string Town { get; set; }
        public string Neighbourhood { get; set; }
        public int BuildingNo { get; set; }
        public int Floor { get; set; }
        public string AddressTitle { get; set; }
        public string AdressDirection { get; set; }

    }

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Response<int>>
    {
        private readonly IAddressRepositoryAsync _addressRepositoryAsync;

        public UpdateAddressCommandHandler(IAddressRepositoryAsync addressRepositoryAsync)
        {
            _addressRepositoryAsync = addressRepositoryAsync;
        }

        public async Task<Response<int>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {

            var address = await _addressRepositoryAsync.GetByIdAsync(request.Id);
            if (address == null) throw new EntityNotFoundException("Address",request.Id);


            
            address.AddressDefinition = request.AddressDefinition;
            address.City = request.City;
            address.Town = request.Town;
            address.Neighbourhood = request.Neighbourhood;
            address.BuildingNo = request.BuildingNo;
            address.Floor = request.Floor;
                address.AddressTitle = request.AddressTitle;
            address.AdressDirection = request.AdressDirection;

            await _addressRepositoryAsync.UpdateAsync(address);

            return new Response<int>( address.Id);
        }

    }
}