using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products= new List<Product>
            {
                new Product {ProductId=1,ProductName="elma", CategoryId =1, UnitPrice=15, UnitsInStock=10},
                new Product {ProductId=2,ProductName="armut", CategoryId =2, UnitPrice=20, UnitsInStock=15}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
            
        }

        public void Delete(Product product)
        {
        Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
        return _products.Where(p=>p.CategoryId==categoryId).ToList();
            
        }

        public void Update(Product product)
        {
            Product ProductToUpdate = _products.SingleOrDefault(p=> p.ProductId==product.ProductId);
            ProductToUpdate.ProductName = product.ProductName;
            ProductToUpdate.CategoryId= product.CategoryId;
            ProductToUpdate.UnitPrice= product.UnitPrice;
            ProductToUpdate.UnitsInStock= product.UnitsInStock;
        }
    }
}
