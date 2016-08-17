using System;

namespace LendLease.Models
{
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