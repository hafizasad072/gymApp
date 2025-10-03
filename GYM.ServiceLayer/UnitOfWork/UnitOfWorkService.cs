using GYM.DataLayer.UserRepository;
using GYM.EF;

namespace GYM.ServiceLayer.UnitOfWork
{
    public class UnitOfWorkService(GymDbContext context) : IUnitOfWorkService
    {

        private IUserRepository _userRepository;

        public IUserRepository UserRepository => _userRepository == null ? new UserRepository(context) : _userRepository;
        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
