using GYM.DataLayer.GymRepository;
using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.DataLayer.ClassRepository
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        public ClassRepository(GymDbContext context) : base(context)
        {
        }
    }
}
