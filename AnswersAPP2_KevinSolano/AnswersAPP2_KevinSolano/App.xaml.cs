using AnswersAPP2_KevinSolano.Services;
using AnswersAPP2_KevinSolano.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswersAPP2_KevinSolano
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
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
