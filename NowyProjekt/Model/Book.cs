using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NowyProjekt.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }

    }
}
