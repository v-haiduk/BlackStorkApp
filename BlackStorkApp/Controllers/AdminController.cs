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
using System.Xml.Serialization;
using PagedList.Mvc;
using PagedList;

namespace BlackStorkApp.Controllers
{
    public class AdminController : Controller
    {
        private IMainService<ProductDTO> productService;
        private IMainService<TopicDTO> topicService;

        public AdminController(IMainService<ProductDTO> pService, IMainService<TopicDTO> tService)
        {
            productService = pService;
            topicService = tService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The method returns the view with forms for add new product
        /// </summary>
        [HttpGet]
        public ActionResult CreateOfProduct()
        {
            return View();
        }


        /// <summary>
        /// The method sends an information about new product, which added the admin 
        /// </summary>
        /// <param name="product">The new product, which will be add in a DB</param>
        /// <param name="photo">The new main photo uploaded by user</param>
        [HttpPost]
        public ActionResult CreateOfProduct(ProductModel product, HttpPostedFileBase photo)
        {
            product.PathForMainPhoto = Upload(photo);
            Mapper.Initialize(configuration => configuration.CreateMap<ProductModel, ProductDTO>());
            var newProduct = Mapper.Map<ProductModel, ProductDTO>(product);
            productService.CreateElement(newProduct);

            return RedirectToAction("GetAllProducts");
        }

        /// <summary>
        /// The method saves the new main photo of product on the server
        /// </summary>
        /// <param name="photo">The new photo uploaded by user </param>
        /// <returns>The path to the photo on the server</returns>
        public string Upload(HttpPostedFileBase photo)
        {
            string fileName = System.IO.Path.GetFileName(photo.FileName);
            string filePath = Server.MapPath("~/Content/img/" + fileName);
            photo.SaveAs(filePath);

            return filePath;
        }


        /// <summary>
        /// The method returns the view with forms, which contain an old information for edit product
        /// </summary>
        /// <param name="id">The product,which will be edit</param>
        [HttpGet]
        public ActionResult EditOfProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var productDTOForEdit = productService.GetElement(id);
            Mapper.Initialize(configuration => configuration.CreateMap<ProductDTO, ProductModel>());
            var productForEdit = Mapper.Map<ProductDTO, ProductModel>(productDTOForEdit);
            
            if (productForEdit != null)
            {
                return View("EditOfProduct",productForEdit);
            }

            return HttpNotFound();
        }


        /// <summary>
        /// The method sends an update about product, which added the admin 
        /// </summary>
        /// <param name="productModel">The product, which edited an administrator</param>
        [HttpPost]
        public ActionResult EditOfProduct(ProductModel productModel)
        {
            if (productModel == null)
            {
                return HttpNotFound();
            }
            Mapper.Initialize(configuration => configuration.CreateMap<ProductModel, ProductDTO>());
            var productForEdit = Mapper.Map<ProductModel, ProductDTO>(productModel);
            productService.UpdateElement(productForEdit);

            return RedirectToAction("GetAllProducts");
        }


        /// <summary>
        /// The method returns the view with list of all products and adds a pagination
        /// </summary>
        public ActionResult GetAllProducts(int page = 1)
        {
            IEnumerable<ProductDTO> productDTOs = productService.GetAllElements();
            Mapper.Initialize(configuration => configuration.CreateMap<ProductDTO, ProductModel>());
            var allProducts = Mapper.Map<IEnumerable<ProductDTO>, List<ProductModel>>(productDTOs);

            PaginationProductsModel productsWithPagination = CreatePaginationForProducts(allProducts, page);

            return View("AllProducts", productsWithPagination);
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
        /// The method deletes a product, which selected the administrator
        /// </summary>
        /// <param name="id">The id of product, which will be add</param>
        [HttpPost]
        public ActionResult DeleteOfProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            productService.DeleteElement(id.Value);

            return RedirectToAction("GetAllProducts");
        }


        /// <summary>
        /// The method returns the view with empty forms for add new topic
        /// </summary>
        [HttpGet]
        public ActionResult CreateOfTopic()
        {
            return View();
        }


        /// <summary>
        /// The method sends an information about new topic, which added the admin 
        /// </summary>
        /// <param name="topic">The new topic, which will be add in a DB</param>
        /// <param name="photo">The new main photo uploaded by user</param>
        [HttpPost]
        public ActionResult CreateOfTopic(TopicModel topic, HttpPostedFileBase photo)
        {
            topic.PathForMainPhoto = Upload(photo);
            Mapper.Initialize(configuration => configuration.CreateMap<TopicModel, TopicDTO>());
            var newTopic = Mapper.Map<TopicModel, TopicDTO>(topic);
            topicService.CreateElement(newTopic);

            return RedirectToAction("GetAllTopics");
        }


