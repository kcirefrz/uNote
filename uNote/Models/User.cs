using SQLite;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

namespace uNote.Models;

[Table("user")]
public class User
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int UserId { get; set; }

    [MaxLength(50), NotNull, Column("username")]
    public string Username { get; set; }

    [Unique, MaxLength(50), NotNull, Column("email")]
    public string Email { get; set; }

    [MaxLength(50), NotNull, Column("password")]
    public string Password { get; set; }

    // [Column("option_image")]
    // public Image? OptionImage { get; set; }
}