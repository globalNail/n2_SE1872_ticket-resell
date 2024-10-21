using Repository.DTOs.Staff;
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
    public class StaffServices : IStaffServices
    {
        private readonly IStaffRepository _repository;

        public StaffServices(IStaffRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> AddStaff(StaffDtos staffDtos)
        {
            if (staffDtos == null)
            {
                return "Data is null here";
            }
            
            var staff = new Staff()
            {
                UserId = staffDtos.UserId,
                Role = staffDtos.Role,
                ModifiedDate = DateTime.Now,
            };
            var result = await _repository.AddStaff(staff);
            return result ? "Add Successful" : "Add Failed";
        }

        public async Task DeleteStaffById(int? id)
        {
            await _repository.DeleteStaffById(id);
        }

        public async Task<List<Staff>> GetAllStaff()
        {
            return await _repository.GetAllStaff();
        }

        public async Task<Staff> GetStaffById(int? id)
        {
            return await _repository.GetStaffById(id);
        }

        public async Task<string> UpdateStaff(int? id, StaffDtos staffDtos)
        {
            var existingStaff = await GetStaffById(id); ;
            if (existingStaff == null)
            {
                return "Staff not found";
            }
            existingStaff.UserId = staffDtos?.UserId;
            existingStaff.Role = staffDtos?.Role;
            existingStaff.ModifiedDate = DateTime.Now;

            var result = await _repository.UpdateStaff(existingStaff);
            return result ? "Update Successful" : "Update Failed";
        }
    }
}
