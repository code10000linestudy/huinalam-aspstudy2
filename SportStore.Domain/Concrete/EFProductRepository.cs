using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges(); 
        }

        public bool Remove(Product product)
        {
            var data = context.Products.FirstOrDefault(q => q.Name == product.Name);
            if (data == null)
                return false;
            context.Products.Remove(data);
            context.SaveChanges();
            return true;
        }
    }
}
