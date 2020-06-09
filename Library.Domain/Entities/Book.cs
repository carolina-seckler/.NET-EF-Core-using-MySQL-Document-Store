using Innofactor.EfCoreJsonValueConverter;
using Library.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Domain.Entities
{
    [MySqlCollation("latin1_spanish_ci")]
    public class Book : TEntity<int>
    {
        public Book()
        {
            Volumes = new HashSet<Volume>();
        }

        [MySqlCharset("latin1")]
        public string ISBN { get; set; }
        public string Author { get; set; }
        public Language Language { get; set; }
        public int IdPublisher { get; set; }
        public virtual Publisher IdPublisherNavigation { get; set; }
        public virtual ICollection<Volume> Volumes { get; set; }
    }
}
