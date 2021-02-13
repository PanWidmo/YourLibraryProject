using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NowyProjekt
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Model.LibraryContext libraryContext;

        public Login(Model.LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
            InitializeComponent();
        }

        Model.Member selectedMember = new Model.Member();
        private void logIn(object s, RoutedEventArgs e)
        {
            selectedMember = (s as FrameworkElement).DataContext as Model.Member;

            
        }

        
    }
}
