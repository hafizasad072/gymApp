using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.DiscussionService
{
    public class DiscussionService : IDiscussionService
    {
        private readonly IUnitOfWorkService _uow;

        public DiscussionService(IUnitOfWorkService uow)
        {
            _uow = uow;
        }

        // ------------------- Discussions -------------------

        public async Task<IEnumerable<Discussion>> GetAll()
            => await _uow.DiscussionRepository.GetAll();

        public async Task<Discussion> Get(Guid id)
            => await _uow.DiscussionRepository.GetAsync(x => x.DiscussionId == id);

        public async Task<Guid> Create(Discussion model)
        {
            model.DiscussionId = Guid.NewGuid();
            model.CreatedAt = DateTime.Now;

            await _uow.DiscussionRepository.InsertAsync(model);
            _uow.Commit();
            return model.DiscussionId;
        }

        public async Task<bool> Update(Discussion model)
        {
            var entity = await _uow.DiscussionRepository.GetAsync(x => x.DiscussionId == model.DiscussionId, null, false);
            if (entity == null) return false;

            entity.Title = model.Title;
            entity.Body = model.Body;
            entity.IsFranchiseWide = model.IsFranchiseWide;
            _uow.Commit();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.DiscussionRepository.GetAsync(x => x.DiscussionId == id);
            if (entity == null) return false;

            _uow.DiscussionRepository.Delete(entity);
            _uow.Commit();
            return true;
        }

        // ------------------- Filters -------------------

        public async Task<IEnumerable<Discussion>> GetByGym(Guid gymId)
            => await _uow.DiscussionRepository.GetAllAsync(x => x.GymId == gymId);

        public async Task<IEnumerable<Discussion>> GetByUser(string userId)
            => await _uow.DiscussionRepository.GetAllAsync(x => x.CreatedByUserId == userId);

        public async Task<IEnumerable<Discussion>> GetActive(Guid gymId)
            => await _uow.DiscussionRepository.GetAllAsync(x => x.GymId == gymId);

        // ------------------- Messages -------------------

        public async Task<IEnumerable<DiscussionMessage>> GetMessages(Guid discussionId)
            => await _uow.DiscussionMessageRepository.GetAllAsync(x => x.DiscussionId == discussionId);

        public async Task<Guid> AddMessage(DiscussionMessage model)
        {
            model.MessageId = Guid.NewGuid();
            model.CreatedAt = DateTime.Now;

            await _uow.DiscussionMessageRepository.InsertAsync(model);
            _uow.Commit();

            return model.MessageId;
        }
    }
}
