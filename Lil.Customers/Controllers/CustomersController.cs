﻿using Lil.Customers.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lil.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider _customersProvider;

        public CustomersController(ICustomersProvider customersProvider)
        {
            _customersProvider = customersProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var customer = await _customersProvider.GetAsync(id);

            if (customer != null)
            {
                return Ok(customer);
            }

            return NotFound();
        }
    }
}
