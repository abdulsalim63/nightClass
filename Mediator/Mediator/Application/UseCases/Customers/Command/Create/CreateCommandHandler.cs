﻿using System;
using MediatR;
using Mediator.Domain.Entities;
using Mediator.Infrastructure;
using System.Threading.Tasks;
using System.Threading;

namespace Mediator.Application.UseCases.Customers //.Command.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ProjectConetxt _context;

        public CreateCustomerCommandHandler(ProjectConetxt context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = request.data.attributes;
            customer.created_at = 10;
            customer.updated_at = 10;
            _context.customers.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return customer;
        }
    }
}
