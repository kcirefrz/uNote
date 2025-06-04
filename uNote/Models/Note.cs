namespace uNote;

public class Note
{
    public Note(int noteId, string noteName, string? noteDescription, DateTime noteStartDate, DateTime? noteEndDate)
    {
        NoteId = noteId;
        NoteName = noteName;
        NoteDescription = noteDescription;
        NoteStartDate = noteStartDate = new DateTime().Date;
        NoteEndDate = noteEndDate;
    }

    public int NoteId { get; }

    public string NoteName { get; set; }

    public string? NoteDescription { get; set; }

    public DateTime NoteStartDate { get; set; }

    public DateTime? NoteEndDate { get; set; }
}