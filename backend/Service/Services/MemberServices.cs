using Repository.Interfaces;
using Repository.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MemberServices: IMemberServices
    {
        private readonly IMemberRepository _memberRepository;

        public MemberServices(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<bool> AddMember(Member member)
        {
           return await _memberRepository.AddMember(member) ;
        }

        public async Task DeleteMember(int id)
        {
             await _memberRepository.DeleteMember(id) ;
        }

        public async Task<List<Member>> GetAllMember()
        {
           return await _memberRepository.GetAllMember() ;
        }

        public async Task<Member> GetMember(int id)
        {
           return await _memberRepository.GetMember(id);
        }
    }
}
