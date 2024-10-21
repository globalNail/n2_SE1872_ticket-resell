using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStaffRepository
    {
        Task<List<Staff>> GetAllStaff();
        Task<Staff> GetStaffById(int? id);
        Task<bool> AddStaff(Staff staff);
        Task<bool> UpdateStaff(Staff staff);
        Task DeleteStaffById(int? id);
    }
}
