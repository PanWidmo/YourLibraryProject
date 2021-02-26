using System;
using System.Linq;
using System.Windows;
using YourLibrary.Model;

namespace YourLibrary
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

        private void exitButton(object s, RoutedEventArgs e)
        {
            this.Close();
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

                    if (member.Email == "admin")
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
                                               
                        var booksInStore = libraryContext.Books.Select(x => new { x.Id, x.Title }).ToList();
                        borrowCombobox.ItemsSource = booksInStore;
                                                
                        var memberBorrowedBooks = (from b in libraryContext.Books
                                                   join o in libraryContext.Orders on b.Id equals o.BookId
                                                   join m in libraryContext.Members on o.MemberId equals m.Id
                                                   where m.Email == emailTextBox.Text
                                                   select new OrderData
                                                   {
                                                       Id = o.Id,
                                                       Title = b.Title
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
            if (string.IsNullOrEmpty(borrowCombobox.Text))
            {
                MessageBox.Show("Select data!");
            }
            else
            {
                char[] znak = { '{', 'I', 'd', '=', ' ' };
                string item = borrowCombobox.SelectedItem.ToString();
                string id = item.Split(',')[0];
                int Id = Int32.Parse(id.Trim(znak));

                var tex = borrowCombobox.Text;

                NewOrder.Id = 0;
                NewOrder.BookId = Id;
                NewOrder.MemberId = ID;

                
                libraryContext.Orders.Add(NewOrder);
                libraryContext.SaveChanges();
                borrowCombobox.DataContext = new Order();

                MessageBox.Show("Successfully borrowed: " + tex + " from Library!");

                var memberBorrowedBooks = (from b in libraryContext.Books
                                           join o in libraryContext.Orders on b.Id equals o.BookId
                                           join m in libraryContext.Members on o.MemberId equals m.Id
                                           where m.Email == emailTextBox.Text
                                           select new OrderData
                                           {
                                               Id=o.Id,
                                               Title=b.Title
                                           }
                                 ).ToList();

                returnCombobox.ItemsSource = memberBorrowedBooks;
            }

        }

        class OrderData
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(returnCombobox.Text))
            {
                MessageBox.Show("Select data!");
            }
            else
            {

                var item = (OrderData)returnCombobox.SelectedItem;
                var id = item.Id;

                var tex = returnCombobox.Text;

                var orderToDelete = libraryContext.Orders.Single(x => x.Id == id);
                libraryContext.Orders.Remove(orderToDelete);
                libraryContext.SaveChanges();

                MessageBox.Show("Successfully returned: " + tex + " to Library!");

                var memberBorrowedBooks = (from b in libraryContext.Books
                                           join o in libraryContext.Orders on b.Id equals o.BookId
                                           join m in libraryContext.Members on o.MemberId equals m.Id
                                           where m.Email == emailTextBox.Text
                                           select new OrderData
                                           {
                                               Id = o.Id,
                                               Title = b.Title
                                           }
                                 ).ToList();

                returnCombobox.ItemsSource = memberBorrowedBooks;
                
            }
        }
    }
}
