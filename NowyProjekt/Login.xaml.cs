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

        private void backToRegisterButton(object s, RoutedEventArgs e)
        {
            Register register = new Register(libraryContext);
            this.Close();
            register.Show();
        }

        private void LogOut(object s, RoutedEventArgs e)
        {
            this.Close();
        }

        private void logIn(object s, RoutedEventArgs e)
        {
            var member = libraryContext.Members.FirstOrDefault(b => b.Email == emailTextBox.Text);

            if (member != null)
            {
                if (member.Password == passwordTextBox.Text)
                {
                    MessageBox.Show("Login successfully!");
                    memberData.Visibility = Visibility.Visible;
                    logOutButton.IsEnabled = true;
                    logInButton.IsEnabled = false;
                    var c = libraryContext.Members.Where(a => a.Email == emailTextBox.Text).ToList();
                    
                    firstNameBox.DataContext = c;
                    lastNameBox.DataContext = c;
                    emailBox.DataContext = c;
                    phoneBox.DataContext = c;
                    passwordBox.DataContext = c;

                    
                    

                }
                else MessageBox.Show("Wrong password");
            }
            else MessageBox.Show("User doesnt exist");

        }

        private void Update(object s, RoutedEventArgs e)
        {
            var member = libraryContext.Members.FirstOrDefault(b => b.Email == emailTextBox.Text);
            libraryContext.Update(member);
            libraryContext.SaveChanges();
            MessageBox.Show("Changes have been saved successfully!");
        }

        private void Delete(object s, RoutedEventArgs e)
        {
            var member = libraryContext.Members.FirstOrDefault(b => b.Email == emailTextBox.Text);
            libraryContext.Remove(member);
            libraryContext.SaveChanges();
            MessageBox.Show("Account deleted successfully");

            MainWindow main = new MainWindow(libraryContext);
            this.Close();
            main.Show();
        }


    }
}
