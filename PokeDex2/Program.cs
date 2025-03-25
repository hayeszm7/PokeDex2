using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using PokeDex2;
using PokeDex2.API;
using PokeDex2.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ApiClient>();
//builder.Services.AddDbContext<PokemonDbContext>(options =>
//    options.UseSqlite("data source=pokemon.db"));
//builder.Services.AddScoped<PokemonDataService>();

await builder.Build().RunAsync();




