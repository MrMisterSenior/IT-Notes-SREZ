using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ITNotes
{
    public partial class App : Application
    {
        public static Database db = new Database(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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