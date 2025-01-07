using Azure;
using BL_API;
using BLL;
using DALByEFCore;
using DALByEFCore.Models;
using IDal;
using Infrastructure;
using Microsoft.Identity.Client;
using System.Globalization;
using System.Reflection;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();
        if (Environment.OSVersion.VersionString  !="win11")
            builder.Logging.AddEventLog();
        //builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command",
         //   Microsoft.Extensions.Logging.LogLevel.Information);

        

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAllDependencies();
        builder.Services.AddLogging();

        //AddDynamicDependencies(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

         app.Use(ShabatMiddlware);

        app.Use(async (context, next) =>
        {
            // אם היום יום שלישי, נחסום את הבקשה
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("access in friday is denied    .");
            }
            else
            {
                // אם לא יום שלישי, נמשיך את הבקשה הלאה
                await next();
            }
        });

         
        app.UseMiddleware<CultureMiddleware>(); 

        app.MapControllers();


        app.Run();
    }

    private static void AddDynamicDependencies(IServiceCollection services)
    {
        //reflection::
        Assembly assemb1 = Assembly.LoadFile("BLL.dll");
        Assembly assemb2 = Assembly.LoadFile("IBL.dll");
        Type typeOfUserBL= assemb1.GetType("UserBL");
        Type typeOfIUserBL = assemb2.GetType("IUserBL");

        services.AddScoped(typeOfUserBL, typeOfIUserBL);
         
    }

    private static RequestDelegate ShabatMiddlware(RequestDelegate @delegate)
    {
        return async (context) =>
        {
            // אם היום יום שלישי, נחסום את הבקשה
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("הגישה אסורה ביום שלישי.");
            }
            else
            {
                // אם לא יום שלישי, נמשיך להעביר את הבקשה הלאה
                await @delegate(context);
            }
        };
    }
}
