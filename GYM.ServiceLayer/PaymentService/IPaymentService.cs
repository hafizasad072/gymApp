using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.PaymentService
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAll();
        Task<Payment> Get(Guid id);
        Task<Guid> Create(Payment model);
        Task<IEnumerable<Payment>> GetByInvoice(Guid invoiceId);
        Task<IEnumerable<Payment>> GetByGym(Guid gymId);
    }

}
