using POC.GoldenRaspberryAwards.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAllServices();

var app = builder.Build();
app.ConfigureWebApplication();
app.Run();
