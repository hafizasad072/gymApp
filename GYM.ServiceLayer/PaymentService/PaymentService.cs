using GYM.BO.Enums;
using GYM.EF.Models;
using GYM.ServiceLayer.InvoiceService;
using GYM.ServiceLayer.UnitOfWork;

namespace GYM.ServiceLayer.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWorkService _uow;
        private readonly IInvoiceService _invoiceService;

        public PaymentService(IUnitOfWorkService uow, IInvoiceService invoiceService)
        {
            _uow = uow;
            _invoiceService = invoiceService;
        }

        public async Task<IEnumerable<Payment>> GetAll() => await _uow.PaymentRepository.GetAll();

        public async Task<Payment> Get(Guid id) => await _uow.PaymentRepository.GetAsync(x => x.PaymentId == id);

        public async Task<Guid> Create(Payment model)
        {
            var invoce = await _invoiceService.Get(model.InvoiceId.Value);

            model.PaymentId = Guid.NewGuid();
            model.PaidAt = DateTime.Now;
            model.GymId = invoce.GymId;
            model.MemberId = invoce.MemberId;


            // Record payment
            await _uow.PaymentRepository.InsertAsync(model);
            _uow.Commit();

            // Mark invoice as paid
            await _invoiceService.MarkPaid(model.InvoiceId.Value);

            // Reactivate subscription if applicable
            var invoice = await _uow.InvoiceRepository.GetAsync(x => x.InvoiceId == model.InvoiceId);
            if (invoice != null)
            {
                var subscription = await _uow.SubscriptionRepository.GetAsync(x => x.SubscriptionId == invoice.SubscriptionId);
                if (subscription != null && subscription.StatusId != (int)SubscriptionStatuses.Active)
                {
                    subscription.StatusId = (int)SubscriptionStatuses.Active;
                    _uow.Commit();
                }
            }

            return model.PaymentId;
        }

        public async Task<IEnumerable<Payment>> GetByInvoice(Guid invoiceId)
            => await _uow.PaymentRepository.GetAllAsync(x => x.InvoiceId == invoiceId);

        public async Task<IEnumerable<Payment>> GetByGym(Guid gymId)
            => await _uow.PaymentRepository.GetAllAsync(x => x.Invoice.GymId == gymId);
    }

}
