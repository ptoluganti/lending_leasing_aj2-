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

        [HttpGet("address/{id:int}", Name = "GetAddressPayment")]
        [Produces(typeof(Payment[]))]
        public IActionResult GetAll(int id)
        {
            return new ObjectResult(_paymentRepository.GetAll(id));
        }

        [HttpGet("{id:int}/address/{aid:int}", Name = "GetPayment")]
        public IActionResult GetById(int id, int aid)
        {
            var item = _paymentRepository.Find(aid, id);
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

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _paymentRepository.Add(item);
            return CreatedAtRoute("GetPayment", new { id = item.Id, aid = item.AddressId }, item);
        }

        [HttpPut("{id:int}")]
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

        [HttpPatch("{id:int}")]
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

        [HttpDelete("{id:int}")]
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