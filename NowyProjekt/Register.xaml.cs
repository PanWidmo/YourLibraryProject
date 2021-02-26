using System.Windows;
using NowyProjekt.Model;

namespace NowyProjekt
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        LibraryContext libraryContext;
        Member NewMember = new Member();

        public Register(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
            InitializeComponent();

            AddNewMemberGrid.DataContext = NewMember;
        }

        private void toLogin(object s, RoutedEventArgs e)
        {
            Login login = new Login(libraryContext);
            this.Close();
            login.Show();
        }

        private void exitButton(object s, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddNewMember(object s, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTextBox.Text) ||
                string.IsNullOrEmpty(lastNameTextBox.Text) ||
                string.IsNullOrEmpty(emailTextBox.Text) ||
                string.IsNullOrEmpty(phoneTextBox.Text) ||
                string.IsNullOrEmpty(passwordTextBox.Text)
                )
            {
                MessageBox.Show("Please enter data in to boxes");
            }
            else
            {
                libraryContext.Add(NewMember);
                libraryContext.SaveChanges();

                MessageBox.Show("Welcome aboard: " + firstNameTextBox.Text + " " + lastNameTextBox.Text + "!");

                Login login = new Login(libraryContext);
                this.Close();
                login.Show();
            }
        }
    }
}
