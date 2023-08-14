using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmailSenderDemoCoreMVC.Models;

namespace EmailSenderDemoCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Index(string to, string subject, string body)
        {
            try
            {
                Thread email = new(delegate ()
                {
                    Sendmail.Email(to, subject, body);
                });
                email.IsBackground = true;
                email.Start();
                TempData["alert"] = "Email Sucessfully Sent";
            }
            catch(Exception)
            {
                TempData["alert"] = "Problem Sending mail please check the configuration";

            }
            return Redirect("Home/Index");
        }
    }
}