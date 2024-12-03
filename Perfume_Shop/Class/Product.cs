using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume_Shop.Class
{
    public class Product
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; } = "Мужские";
    }
}
