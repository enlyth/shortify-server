using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shortify.Models
{
    public class URL
    {
        [Key]
        public string Identifier { get; set; }
        public string LongURL { get; set; }
        public string ShortURL { get; set; }
        public DateTime Created { get; set; }

        public uint TimesAccessed { get; set; } = 0;
    }
}
