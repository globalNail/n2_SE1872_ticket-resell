using Microsoft.EntityFrameworkCore;
using Repository.DTOs.Member;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly Swp391ticketResellPlatformContext _context;

        public MemberRepository(Swp391ticketResellPlatformContext context)
        {
            _context = context;
        }

        public async Task<Member> GetMemberById(int? memberId)
        {
            return await _context.Members.FirstOrDefaultAsync(sc => sc.MemberId.Equals(memberId));
        }

        public async Task<Member> GetMemberByUserId(int? memberId)
        {
            return await _context.Members.Include(m => m.User).FirstOrDefaultAsync(m => m.MemberId == memberId); 
           
        }
        public async Task<List<Member>> GetAllMember()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task AddMember(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMember(int? id)
        {
            var member = await GetMemberById(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }
    }
}
