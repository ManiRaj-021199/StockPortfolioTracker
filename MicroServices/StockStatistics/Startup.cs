using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Logic;
using StockStatistics.BasicAuthentication;

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

        /* OAuth
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
        */

        builder.Services.AddSwaggerGen(c =>
                                       {
                                           c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasicAuth", Version = "v1" });
                                           c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                                                                            {
                                                                                Name = "Authorization",
                                                                                Type = SecuritySchemeType.Http,
                                                                                Scheme = "basic",
                                                                                In = ParameterLocation.Header,
                                                                                Description = "Basic Authorization header using the Bearer scheme."
                                                                            });
                                           c.AddSecurityRequirement(new OpenApiSecurityRequirement
                                                                    {
                                                                        {
                                                                            new OpenApiSecurityScheme
                                                                            {
                                                                                Reference = new OpenApiReference
                                                                                            {
                                                                                                Type = ReferenceType.SecurityScheme,
                                                                                                Id = "basic"
                                                                                            }
                                                                            },
                                                                            new string[] { }
                                                                        }
                                                                    });
                                       });

        builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

        // Services
        builder.Services.AddSingleton<IEquityFacade, EquityFacade>();
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