using Microsoft.AspNetCore.Mvc;
using Hangfire;
using HangfireJobManagement.Service;

namespace HangfireJobManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController : ControllerBase
{
    [HttpPost]
    [Route("[action]")]
    public IActionResult SignUp()
    {
        var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("SingUp is Success"));
        JobLogger jobLogger = new JobLogger();
        BackgroundJob.Enqueue(()=>jobLogger.TaskMethod(null));
        return Ok(jobId);
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult SignUpWithDelay()
    {
        var jobId = BackgroundJob.Schedule(() => Console.WriteLine("Welcome my app"), TimeSpan.FromSeconds(3));
        
        return Ok(jobId);
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult ScheduleDiscountMail()
    {
        RecurringJob.AddOrUpdate(() => Console.WriteLine("Discount Mail"),Cron.Weekly(DayOfWeek.Monday,09,30));
        return Ok();
    }
}