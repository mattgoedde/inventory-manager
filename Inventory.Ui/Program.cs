using Inventory.DataAccess;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

var clientId = builder.Configuration["UiSettings:MicrosoftClientId"]!;
var clientSecret = builder.Configuration["UiSettings:MicrosoftClientSecret"]!;
var connectionString = builder.Configuration["UiSettings:ConnectionString"]!;

// Add services to the container.
builder.Services
    .AddRazorPages().Services
    .AddServerSideBlazor().Services
    .AddMudServices()
    .AddSqlServerDataAccess(connectionString)
    .AddAuthentication()
    .AddMicrosoftAccount(options =>
    {
        options.ClientId = clientId;
        options.ClientSecret = clientSecret;
    }).Services
    .AddAuthorization();

var app = builder.Build();

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

app.Run();
