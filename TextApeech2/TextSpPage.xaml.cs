using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextApeech2
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextSpPage : ContentPage
    {
        static CrossLocale? locale = null;
        public TextSpPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var locales = await CrossTextToSpeech.Current.GetInstalledLanguages();
            var items = locales.Select(a => a.ToString()).ToArray();


            var selected = await DisplayActionSheet("idioma", "OK",null, items);
            
            if(string.IsNullOrEmpty(selected) || selected == "OK")
            {
                
                return;
            }
            if (Device.RuntimePlatform == Device.Android)
            {
                locale = locales.FirstOrDefault(l =>l.ToString() == selected);
                


            }
            else
            {
                locale = new CrossLocale { Language = selected}; //UWP-IOS
            }
            
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            btnSpeak.IsEnabled = false;
            var text = txtToSpeech.Text;
            if( useDafaults.IsToggled)
            {
                await CrossTextToSpeech.Current.Speak(text);
                btnSpeak.IsEnabled = true;
                return;
            }
            await CrossTextToSpeech.Current.Speak(text,
                pitch: (float)sliderPitch.Value,
                speakRate: (float)sliderPitch.Value,
                volume: (float)sliderVolume.Value,
                crossLocale: locale);

            btnSpeak.IsEnabled = true;
        }

        private void btnclean_Clicked(object sender, EventArgs e)
        {
            txtToSpeech.Text = "";
        }
    }
}