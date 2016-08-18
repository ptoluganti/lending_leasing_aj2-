using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LendLease.Models
{
    public class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public ICollection<Address> Addresses { get; set; }
    }
}