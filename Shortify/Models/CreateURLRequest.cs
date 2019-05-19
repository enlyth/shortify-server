using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shortify.Models
{
    public class CreateURLRequest
    {
        public string URL { get; set; }
        public string CustomPath { get; set; }
    }
}
