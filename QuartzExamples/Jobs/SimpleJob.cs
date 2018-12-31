using Quartz;
using QuartzExamples.Models;
using QuartzExamples.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzExamples.Jobs
{
    public class SimpleJob : IJob
    {
        IEmailService _emailService;
        public SimpleJob(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            _emailService.Send("info@devhow.net", "Quartz.net DI", "Dependency injection in quartz");
        }
    }
}
