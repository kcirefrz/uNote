using SQLite;

namespace uNote;

public class DatabaseService
{
    private const string DB_NAME = "uNote_local_db_.db3";
    private SQLiteAsyncConnection database;
}