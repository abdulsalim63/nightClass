using System;
using MediatR;
using Mediator.Domain.Entities;
using Mediator.Infrastructure;
using System.Threading.Tasks;
using System.Threading;

namespace Mediator.Application.UseCases.Customers //.Queries.GetbyId
{
    public class GetbyIdCustomerQueryHandler : IRequestHandler<GetbyIdCustomerQuery, Customer>
    {
        private readonly ProjectConetxt _context;

        public GetbyIdCustomerQueryHandler(ProjectConetxt context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(GetbyIdCustomerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.customers.FindAsync(request.id);
                //return new Customer { username = "salim", address = "bandung" };
            }
            catch
            {
                return null;
            }
        }
    }
}
