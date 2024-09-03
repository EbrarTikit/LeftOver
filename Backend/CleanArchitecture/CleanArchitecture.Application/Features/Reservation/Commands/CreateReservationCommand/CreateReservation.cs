using CleanArchitecture.Core.Features.Reservation.Commands;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Core.Features.Address.Command.CreateAddress;

namespace CleanArchitecture.Core.Features.Reservation.Commands.CreateReservationCommand
{
    public class CreateReservation : IRequest<int>
    {
        
        public int RestaurantId { get; set; }
        public int itemId { get; set; }
        public bool isDelivered { get; set; }
        public bool isCancelled { get; set; }
        public double totalPrice { get; set; }
        public string ReservationCode { get; set; }
        public DateTime Created { get; set; }

    }

    public class AddReservationCommandHandler : IRequestHandler<CreateReservation, int>
    {
        private readonly IReservationRepositoryAsync _reservationRepositoryAsync;
        private readonly IItemRepositoryAsync _itemRepositoryAsync;


        public AddReservationCommandHandler(
            IReservationRepositoryAsync reservationRepositoryAsync, IItemRepositoryAsync itemRepositoryAsync)
        {
            _reservationRepositoryAsync = reservationRepositoryAsync;
            _itemRepositoryAsync = itemRepositoryAsync;
        }


        public async Task<int> Handle(CreateReservation request, CancellationToken cancellationToken)
        {

           

           
                var item = await _itemRepositoryAsync.GetByIdAsync(request.itemId);
                if (item == null)
                {
                    throw new InvalidOperationException($"Item with ID {request.itemId} not found.");
                }
            double totalPrice = 0.0; // Toplam fiyatý hesaplamak için kullanacaðýz
            totalPrice += item.price; // Ürün fiyatýný toplam fiyata ekle
            
            var newReservation = new Entities.Reservation
            {

                RestaurantId = request.RestaurantId,
                isDelivered = request.isDelivered,
                isCancelled = request.isCancelled,
                totalPrice = request.totalPrice,
                Created = DateTime.UtcNow,
                 ReservationCode=Guid.NewGuid().ToString()
            };

            await _reservationRepositoryAsync.AddAsync(newReservation);

            return newReservation.Id;
        }
    }
    }

