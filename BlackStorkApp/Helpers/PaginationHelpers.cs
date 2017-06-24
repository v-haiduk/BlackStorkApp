using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using BlackStorkApp.Models;

namespace BlackStorkApp.Helpers
{
    /// <summary>
    /// The class needs for create a pagination.
    /// </summary>
    public static class PaginationHelpers
    {
        /// <summary>
        /// The method creates a collection of links and adds for it classes of visualiation
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pageModel">The model contains description of page</param>
        /// <param name="pageUrl">The link on next page</param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageModel pageModel, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pageModel.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

    }
}