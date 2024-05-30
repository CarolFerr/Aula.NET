using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
// Para fazer conexão com o banco de dados em desenvolvimento
if(builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ImobiliariaContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ImobiliariaContext")));
}else{
    builder.Services.AddDbContext<ImobiliariaContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ImobiliariaContext")));
}

builder.Services.AddDbContext<ImobiliariaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ImobiliariaContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Padrão de roteamento, pode ser alterado
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
