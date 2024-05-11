var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

var localizationOptions = services.AddAndValidateOptions<LocalizationOptions>(config);
var supportedCultures = localizationOptions.SupportedCultures.Keys.ToArray();

services.AddControllers();
services.AddLocalization(options => options.ResourcesPath = "Resources");

services.AddRazorPages();
services.AddServerSideBlazor();

services.AddSingleton(_ => localizationOptions)
    .AddScoped<AppState>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRequestLocalization(new RequestLocalizationOptions()
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures));

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
