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
        /// The method replys information about new product, which added the admin 
        /// </summary>
        /// <param name="product">The new product, which will be add in DB</param>
        [HttpPost]
        public ActionResult CreateOfProduct(ProductModel product)
        {
            Mapper.Initialize(configuration => configuration.CreateMap<ProductModel, ProductDTO>());
            var newProduct = Mapper.Map<ProductModel, ProductDTO>(product);
            productService.CreateElement(newProduct);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// The method returns the view with forms for add new topic
        /// </summary>
        [HttpGet]
        public ActionResult CreateOfTopic()
        {
            return View();
        }


        /// <summary>
        /// The method replys information about new topuc, which added the admin 
        /// </summary>
        /// <param name="topic">The new topic, which will be add in DB</param>
        /// <returns></returns>
        public ActionResult CreateOfTopc(TopicModel topic)
        {
            Mapper.Initialize(configuration => configuration.CreateMap<TopicModel, TopicDTO>());
            var newTopic = Mapper.Map<TopicModel, TopicDTO>(topic);
            topicService.CreateElement(newTopic);

            return RedirectToAction("Index");
        }
    }
}