using DSWI_T1_Grupo_08.Data;
using DSWI_T1_Grupo_08.Repositories;
using DSWI_T1_Grupo_08.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<LibreriaBDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibreriaBD")));

// Repositorios
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

// Servicios
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<ILibroService, LibroService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();