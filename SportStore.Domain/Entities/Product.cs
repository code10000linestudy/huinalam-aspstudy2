using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public bool IsValid
        {
            get
            {
                if (Name == null ||
                    Description == null ||
                    Price == 0 ||
                    Category == null)
                    return false;
                return true;
            }
        }
    }
}
