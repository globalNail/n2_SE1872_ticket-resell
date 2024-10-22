using Repository.Models;

namespace Repository.Interfaces
{
    public interface IUserRepository: IGenericRepository<User>
    {
        Task<User> GetUserById(int id);
        Task<User> GetByUsernameOrEmailAsync(string usernameOrEmail);
    }
}
