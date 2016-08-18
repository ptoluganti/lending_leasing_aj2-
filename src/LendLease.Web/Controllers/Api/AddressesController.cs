using LendLease.Interfaces;
using LendLease.Models;
using Microsoft.AspNetCore.Mvc;

namespace LendLease.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class AddressesController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        public AddressesController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet("customer/{id:int}", Name = "GetCustomerAddress")]
        [Produces(typeof(Address[]))]
        public IActionResult GetAll(int id)
        {
            return new ObjectResult(_addressRepository.GetAll(id));
        }

        [HttpGet("{id:int}/customer/{cid:int}", Name = "GetAddress")]
        public IActionResult GetById(int id, int cid)
        {
            var item = _addressRepository.Find(cid, id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Address item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _addressRepository.Add(item);
            return CreatedAtRoute("GetAddress", new { id = item.Id, cid = item.CustomerId }, item);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Address item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var customer = _addressRepository.Find(item.CustomerId, id);
            if (customer == null)
            {
                return NotFound();
            }

            _addressRepository.Update(item);
            return new NoContentResult();
        }

        [HttpPatch("{id:int}")]
        public IActionResult Update([FromBody] Address item, int id)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var customer = _addressRepository.Find(item.CustomerId, id);
            if (customer == null)
            {
                return NotFound();
            }

            item.Id = customer.Id;

            _addressRepository.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var address = _addressRepository.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            _addressRepository.Remove(id);
            return new NoContentResult();
        }
    }
}