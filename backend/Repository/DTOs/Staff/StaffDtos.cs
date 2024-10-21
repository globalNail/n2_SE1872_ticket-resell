using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.Staff
{
    public class StaffDtos
    {       
        public int? UserId { get; set; }
        public string Role { get; set; } = null!;     
         
    }
}
