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

            string html = "<form method='post' action='/helloworld/greeting'>" +
      "<input type='text' name='name' />" +
      "<select name='language' id='language'><option value=''>Languages</option> <option value='English'>English</option> <option value='Spanish'>Spanish</option> <option value='French'>French</option> <option value='Italian'>Italian</option> <option value='German'>German</option>" +
            
      "<input type='submit' value='Greet Me!' />" +
      "</form>"; 

            return Content(html, "text/html");
        }

        [HttpGet("welcome/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string name = "World")
        {
            if (String.IsNullOrEmpty(name))
            {
                name = "World";
            }

            return Content("<h1>Welcome to my app, " + name + "!</h1>", "text/html");
        }



        [HttpGet("greeting/{name?}/{language?}")]
        [HttpPost("greeting")]
        public IActionResult CreateMessage(string name = "Fella", string language = "English")
        {
            var languageList = new Dictionary<string, string>()
            {
                {"English", "Hello" },
                {"Spanish", "Hola" },
                {"French", "Bonjour" },
                {"Italian", "Ciao" },
                {"German", "Guten Tag" }
            };


            if (String.IsNullOrEmpty(name))
            {
                name = "Fella";
            }

            if (String.IsNullOrEmpty(language))
            {
                language = "English";
            }

           
            string languageChoice = languageList[language];
                

            return Content("<h1>" + languageChoice + "," + " " + name + "!</h1>", "text/html");



            
        }
        
    }
}
