using AVWintory.Components;
using MudBlazor.Services;
using AVWintory.ModulesDb;
using AVWintory.Components.Services.Login;
using AVWintory.Components.Services.Sale;
using AVWintory.Components.Services.SaleDetail;
using AVWintory.Components.Services.Product;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. REGISTRA LA FÁBRICA (Esto es lo que te falta)
builder.Services.AddDbContextFactory<AVContext>(options =>
    options.UseSqlite(connectionString));

// Add services to the container.
builder.Services.AddMudServices();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleDetailService, SaleDetailService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();