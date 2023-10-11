using Microsoft.AspNetCore.OutputCaching;

var builder = WebApplication.CreateBuilder(args);

// add services
builder.Services.AddOutputCache(options => {
    // optional: named output-cache profiles
});
builder.Services.AddStackExchangeRedisOutputCache(options => {
    // your configuration here
    options.Configuration = "127.0.0.1:6379";
});
var app = builder.Build();
// add routes
app.MapGet("/test", [OutputCache(Duration = 15)] () => $"response from {DateTime.UtcNow}");

app.UseOutputCache();
app.Run();
