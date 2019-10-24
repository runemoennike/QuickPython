using System.Windows;
using QuickPython.IDE.ViewModels;

namespace QuickPython.IDE.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            DataContext = mainWindowViewModel;

            InitializeComponent();
        }
    }
}
