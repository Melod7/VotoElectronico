var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();
// MVC
builder.Services.AddControllersWithViews();

// HttpClient hacia API
builder.Services.AddHttpClient("API", c =>
{
    c.BaseAddress = new Uri("https://localhost:7126/");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseSession();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();