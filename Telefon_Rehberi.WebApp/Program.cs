using Telefon_Rehberi.WebApp.Services.Abstact;
using Telefon_Rehberi.WebApp.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IPersonService, PersonManager>();
builder.Services.AddSingleton<IContactInformationService, ContactInformationManager>();
builder.Services.AddSingleton<IReportService, ReportManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
