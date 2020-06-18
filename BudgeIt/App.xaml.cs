using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BudgeIt.Skateboard;

namespace BudgeIt
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SkateboardHomePage());
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
