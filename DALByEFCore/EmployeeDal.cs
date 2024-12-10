using DALByEFCore.Models;
using EntitiesAPI;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALByEFCore
{
    public  class EmployeeDal : IEmployeeDal
    {
        public void AddNewEmployee(IEmployee employee)
        {
            using  Models.EmployeesContext ctx = new()  ;
            ctx.Employees.Add((Employee )employee);    
            ctx.SaveChanges();  
        }

        public List<IEmployee> GetEmployees()
        {
            using Models.EmployeesContext ctx = new();

            return ctx.Employees .Select(item => (IEmployee)item).ToList();
            
        }
    }
}
