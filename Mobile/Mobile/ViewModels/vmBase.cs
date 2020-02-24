using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace GoldDigger.Mobile.ViewModels
{
    class vmBase
    {
        public Action BackButtonPressed { get; set; }

        public void ShowPage(ContentPage page)
        {
            App.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public void DisplayAlert(string title, string message, string cancel = "OK")
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.DisplayAlert(title, message, cancel);
            });
        }
    }
}
