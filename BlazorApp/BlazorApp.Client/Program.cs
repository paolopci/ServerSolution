using BlazorApp.Client.Services;
using BlazorApp.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddScoped<IServersService, ServersServiceClient>();


await builder.Build().RunAsync();
