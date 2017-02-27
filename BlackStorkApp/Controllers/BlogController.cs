﻿using System;
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
    public class BlogController : Controller
    {
        private IMainService<TopicDTO> topicService;

        public BlogController(IMainService<TopicDTO> service)
        {
            topicService = service;
        }

        /// <summary>
        /// The method shows all news in the blog
        /// </summary>
        /// <returns>The views with list of news</returns>
        public ActionResult Index()
        {
            IEnumerable<TopicDTO> topicDTOs = topicService.GetAllElements();
            Mapper.Initialize(configuration => configuration.CreateMap<TopicDTO, TopicModel>());
            var topicsForDisplay = Mapper.Map<IEnumerable<TopicDTO>, List<TopicModel>>(topicDTOs);

            return View(topicsForDisplay);
        }


        /// <summary>
        /// The method shows a full text of news, which selected  a user
        /// </summary>
        /// <param name="id">The id of a selected news</param>
        /// <returns>The view with full text of a news</returns>
        [HttpPost]
        public ActionResult FullTextNews(int id)
        {
            TopicDTO topicDTO = topicService.GetElement(2);
            Mapper.Initialize(config => config.CreateMap<TopicDTO, TopicModel>());
            var topicForDisplay = Mapper.Map<TopicDTO, TopicModel>(topicDTO);

            return View("News",topicForDisplay);
        }


        protected override void Dispose(bool disposing)
        {
            topicService.Dispose();
            base.Dispose(disposing);
        }
    }
}