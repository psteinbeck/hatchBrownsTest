using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using hatchBrownsTest.Services;
using hatchBrownsTest.Views;

namespace hatchBrownsTest
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //Original: MainPage = new AppShell();
            MainPage = new MainShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
