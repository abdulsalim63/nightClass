using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Mediator.Domain.Entities;
using Mediator.Infrastructure;

namespace Mediator.Application.UseCases.Customers //.Queries.Get
{
    public class GetQueryHandler : IRequestHandler<GetCustomerQuery, List<Customer>>
    {
        private readonly ProjectConetxt _context;

        public GetQueryHandler(ProjectConetxt context)
        {
            _context = context;
        }

        public async Task<List<Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = new List<Customer>
            {
                new Customer { id = 1}
            };

            return await _context.customers.ToListAsync();

            //return customers;
        }
    }
}
