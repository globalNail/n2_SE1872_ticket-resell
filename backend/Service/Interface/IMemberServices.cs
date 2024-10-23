using Repository.DTOs.Member;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IMemberServices
    {
        Task<List<Member>> GetAllMember();
        Task<Member> GetMember(int id);
        Task DeleteMember(int id);
        Task<string> AddMember(int userId);
        Task<string> UpdateMember(int id, MemberRequest memberRequest);
    }
}
