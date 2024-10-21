using Repository.Base;
using Repository.Models;

namespace Repository.Interfaces;

public interface IUserRoleRepository : IGenericRepository<UserRole>
{
    Task<UserRole> GetByNameAsync(string roleName);

}
