using System;
using System.Collections.Generic;

namespace Library.Scaffold.Entities
{
    public partial class book
    {
        public book()
        {
            volume = new HashSet<volume>();
        }

        public int id { get; set; }
        public string isbn { get; set; }
        public string author { get; set; }
        public string language { get; set; }
        public int idpublisher { get; set; }

        public virtual publisher idpublisherNavigation { get; set; }
        public virtual ICollection<volume> volume { get; set; }
    }
}
