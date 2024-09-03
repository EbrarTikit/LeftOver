using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Cart.Command.CreateCart
{
    public class CreateCartCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
    }

    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, int>
    {
        private readonly ICartRepositoryAsync _cartRepository;

        public CreateCartCommandHandler(ICartRepositoryAsync cartRepository)
        { 
            _cartRepository = cartRepository;
        }

        public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = new Entities.Cart
            {
                customerId = request.CustomerId,
                price = 0 // Initial total price
            };

            await _cartRepository.AddAsync(cart);
            return cart.Id;
        }
    }

}
