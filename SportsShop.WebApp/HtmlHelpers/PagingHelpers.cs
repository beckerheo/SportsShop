namespace SportsShop.WebApp.HtmlHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using SportsShop.WebApp.Models;

    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder cellResult = new StringBuilder();

            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tdTag = new TagBuilder("td");
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                tdTag.InnerHtml = tag.ToString();
                cellResult.Append(tdTag.ToString());
            }

            TagBuilder trTag = new TagBuilder("tr")
            {
                InnerHtml = cellResult.ToString()
            };
            TagBuilder tableTag = new TagBuilder("table")
            {
                InnerHtml = trTag.ToString()
            };

            result.Append(tableTag.ToString());

            return MvcHtmlString.Create(result.ToString());
        }
    }
}