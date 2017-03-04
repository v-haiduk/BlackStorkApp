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
    public class AdminController : Controller
    {
        private IMainService<ProductDTO> productService;
        private IMainService<TopicDTO> topicService;

        public AdminController(IMainService<ProductDTO> pService, IMainService<TopicDTO> tService)
        {
            productService = pService;
            topicService = tService;
        }


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
        [HttpPost]
        public ActionResult CreateOfProduct(ProductModel product)
        {
            Mapper.Initialize(configuration => configuration.CreateMap<ProductModel, ProductDTO>());
            var newProduct = Mapper.Map<ProductModel, ProductDTO>(product);
            productService.CreateElement(newProduct);

            return RedirectToAction("Index");
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
                return View(productForEdit);
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

            return RedirectToAction("Index");
        }


        /// <summary>
        /// The method returns the view with list of all products
        /// </summary>
        public ActionResult GetAllProducts()
        {
            IEnumerable<ProductDTO> productDTOs = productService.GetAllElements();
            Mapper.Initialize(configuration => configuration.CreateMap<ProductDTO, ProductModel>());
            var allProducts = Mapper.Map<IEnumerable<ProductDTO>, List<ProductModel>>(productDTOs);

            return View("AllProducts", allProducts);
        }


        [HttpPost]
        public ActionResult DeleteOfProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            productService.DeleteElement(id.Value);

            return RedirectToAction("Index");
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
        [HttpPost]
        public ActionResult CreateOfTopic(TopicModel topic)
        {
            Mapper.Initialize(configuration => configuration.CreateMap<TopicModel, TopicDTO>());
            var newTopic = Mapper.Map<TopicModel, TopicDTO>(topic);
            topicService.CreateElement(newTopic);

            return RedirectToAction("Index");
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
                return View(topicModelForEdit);
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

            return RedirectToAction("Index");
        }


        /// <summary>
        /// The method returns the view with list of all topics
        /// </summary>
        public ActionResult GetAllTopics()
        {
            IEnumerable<TopicDTO> topicDTOs = topicService.GetAllElements();
            Mapper.Initialize(configuration => configuration.CreateMap<TopicDTO, TopicModel>());
            var allTopics = Mapper.Map<IEnumerable<TopicDTO>, List<TopicModel>>(topicDTOs);

            return View("AllTopics", allTopics);
        }



        [HttpPost]
        public ActionResult DeleteOfTopic(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            topicService.DeleteElement(id.Value);

            return RedirectToAction("Index");
        }



    }
}