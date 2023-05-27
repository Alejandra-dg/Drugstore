using CurrieTechnologies.Razor.SweetAlert2;
using Drugstore.WEB.Repositories;
using Drugstore.WEB;
using Drusgstore.WEB.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Drugstore.WEB.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.Modal;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredModal();
//Autorización
builder.Services.AddAuthorizationCore();
// Clase autorazión 
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderTest>();

//Injecciones de dependencia de autenticación real
builder.Services.AddScoped<AuthenticationProviderJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
builder.Services.AddScoped<ILoginService, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());



// Depronto se tiene que cambios el local cambiar puerto del api-- Esto se debe cambiar depende donde valla a correr el proyecto en el puerto 
builder.Services.AddSingleton(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7096/")
});



await builder.Build().RunAsync();