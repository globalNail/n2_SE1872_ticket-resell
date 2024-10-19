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
        Task<List<Member>> GetAllMember();
        Task<Member> GetMember(int? id);
        Task DeleteMember(int id);
        Task<bool> AddMember(Member member);
    }
}
