using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.Member
{
    public class MemberRequest
    {
        public decimal? AverageRating { get; set; }

        public int? RatingCount { get; set; }

    }
}
