using System.Windows;
using NowyProjekt.Model;

namespace NowyProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LibraryContext libraryContext;

        public MainWindow(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
            InitializeComponent();

        }

        private void logInFirstScreen_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login(libraryContext);
            loginWindow.Show();
            this.Close();
        }

        private void registerFirstScreen_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register(libraryContext);
            registerWindow.Show();
            this.Close();
        }
    }
}
