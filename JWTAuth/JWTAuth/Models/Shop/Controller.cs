using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Models.Shop
{
    [ApiController]
    [Route("api/[controller]")] // path : api/shop
    public class ShopController : ControllerBase
    {
        private readonly ShopContext _context;

        public ShopController(ShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customer = _context.customers.ToList();
            var address = _context.addresses.ToList();
            var order = _context.orders.ToList();

            var result = customer.Select(s =>
                    new
                    {
                        id = s.id,
                        name = s.name,
                        address = address.First(x => x.customer_id == s.id),
                        orders = order.Where(x => x.customer_id == s.id)
                                      .Select(s => new {
                                          name = s.name,
                                          price = s.price
                                      })
                    }
                );

            return Ok(new {
                Message = "Succes retrieve shop data",
                Status = true,
                Data = result
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int Id)
        {
            try
            {
                var customer = _context.customers.First(x => x.id == Id);
                var address = _context.addresses.ToList();
                var order = _context.orders.ToList();

                var result = new
                {
                    id = customer.id,
                    name = customer.name,
                    address = address.First(x => x.customer_id == customer.id),
                    orders = order.Where(x => x.customer_id == customer.id)
                                  .Select(s => new {
                                      name = s.name,
                                      price = s.price
                                  })
                };

                return Ok(new
                {
                    Message = "Succes retrieve shop data",
                    Status = true,
                    Data = result
                });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
