using System.Collections.Generic;
using LendLease.Interfaces;
using LendLease.Models;
using Microsoft.AspNetCore.Mvc;

namespace LendLease.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetById(int id)
        {
            var item = _customerRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Customer item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _customerRepository.Add(item);
            return CreatedAtRoute("GetCustomer", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Customer item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _customerRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _customerRepository.Update(item);
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] Customer item, int id)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var todo = _customerRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            item.Id = todo.Id;

            _customerRepository.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _customerRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _customerRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
