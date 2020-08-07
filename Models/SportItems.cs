using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFill.Models
{
    public class SportItems
    {
        public int Id { get; set; }
        public string Sport { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}
