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

        
        private void AddNewMember(object s, RoutedEventArgs e)
        {
            libraryContext.Add(NewMember);
            libraryContext.SaveChanges();
            NewMember = new Model.Member();
        }















        /// <summary>
        /// Insert new member to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void register_Click(object sender, RoutedEventArgs e) 
        //{
        //    if (string.IsNullOrEmpty(firstName.Text) || string.IsNullOrEmpty(lastName.Text) || string.IsNullOrEmpty(email.Text)
        //        || string.IsNullOrEmpty(phone.Text) || string.IsNullOrEmpty(password.Text) || string.IsNullOrEmpty(confirmPassword.Text))
        //    {
        //        MessageBox.Show("Please enter text in box!");
        //    }

        //    else if(password.Text != confirmPassword.Text){
        //        MessageBox.Show("Passwords do not match");
        //    }
        //    else
        //    {
        //        using (var dbContext = new Model.LibraryContext())
        //        {
        //            Model.Member member = new Model.Member()
        //            {
        //                FirstName=firstName.Text,
        //                LastName=lastName.Text,
        //                Email=email.Text,
        //                Phone = phone.Text,
        //                Password=password.Text
        //            };

        //            dbContext.Add(member);
        //            dbContext.SaveChanges();

        //            if (member.MemberId > 0)
        //            {
        //                MessageBox.Show("Welcome aboard: "+member.FirstName + " " + member.LastName+"!");


        //            }

        //            else MessageBox.Show("Error");



        //        }

        //    }
        //}
    }
}
