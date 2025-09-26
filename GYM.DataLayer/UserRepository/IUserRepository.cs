using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM.DataLayer.Repository;
using GYM.EF.Models;

namespace GYM.DataLayer.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
