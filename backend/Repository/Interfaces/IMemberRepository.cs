using Repository.DTOs.Member;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member> GetMemberById(int? memberId);
        Task<Member> GetMemberByUserId(int? memberId);
        Task<List<Member>> GetAllMember();
        Task AddMember(Member member);
        Task DeleteMember(int? id);

    }
}
