using SQLite;

namespace XamarinDiary.Services
{
    public interface ISQLiteConnectionFactory
    {
        SQLiteAsyncConnection GetAsyncConnection();
        SQLiteConnection GetConnection();
    }
}
