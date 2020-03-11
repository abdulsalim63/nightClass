using System;
using MediatR;
using Mediator.Domain.Entities;

namespace Mediator.Application.UseCases.Customers //.Queries.GetbyId
{
    public class GetbyIdCustomerQuery : IRequest<Customer>
    {
        public int id { get; set; }
    }
}
