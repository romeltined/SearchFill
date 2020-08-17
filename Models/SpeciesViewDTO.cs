using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFill.Models
{
    public class SpeciesViewDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> ImagesBase64 { get; set; }
    }
}
