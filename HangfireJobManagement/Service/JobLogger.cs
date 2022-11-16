using Hangfire.JobsLogger;
using Hangfire.Server;

namespace HangfireJobManagement.Service;

public class JobLogger
{
    public void TaskMethod(PerformContext context)
    {
        var jobId = context.BackgroundJob.Id;

        foreach (int i in Enumerable.Range(1, 10)) 
        {
            context.LogTrace($"{i} - Trace Message.. {DateTime.UtcNow.Ticks}");
            context.LogDebug($"{i} - Debug Message.. {DateTime.UtcNow.Ticks}");
            context.LogInformation($"{i} - Information Message.. {DateTime.UtcNow.Ticks}");
            context.LogWarning($"{i} - Warning Message.. {DateTime.UtcNow.Ticks}");
            context.LogError($"{i} - Error Message.. {DateTime.UtcNow.Ticks}");
            context.LogCritical($"{i} - Critical Message.. {DateTime.UtcNow.Ticks}");
        }
    }
}