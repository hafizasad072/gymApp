using GYM.DataLayer.Repository;
using GYM.EF;
using GYM.EF.Models;

namespace GYM.DataLayer.UserRepository
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(GymDbContext context) : base(context)
        {
        }
    }
}
