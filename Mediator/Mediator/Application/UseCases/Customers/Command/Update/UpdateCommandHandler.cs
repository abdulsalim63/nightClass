using System;
using MediatR;
using Mediator.Infrastructure;
using Mediator.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace Mediator.Application.UseCases.Customers //.Command.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly ProjectConetxt _context;

        public UpdateCustomerCommandHandler(ProjectConetxt context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.customers.FindAsync(request.id);
                var customer = request.data.attributes;
                result.username = customer.username;
                result.address = customer.address;
                result.updated_at = customer.updated_at;
                await _context.SaveChangesAsync();
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
