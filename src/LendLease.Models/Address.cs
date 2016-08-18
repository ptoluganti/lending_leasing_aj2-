using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LendLease.Models
{
    public class Address
    {
        public Address()
        {
            Payments = new HashSet<Payment>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}