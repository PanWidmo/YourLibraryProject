using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NowyProjekt.Model
{
    class Order
    {
        public int OrderID {get;set;}
        public int MemberID { get; set; }
        public int BookID { get; set; }

        public virtual Member Member { get; set; }
        public virtual Book Book { get; set; }
    }
}
