using GYM.DataLayer.UserRepository;

namespace GYM.ServiceLayer.UnitOfWork
{
    public interface IUnitOfWorkService
    {
        IUserRepository UserRepository
        {
            get;
        }

        int Commit();
    }
}
