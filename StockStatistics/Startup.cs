using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StockPortfolioTracker.Logic;
using Swashbuckle.AspNetCore.Filters;

namespace StockStatistics;

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

        // Services
        builder.Services.AddSingleton<IEquityServices, EquityServices>();
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