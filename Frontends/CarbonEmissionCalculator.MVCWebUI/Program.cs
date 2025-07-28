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
    // Varsay�lan olarak �ngiliz (en-US) k�lt�r�n� kullan
    // Bu, ondal�k ay�r�c�n�n '.' olmas�n� sa�lar.
    var defaultCulture = new CultureInfo("en-US");

    // Desteklenen k�lt�rleri belirle (sadece en-US veya ihtiyac�n�za g�re tr-TR de ekleyebilirsiniz)
    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
    options.SupportedCultures = new List<CultureInfo> { defaultCulture };
    options.SupportedUICultures = new List<CultureInfo> { defaultCulture };

    // E�er front-end'den spesifik bir Culture header (Accept-Language) gelmezse
    // veya bu k�lt�r� zorlamak isterseniz kullan�labilir:
    // options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
    // {
    //     // �stek yoluyla k�lt�r� belirle veya sabit bir k�lt�r d�nd�r
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
