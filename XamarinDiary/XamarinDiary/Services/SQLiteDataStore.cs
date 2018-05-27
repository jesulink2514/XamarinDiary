using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace XamarinDiary.Services
{
    public class SQLiteDataStore<T> : IDataStore<T> where T:new()
    {
        private readonly SQLiteAsyncConnection connection;

        public SQLiteDataStore()
        {
            connection = DependencyService.Get<ISQLiteConnectionFactory>().GetAsyncConnection();
        }
        private Task EnsureTableExists() => connection.CreateTableAsync<T>();
        public async Task<bool> AddItemAsync(T item)
        {
            await EnsureTableExists();
            var rows = await connection.InsertAsync(item);
            return rows > 0;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            await EnsureTableExists();
            var item = await connection.FindAsync<T>(id);
            var rows = await connection.DeleteAsync(item);
            return rows > 0;
        }

        public async Task<T> GetItemAsync(int id)
        {
            await EnsureTableExists();
            return await connection.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetItemsAsync()
        {
            await EnsureTableExists();
            return await connection.Table<T>().ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            await EnsureTableExists();
            var rows = await connection.UpdateAsync(item);
            return rows > 0;
        }

        public async Task<float> GetAveragePostsLenght()
        {
            await EnsureTableExists();
            var avg = await connection.ExecuteScalarAsync<float>("SELECT COUNT(Description) FROM DiaryPage WHERE Category=?","Cat1");
            return avg;
        }
    }
}
