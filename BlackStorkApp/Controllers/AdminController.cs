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
        /// The method returns the view with forms for add new topic
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
        /// <returns></returns>
        public ActionResult CreateOfTopc(TopicModel topic)
        {
            Mapper.Initialize(configuration => configuration.CreateMap<TopicModel, TopicDTO>());
            var newTopic = Mapper.Map<TopicModel, TopicDTO>(topic);
            topicService.CreateElement(newTopic);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// The method returns the view with forms for edit topic
        /// </summary>
        /// <param name="id">The if of topic,which will be edit</param>
        [HttpPost]
        public ActionResult EditOfTopic(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var topicDTOForEdit = topicService.GetElement(id);
            if (topicDTOForEdit != null)
            {
                return HttpNotFound();
            }

            Mapper.Initialize(configuration => configuration.CreateMap<TopicDTO, TopicModel>());
            var topicModelForEdit = Mapper.Map<TopicDTO, TopicModel>(topicDTOForEdit);
            if (topicModelForEdit != null)
            {
                return View(topicModelForEdit);
            }
           
            return HttpNotFound();
        }


        /// <summary>
        /// The method sends an information about new topic, which added the admin 
        /// </summary>
        /// <param name="topic">The new topic, which will be add in a DB</param>
        [HttpPost]
        public ActionResult EditOfTopic(TopicModel topicModel)
        {
            if (topicModel == null)
            {
                HttpNotFound();
            }
            Mapper.Initialize(configuration => configuration.CreateMap<TopicModel, TopicDTO>());
            var topicDTOForEdit = Mapper.Map<TopicModel, TopicDTO>(topicModel);
            topicService.UpdateElement(topicDTOForEdit);

            return RedirectToAction("Index");
        }
    }
}