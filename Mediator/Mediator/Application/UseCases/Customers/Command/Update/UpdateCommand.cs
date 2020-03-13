using System;
using MediatR;
using Mediator.Domain.Entities;

namespace Mediator.Application.UseCases.Customers //.Command.Update
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public int id { get; set; }

        public CustomerData data { get; set; }
    }

    public class CustomerData
    {
        public Customer attributes { get; set; }
    }
}
