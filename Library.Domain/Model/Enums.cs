using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Library.Domain.Model
{
    public enum Language 
    {
        [Description("English")]
        English = 0,
                           
        [Description("Português")]
        Portuguese = 1,

        [Description("日本語")]
        Japanese = 2
    }

}
