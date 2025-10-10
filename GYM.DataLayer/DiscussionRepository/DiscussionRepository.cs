using GYM.DataLayer.GymRepository;
using GYM.DataLayer.Repository;
using GYM.EF;
using GYM.EF.Models;

namespace GYM.DataLayer.DiscussionRepository
{
    public class DiscussionRepository : GenericRepository<Discussion>, IDiscussionRepository
    {
        public DiscussionRepository(GymDbContext context) : base(context)
        {
        }
    }
}
