using Blazored.Toast;
using LibraryApp.Web;
using LibraryApp.Web.Pages.Books;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLogging();
builder.Services.AddHttpClient();
builder.Services.AddBlazoredToast();
builder.Services.AddCustomServices();


await builder.Build().RunAsync();
