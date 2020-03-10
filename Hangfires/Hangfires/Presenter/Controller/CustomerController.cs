using System;
using System.Collections.Generic;
using Hangfires.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Hangfire;
using MediatR;
using Hangfires.Application.UseCases.Customers;
using System.Threading.Tasks;

namespace Hangfires.Presenter.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public string UseMediator(string s)
        {
            Console.WriteLine(s);
            return s;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            BackgroundJob.Enqueue(() => UseMediator("Somebody Getting Customer Data"));

            return Ok(await _mediator.Send(new GetCustomerQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCustomerCommand request)
        {
            BackgroundJob.Enqueue(() => UseMediator("Somebody Posting Customer Data"));

            return Ok(await _mediator.Send(new CreateCustomerCommand() { data = request.data }));
        }
    }
}
