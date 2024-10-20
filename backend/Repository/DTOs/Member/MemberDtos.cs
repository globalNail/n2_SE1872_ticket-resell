using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.Member
{
    public class MemberDtos
    {
        public int? UserId { get; set; }
        public decimal? AverageRating { get; set; }

        public int? RatingCount { get; set; }

        public string? MembershipStatus { get; set; }

    }
}
