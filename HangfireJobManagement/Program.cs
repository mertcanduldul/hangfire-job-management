using Hangfire;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHangfire(x => 
    x.UseSqlServerStorage("Server=localhost;Database=Hangfire;User=sa;Password=sifre; Trusted_Connection=False;"));
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