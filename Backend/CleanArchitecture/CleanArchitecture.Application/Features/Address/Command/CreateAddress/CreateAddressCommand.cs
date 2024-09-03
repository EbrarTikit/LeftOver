using CleanArchitecture.Core.Features.Address.Command.CreateAddress;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Address.Command.CreateAddress
{
    public class CreateAddressCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string AddressDefinition { get; set; } //avene street and other info
        public string City { get; set; }
        public string Town { get; set; }
        public string Neighbourhood { get; set; }
        public int BuildingNo { get; set; }
        public int Floor { get; set; }
        public string AddressTitle { get; set; }
        public string AdressDirection { get; set; }
    }

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IAddressRepositoryAsync _addressRepositoryAsync;



        public CreateAddressCommandHandler(
            IAddressRepositoryAsync addressRepositoryAsync)
        {
            _addressRepositoryAsync = addressRepositoryAsync;
        }


        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Entities.Address
            {

                UserName = request.UserName,
                AddressDefinition = request.AddressDefinition,
                City = request.City,
                Town = request.Town,
                Neighbourhood = request.Neighbourhood,
                BuildingNo = request.BuildingNo,
                Floor = request.Floor,
                AddressTitle = request.AddressTitle,
                AdressDirection = request.AdressDirection,
                
            };

            await _addressRepositoryAsync.AddAsync(newAddress);

            return newAddress.Id;
        }
    }
}
