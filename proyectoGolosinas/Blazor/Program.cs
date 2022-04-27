using Blazor.Data;
using Blazor.Interfaces;
using Blazor.Servicios;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


MySQLConfiguration cadenaConexion = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySQL")); 
builder.Services.AddSingleton(cadenaConexion);

//CONECTAR A BASE 
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();

builder.Services.AddSweetAlert2(); //<=============================== ALERT2 ****************

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddHttpContextAccessor();

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

app.UseAuthorization();  //AGREAGADO
app.UseAuthentication(); //AGREAGADO

app.MapBlazorHub();
app.MapControllers(); //AGREAGADO

app.MapFallbackToPage("/_Host");

app.Run();
