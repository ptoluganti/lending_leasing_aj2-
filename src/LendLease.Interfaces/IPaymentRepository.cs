using System.Collections.Generic;
using LendLease.Models;

namespace LendLease.Interfaces
{
    public interface IPaymentRepository
    {
        void Add(Payment item);
        IEnumerable<Payment> GetAll(int id);
        Payment Find(int cid, int id);
        Payment Find(int id);

        Payment Remove(int id);
        void Update(Payment item);
    }
}