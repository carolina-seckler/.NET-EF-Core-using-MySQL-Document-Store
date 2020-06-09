using System;
using System.Collections.Generic;

namespace Library.Scaffold.Entities
{
    public partial class publisher
    {
        public publisher()
        {
            book = new HashSet<book>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        public virtual ICollection<book> book { get; set; }
    }
}
