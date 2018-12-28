using Microsoft.AspNetCore.Mvc;
using Quartz;
using QuartzExamples.Jobs;
using QuartzExamples.Models;
using System.Diagnostics;

namespace QuartzExamples.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult StartSimpleJob()
        {
            IJobDetail job = JobBuilder.Create<SimpleJob>()
                .WithIdentity("simplejob", "qurtzexamples")
                .Build();

            return RedirectToAction("Index");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
