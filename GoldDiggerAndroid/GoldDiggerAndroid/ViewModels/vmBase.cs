using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace GoldDiggerAndroid.ViewModels
{
    class vmBase
    {
        public INavigation Navigation { get; set; }

        public void ShowPage(ContentPage page)
        {
            var vm = page.BindingContext as vmBase;
            vm.Navigation = Navigation;
            Navigation.PushModalAsync(page);
        }
    }
}
