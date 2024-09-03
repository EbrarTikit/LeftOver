using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Features.Restaurant.Command.DeleteRestaurant;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Cart.Command.DeleteCart
{
    public class DeleteCartCommand : IRequest<Response<int>>
    {     
        public int Id { get; set; }
        public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, Response<int>>
        {
            private readonly ICartRepositoryAsync _cartRepository;
            public DeleteCartCommandHandler(ICartRepositoryAsync cartRepository)
            {
                _cartRepository = cartRepository;
            }
            public async Task<Response<int>> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
            {
                var cart = await _cartRepository.GetByIdAsync(command.Id);
                if (cart == null) throw new ApiException($"Cart Not Found.");
                await _cartRepository.DeleteAsync(cart);
                return new Response<int>(cart.Id);
            }
        }
    }
}
