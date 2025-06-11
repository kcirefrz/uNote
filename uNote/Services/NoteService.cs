using SQLite;
using uNote.Interfaces;

namespace uNote.Services;

public class NoteService : INoteService
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
            GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "note.db3");

            dbConnection = new SQLiteAsyncConnection(dbPath);
            await dbConnection.CreateTableAsync<NoteItem>();
        }
    }

    public async Task<List<NoteItem>> GetAllNotesAsync()
    {
        return await dbConnection.Table<NoteItem>().ToListAsync();
    }

    public async Task<NoteItem> GetNoteByIdAsync(int id)
    {
        return await dbConnection.Table<NoteItem>().FirstOrDefaultAsync(x => x.NoteId == id);
    }

    public async Task<int> SaveNoteAsync(NoteItem item)
    {
        return await dbConnection.InsertAsync(item);
    }

    public async Task<int> UpdateNoteAsync(NoteItem item)
    {
        return await dbConnection.UpdateAsync(item);
    }

    public async Task<int> DeleteNoteAsync(NoteItem item)
    {
        return await dbConnection.DeleteAsync<NoteItem>(item);
    }
}