using System.Collections.Generic;
using System.Linq;
using LendLease.Interfaces;
using LendLease.Models;

namespace LendLease.Data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Address item)
        {
            _context.Addresses.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<Address> GetAll(int id)
        {
            return _context.Addresses.Where(c => c.CustomerId == id);
        }

        public Address Find(int cid, int id)
        {
            var item = _context.Addresses.FirstOrDefault(c => c.CustomerId == cid && c.Id == id);
            return item;
        }

        public Address Find(int id)
        {
            var item = _context.Addresses.FirstOrDefault(c => c.Id == id);
            return item;
        }

        public Address Remove(int id)
        {
            var item = _context.Addresses.FirstOrDefault(c => c.Id == id);
            _context.Addresses.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public void Update(Address item)
        {
            var address = _context.Addresses.FirstOrDefault(c => c.Id == item.Id);
            address.Name = item.Name;
            _context.SaveChanges();
        }
    }
}