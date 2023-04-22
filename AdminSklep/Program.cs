using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using AdminSklep;
using Blazored.Modal;
using External.Repository;
using Services;
using Services.ServiceInterfaces;

// var builder = WebApplication.CreateBuilder(args);
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredModal();

builder.Services.AddSingleton<IOutpostRepository, OutpostRepositoryList>();
builder.Services.AddSingleton<IOutpostService, OutpostService>();

builder.Services.AddSingleton<IWorkerRepository, WorkerRepositoryList>();
builder.Services.AddSingleton<IWorkerService, WorkerService>();

await builder.Build().RunAsync();

// builder.Services.AddRazorPages();
// builder.Services.AddServerSideBlazor();
// builder.Services.AddSingleton<WeatherForecastService>();

// var app = builder.Build();

// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }
//
// app.UseHttpsRedirection();
//
// app.UseStaticFiles();
//
// app.UseRouting();
//
// app.MapBlazorHub();
// app.MapFallbackToPage("/_Host");
//
// app.RunAsync();