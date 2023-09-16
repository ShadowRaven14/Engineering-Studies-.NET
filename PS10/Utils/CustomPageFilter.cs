using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace filters.Utils
{
    public class CustomPageFilter : IPageFilter
    {
        string companyName;

        public CustomPageFilter(IConfiguration _config)
        {
            companyName = _config.GetValue<string>("CompanyName");
        }
        public void OnPageHandlerSelected(PageHandlerSelectedContext pageContext)
        {
            int a = 0;

        }
        public void OnPageHandlerExecuting(PageHandlerExecutingContext pageContext)
        {
            int a = 0;
        }
        public void OnPageHandlerExecuted(PageHandlerExecutedContext pageContext)
        {
            var result = pageContext.Result;
            if(result is PageResult)
            {
                var page = ((PageResult)result);
                page.ViewData["companyName"] = companyName;
            }
        }
    }
}
