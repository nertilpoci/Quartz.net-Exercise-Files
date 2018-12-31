using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzExamples.Jobs
{
    public class JobListener : IJobListener
    {
        public string Name => "Test job listener";

        public async Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.WriteLine($"Job vetoed : {context.JobDetail.Key.Name}");
        }

        public async Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.WriteLine($"Job is to be executed : {context.JobDetail.Key.Name}");
        }

        public async Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.WriteLine($"Job executed : {context.JobDetail.Key.Name}");
        }
    }
}
