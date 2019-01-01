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
                                       .RequestRecovery()
                                       .Build();
            job.JobDataMap.Put("user", new JobUserParameter { Username = "devhow", Password = "Security!!" });

            //save the job
            await _scheduler.AddJob(job, true);

            ITrigger trigger = TriggerBuilder.Create()
                                             .ForJob(job)
                                             .UsingJobData("triggerparam", "Simple trigger 1 Parameter")
                                             .WithIdentity("testtrigger", "quartzexamples")
                                             .StartNow()
                                             .WithSimpleSchedule(z=> z.WithIntervalInSeconds(5).RepeatForever().WithMisfireHandlingInstructionIgnoreMisfires())
                                             .Build();
            ITrigger trigger2 = TriggerBuilder.Create()
                                            .ForJob(job)
                                            .UsingJobData("triggerparam", "Simple trigger 2 Parameter")
                                            .WithIdentity("testtrigger2", "quartzexamples")
                                            .StartNow()
                                            .WithSimpleSchedule(z => z.WithIntervalInSeconds(5).RepeatForever().WithMisfireHandlingInstructionIgnoreMisfires())
                                            .Build();
            ITrigger trigger3 = TriggerBuilder.Create()
                                            .ForJob(job)
                                            .UsingJobData("triggerparam", "Simple trigger 3 Parameter")
                                            .WithIdentity("testtrigger3", "quartzexamples")
                                            .StartNow()
                                            .WithSimpleSchedule(z => z.WithIntervalInSeconds(5).RepeatForever().WithMisfireHandlingInstructionIgnoreMisfires())
                                            .Build();

            await _scheduler.ScheduleJob(trigger);
            await _scheduler.ScheduleJob(trigger2);
            await _scheduler.ScheduleJob(trigger3);

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
