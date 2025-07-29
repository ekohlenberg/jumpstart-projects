using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using Microsoft.Extensions.Hosting;
/*
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;*/
using Microsoft.Extensions.DependencyInjection;

using defarge;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5209" )});


   // Named client for the "Local API"
        // Named client for the "Remote API"
        builder.Services.AddHttpClient("RemoteAPI", client2 =>
        {
            client2.BaseAddress = new Uri("http://localhost:5209");
        });
        

await builder.Build().RunAsync();

/*
// 1. Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendApp", policy =>
    {
        policy.WithOrigins("http://localhost:5063")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 2. Use the configured CORS policy
app.UseCors("AllowFrontendApp");

app.MapControllers();

app.Run();
*/
