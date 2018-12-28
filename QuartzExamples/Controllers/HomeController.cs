using Microsoft.AspNetCore.Mvc;
using Quartz;
using QuartzExamples.Jobs;
using QuartzExamples.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace QuartzExamples.Controllers
{
    public class HomeController : Controller
    {
        IScheduler _scheduler;
        public HomeController(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public async Task<IActionResult> StartSimpleJob()
        {
            IJobDetail job = JobBuilder.Create<SimpleJob>()
                                       .WithIdentity("simplejob", "qurtzexamples")
                                       .Build();

            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("testtrigger", " qurtzexamples ")
                                             .StartNow()
                                             .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).WithRepeatCount(5))
                                             .Build();

           await _scheduler.ScheduleJob(job, trigger);
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
