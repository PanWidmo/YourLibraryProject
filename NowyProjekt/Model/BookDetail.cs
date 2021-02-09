using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NowyProjekt.Model
{
    public class BookDetail
    {

        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public string Author { get; set; }


    }
}
