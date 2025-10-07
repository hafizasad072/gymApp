using GYM.BO.Enums;
using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.SubscriptionService
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWorkService _uow;
        
        public SubscriptionService(IUnitOfWorkService uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Subscription>> GetAll()
        {
            return await _uow.SubscriptionRepository.GetAll();
        }

        public async Task<Subscription> Get(Guid id)
        {
            return await _uow.SubscriptionRepository.GetAsync(x => x.SubscriptionId == id);
        }

        public async Task<Guid> Create(Subscription model)
        {
            var plan = await _uow.MembershipPlanRepository.GetAsync(x => x.PlanId == model.PlanId);
            if (plan == null)
                throw new Exception("Invalid Membership Plan");

            model.SubscriptionId = Guid.NewGuid();
            model.StartDate = DateTime.Now;
            model.EndDate = model.StartDate.AddDays(plan.DurationDays ?? 0);
            model.StatusId = (int)SubscriptionStatuses.Active;

            await _uow.SubscriptionRepository.InsertAsync(model);
            _uow.Commit();

            // Auto-create invoice
            var invoice = new Invoice
            {
                SubscriptionId = model.SubscriptionId,
                MemberId = model.MemberId,
                GymId = plan.GymId,
                Amount = plan.Price,
                IssuedAt = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(3),
                StatusId = (int)InvoiceStatuses.Issued,
                Currency = "PKR"
            };
            await _uow.InvoiceRepository.InsertAsync(invoice);
            _uow.Commit();
            return model.SubscriptionId;
        }

        public async Task<bool> Update(Subscription model)
        {
            var entity = await _uow.SubscriptionRepository.GetAsync(x => x.SubscriptionId == model.SubscriptionId, null, false);
            if (entity == null) return false;

            entity.StatusId = model.StatusId;
            entity.EndDate = model.EndDate ?? entity.EndDate;

            _uow.Commit();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.SubscriptionRepository.GetAsync(x => x.SubscriptionId == id);
            if (entity == null) return false;

            _uow.SubscriptionRepository.Delete(entity);
            _uow.Commit();
            return true;
        }

        public async Task<IEnumerable<Subscription>> GetByMember(Guid memberId)
        {
            return await _uow.SubscriptionRepository.GetAllAsync(x => x.MemberId == memberId);
        }

        public async Task<IEnumerable<Subscription>> GetByGym(Guid gymId)
        {
            return await _uow.SubscriptionRepository.GetAllAsync(x => x.Plan.GymId == gymId);
        }

        public async Task<IEnumerable<Subscription>> GetActiveByGym(Guid gymId)
        {
            return await _uow.SubscriptionRepository.GetAllAsync(
                x => x.Plan.GymId == gymId && x.StatusId == 1 && x.EndDate > DateTime.Now);
        }

        public async Task<IEnumerable<Subscription>> GetExpired()
        {
            return await _uow.SubscriptionRepository.GetAllAsync(
                x => x.EndDate < DateTime.Now && x.StatusId == 1);
        }

        public async Task<bool> Cancel(Guid id)
        {
            var entity = await _uow.SubscriptionRepository.GetAsync(x => x.SubscriptionId == id, null, false);
            if (entity == null) return false;

            entity.StatusId = (int)SubscriptionStatuses.Cancelled;
            entity.EndDate = DateTime.Now;
            _uow.Commit();
            return true;
        }

        public async Task<bool> Renew(Guid id)
        {
            var entity = await _uow.SubscriptionRepository.GetAsync(x => x.SubscriptionId == id, null, false);
            if (entity == null) return false;

            var plan = await _uow.MembershipPlanRepository.GetAsync(x => x.PlanId == entity.PlanId);
            if (plan == null) return false;

            entity.StartDate = DateTime.Now;
            entity.EndDate = entity.StartDate.AddDays(plan.DurationDays ?? 0);
            entity.StatusId = (int)SubscriptionStatuses.Active;
            _uow.Commit();

            // Create a new invoice for renewal
            var invoice = new Invoice
            {
                SubscriptionId = entity.SubscriptionId,
                MemberId = entity.MemberId,
                GymId = plan.GymId,
                Amount = plan.Price,
                IssuedAt = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(3),
                StatusId = (int)InvoiceStatuses.Issued,
                Currency = "PKR"
            };
            await _uow.InvoiceRepository.InsertAsync(invoice);
            _uow.Commit();

            return true;
        }
    }
}
