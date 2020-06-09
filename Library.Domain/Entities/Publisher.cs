using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    [MySqlCollation("latin1_spanish_ci")]
    public class Publisher : TEntity<int>
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        [MySqlCharset("latin1")]
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
