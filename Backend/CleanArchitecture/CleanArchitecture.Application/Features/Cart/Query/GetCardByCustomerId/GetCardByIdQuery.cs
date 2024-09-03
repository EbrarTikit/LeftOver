using AutoMapper;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Cart.Query.GetCardByCustomerId
{
    public class GetCartByIdQuery : IRequest<GetCardByIdViewModel>
    {
        public int CustomerId { get; set; }
    }

    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, GetCardByIdViewModel>
    {
        private readonly ICartRepositoryAsync _cartRepository;
        private readonly IMapper _mapper;

        public GetCartByIdQueryHandler(ICartRepositoryAsync cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<GetCardByIdViewModel> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartByCustomerIdAsync(request.CustomerId);
            if (cart == null) return null;

            return _mapper.Map<GetCardByIdViewModel>(cart);
        }
    }

}
