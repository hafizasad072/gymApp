using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.MembershipPlanService
{
    public class MembershipPlanService : IMembershipPlanService
    {
        private readonly IUnitOfWorkService _uow;

        public MembershipPlanService(IUnitOfWorkService uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<MembershipPlan>> GetAll()
        {
            return await _uow.MembershipPlanRepository.GetAll();
        }

        public async Task<MembershipPlan> Get(Guid id)
        {
            return await _uow.MembershipPlanRepository.GetAsync(x => x.PlanId == id);
        }

        public async Task<Guid> Create(MembershipPlan model)
        {
            model.PlanId = Guid.NewGuid();
            model.CreatedAt = DateTime.UtcNow;
            model.IsActive = true;

            await _uow.MembershipPlanRepository.InsertAsync(model);
            _uow.Commit();

            return model.PlanId;
        }

        public async Task<bool> Update(MembershipPlan model)
        {
            var entity = await _uow.MembershipPlanRepository.GetAsync(x => x.PlanId == model.PlanId, null, false);
            if (entity == null) return false;

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.IsActive = model.IsActive;
            entity.DurationDays = model.DurationDays;

            _uow.Commit();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.MembershipPlanRepository.GetAsync(x => x.PlanId == id);
            if (entity == null) return false;

            _uow.MembershipPlanRepository.Delete(entity);
            _uow.Commit();
            return true;
        }

        public async Task<IEnumerable<MembershipPlan>> GetByGym(Guid gymId)
        {
            return await _uow.MembershipPlanRepository.GetAllAsync(x => x.GymId == gymId);
        }

        public async Task<IEnumerable<MembershipPlan>> GetActivePlans(Guid gymId)
        {
            return await _uow.MembershipPlanRepository.GetAllAsync(x => x.GymId == gymId && x.IsActive);
        }

        public async Task<IEnumerable<MembershipPlan>> GetByDurationRange(int minDays, int maxDays)
        {
            return await _uow.MembershipPlanRepository.GetAllAsync(x => x.DurationDays >= minDays && x.DurationDays <= maxDays);
        }
    }
}
