using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Database bağlantıları için ekledik
builder.Services.AddDbContext<RepositoryContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlConnection"),
    b => b.MigrationsAssembly("StoreApp"));
});


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
