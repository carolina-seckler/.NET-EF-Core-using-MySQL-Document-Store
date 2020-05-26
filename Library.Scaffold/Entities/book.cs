using System;
using System.Collections.Generic;

namespace Library.Scaffold.Entities
{
    public partial class book
    {
        public int id { get; set; }
        public string info { get; set; }
        public int publisherid { get; set; }

        public virtual publisher publisher { get; set; }
    }
}
