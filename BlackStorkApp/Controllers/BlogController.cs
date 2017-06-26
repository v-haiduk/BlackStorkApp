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
    public class BlogController : Controller
    {
        private IMainService<TopicDTO> topicService;

        public BlogController(IMainService<TopicDTO> service)
        {
            topicService = service;
        }

        /// <summary>
        /// The method shows all news with short-description in the blog
        /// </summary>
        /// <returns>The views with list of news</returns>
        public ActionResult Index(int page = 1)
        {
            IEnumerable<TopicDTO> topicDTOs = topicService.GetAllElements();
            topicDTOs.ToList().ForEach(topic => topic.Description = topic.Description.Substring(0, 100));

            Mapper.Initialize(configuration => configuration.CreateMap<TopicDTO, TopicModel>());
            var topicsForDisplay = Mapper.Map<IEnumerable<TopicDTO>, List<TopicModel>>(topicDTOs);

            PaginationTopicsModel topicsWithPagination = CreatePaginationForTopics(topicsForDisplay, page);

            return View(topicsWithPagination);
        }

        /// <summary>
        /// The method adds the pagination for collection of topics
        /// </summary>
        /// <param name="products">The list of topics without pagination</param>
        /// <param name="page">The number of current page</param>
        private PaginationTopicsModel CreatePaginationForTopics(IEnumerable<TopicModel> topics, int page)
        {
            int amountOfItemOnPage = 10;
            IEnumerable<TopicModel> topicsOnPage = topics.Skip((page - 1) * amountOfItemOnPage).Take(amountOfItemOnPage);

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
        /// The method shows a full text of news, which selected  a user
        /// </summary>
        /// <param name="id">The id of a selected news</param>
        /// <returns>The view with full text of a news</returns>
        [HttpPost]
        public ActionResult GetDescriptionOfNews(int id)
        {
            TopicDTO topicDTO = topicService.GetElement(id);
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