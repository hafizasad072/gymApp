using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace GYM.ServiceLayer.MemberService
{

    public class MemberService : IMemberService
    {
        private readonly ILogger<MemberService> _logger;
        private IUnitOfWorkService _uow;
        public MemberService(ILogger<MemberService> logger, IUnitOfWorkService uow) { _logger = logger; _uow = uow; }

        public async Task<(Guid userId, Guid memberId)> QuickRegisterAsync(Guid gymId, string email, string phone, string displayName, Guid? invitedBy)
        {
            // minimal validation
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email is required", nameof(email));

            try
            {
                var user = new Users { UserId = Guid.NewGuid(), Email = email, DisplayName = displayName, IsActive = true };
                await _uow.UserRepository.InsertAsync(user);
                _uow.Commit();
                var member = new Members { MemberId = Guid.NewGuid(), UserId = user.UserId, GymId = gymId };
                await _uow.MemberRepository.InsertAsync(member);

                _uow.Commit();
                _logger.LogInformation("Quick registered member {MemberId} (user {UserId}) at gym {GymId}", member.MemberId, user.UserId, gymId);
                return (user.UserId, member.MemberId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Members> GetMember(Guid memberId)
        {
            return await _uow.MemberRepository.GetByIdAsync(memberId);
        }

        public async Task<IEnumerable<Members>> GetAllMembers()
        {
            return await _uow.MemberRepository.GetAllAsync(a => true);
        }

        public async Task<bool> DeleteMember(Guid memberId)
        {
            var member = await _uow.MemberRepository.GetByIdAsync(memberId);
            if (member == null)
                return false;

            _uow.MemberRepository.Delete(member);
            _uow.Commit();

            return true;
        }
    }
}
