using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Reservation.Commands.DeleteReservation
{
    public class DeleteReservation : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteReservationHandler : IRequestHandler<DeleteReservation, Response<int>>
    {
        private readonly IReservationRepositoryAsync _reservationRepositoryAsync;

        public DeleteReservationHandler(IReservationRepositoryAsync reservationRepositoryAsync)
        {
            _reservationRepositoryAsync = reservationRepositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteReservation request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepositoryAsync.GetByIdAsync(request.Id);
            if (reservation == null)
            {
                throw new InvalidOperationException("Reservation not found.");
            }

            if (!reservation.isCancelled)
            {
                var creationTime = reservation.Created;
                var currentTime = DateTime.UtcNow;
                var timeDifference = currentTime - creationTime;

                if (!reservation.isDelivered && timeDifference.TotalHours >= 1)
                {
                    reservation.isCancelled = true;
                }
                else
                {
                    reservation.isCancelled = false;
                }
            }

            if (reservation.isCancelled)
            {
                await _reservationRepositoryAsync.DeleteAsync(reservation);
            }

            return new Response<int>(reservation.Id);
        }
    }
}
