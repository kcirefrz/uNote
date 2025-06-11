using SQLite;
using uNote.Interfaces;
using uNote.Models;

namespace uNote.Services;

public class UserService : IUserService
{
    private SQLiteAsyncConnection dbConnection;

    public async Task Initialize()
    {
        await SetUpDb();
    }

    public async Task SetUpDb()
    {
        if (dbConnection == null)
        {
            string dbPath = Path.Combine(Environment.
            GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "user.db3");

            dbConnection = new SQLiteAsyncConnection(dbPath);
            await dbConnection.CreateTableAsync<User>();
        }
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var users = await dbConnection.Table<User>().ToListAsync();
        return users;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await dbConnection.Table<User>().FirstOrDefaultAsync(x => x.UserId == id);
        return user;
    }

    public async Task<int> SaveUserAsync(User item)
    {
        return await dbConnection.InsertAsync(item);
    }

    public async Task<int> UpdateUserAsync(User item)
    {
        return await dbConnection.UpdateAsync(item);
    }

    public async Task<int> DeleteUserAsync(User item)
    {
        return await dbConnection.DeleteAsync<User>(item);
    }
}