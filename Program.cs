using Microsoft.AspNetCore.OutputCaching;

var builder = WebApplication.CreateBuilder(args);

// add services
builder.Services.AddOutputCache(options => {
    // optional: named output-cache profiles
});
builder.Services.AddStackExchangeRedisOutputCache(options => {
    options.Configuration = "172.17.63.233:6379";
});
var app = builder.Build();
// add routes
app.MapGet("/test", [OutputCache(Duration = 15)] () => $"response from {DateTime.UtcNow}");

app.UseOutputCache();
app.Run();
