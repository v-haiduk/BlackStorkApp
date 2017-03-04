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
        private IUnitOfWork uow { get; set; }

        //EFUnitOfWork will be used as the object of the IUnitOfWork
        public ProductService(IUnitOfWork database)
        {
            uow = database;
        }

        public IEnumerable<ProductDTO> GetAllElements()
        {
            Mapper.Initialize(configuration => configuration.CreateMap<Product, ProductDTO>());

            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(uow.Products.GetAllElements());
        }

        public ProductDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("????????", "");      //нельзя писать, что id не установлен. надо придумать текст
            }

            var product = uow.Products.GetElement(id.Value);
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
                //add id
                Name = element.Name,
                Description = element.Description,
                PathForMainPhoto = element.PathForMainPhoto,
                PathForFolderWithPhotos = element.PathForFolderWithPhotos
            };

            uow.Products.Create(product);
            uow.SaveChanges();
        }

        public void UpdateElement(ProductDTO element)
        {
            Product product = new Product
            {
                ProductId = element.ProductId,
                Name = element.Name,
                Description = element.Description,
                PathForMainPhoto = element.PathForMainPhoto,
                PathForFolderWithPhotos = element.PathForFolderWithPhotos
            };

            uow.Products.Update(product);
            uow.SaveChanges();
        }

        public void DeleteElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("", "");
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
