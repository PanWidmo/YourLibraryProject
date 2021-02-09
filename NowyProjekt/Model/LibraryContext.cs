using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;


namespace NowyProjekt.Model
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext>options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(GetMembers());
            modelBuilder.Entity<Book>().HasData(GetBooks());
            modelBuilder.Entity<BookDetail>().HasData(GetBooksDetails());
            modelBuilder.Entity<Order>().HasData(GetOrders());
            base.OnModelCreating(modelBuilder);
        }

        private Member[] GetMembers()
        {
            return new Member[]
            {
                new Member{Id=1, FirstName="John"},
                new Member{Id=2, FirstName="Paul"},
                new Member{Id=3, FirstName="Mario"},
            };
        }

        private Book[] GetBooks()
        {
            return new Book[]
            {
                new Book{Id=1,Title="Sztuka Wojny"},
                new Book{Id=2,Title="Rok 1984"},
            };
        }

        private BookDetail[] GetBooksDetails()
        {
            return new BookDetail[]
            {
                new BookDetail{Id=1, Author="Sun Tzu", BookId=1},
                new BookDetail{Id=2,Author="George Orwell", BookId=2},
            };
        }
        
        private Order[] GetOrders()
        {
            return new Order[]
            {
                new Order{Id=1,MemberId=1,BookId=1},
                new Order{Id=2,MemberId=1,BookId=1},
            };
        }

    }
}
