using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// The implementation of IRepository
    /// </summary>
    class ProductRepository : IRepository<Product>
    {
        private BlackStorkContext db;

        public ProductRepository(BlackStorkContext blackStorkContext)
        {
            this.db = blackStorkContext;
        }

        public IEnumerable<Product> GetAllElements()
        {
            return db.Products;
        }

        public Product GetElement(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> FindElement(Expression<Func<Product, bool>> predicate) 
        {
            return db.Products.Where(predicate).Select(i => i);
        }

        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Delete(int id)
        {
            var productForDelete = db.Products.Find(id);
            if (productForDelete != null)
            {
                db.Products.Remove(productForDelete);
            }
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
