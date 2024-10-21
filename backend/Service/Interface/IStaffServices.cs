using Repository.DTOs.Staff;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IStaffServices
    {
        Task<List<Staff>> GetAllStaff();
        Task<Staff> GetStaffById(int? id);
        Task<string> AddStaff(StaffDtos staffDtos);
        Task<string> UpdateStaff(int? id, StaffDtos staffDtos);
        Task DeleteStaffById(int? id);
    }
}
