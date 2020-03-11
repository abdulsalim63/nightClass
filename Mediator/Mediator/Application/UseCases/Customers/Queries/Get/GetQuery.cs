using System;
using System.Collections.Generic;
using Mediator.Domain.Entities;
using MediatR;

namespace Mediator.Application.UseCases.Customers //.Queries.Get
{
    public class GetCustomerQuery : IRequest<List<Customer>>
    {
    }
}
