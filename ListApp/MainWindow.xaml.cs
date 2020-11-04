using ListApp.Services;
using ListApp.ViewModels;
using System.Windows;

namespace ListApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ViewHelper.RegisterView<LoginViewModel>("LoginView");
            ViewHelper.RegisterView<SignUpViewModel>("SignUpView");
            ViewHelper.RegisterView<NotesViewModel>("NotesView");

            InitializeComponent();
        }
    }
}
