using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Features.Restaurant.Command.UpdateRestaurant;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Customer.Command.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<int>>
        {
            private readonly ICustomerRepositoryAsync _customerRepository;
            public UpdateCustomerCommandHandler(ICustomerRepositoryAsync customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<Response<int>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(command.Id);

                if (customer == null) throw new EntityNotFoundException("customer", command.Id);

                customer.FirstName = command.FirstName;
                customer.LastName = command.LastName;
                customer.UserName = command.UserName;
                customer.PhoneNumber = command.PhoneNumber;

                await _customerRepository.UpdateAsync(customer);

                return new Response<int>(customer.Id);
            }
        }
    }
}
