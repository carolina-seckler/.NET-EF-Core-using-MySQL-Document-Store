using Innofactor.EfCoreJsonValueConverter;
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
    public class Book
    {
        [MySqlCharset("latin1")]
        public int ID { get; set; }
        public string Info { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
