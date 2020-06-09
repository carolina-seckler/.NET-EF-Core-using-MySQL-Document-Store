using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    [MySqlCollation("latin1_spanish_ci")]
    public class Volume : TEntity<int>
    {
        [MySqlCharset("latin1")]
        public string Title { get; set; }
        public int Number { get; set; }
        public int Pages { get; set; }
        public int IdBook { get; set; }
        public virtual Book IdBookNavigation { get; set; }
    }
}
