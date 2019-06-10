using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BaseUser
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserCustomName { get; set; }
        public string UserEmail { get; set; }
        public int UserAge { get; set; }
        public string UserPassword { get;set;}

    }
}
