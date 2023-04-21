using Inventory.DataAccess;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MudBlazor.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorPages().AddMicrosoftIdentityUI().Services
    .AddServerSideBlazor().Services
    .AddMudServices()
    .AddSqlServerDataAccess(builder.Configuration["UiSettings:ConnectionString"]!)
    .AddAuthentication().Services
    //.AddMicrosoftAccount(options =>
    //{
    //    options.ClientId = builder.Configuration["UiSettings:MicrosoftClientId"]!;
    //    options.ClientSecret = builder.Configuration["UiSettings:MicrosoftClientSecret"]!;
    //}).Services
    .AddAuthorization()
    .AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd").Services
    .AddLogging(options =>
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("out.log")
            .CreateLogger();
        options.AddSerilog(Log.Logger);
    });

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.MapControllers();

app.Run();
