using BlazorApp.Client.Pages;
using BlazorApp.Components;
using BlazorApp.Shared.Services;
using BlazorApp.Client.Services;

var builder = WebApplication.CreateBuilder(args);

var serverBaseUrl = builder.Configuration["Server:BaseUrl"]
                    ?? throw new InvalidOperationException("Server:BaseUrl non è configurato");

builder.Services
       .AddHttpClient<IServersService, ServersServiceClient>(client =>
       {
           client.BaseAddress = new Uri(serverBaseUrl);
       });
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp.Client._Imports).Assembly);

app.Run();
