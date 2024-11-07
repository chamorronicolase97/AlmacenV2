using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configura el HttpClient para que apunte a la URL de tu API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7173/") });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<SessionService>();

await builder.Build().RunAsync();
