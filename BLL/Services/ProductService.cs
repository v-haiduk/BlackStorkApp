using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;
using AutoMapper;

namespace BLL.Services
{
    /// <summary>
    /// The class implements the interface IMainService.
    /// </summary>
    public class ProductService : IMainService<ProductDTO>
    {
        private IUnitOfWork uow { get; set; }

        //EFUnitOfWork will be used as the object of the IUnitOfWork
        public ProductService(IUnitOfWork database)
        {
            uow = database;
        }

        /// <summary>
        /// The method gets all products from DB and transfer them on PL
        /// </summary>
        public IEnumerable<ProductDTO> GetAllElements()
        {
            Mapper.Initialize(configuration => configuration.CreateMap<Product, ProductDTO>());

            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(uow.Products.GetAllElements());
        }

        public IEnumerable<ProductDTO> FindElement(Expression<Func<ProductDTO, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ValidationException("Извините, товар не найден", "");
            }
            var predicateCompile = predicate.Compile();
            var resultOfFind = GetAllElements().Where(predicateCompile);

            return resultOfFind;
        }

        /// <summary>
        /// The method gets the product from DB and transfer it on PL
        /// </summary>
        /// <param name="id">The id of product</param>
        public ProductDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id товара", "");
            }

            var product = uow.Products.GetElement(id.Value);
            if (id == null)
            {
                throw new ValidationException("Извините, но ничего не найдено", "");
            }

            Mapper.Initialize(configuration => configuration.CreateMap<Product, ProductDTO>());
            return Mapper.Map<Product, ProductDTO>(product);
        }

        /// <summary>
        /// The method gets the new product from PL and save it in DB
        /// </summary>
        /// <param name="element">Thew new product</param>
        public void CreateElement(ProductDTO element)
        {
            Mapper.Initialize(configuration => configuration.CreateMap<ProductDTO, Product>() );
            var product = Mapper.Map<ProductDTO, Product>(element);

            uow.Products.Create(product);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the updated product from PL and save it in DB
        /// </summary>
        /// <param name="item">The updated product</param>
        public void UpdateElement(ProductDTO element)
        {
            Mapper.Initialize(configuration => configuration.CreateMap<ProductDTO, Product>());
            var product = Mapper.Map<ProductDTO, Product>(element);

            uow.Products.Update(product);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the id of product from PL and delete it in DB
        /// </summary>
        /// <param name="id">The id of product for delete</param>
        public void DeleteElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id товара", "");
            }

            uow.Products.Delete(id.Value);
            uow.SaveChanges();
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
