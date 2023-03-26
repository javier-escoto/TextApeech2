using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextApeech2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TextSpPage();
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
