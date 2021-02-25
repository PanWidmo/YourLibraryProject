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
                new Member{Id=1, FirstName="John", LastName="Smith",Email="jsmith@project.com", Phone="123123123", Password="smith123"},
                new Member{Id=2, FirstName="Paul", LastName="Orange",Email="porange@project.com", Phone="321321321", Password="orange123" },
                new Member{Id=3, FirstName="Mario", LastName="Busc",Email="mbusc@project.com", Phone="123321123", Password="busc123"},
                new Member{Id=4, FirstName="admin", LastName="admin",Email="admin", Phone="998997999", Password="admin"},
            };
        }

        private Book[] GetBooks()
        {
            return new Book[]
            {
                new Book{Id=1,Title="Sztuka Wojny"},
                new Book{Id=2,Title="Rok 1984"},
                new Book{Id=3,Title="Kod Da Vinci"},
                new Book{Id=4,Title="Quo Vadis"},
                new Book{Id=5,Title="Pan Tadeusz"}
                
            };
        }

        private BookDetail[] GetBooksDetails()
        {
            return new BookDetail[]
            {
                new BookDetail{Id=1, Author="Sun Tzu", BookId=1},
                new BookDetail{Id=2,Author="George Orwell", BookId=2},
                new BookDetail{Id=3,Author="Dany Brown", BookId=3},
                new BookDetail{Id=4, Author="Henryk Sienkiewicz", BookId=4},
                new BookDetail{Id=5,Author="Pan Tadeusz",BookId=5}
            };
        }
        
        private Order[] GetOrders()
        {
            return new Order[]
            {
                new Order{Id=1,MemberId=1,BookId=1},
                new Order{Id=2,MemberId=1,BookId=2},
                new Order{Id=3, MemberId=1,BookId=3 },
                new Order{Id=4,MemberId=2,BookId=4},
                new Order{Id=5,MemberId=3,BookId=5}

            };
        }

    }
}
