using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid MemberId { get; set; }
        public Guid GymId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
        public string ProviderTransactionId { get; set; }
        public DateTime PaidAt { get; set; }

        public Member Member { get; set; }
        public Gym Gym { get; set; }
    }
}
