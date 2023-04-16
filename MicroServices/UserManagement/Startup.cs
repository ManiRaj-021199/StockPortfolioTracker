﻿namespace UserManagement;

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
        builder.Services.AddSwaggerGen();
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

        app.UseAuthorization();

        app.MapControllers();
    }
    #endregion
}