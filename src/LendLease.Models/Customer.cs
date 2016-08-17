using System;

namespace LendLease.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }


        //public ICollection<Address> Addresses { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? PaymentInfoId { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
    }

    public class PaymentInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal ScheduledAmount { get; set; }

        public decimal RecievedAmount { get; set; }

        public DateTime ScheduledDate { get; set; }

        public DateTime? RecievedDate { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}