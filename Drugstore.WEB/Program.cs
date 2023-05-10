using CurrieTechnologies.Razor.SweetAlert2;
using Drugstore.WEB.Repositories;
using Drugstore.WEB;
using Drusgstore.WEB.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Drugstore.WEB.Auth;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();
//Autorización
builder.Services.AddAuthorizationCore();
// Clase autorazión 
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderTest>();


// Depronto se tiene que cambios el local cambiar puerto del api-- Esto se debe cambiar depende donde valla a correr el proyecto en el puerto 
builder.Services.AddSingleton(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7096/")
});



await builder.Build().RunAsync();