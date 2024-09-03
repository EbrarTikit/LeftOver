using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Features.Item.Command;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CleanArchitecture.Core.Entities;


namespace CleanArchitecture.Core.Features.Item.Command.UpdateItem
{
    public class UpdateItemCommand : IRequest<Response<int>>
    {
        //  public string RestaurantID { get; }
        public int Id { get; set; }
        public string itemName { get; set; }
        public double price { get; set; }
        public string picture { get; set; }
        public string explanation { get; set; }
        public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Response<int>>
        {
            private readonly IItemRepositoryAsync _itemRepository;
            public UpdateItemCommandHandler(IItemRepositoryAsync itemRepository)
            {
                _itemRepository = itemRepository;
            }
            public async Task<Response<int>> Handle(UpdateItemCommand command, CancellationToken cancellationToken)
            {
                var item = await _itemRepository.GetByIdAsync(command.Id);

                if (item == null) throw new EntityNotFoundException("item", command.Id);

                item.itemName = command.itemName;
                item.price = command.price;
                item.picture = command.picture;
                item.explanation = command.explanation;


                await _itemRepository.UpdateAsync(item);

                return new Response<int>(item.Id);
            }
        }
    }
}