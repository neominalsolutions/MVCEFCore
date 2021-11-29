using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEFCore.Data
{
    public class Category
    {
        public string Id { get; private set; }
        public string Name { get; set; }

        public Category()
        {
            Id = Guid.NewGuid().ToString();
        }

        // navigation property
        // select ile bir sınıftan diğer sınafa bağlantı yapılabilir.
        public virtual ICollection<Product> Products { get; set; }


    }
}
