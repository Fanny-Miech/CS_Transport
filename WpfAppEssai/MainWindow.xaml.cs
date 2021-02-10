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
using WpfDisplayCoordonates.ViewModel;

namespace WpfDisplayCoordonates
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MyViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MyViewModel();
            // The DataContext serves as the starting point of Binding Paths
            DataContext = _viewModel;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
