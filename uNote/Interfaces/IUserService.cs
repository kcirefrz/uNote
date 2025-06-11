using uNote.Models;

namespace uNote.Interfaces;

public interface IUserService
{
    Task Initialize();
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int id); 
    Task<int> SaveUserAsync(User item); 
    Task<int> UpdateUserAsync(User item); 
    Task<int> DeleteUserAsync(User item); 
}