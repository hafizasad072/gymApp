using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM.EF.Models;

namespace GYM.ServiceLayer.MemberService
{
    public interface IMemberService
    {
        Task<(Guid userId, Guid memberId)> QuickRegisterAsync(Guid gymId, string email, string phone, string displayName, Guid? invitedBy);
        Task<Member> GetMember(Guid memberId);
        Task<IEnumerable<Member>> GetAllMembers();
        Task<bool> DeleteMember(Guid memberId);
    }
}
