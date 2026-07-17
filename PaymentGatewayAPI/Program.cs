using PaymentGatewayAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var appName = "Payment Gateway API";

builder.AddSerilog();

// Add services to the container.
builder.AddPsp();

builder.Services.AddControllers();
builder.Services.AddSwagger(appName);

var app = builder.Build();

app.UseSwaggerDoc(appName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
