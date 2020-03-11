using System;
using MediatR;
using Mediator.Domain.Entities;

namespace Mediator.Application.UseCases.Customers //.Command.Create
{
    public class CreateCustomerCommand : Customer, IRequest<Customer>
    {
    }
}
