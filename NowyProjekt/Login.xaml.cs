using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        private void logIn(object s, RoutedEventArgs e)
        {
            var member = libraryContext.Members.FirstOrDefault(b => b.Email == emailTextBox.Text);

            if (member != null)
            {
                if (member.Password == passwordTextBox.Text)
                {
                    MessageBox.Show("Login successfully!");
                    MemberInfo.Visibility = Visibility.Visible;
                    logOut.IsEnabled = true;
                    var c = libraryContext.Members.Where(a => a.Email == emailTextBox.Text).ToList();
                    MemberInfo.ItemsSource = c;

                    


                }
                else MessageBox.Show("Wrong password");
            }
            else MessageBox.Show("User doesnt exist");

        }

        
    }
}
