using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzExamples.Jobs
{
    public class SimpleJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var message = $"Simple executed at ${DateTime.Now.ToString()}";
            Debug.WriteLine(message);
        }
    }
}
