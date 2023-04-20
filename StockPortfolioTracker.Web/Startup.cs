using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace StockPortfolioTracker.Web;

public class Startup
{
    #region Publics
    public static WebApplication InitializeApp(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder);

        WebApplication app = builder.Build();
        Configure(app);

        return app;
    }
    #endregion

    #region Privates
    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        // Authentication
        builder.Services.AddBlazoredSessionStorage();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
    }

    private static void Configure(WebApplication app)
    {
        if(!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        // Authentication & Authorization
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");
    }
    #endregion
}