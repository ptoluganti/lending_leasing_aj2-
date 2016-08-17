using System.Collections.Generic;
using System.Linq;
using LendLease.Interfaces;
using LendLease.Models;

namespace LendLease.Data
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Payment item)
        {
            _context.Payments.Add(item);
            _context.SaveChanges();
        }
    
        public IEnumerable<Payment> GetAll(int id)
        {
            return _context.Payments.Where(c => c.AddressId == id);
        }

        public Payment Find(int cid, int id)
        {
            var item = _context.Payments.FirstOrDefault(c => c.AddressId == cid && c.Id == id);
            return item;
        }

        public Payment Find(int id)
        {
            var item = _context.Payments.FirstOrDefault(c => c.Id == id);
            return item;
        }

        public Payment Remove(int id)
        {
            var item = _context.Payments.FirstOrDefault(c => c.Id == id);
            _context.Payments.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public void Update(Payment item)
        {
            var payment = _context.Payments.FirstOrDefault(c => c.Id == item.Id);
            payment.Name = item.Name;
            _context.SaveChanges();
        }
    }
}