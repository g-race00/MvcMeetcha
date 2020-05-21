using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace MvcMeetcha.Pages
{
    public class CustomPaginatedList<T>: List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public CustomPaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int) Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public CustomPageData GetPageData(PageModel pageModel) => new CustomPageData
        {
            PageIndex = PageIndex,
            TotalPages = TotalPages,
            UrlParams = pageModel.Request.Query.ToDictionary(x => x.Key, x => x.Value.ToString())
        };

        public static async Task<CustomPaginatedList<T>> CreateAsync(
            IQueryable<T> source, 
            int pageIndex, 
            int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new CustomPaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
