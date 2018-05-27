﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinDiary.Models;

namespace XamarinDiary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public DiaryPage Item { get; set; }

        public NewItemPage():this(new DiaryPage
        {
            Title = "Item name",
            Description = "This is an item description.",
            Category = "Cat1"
        }){ }

        public NewItemPage(DiaryPage item)
        {
            InitializeComponent();
            Item = item;
            BindingContext = this;
            Title = item.Id == 0 ? "New Item" : "Update Item";
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Item.LastUpdated = DateTime.Now;
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}