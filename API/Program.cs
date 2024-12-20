using BL_API;
using BLL;
using DALByEFCore;
using DALByEFCore.Models;
using IDal;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<ICustomerBL, CustomerBL>();
        builder.Services.AddScoped<ICustomerDal, CustomerDal>();
        builder.Services.AddScoped<IEmployeeBL, EmployeeBL>();
        builder.Services.AddScoped<IEmployeeDal, EmployeeDal>();
        builder.Services.AddScoped<Employee, Employee>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
