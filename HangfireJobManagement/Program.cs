using Hangfire;
using Hangfire.JobsLogger;
using Hangfire.RecurringJobAdmin;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHangfire(x =>
    x.UseSqlServerStorage(
            "Server=localhost;Database=Hangfire;User=sa;Password=Passw0rd.1; Trusted_Connection=False;")
        .UseJobsLogger()
        .UseRecurringJobAdmin()
);
builder.Services.AddHangfireServer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseHangfireDashboard();
app.Run();