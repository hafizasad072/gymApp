using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.DiscussionService
{
    public interface IDiscussionService
    {
        Task<IEnumerable<Discussion>> GetAll();
        Task<Discussion> Get(Guid id);
        Task<Guid> Create(Discussion model);
        Task<bool> Update(Discussion model);
        Task<bool> Delete(Guid id);

        // Filters
        Task<IEnumerable<Discussion>> GetByGym(Guid gymId);
        Task<IEnumerable<Discussion>> GetByUser(string userId);
        Task<IEnumerable<Discussion>> GetActive(Guid gymId);

        // Messages
        Task<IEnumerable<DiscussionMessage>> GetMessages(Guid discussionId);
        Task<Guid> AddMessage(DiscussionMessage model);
    }
}
