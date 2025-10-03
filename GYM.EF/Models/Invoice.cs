using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class InvoiceStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }
    }

    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public Guid SubscriptionId { get; set; }
        public Guid MemberId { get; set; }
        public Guid GymId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public int StatusId { get; set; }
    }
}
