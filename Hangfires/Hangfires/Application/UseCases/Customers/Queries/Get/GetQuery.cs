using System;
using MediatR;
using Hangfires.Domain.Entities;
using System.Collections.Generic;

namespace Hangfires.Application.UseCases.Customers //.Queries.Get
{
    public class GetCustomerQuery : IRequest<List<Customer>>
    {
    }
}
