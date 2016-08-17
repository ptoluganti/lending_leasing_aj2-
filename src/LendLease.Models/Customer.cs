using System.Collections.Generic;

namespace LendLease.Models
{
    public class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
        }
        public int Id { get; set; }

        public string Name { get; set; }


        public ICollection<Address> Addresses { get; set; }
    }
}