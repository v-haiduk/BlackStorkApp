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
        /// The method shows all products with short-description and adds a pagination
        /// </summary>
        /// <returns>The views with list of products</returns>
        public ActionResult Index(int page = 1)
        {
            IEnumerable<ProductDTO> productDTOs = productService.GetAllElements();
            productDTOs.ToList().ForEach(prod => prod.Description = prod.Description.Substring(0, 100));

            Mapper.Initialize(configuratin => configuratin.CreateMap<ProductDTO, ProductModel>());
            var productsForDisplay = Mapper.Map<IEnumerable<ProductDTO>, List<ProductModel>>(productDTOs);

            PaginationProductsModel productsWithPagination = CreatePaginationForProducts(productsForDisplay, page);

            return View("Index", productsWithPagination);
        }

        /// <summary>
        /// The method adds the pagination for collection of products
        /// </summary>
        /// <param name="products">The list of product without pagination</param>
        /// <param name="page">The number of current page</param>
        private PaginationProductsModel CreatePaginationForProducts(IEnumerable<ProductModel> products, int page)
        {
            int amountItemOnPage = 10;
            IEnumerable<ProductModel> productsOnPage = products.Skip((page - 1) * amountItemOnPage).Take(amountItemOnPage);
            PageModel pageModel = new PageModel
            {
                PageNumber = page,
                PageCapacity = amountItemOnPage,
                TotalItems = products.Count()
            };

            PaginationProductsModel productsOnPages = new PaginationProductsModel
            {
                Page = pageModel,
                Products = productsOnPage
            };

            return productsOnPages;
        }


        /// <summary>
        /// The method shows a description of product, which selected  a user
        /// </summary>
        /// <param name="id">The id of a selected product</param>
        /// <returns>The view with a description of product</returns>
        [HttpPost]
        public ActionResult Product(int id)
        {
            ProductDTO productDTO = productService.GetElement(id);
            Mapper.Initialize(configuration => configuration.CreateMap<ProductDTO, ProductModel>());
            var productForDisplay = Mapper.Map<ProductDTO, ProductModel>(productDTO);

            return View("Product", productForDisplay);
        }

        /// <summary>
        /// The method finds products by predicate
        /// </summary>
        /// <param name="name">The name, which will be used like predicate</param>
        /// <returns>JSON with result of search</returns>
        public JsonResult Search(string name)
        {
            var resultOfSearch = productService.FindElement(product => product.Name.Contains(name)).ToList();

            return Json(resultOfSearch, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            productService.Dispose();
            base.Dispose(disposing);
        }
    }
}