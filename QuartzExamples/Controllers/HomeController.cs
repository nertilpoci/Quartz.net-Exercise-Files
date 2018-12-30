using Microsoft.AspNetCore.Mvc;
using Quartz;
using QuartzExamples.Jobs;
using QuartzExamples.Models;
using System;
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
                                       .UsingJobData("username", "devhow")
                                       .UsingJobData("password", "Security!!")
                                       .WithIdentity("simplejob", "quartzexamples")
                                       .StoreDurably()
                                       .Build();
            job.JobDataMap.Put("user", new JobUserParameter { Username = "devhow", Password = "Security!!" });

            //save the job
            await _scheduler.AddJob(job, true);

            ITrigger trigger = TriggerBuilder.Create()
                                             .ForJob(job)
                                             .UsingJobData("triggerparam", "Simple trigger 1 Parameter")
                                             .WithIdentity("testtrigger", "quartzexamples")
                                             .StartNow()
                                             .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(5)).RepeatForever())
                                             .Build();

            await _scheduler.ScheduleJob(trigger);
          
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
