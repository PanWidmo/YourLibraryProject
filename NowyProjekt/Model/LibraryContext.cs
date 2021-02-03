using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;


namespace NowyProjekt.Model
{
    class LibraryContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=library.db");

            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

    }
}
