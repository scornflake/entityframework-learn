using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public class ProductGroup : CommonWithOrganization
    {
        public string Name { get; set; }

    }

    public class Product  : CommonWithOrganization
    {
        public string Name { get; set; }

        public ProductGroup ProductGroupID { get; set; }
        public ProductGroup OwningGroup { get; set; }
    }
}
