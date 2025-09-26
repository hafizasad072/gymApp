using GYM.DataLayer.Repository;
using GYM.EF.Models;

namespace GYM.DataLayer.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(GYMContext context) : base(context)
        {
        }
    }
}
