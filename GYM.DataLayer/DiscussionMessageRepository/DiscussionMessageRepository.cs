using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;

namespace GYM.DataLayer.DiscussionMessageRepository
{
    public class DiscussionMessageRepository : GenericRepository<DiscussionMessage>, IDiscussionMessageRepository
    {
        public DiscussionMessageRepository(GymDbContext context) : base(context)
        {
        }
    }
}


