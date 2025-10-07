using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.InvoiceService
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWorkService _uow;

        public InvoiceService(IUnitOfWorkService uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Invoice>> GetAll() => await _uow.InvoiceRepository.GetAll();

        public async Task<Invoice> Get(Guid id) =>
            await _uow.InvoiceRepository.GetAsync(x => x.InvoiceId == id);

        public async Task<Guid> Create(Invoice model)
        {
            model.InvoiceId = Guid.NewGuid();
            model.IssuedAt = DateTime.UtcNow;
            model.StatusId = 1; // Pending

            await _uow.InvoiceRepository.InsertAsync(model);
            _uow.Commit();

            return model.InvoiceId;
        }

        public async Task<bool> UpdateStatus(Guid invoiceId, int statusId)
        {
            var entity = await _uow.InvoiceRepository.GetAsync(x => x.InvoiceId == invoiceId, null, false);
            if (entity == null) return false;

            entity.StatusId = statusId;
            _uow.Commit();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.InvoiceRepository.GetAsync(x => x.InvoiceId == id);
            if (entity == null) return false;

            _uow.InvoiceRepository.Delete(entity);
            _uow.Commit();
            return true;
        }

        public async Task<IEnumerable<Invoice>> GetByMember(Guid memberId) =>
            await _uow.InvoiceRepository.GetAllAsync(x => x.MemberId == memberId);

        public async Task<IEnumerable<Invoice>> GetByGym(Guid gymId) =>
            await _uow.InvoiceRepository.GetAllAsync(x => x.GymId == gymId);

        public async Task<IEnumerable<Invoice>> GetByStatus(int statusId) =>
            await _uow.InvoiceRepository.GetAllAsync(x => x.StatusId == statusId);

        public async Task<IEnumerable<Invoice>> GetOverdue() =>
            await _uow.InvoiceRepository.GetAllAsync(x => x.StatusId == 1 && x.DueDate < DateTime.UtcNow);

        public async Task<bool> MarkPaid(Guid invoiceId)
        {
            var entity = await _uow.InvoiceRepository.GetAsync(x => x.InvoiceId == invoiceId, null, false);
            if (entity == null) return false;

            entity.StatusId = 2; // Paid
            _uow.Commit();
            return true;
        }
    }
}
