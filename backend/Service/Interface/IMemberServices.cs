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
        Task<Member> GetMemberById(int? memberId);
        Task<List<Member>> GetAllMember();
        Task AddMember(Member member);
        Task DeleteMember(int? id);
    }
}
