using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace YourLibrary.Model
{
    public class Order
    {
        public int Id {get;set;}
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
