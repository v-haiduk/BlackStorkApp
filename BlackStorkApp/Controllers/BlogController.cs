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
        // GET: Blog

        public BlogController(IMainService<TopicDTO> service)
        {
            topicService = service;
        }

        public ActionResult Index()
        {
            IEnumerable<TopicDTO> topicDTOs = topicService.GetAllElements();
            Mapper.Initialize(configuration => configuration.CreateMap<TopicDTO, TopicModel>());
            var topicsForDisplay = Mapper.Map<IEnumerable<TopicDTO>, List<TopicModel>> (topicDTOs);

            return View("Blog", topicsForDisplay);
        }
    }
}