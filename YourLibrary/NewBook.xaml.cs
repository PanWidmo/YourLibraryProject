using System.Linq;
using System.Windows;
using YourLibrary.Model;

namespace YourLibrary
{
    /// <summary>
    /// Interaction logic for NewBook.xaml
    /// </summary>
    public partial class NewBook : Window
    {
        LibraryContext libraryContext;
        Book addBook = new Book();
        
        public NewBook(LibraryContext libraryContext)
        {

            this.libraryContext = libraryContext;
            InitializeComponent();
            NewBookGrid.DataContext = addBook;
            GetBooks();

        }

        public void GetBooks()
        {
            booksInLibrary.ItemsSource = libraryContext.Books.ToList();
        }

        public void AddNewBook(object s, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(titleTextBox.Text)){
                MessageBox.Show("Enter title");
            }
            else
            {
                addBook.Id = 0;
                addBook.Title = titleTextBox.Text;

                libraryContext.Add(addBook);
                libraryContext.SaveChanges();

                GetBooks();
                MessageBox.Show(titleTextBox.Text + " successfully added to library!");
                titleTextBox.Text = "";
            }
        }

        private void exitButton(object s, RoutedEventArgs e)
        {
            this.Close();
        }

        private void backToMainWindow(object s, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(libraryContext);
            this.Close();
            main.Show();
        }
    }
}
