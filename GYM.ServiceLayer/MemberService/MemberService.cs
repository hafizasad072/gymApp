using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.MemberService
{
    public class MemberService(IUnitOfWorkService _uow) : IMemberService
    {
        public async Task<IEnumerable<Member>> GetAll() => await _uow.MemberRepository.GetAll();

        public async Task<Member> Get(Guid id) => await _uow.MemberRepository.GetAsync(x => x.MemberId == id);

        public async Task<Guid> Create(Member model)
        {
            model.MemberId = Guid.NewGuid();
            await _uow.MemberRepository.InsertAsync(model);
            _uow.Commit();
            return model.MemberId;
        }

        public async Task<bool> Update(Member model)
        {
            var entity = await _uow.MemberRepository.GetAsync(x => x.MemberId == model.MemberId, null, false);
            if (entity == null) return false;

            entity.LeagueId = model.LeagueId;
            entity.DateOfBirth = model.DateOfBirth;
            entity.Gender = model.Gender;

            _uow.Commit();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.MemberRepository.GetAsync(x => x.MemberId == id);
            if (entity == null) return false;

            _uow.MemberRepository.Delete(entity);
            _uow.Commit();
            return true;
        }

        public async Task<IEnumerable<Member>> GetByGym(Guid gymId)
        {
            return await _uow.MemberRepository.GetAllAsync(x => x.GymId == gymId);
        }

        public async Task<IEnumerable<Member>> GetByLeague(int leagueId)
        {
            return await _uow.MemberRepository.GetAllAsync(x => x.LeagueId == leagueId);
        }
    }
}
