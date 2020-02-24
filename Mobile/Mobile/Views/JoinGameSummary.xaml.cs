using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldDigger.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JoinGameSummary : ContentPage
    {
        public JoinGameSummary()
        {
            InitializeComponent();
            Xamarin.Forms.DataGrid.DataGridComponent.Init();
            //MessagingCenter.Subscribe<ViewModels.vmBase, string[]>(this, "DisplayAlert", (sender, values) => { DisplayAlert(values[0], values[1], "OK"); });

            var vm = BindingContext as ViewModels.vmJoinGameSummary;
            vm.DisplayMessage = Asdf;
        }

        protected override bool OnBackButtonPressed()
        {
            var vm = BindingContext as ViewModels.vmJoinGameSummary;
            vm.BackButtonPressed();
            return base.OnBackButtonPressed();
        }

        private void Asdf(string title, string message, string cancel)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert(title, message, cancel);
            });

        }
    }
}