using Repository.Interfaces;
using Repository.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MemberServices: IMemberServices
    {
        private readonly IMemberRepository _memberRepository;

        public MemberServices(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task AddMember(Member member)
        {
            await _memberRepository.AddMember(member);
        }

        public async Task DeleteMember(int? id)
        {
           await _memberRepository.DeleteMember(id);
        }

        public async Task<List<Member>> GetAllMember()
        {
            return await _memberRepository.GetAllMember();
        }

        public async Task<Member> GetMemberById(int? memberId)
        {
            return await _memberRepository.GetMemberById(memberId);
        }
    }
}
