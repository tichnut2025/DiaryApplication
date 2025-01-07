using BL_API;
using BLL;
using DALByEFCore;
using IDal;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Infrastructure
{
    public static class Extensions
    {
        public static  void AddAllDependencies(this IServiceCollection service)
        {
            service.AddScoped<ICustomerBL, CustomerBL>(); 
            service.AddScoped<ICustomerDal, CustomerDal>();
            service.AddScoped<IEmployeeBL, EmployeeBL>();  
            service.AddScoped<IEmployeeDal, EmployeeDal>();
             
        }

        public static  int Gimatria(this string txt)
        {
            return 99;
        }
    }
}
