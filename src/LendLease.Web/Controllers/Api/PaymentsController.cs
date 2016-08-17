using LendLease.Interfaces;
using LendLease.Models;
using Microsoft.AspNetCore.Mvc;

namespace LendLease.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentsController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet("address/{id}", Name = "GetAddressPayment")]
        public IActionResult GetAll(int id)
        {
            return new ObjectResult(_paymentRepository.GetAll(id));
        }

        [HttpGet("{id}/address/{cid}", Name = "GetPayment")]
        public IActionResult GetById(int id, int cid)
        {
            var item = _paymentRepository.Find(cid, id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Payment item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _paymentRepository.Add(item);
            return CreatedAtRoute("GetPayment", new { id = item.Id, cid = item.AddressId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Payment item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var customer = _paymentRepository.Find(item.AddressId, id);
            if (customer == null)
            {
                return NotFound();
            }

            _paymentRepository.Update(item);
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] Payment item, int id)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var customer = _paymentRepository.Find(item.AddressId, id);
            if (customer == null)
            {
                return NotFound();
            }

            item.Id = customer.Id;

            _paymentRepository.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var payment = _paymentRepository.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            _paymentRepository.Remove(id);
            return new NoContentResult();
        }
    }
}