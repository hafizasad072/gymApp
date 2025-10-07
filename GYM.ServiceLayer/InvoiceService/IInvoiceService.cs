using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.InvoiceService
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetAll();
        Task<Invoice> Get(Guid id);
        Task<Guid> Create(Invoice model);
        Task<bool> UpdateStatus(Guid invoiceId, int statusId);
        Task<bool> Delete(Guid id);

        // Filters
        Task<IEnumerable<Invoice>> GetByMember(Guid memberId);
        Task<IEnumerable<Invoice>> GetByGym(Guid gymId);
        Task<IEnumerable<Invoice>> GetByStatus(int statusId);
        Task<IEnumerable<Invoice>> GetOverdue();

        // Payment link
        Task<bool> MarkPaid(Guid invoiceId);
    }
}
