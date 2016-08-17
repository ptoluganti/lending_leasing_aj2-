using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LendLease.Models;

namespace LendLease.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer item);
        IEnumerable<Customer> GetAll();
        Customer Find(int key);
        Customer Remove(int key);
        void Update(Customer item);
        Task<List<Customer>> ListAsync();
    }
}
