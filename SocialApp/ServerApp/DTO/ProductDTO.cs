using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.DTO
{
    public class ProductDTO
    {
        public int productId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }

        public bool  IsActive { get; set; }
    
    }
}