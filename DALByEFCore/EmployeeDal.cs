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
        public void AddNewEmployee(Employee employee)
        {
            using  Models.EmployeesContext ctx = new()  ;
            Employee emp = (Employee)employee;
             ctx.Employees.Add(employee as Employee );    
            ctx.SaveChanges();  
        }

        public void AddNewEmployee(EmployeeEntityApi employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee > GetEmployees()
        {
            using Models.EmployeesContext ctx = new();

            return ctx.Employees .Select(item => (Employee )item).ToList();
            
        }

        List<EmployeeEntityApi> IEmployeeDal.GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
