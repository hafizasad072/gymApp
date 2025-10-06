using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;

namespace GYM.DataLayer.GymRepository
{
    public class GymRepository : GenericRepository<Gym>, IGymRepository
    {
        public GymRepository(GymDbContext context) : base(context)
        {
        }
    }
}
