using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BlackStorkApp.Models;
using AutoMapper;

namespace BlackStorkApp.Controllers
{
    public class CatalogController : Controller
    {
        private IMainService<ProductDTO> productService;

        public CatalogController(IMainService<ProductDTO> service)
        {
            productService = service;
        }

        /// <summary>
        /// The method shows all products
        /// </summary>
        /// <returns>The views with list of products</returns>
        public ActionResult Index()
        {
            IEnumerable<ProductDTO> productDTOs = productService.GetAllElements();
            Mapper.Initialize(configuratin => configuratin.CreateMap<ProductDTO, ProductModel>());
            var productsForDisplay = Mapper.Map<IEnumerable<ProductDTO>, List<ProductModel>>(productDTOs);

            return View(productsForDisplay);
        }


        /// <summary>
        /// The method shows a description of product, which selected  a user
        /// </summary>
        /// <param name="id">The id of a selected product</param>
        /// <returns>The view with a description of product</returns>
        [HttpPost]
        public ActionResult Product(int id)
        {
            ProductDTO productDTO = productService.GetElement(2);
            Mapper.Initialize(configuration => configuration.CreateMap<ProductDTO, ProductModel>());
            var productForDisplay = Mapper.Map<ProductDTO, ProductModel>(productDTO);

            return View("Product", productForDisplay);
        }


        protected override void Dispose(bool disposing)
        {
            productService.Dispose();
            base.Dispose(disposing);
        }
    }
}