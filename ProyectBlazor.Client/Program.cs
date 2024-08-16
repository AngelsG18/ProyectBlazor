using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProyectBlazor.Client;
using ProyectBlazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//Siempre registrar el servicio para poder inyectar al componente (Form) los metodos
builder.Services.AddScoped<SrvOpciones>();
builder.Services.AddScoped<SrvApp>();
builder.Services.AddScoped<SrvSegUser>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5123/") });

await builder.Build().RunAsync();
