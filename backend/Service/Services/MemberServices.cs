using Repository.DTOs.Member;
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
        private readonly IUserRepository _userRepository;

        public MemberServices(IMemberRepository memberRepository, IUserRepository userRepository)
        {
            _memberRepository = memberRepository;
            _userRepository = userRepository;
        }

        public async Task<string> AddMember(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return "User Not found";
            }
            Member member = new Member()
            {
                UserId = userId,
                AverageRating = null,
                RatingCount = null,
                MembershipDate = null,
                MembershipStatus = "Active",
                ModifiedDate = DateTime.Now,
            };
            var result = await _memberRepository.AddMember(member);
            return result ? "Add Success" : "Add Failed";
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

        public async Task<string> UpdateMember(int id, MemberRequest memberRequest)
        {
            var existingMember = await _memberRepository.GetMember(id);
            if (existingMember == null)
            {
                return "Member not found";
            }
            if (existingMember.RatingCount > 0 && memberRequest.AverageRating > 0)
            {
                // Tính lại giá trị trung bình dựa trên giá trị đánh giá mới được cung cấp từ memberRequest
                existingMember.AverageRating = (existingMember.AverageRating * existingMember.RatingCount + memberRequest.AverageRating) / (existingMember.RatingCount + 1);
            }
            existingMember.AverageRating = memberRequest.AverageRating;
            existingMember.RatingCount = memberRequest.RatingCount + 1;
            existingMember.MembershipDate = DateTime.Now;         
            existingMember.ModifiedDate = DateTime.Now;
            var result = await _memberRepository.UpdateMember(existingMember);

            return result ? "Update Success " : "Update Failed";

        }

    }
}
