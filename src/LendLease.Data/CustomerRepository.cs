using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LendLease.Interfaces;
using LendLease.Models;
using Microsoft.EntityFrameworkCore;

namespace LendLease.Data
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers;
        }

        public void Add(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
        }

        public Customer Find(int id)
        {
            var item = _context.Customers.FirstOrDefault(c => c.Id == id);
            return item;
        }

        public Customer Remove(int id)
        {
            var item = _context.Customers.FirstOrDefault(c => c.Id == id);
            _context.Customers.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public void Update(Customer item)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == item.Id);
            customer.Name = item.Name;
            _context.SaveChanges();
        }

        public Task<List<Customer>> ListAsync()
        {
            return _context.Customers.ToListAsync();
        }
    }
}