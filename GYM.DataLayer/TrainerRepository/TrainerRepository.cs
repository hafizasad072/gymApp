using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;

namespace GYM.DataLayer.TrainerRepository
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(GymDbContext context) : base(context)
        {
        }
    }
}
