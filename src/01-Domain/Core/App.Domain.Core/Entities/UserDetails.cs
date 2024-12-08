using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
    public class UserDetails
    {
        public int UserDetailsId { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public virtual  User? User { get; set; }
    }
}
