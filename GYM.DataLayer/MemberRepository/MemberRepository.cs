using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM.DataLayer.Repository;
using GYM.EF.Models;

namespace GYM.DataLayer.MemberRepository
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(GYMContext context) : base(context)
        {
        }
    }
}
