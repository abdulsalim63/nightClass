using System;
using MediatR;
using Mediator.Domain.Entities;

namespace Mediator.Application.UseCases.Customers //.Command.Create
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public DataCustomer data { get; set; }
    }

    public class DataCustomer
    {
        public Customer attributes { get; set; }
    }
}
