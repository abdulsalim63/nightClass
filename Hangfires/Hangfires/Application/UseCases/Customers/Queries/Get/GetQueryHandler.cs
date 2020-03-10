using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hangfires.Domain.Entities;
using Hangfires.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Hangfires.Application.UseCases.Customers //.Queries.Get
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<Customer>>
    {
        private readonly CustomerContext _context;

        public GetCustomerQueryHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {

            return await _context.customers.ToListAsync();
        }
    }
}
