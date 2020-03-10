using System;
using MediatR;
using Hangfires.Domain.Entities;
using Hangfires.Application.Models.Query;

namespace Hangfires.Application.UseCases.Customers //.Command.Create
{
    public class CreateCustomerCommand : BaseRequest<Customer>, IRequest<BaseResponse<Customer>>
    {
    }
}
