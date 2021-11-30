using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEFCore.Data
{
    // FluentAPI ile configürasyon bazlı çalışma
    // DataAnnotations yöntemi POCO Classlar için önerilmeyen bir yöntem DDD yaklaşımda da doğru bir yöntem değil.
    public class Product
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public string CategoryId { get; set; }

        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }

        public virtual Category Category { get; set; }

        public virtual List<ProductFile> Files { get; set; }

    }
}
