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
using System.Windows.Shapes;
using NowyProjekt.Model;

namespace NowyProjekt
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
        }

        public void AddNewBook(object s, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(titleTextBox.Text)){
                MessageBox.Show("Enter title");
            }
            else
            {
                libraryContext.Add(addBook);
                libraryContext.SaveChanges();
                addBook = new Book();
                MessageBox.Show("Book: " + titleTextBox.Text + " successfully added!");
            }
        }
    }
}
