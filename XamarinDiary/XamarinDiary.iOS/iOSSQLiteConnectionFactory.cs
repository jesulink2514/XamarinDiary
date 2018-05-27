using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using XamarinDiary.iOS;
using XamarinDiary.Services;

[assembly: Dependency(typeof(iOSSQLiteConnectionFactory))]
namespace XamarinDiary.iOS
{
    public class iOSSQLiteConnectionFactory : ISQLiteConnectionFactory
    {
        private readonly string _path;

        public iOSSQLiteConnectionFactory()
        {
            var sqliteFilename = "app.db";
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library","xamarin.diary");
            _path = Path.Combine(libFolder,sqliteFilename);
        }
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return new SQLiteAsyncConnection(_path, SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.ProtectionComplete, true);
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_path, SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.ProtectionComplete, true);
        }
    }
}