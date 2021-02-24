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
using NowyProjekt.Model;

namespace NowyProjekt
{

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        LibraryContext libraryContext;

        Order NewOrder = new Order();

        private int ID { get; set; }

        public Login(LibraryContext libraryContext)
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
                    //opens special admin window that allows to add new book to lib (email: admin@admin.admin pass: admin)
                    if (member.Email == "admin@admin.admin")
                    {
                        NewBook newbook = new NewBook(libraryContext);
                        this.Close();
                        newbook.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login successfully!");

                        memberData.Visibility = Visibility.Visible;

                        logOutButton.IsEnabled = true;
                        logInButton.IsEnabled = false;

                        var currentMember = libraryContext.Members.Where(a => a.Email == emailTextBox.Text).ToList();

                        firstNameBox.DataContext = currentMember;
                        lastNameBox.DataContext = currentMember;
                        emailBox.DataContext = currentMember;
                        phoneBox.DataContext = currentMember;
                        passwordBox.DataContext = currentMember;
                        ID = member.Id;

                        //wypisanie z bazy ksiazek do wypozyczenia
                        //var booksInStore = (from Book in libraryContext.Books
                        //         select Book.Title
                        //         ).ToList();

                        var booksInStore = libraryContext.Books.Select(x => new { x.Id, x.Title }).ToList();
                        borrowCombobox.ItemsSource = booksInStore;

                        //do comboboxa wypozyczone ksiazki
                        var memberBorrowedBooks = (from b in libraryContext.Books
                                                   join o in libraryContext.Orders on b.Id equals o.BookId
                                                   join m in libraryContext.Members on o.MemberId equals m.Id
                                                   where m.Email == emailTextBox.Text
                                                   select new
                                                   {
                                                       b.Id,
                                                       b.Title
                                                   }
                                 ).ToList();
                        returnCombobox.ItemsSource = memberBorrowedBooks;
                    }


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

        private void borrowButton_Click(object sender, RoutedEventArgs e)
        {
            char[] znak = { '{', 'I', 'd', '=', ' ' };
            string item = borrowCombobox.SelectedItem.ToString();

            string id = item.Split(',')[0];
            int Id = Int32.Parse(id.Trim(znak));

            NewOrder.BookId = Id;
            NewOrder.MemberId = ID;

            libraryContext.Orders.Add(NewOrder);
            libraryContext.SaveChanges();
            borrowCombobox.DataContext = new Order();
            libraryContext.ChangeTracker.Clear();

        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            char[] znak = { '{', 'I', 'd', '=', ' ' };
            string item = returnCombobox.SelectedItem.ToString();

            string id = item.Split(',')[0];
            int Id = Int32.Parse(id.Trim(znak));

            NewOrder.MemberId = ID;
            NewOrder.BookId = Id;

            libraryContext.Orders.Remove(NewOrder);
            libraryContext.SaveChanges();
            borrowCombobox.DataContext = new Order();
        }
    }
}
