using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.PortfolioContext;
using StockPortfolioTracker.Logic;
using Swashbuckle.AspNetCore.Filters;

namespace UserManagement;

public static class Startup
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
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services
               .AddSwaggerGen(options =>
                              {
                                  options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                                                                          {
                                                                              Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                                                                              In = ParameterLocation.Header,
                                                                              Name = "Authorization",
                                                                              Type = SecuritySchemeType.ApiKey
                                                                          });

                                  options.OperationFilter<SecurityRequirementsOperationFilter>();
                              });

        // Authentication
        builder.Services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
                             {
                                 options.TokenValidationParameters = new TokenValidationParameters
                                                                     {
                                                                         ValidateIssuerSigningKey = true,
                                                                         IssuerSigningKey = JwtTokenHelper.GetSecretKey(),
                                                                         ValidateIssuer = false,
                                                                         ValidateAudience = false
                                                                     };
                             });

        // Db Context
        builder.Services.AddDbContext<PortfolioTrackerDbContext>();

        // Services
        builder.Services.AddScoped<IUserManagementFacade, UserManagementFacade>();
        builder.Services.AddScoped<IClientManagementFacade, ClientManagementFacade>();
    }

    private static void Configure(WebApplication app)
    {
        if(app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }
    #endregion
}