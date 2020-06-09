using System;
using System.Collections.Generic;

namespace Library.Scaffold.Entities
{
    public partial class volume
    {
        public int id { get; set; }
        public string title { get; set; }
        public int number { get; set; }
        public int pages { get; set; }
        public int idbook { get; set; }

        public virtual book idbookNavigation { get; set; }
    }
}
