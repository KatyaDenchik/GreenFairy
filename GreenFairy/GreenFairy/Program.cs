using GreenFairy.Data;
using GreenFairy.Data.Authentication;
using GreenFairy.Data.Controllers;
using GreenFairy.DomainLayer.DataBase;
using GreenFairy.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
//UploadController
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddServerSideBlazor().AddHubOptions(o =>
{
	o.MaximumReceiveMessageSize = 10 * 1024 * 1024;
});
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<Repository>();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddSingleton<UserAccountService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<DataBaseView>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddSingleton<EntityService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();
