using BL_API;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class CommonBLExtensions
    {
        public static void AddDependencies (this IServiceCollection ser)
        {
            ser.AddScoped<ICustomerBL , CustomerBL> (); 
        }
    }
}
