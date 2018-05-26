using System;

using XamarinDiary.Models;

namespace XamarinDiary.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public DiaryPage Item { get; set; }
        public ItemDetailViewModel(DiaryPage item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
