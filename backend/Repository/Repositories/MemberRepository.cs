using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class MemberRepository: IMemberRepository
    {
        private readonly Swp391ticketResellPlatformContext _context;

        public MemberRepository(Swp391ticketResellPlatformContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMember(Member member)
        {
            _context.Members.Add(member);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteMember(int id)
        {
            var member = await GetMember(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Member>> GetAllMember()
        {
           return await _context.Members.ToListAsync();
        }

        public async Task<Member> GetMember(int? id)
        {
            return await _context.Members.Include(m => m.User).FirstOrDefaultAsync(sc => sc.MemberId.Equals(id));
        }
    }
}
