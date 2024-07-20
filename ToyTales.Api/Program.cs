using ToyTales.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapToysEndpoints();

app.Run();