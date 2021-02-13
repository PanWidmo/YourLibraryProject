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
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
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
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Hide();
        }

        private void registerFirstScreen_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register(libraryContext);
            registerWindow.Show();
            this.Close();
        }
    }
}
