using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Xamarin.Forms;
using XamarinDiary.Droid;
using XamarinDiary.Services;

[assembly:Dependency(typeof(AndroidSQLiteConnectionFactory))]
namespace XamarinDiary.Droid
{
    public class AndroidSQLiteConnectionFactory : ISQLiteConnectionFactory
    {
        private readonly string _path;

        public AndroidSQLiteConnectionFactory()
        {
            var sqliteFilename = "app.db";
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            _path = Path.Combine(documentsDirectoryPath, sqliteFilename);
        }
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return new SQLiteAsyncConnection(_path,SQLiteOpenFlags.Create| SQLiteOpenFlags.FullMutex|SQLiteOpenFlags.ReadWrite|SQLiteOpenFlags.ProtectionComplete,true);
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_path, SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.ProtectionComplete,true);
        }
    }
}