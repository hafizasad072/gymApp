using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;

namespace GYM.ServiceLayer.BodyMetricService
{
    public class BodyMetricService : IBodyMetricService
    {
        private readonly IUnitOfWorkService _uow;

        public BodyMetricService(IUnitOfWorkService uow)
        {
            _uow = uow;
        }

        // ------------------- CRUD -------------------

        public async Task<IEnumerable<BodyMetric>> GetAll()
            => await _uow.BodyMetricRepository.GetAll();

        public async Task<BodyMetric> Get(Guid id)
            => await _uow.BodyMetricRepository.GetAsync(x => x.BodyMetricId == id);

        public async Task<Guid> Create(BodyMetric model)
        {
            model.MeasuredAt = model.MeasuredAt == default ? DateTime.UtcNow : model.MeasuredAt;
            await _uow.BodyMetricRepository.InsertAsync(model);
            _uow.Commit();
            return model.BodyMetricId;
        }

        public async Task<bool> Update(BodyMetric model)
        {
            var entity = await _uow.BodyMetricRepository.GetAsync(x => x.BodyMetricId == model.BodyMetricId, null, false);
            if (entity == null) return false;

            entity.Value = model.Value;
            entity.Unit = model.Unit;
            entity.MeasuredAt = model.MeasuredAt;
            entity.SourceId = model.SourceId;
            _uow.Commit();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.BodyMetricRepository.GetAsync(x => x.BodyMetricId == id);
            if (entity == null) return false;

            _uow.BodyMetricRepository.Delete(entity);
            _uow.Commit();
            return true;
        }

        // ------------------- Filters -------------------

        public async Task<IEnumerable<BodyMetric>> GetByMember(Guid memberId)
            => await _uow.BodyMetricRepository.GetAllAsync(
                x => x.MemberId == memberId);

        public async Task<IEnumerable<BodyMetric>> GetByType(Guid memberId, int metricTypeId)
            => await _uow.BodyMetricRepository.GetAllAsync(
                x => x.MemberId == memberId && x.MetricTypeId == metricTypeId);

        public async Task<IEnumerable<BodyMetric>> GetByDateRange(Guid memberId, DateTime start, DateTime end)
            => await _uow.BodyMetricRepository.GetAllAsync(
                x => x.MemberId == memberId && x.MeasuredAt >= start && x.MeasuredAt <= end);
    }

}
