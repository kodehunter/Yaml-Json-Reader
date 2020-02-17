using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalogue.Entity
{
    public class Product
    {
        public List<string> categories { get; set; }
        public string twitter { get; set; }
        public string title { get; set; }
    }

    public class JsonOrgProduct
    {
        public List<Product> products { get; set; }
    }
}
