using System.Collections.Generic;

namespace MvcMeetcha.Pages
{
    public class CustomPageData
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public IDictionary<string, string> UrlParams { get; set; } = null!;
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
    }
}
