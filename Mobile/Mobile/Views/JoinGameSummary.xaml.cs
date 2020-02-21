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
        }

        protected override bool OnBackButtonPressed()
        {
            var vm = BindingContext as ViewModels.vmJoinGameSummary;
            vm.BackButtonPressed();
            return base.OnBackButtonPressed();
        }
    }
}