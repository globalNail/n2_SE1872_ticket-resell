using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.Member
{
    public class MemberWithUsernameDto
    {
        public int MemberID { get; set; }
        public int? UserID { get; set; }
        public decimal? AverageRating { get; set; }
        public int? RatingCount { get; set; }
        public DateTime? MembershipDate { get; set; }
        public string? MembershipStatus { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Username { get; set; } // Username from the User table

    }
}
