using DBEntities;
using DBEntities.Models;
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
            using  DiaryContext ctx = new()  ;
            Employee emp = (Employee)employee;
             ctx.Employees.Add(employee as Employee );    
            ctx.SaveChanges();  
        }

      

        public List<Employee > GetEmployees()
        {
            using  DiaryContext ctx = new();

            return ctx.Employees .Select(item => (Employee)item).ToList();
            
        }
 
    }
     
}
