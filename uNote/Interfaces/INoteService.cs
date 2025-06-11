namespace uNote.Interfaces;

public interface INoteService
{
    Task Initialize();
    Task<List<NoteItem>> GetAllNotesAsync();
    Task<NoteItem> GetNoteByIdAsync(int id); 
    Task<int> SaveNoteAsync(NoteItem item); 
    Task<int> UpdateNoteAsync(NoteItem item); 
    Task<int> DeleteNoteAsync(NoteItem item); 
}