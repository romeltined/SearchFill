using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFill.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Content { get; set; }

    }
}
