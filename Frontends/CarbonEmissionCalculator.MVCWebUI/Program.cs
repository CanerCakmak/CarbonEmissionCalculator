using CarbonEmissionCalculator.Application;
using CarbonEmissionCalculator.CustomMapper;
using CarbonEmissionCalculator.Persistence;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using CarbonEmissionCalculator.MVCWebUI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<CompanyService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // Varsayýlan olarak Ýngiliz (en-US) kültürünü kullan
    // Bu, ondalýk ayýrýcýnýn '.' olmasýný saðlar.
    var defaultCulture = new CultureInfo("en-US");

    // Desteklenen kültürleri belirle (sadece en-US veya ihtiyacýnýza göre tr-TR de ekleyebilirsiniz)
    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
    options.SupportedCultures = new List<CultureInfo> { defaultCulture };
    options.SupportedUICultures = new List<CultureInfo> { defaultCulture };

    // Eðer front-end'den spesifik bir Culture header (Accept-Language) gelmezse
    // veya bu kültürü zorlamak isterseniz kullanýlabilir:
    // options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
    // {
    //     // Ýstek yoluyla kültürü belirle veya sabit bir kültür döndür
    //     return new ProviderCultureResult("en-US");
    // }));
});


#region EnvironmentBasedJson
IWebHostEnvironment env = builder.Environment;
builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
#endregion

#region AllLayers
builder.Services.AddApplication();
builder.Services.AddCustomMapper();
builder.Services.AddPersistence(builder.Configuration);
#endregion

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

app.UseRequestLocalization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
