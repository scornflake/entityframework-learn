using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public class Common
    {
        public int ID { get; set; }
        public Boolean Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }


    }

    public class Organization : Common
    {
        public String Name { get; set; }
    }

    public class CommonWithOrganization : Common
    {
        public Organization organization { get; set; }
    }
}
