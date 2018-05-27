using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamarinDiary.Models;
using XamarinDiary.Views;

namespace XamarinDiary.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<DiaryPage> Items { get; private set; }
        public Command LoadItemsCommand { get; private set; }
        public Command<DiaryPage> EditCommand { get;private set;}

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<DiaryPage>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            EditCommand = new Command<DiaryPage>(EditItem);

            MessagingCenter.Subscribe<NewItemPage, DiaryPage>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as DiaryPage;
                if(item.Id == default(int))
                {
                    await DataStore.AddItemAsync(_item);
                }
                else
                {
                    await DataStore.UpdateItemAsync(_item);
                }
                await ExecuteLoadItemsCommand();
            });
        }

        private async void EditItem(DiaryPage item)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new NewItemPage(item)));
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }

                var avg = await DataStore.GetAveragePostsLenght();
                await App.Current.MainPage.DisplayAlert("Posts",$"Average length:{avg}","Ok");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}