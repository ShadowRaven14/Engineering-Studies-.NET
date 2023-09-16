using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filters.Utils
{
    public class CustomFilterAttributes : ResultFilterAttribute
    {
        private string _company { get; set; }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var _config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            _company = _config.GetSection("Company").GetSection("name").Value;
            var result = context.Result;
            if (result is PageResult)
            {
                var page = ((PageResult)result);
                page.ViewData["filterMessage"] = _company;
            }
        }
    }
}
