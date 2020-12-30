using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers

{   [Route("/hello/")]
    public class HelloController : Controller
    {
        // Get: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {   
            // HttpContext.Request provides information on the request that comes from user
            Console.WriteLine(HttpContext.Request.Host);
            // Get the "Accept" header
            HttpContext.Request.Headers.TryGetValue("Accept", out var acceptHeaderVal);
            Console.WriteLine(acceptHeaderVal);

           
            return View();

        }

        [HttpGet("welcome/{name?}/{language?}")]
        [HttpPost]
        public IActionResult Welcome(string name = "Fella", string language = "English")
        {
            var languageList = new Dictionary<string, string>()
             {
                 {"English", "Hello" },
                 {"Spanish", "Hola" },
                 {"French", "Bonjour" },
                 {"Italian", "Ciao" },
                 {"German", "Guten Tag" }
             };

            ViewBag.person = name;

            if (String.IsNullOrEmpty(name))
            {
                ViewBag.person = "Fella";
            }

            if (String.IsNullOrEmpty(language))
            {
                ViewBag.language = "English";
            }

            ViewBag.language = languageList[language];
            return View();

            


           

        }



     
        
    }
}
