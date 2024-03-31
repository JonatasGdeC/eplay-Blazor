using Eplay.Areas.Identity;
using Eplay.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

//ENDERE�O DA API PRINCIPAL
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://fake-api-tau.vercel.app/api/eplay/")
});

//CRIANDO AUTENTICA��O
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//CRIANDO AUTENTICA��O
app.UseAuthentication(); // Adicionado para habilitar a autentica��o
app.UseAuthorization();

app.MapControllers();

app.MapBlazorHub();

// Configurando p�ginas Razor
app.MapRazorPages();

app.MapFallbackToPage("/_Host");

app.Run();
