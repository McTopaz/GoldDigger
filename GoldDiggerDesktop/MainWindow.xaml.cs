using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoldDiggerDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var view = Container.Content as Views.NewGame;
            var vm = view.DataContext as ViewModels.vmNewGame;
            vm.ShowContent = DisplayContent;
        }

        private void DisplayContent(UserControl view)
        {
            var vm = view.DataContext as ViewModels.vmBase;
            vm.ShowContent = DisplayContent;
            Container.Content = view;
            view.VerticalAlignment = VerticalAlignment.Center;
            view.HorizontalAlignment = HorizontalAlignment.Center;
        }

        private void DisplayContent(UserControl view, GoldDiggerCommunication.Host host)
        {
            var vm = view.DataContext as ViewModels.vmBase;
            vm.ShowContent = DisplayContent;
            Container.Content = view;

        }
    }
}
