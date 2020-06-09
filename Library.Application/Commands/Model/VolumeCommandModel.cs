using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Commands.Model
{
    public class VolumeCommandModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public int Pages { get; set; }
        public int IdBook { get; set; }
        public virtual BookCommandModel Book { get; set; }
    }
}
