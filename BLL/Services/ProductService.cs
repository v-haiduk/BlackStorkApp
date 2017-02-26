using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;
using AutoMapper;

namespace BLL.Services
{
    public class ProductService : IMainService<ProductDTO>
    {
        private IUnitOfWork DB { get; set; }

        //EFUnitOfWork will be used as the object of the IUnitOfWork
        public ProductService(IUnitOfWork database)
        {
            DB = database;
        }

        public IEnumerable<ProductDTO> GetAllElements()
        {
            Mapper.Initialize(configuration => configuration.CreateMap<Product, ProductDTO>());

            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(DB.Products.GetAllElements());
        }

        public ProductDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("????????", "");      //нельзя писать, что id не установлен. надо придумать текст
            }

            var product = DB.Products.GetElement(id.Value);
            if (id == null)
            {
                throw new ValidationException("Извините, но ничего не найдено", "");
            }

            Mapper.Initialize(configuration => configuration.CreateMap<Product, ProductDTO>());

            return Mapper.Map<Product, ProductDTO>(product);
        }

        public void CreateElement(ProductDTO element)
        {
            Product product = new Product
            {
                Name = element.Name,
                Description = element.Description,
                PathForMainPhoto = element.pathForMainPhoto
            };

            DB.Products.Create(product);
            DB.SaveChanges();
        }

        public void UpdateElement(ProductDTO element)
        {
            Product product = new Product
            {
                Name = element.Name,
                Description = element.Description,
                PathForMainPhoto = element.pathForMainPhoto
            };

            DB.Products.Update(product);
            DB.SaveChanges();
        }

        public void DeleteElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("", "");
            }

            DB.Products.Delete(id.Value);
            DB.SaveChanges();
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
