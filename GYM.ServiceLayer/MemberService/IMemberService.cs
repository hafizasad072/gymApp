using GYM.EF.Models;

namespace GYM.ServiceLayer.MemberService
{
    public interface IMemberService
    {
        Task<(Guid userId, Guid memberId)> QuickRegisterAsync(Guid gymId, string email, string phone, string displayName, Guid? invitedBy);
        Task<Members> GetMember(Guid memberId);
        Task<IEnumerable<Members>> GetAllMembers();
        Task<bool> DeleteMember(Guid memberId);
    }
}
