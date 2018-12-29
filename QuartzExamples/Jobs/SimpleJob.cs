using Quartz;
using QuartzExamples.Models;
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
            JobDataMap dataMap = context.MergedJobDataMap;
            string username = dataMap.GetString("username");
            string password = dataMap.GetString("password");
            string triggerparam = dataMap.GetString("triggerparam");
            JobUserParameter user = (JobUserParameter)dataMap.Get("user");
            var message = $"Simple executed with username {user.Username} and password {user.Password} with trigger param '{triggerparam}'";
            Debug.WriteLine(message);
        }
    }
}
