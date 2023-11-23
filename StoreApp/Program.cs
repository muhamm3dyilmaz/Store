using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Database bağlantıları için ekledik
builder.Services.AddDbContext<RepositoryContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlConnection"),
    b => b.MigrationsAssembly("StoreApp"));
});
//IRepositoryManager implemente edildi
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
//IProductRepository implemente edildi
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//ICategoryRepository implemente edildi
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();



var app = builder.Build();

//wwwroot klasörünü kullanıma açar
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
