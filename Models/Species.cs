using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFill.Models
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [EnumDataType(typeof(SpeciesType))]
        public SpeciesType Type { get; set; }

        public virtual List<Image> Images { get; set; }
    }

    public enum SpeciesType
    {
        Animal = 1,
        Plant = 2
    }
}
