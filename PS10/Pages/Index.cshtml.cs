using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using filters.Utils;
using Microsoft.Extensions.Configuration;

namespace filters.Pages
{
    
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IConfiguration _config;
        [BindProperty(SupportsGet = true)]
        public int testVriable { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        public override void OnPageHandlerSelected(PageHandlerSelectedContext pageContext)
        {
            int a = 0;
        }
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext
       pageContext)
        {
            int a = 0;
        }
        public override void OnPageHandlerExecuted(PageHandlerExecutedContext pageContext)
        {
            int a = 0;
        }
        public void OnGet()
        {
            int a = 0;
        }
    }
}