using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Wrappers;

namespace CleanArchitecture.Core.Features.Address.Command.DeleteAddress
{
    public class DeleteAddressCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, Response<int>>
    {
        private readonly IAddressRepositoryAsync _addressRepositoryAsync;

        public DeleteAddressCommandHandler(IAddressRepositoryAsync addressRepositoryAsync)
        {
            _addressRepositoryAsync = addressRepositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepositoryAsync.GetByIdAsync(request.Id);
            if (address == null) throw new ApiException($"Address not found.");
            await _addressRepositoryAsync.DeleteAsync(address);
            return new Response<int>(address.Id);
        }
    }
}