        /// <summary>
        /// The method returns the view with forms, which contain an old information for edit topic
        /// </summary>
        /// <param name="id">The topic,which will be edit</param>
        [HttpGet]
        public ActionResult EditOfTopic(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var topicDTOForEdit = topicService.GetElement(id);
            if (topicDTOForEdit == null)
            {
                return HttpNotFound("first exception");
            }

            Mapper.Initialize(configuration => configuration.CreateMap<TopicDTO, TopicModel>());
            var topicModelForEdit = Mapper.Map<TopicDTO, TopicModel>(topicDTOForEdit);
            if (topicModelForEdit != null)
            {
                return View("EditOfTopic",topicModelForEdit);
            }

            return HttpNotFound("second exception");
        }


        /// <summary>
        /// The method sends an update about topic, which added the admin 
        /// </summary>
        /// <param name="topicModel">The topic, which edited an administrator</param>
        [HttpPost]
        public ActionResult EditOfTopic(TopicModel topicModel)
        {
            if (topicModel == null)
            {
                return HttpNotFound();
            }
            Mapper.Initialize(configuration => configuration.CreateMap<TopicModel, TopicDTO>());
            var topicDTOForEdit = Mapper.Map<TopicModel, TopicDTO>(topicModel);
            topicService.UpdateElement(topicDTOForEdit);

            return RedirectToAction("GetAllTopics");
        }


        /// <summary>
        /// The method returns the view with list of all topics and adds a pagination
        /// </summary>
        public ActionResult GetAllTopics(int page = 1)
        {
            IEnumerable<TopicDTO> topicDTOs = topicService.GetAllElements();
            Mapper.Initialize(configuration => configuration.CreateMap<TopicDTO, TopicModel>());
            var allTopics = Mapper.Map<IEnumerable<TopicDTO>, List<TopicModel>>(topicDTOs);

            PaginationTopicsModel topicsWithPagination = CreatePaginationForTopics(allTopics, page);

            return View("AllTopics", topicsWithPagination);
        }

        /// <summary>
        /// The method adds the pagination for collection of topics
        /// </summary>
        /// <param name="products">The list of topics without pagination</param>
        /// <param name="page">The number of current page</param>
        private PaginationTopicsModel CreatePaginationForTopics(IEnumerable<TopicModel> topics, int page)
        {
            int amountOfItemOnPage = 10;
            IEnumerable<TopicModel> topicsOnPage = topics.Skip((page - 1)*amountOfItemOnPage).Take(amountOfItemOnPage);

            PageModel pageModel = new PageModel
            {
                PageNumber = page,
                PageCapacity = amountOfItemOnPage,
                TotalItems = topics.Count()
            };

            PaginationTopicsModel topicsOnPages = new PaginationTopicsModel
            {
                Page = pageModel,
                Topics = topicsOnPage
            };

            return topicsOnPages;

        }


        /// <summary>
        /// The method deletes a topic, which selected the administrator
        /// </summary>
        /// <param name="id">The id of topic, which will be add</param>
        [HttpPost]
        public ActionResult DeleteOfTopic(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            topicService.DeleteElement(id.Value);

            return RedirectToAction("GetAllTopics");
        }


        /// <summary>
        /// The method creats xml file with all products, save it on server and returns it to client
        /// </summary>
        /// <returns>The XML file with all products</returns>
        public FileResult ExportToXML()
        {
            TransferData export = new TransferData();

            string filePath = Server.MapPath("~/Content/documents/Catalog.xml");
            string fileType = "xml";
            string fileName = "Catalog.xml";

            export.ExportToXML(productService.GetAllElements(), filePath);       

            return File(filePath, fileType, fileName);
        }


        /// <summary>
        /// The method creats XLSX file with all products, save it on server and returns it to client
        /// </summary>
        /// <returns>The XLSX (MS Exel) file with all products</returns>
        public FileResult ExportToExel()
        {
            TransferData export = new TransferData();

            string filePath = Server.MapPath("~/Content/documents/Catalog.xlsx");
            string fileType = "xlsx";
            string fileName = "Catalog.xlsx";

            export.ExportToXLSX(productService.GetAllElements(), filePath);

            return File(filePath, fileType, fileName);
        }

    }
}