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

namespace CleanArchitecture.Core.Features.Item.Command.DeleteItem
{
    public class DeleteItemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Response<int>>
        {
            private readonly IItemRepositoryAsync _itemRepository;
            public DeleteItemCommandHandler(IItemRepositoryAsync itemRepository)
            {
                _itemRepository = itemRepository;
            }
            public async Task<Response<int>> Handle(DeleteItemCommand command, CancellationToken cancellationToken)
            {
                var item = await _itemRepository.GetByIdAsync(command.Id);
                if (item == null) throw new ApiException($"Item Not Found.");
                await _itemRepository.DeleteAsync(item);
                return new Response<int>(item.Id);
            }
        }
    }
}