using System;
using Xamarin.Forms;
using XamarinDiary.Views;
using Xamarin.Forms.Xaml;
using SQLite;
using XamarinDiary.Services;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XamarinDiary
{
	public partial class App : Application
	{
		
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new ItemsPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
