using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFill.Models
{
    public class UserRoleDTO
    {
        public string Guid { get; set; }
        public string Email { get; set; }
        public Dictionary<string, bool> Roles { get; set; }
    }
}
