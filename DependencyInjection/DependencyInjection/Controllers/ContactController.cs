using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
using DependencyInjection.Models;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        // Attributes
        private readonly IDatabase _database;

        // Constructor
        public ContactController(IDatabase database)
        {
            _database = database;
        }

        // path localhost:port/contact
        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            _database.Create(contact);
            return Ok();
        }
    }
}
