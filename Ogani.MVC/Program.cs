using Microsoft.EntityFrameworkCore;
using Ogani.DAL;
using Ogani.DAL.DataContext;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDalServices(builder.Configuration);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await appDbContext.Database.MigrateAsync();
    //var dataInit = new DataInitalizer(appDbContext);
    //await dataInit.SeedDataAsync();
}

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

await app.RunAsync();
