using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFill.Models
{
    public class SportItemsDTO
    {
        public string Sport { get; set; }
        public virtual List<string> Items { get; set; }
    }
}
