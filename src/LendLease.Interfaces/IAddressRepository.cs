using System.Collections.Generic;
using LendLease.Models;

namespace LendLease.Interfaces
{
    public interface IAddressRepository
    {
        void Add(Address item);
        IEnumerable<Address> GetAll(int id);
        Address Find(int cid, int id);
        Address Find(int id);

        Address Remove(int id);
        void Update(Address item);
    }
}