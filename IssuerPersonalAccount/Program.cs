using IssuerPersonalAccount.Components;
using IssuerPersonalAccount.Data;
using IssuerPersonalAccount.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("secret.json");

// Add services to the container.
ConfigureServices(builder.Services);

var app = builder.Build();

ConfigureApp(app);

app.Run();

void ConfigureServices(IServiceCollection serviceCollection)
{
    var configuration = builder.Configuration;

    serviceCollection.AddAuthentication();
    serviceCollection.AddAuthorization();

    serviceCollection
        .AddRazorComponents()
        .AddInteractiveServerComponents();

    serviceCollection
        .AddDbContext<AppDbContext>(optionsBuilder =>
        {
            optionsBuilder
                .UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
        });
    
    serviceCollection
        .AddIdentity<User, IdentityRole<int>>()
        .AddEntityFrameworkStores<AppDbContext>();

    serviceCollection.AddScoped<DataSeeder>();
}

void ConfigureApp(WebApplication webApplication)
{
    // Configure the HTTP request pipeline.
    if (!webApplication.Environment.IsDevelopment())
    {
        webApplication.UseExceptionHandler("/Error", createScopeForErrors: true);
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        webApplication.UseHsts();
    }
    else
        SeedData(webApplication);

    webApplication.UseHttpsRedirection();

    webApplication.UseStaticFiles();

    webApplication.UseAuthentication();
    webApplication.UseAuthorization();

    webApplication.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();
    
    webApplication.UseAntiforgery();
}

void SeedData(WebApplication webApplication)
{
    using var scope = webApplication.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    seeder.SeedUser();
}