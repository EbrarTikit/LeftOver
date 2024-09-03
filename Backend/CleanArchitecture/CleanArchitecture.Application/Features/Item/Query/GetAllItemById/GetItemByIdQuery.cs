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

namespace CleanArchitecture.Core.Features.Item.Query.GetAllItemById
{
    public class GetItemByIdQuery : IRequest<Response<Entities.Item>>
    {
        public int Id { get; set; }
        public class GetItemsByIdQueryHandler : IRequestHandler<GetItemByIdQuery, Response<Entities.Item>>
        {
            private readonly IItemRepositoryAsync _itemRepository;
            public GetItemsByIdQueryHandler(IItemRepositoryAsync itemRepository)
            {
                _itemRepository = itemRepository;
            }
            public async Task<Response<Entities.Item>> Handle(GetItemByIdQuery query, CancellationToken cancellationToken)
            {
                var item = await _itemRepository.GetByIdAsync(query.Id);
                if (item == null) throw new ApiException($"Item Not Found.");
                return new Response<Entities.Item>(item);
            }
        }
    }
}
