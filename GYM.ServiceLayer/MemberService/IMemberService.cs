using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.MemberService
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> Get(Guid id);
        Task<Guid> Create(Member model);
        Task<bool> Update(Member model);
        Task<bool> Delete(Guid id);

        Task<IEnumerable<Member>> GetByGym(Guid gymId);
        Task<IEnumerable<Member>> GetByLeague(int leagueId);

    }
}
