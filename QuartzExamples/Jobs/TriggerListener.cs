using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzExamples.Jobs
{
    public class TriggerListener : ITriggerListener
    {
        public string Name => "Test Trigger Listener";

        public async Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.WriteLine($"Trigger completed : {trigger.Key.Name}");
        }

        public async Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.WriteLine($"Trigger fired : {trigger.Key.Name}");
        }

        public async Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.WriteLine($"Trigger misfired : {trigger.Key.Name}");
        }

        public async Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return false;
        }
    }
}
