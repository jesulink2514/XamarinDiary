using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using XamarinDiary.Models;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinDiary.Services.MockDataStore))]
namespace XamarinDiary.Services
{
    public class MockDataStore : IDataStore<DiaryPage>
    {
        List<DiaryPage> items;

        public MockDataStore()
        {
            items = new List<DiaryPage>();
            var mockItems = new List<DiaryPage>
            {
                new DiaryPage { Id = Guid.NewGuid().ToString(), Title = "First item", Description="This is an item description. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum,Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32.The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H.Rackham." , LastUpdated = DateTime.Now},
                new DiaryPage { Id = Guid.NewGuid().ToString(), Title = "Second item", Description="This is an item description.", LastUpdated = DateTime.Now },
                new DiaryPage { Id = Guid.NewGuid().ToString(), Title = "Third item", Description="This is an item description.", LastUpdated = DateTime.Now },
                new DiaryPage { Id = Guid.NewGuid().ToString(), Title = "Fourth item", Description="This is an item description.", LastUpdated = DateTime.Now },
                new DiaryPage { Id = Guid.NewGuid().ToString(), Title = "Fifth item", Description="This is an item description.", LastUpdated = DateTime.Now },
                new DiaryPage { Id = Guid.NewGuid().ToString(), Title = "Sixth item", Description="This is an item description.", LastUpdated = DateTime.Now }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(DiaryPage item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(DiaryPage item)
        {
            var _item = items.Where((DiaryPage arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((DiaryPage arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<DiaryPage> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<DiaryPage>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}