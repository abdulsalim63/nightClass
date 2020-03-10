using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfires.Application.Models.Query;
using Hangfires.Domain.Entities;
using Hangfires.Infrastructure;
using MediatR;

namespace Hangfires.Application.UseCases.Customers.Command.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, BaseResponse<Customer>>
    {
        private readonly CustomerContext _context;

        public CreateCustomerCommandHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            _context.customers.Add(request.data.attributes);
            await _context.SaveChangesAsync();

            return new BaseResponse<Customer>
            {
                Message = "Success Add Customer Data",
                Status = true,
                Data = request.data.attributes
            };
        }
    }
}
