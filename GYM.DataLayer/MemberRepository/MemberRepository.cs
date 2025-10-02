using GYM.DataLayer.Repository;
using GYM.EF.Models;

namespace GYM.DataLayer.MemberRepository
{
    public class MemberRepository : GenericRepository<Members>, IMemberRepository
    {
        public MemberRepository(GYMContext context) : base(context)
        {
        }
    }
}
