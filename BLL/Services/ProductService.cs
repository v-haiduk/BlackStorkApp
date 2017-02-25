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
    class ProductService : IMainService<ProductDTO>
    {
        private IUnitOfWork DB { get; set; }

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

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
