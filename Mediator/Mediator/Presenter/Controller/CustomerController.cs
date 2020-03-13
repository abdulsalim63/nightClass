using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Mediator.Application.UseCases.Customers;
using System.Threading.Tasks;

namespace Mediator.Presenter.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CustomerController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand request)
        {
            return Ok(await _mediatr.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediatr.Send(new GetCustomerQuery() ));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetbyId(int Id)
        {
            return Ok(await _mediatr.Send(new GetbyIdCustomerQuery
            {
                id = Id
            }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutbyId(int Id, [FromBody] UpdateCustomerCommand request)
        {
            return Ok(await _mediatr.Send(new UpdateCustomerCommand() { id = Id, data = request.data }));
        }
    }
}
