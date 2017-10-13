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

        /// <summary>
        /// The method gets all products from DB
        /// </summary>
        /// <returns>The collection of Products</returns>
        public IEnumerable<Product> GetAllElements()
        {
            return db.Products;          
        }


        /// <summary>
        /// The method gets the product from DB
        /// </summary>
        /// <param name="id">The id of product</param>
        /// <returns>The product with the requested id</returns>
        public Product GetElement(int id)
        {
            return db.Products.Find(id);
        }

        /// <summary>
        /// The method finds the product by predicate
        /// </summary>
        /// <param name="predicate">The Predicate for search</param>
        /// <returns>The product, which the name coincides with the predicate</returns>
        public IEnumerable<Product> FindElement(Expression<Func<Product, bool>> predicate) 
        {
            return db.Products.Where(predicate).Select(i => i);
        }

        /// <summary>
        /// The method gets the new product and adds it in DB
        /// </summary>
        /// <param name="item">The new product</param>
        public void Create(Product item)
        {
            db.Products.Add(item);
        }


        /// <summary>
        /// The method deletes the product from DB
        /// </summary>
        /// <param name="id">The id of product,which will be deleted</param>
        public void Delete(int id)
        {
            var productForDelete = db.Products.Find(id);
            if (productForDelete != null)
            {
                db.Products.Remove(productForDelete);
            }
        }

        /// <summary>
        /// The method gets the updated product and modified old record
        /// </summary>
        /// <param name="item">The updated product</param>
        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
