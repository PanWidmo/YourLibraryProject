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
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.SqlServer;

namespace NowyProjekt
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        Model.LibraryContext libraryContext;
        Model.Member NewMember = new Model.Member();

        public Register(Model.LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
            InitializeComponent();

            AddNewMemberGrid.DataContext = NewMember;
        }

    /// <summary>
    /// Insert new member to database
    /// </summary>
    /// <param name="s"></param>
    /// <param name="e"></param>
        private void AddNewMember(object s, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTextBox.Text) ||
                string.IsNullOrEmpty(lastNameTextBox.Text) ||
                string.IsNullOrEmpty(emailTextBox.Text) ||
                string.IsNullOrEmpty(phoneTextBox.Text) ||
                string.IsNullOrEmpty(passwordTextBox.Text)
                )
            {
                MessageBox.Show("Please enter text in to boxes");
            }
            else
            {
                libraryContext.Add(NewMember);
                libraryContext.SaveChanges();
                NewMember = new Model.Member();
                MessageBox.Show("Welcome aboard: " + firstNameTextBox.Text + " " + lastNameTextBox.Text + "!");

                Login login = new Login(libraryContext);
                this.Close();
                login.Show();
            }
        }
    }
}
