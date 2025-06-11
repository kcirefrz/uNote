using SQLite;

namespace uNote;

[Table("note")]
public class NoteItem
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int NoteId { get; set; }

    [MaxLength(30), NotNull, Column("noteTitle")]
    public string NoteTitle { get; set; } = "New page";

    [MaxLength(50), Column("noteDescription")]
    public string? NoteDescription { get; set; }

    [NotNull, Column("startDate")]
    public DateTime NoteStartDate { get; set; }

    [Column("endDate")]
    public DateTime? NoteEndDate { get; set; }
}