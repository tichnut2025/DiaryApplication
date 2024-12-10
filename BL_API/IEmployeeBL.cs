using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_API
{
    /// <summary>
    /// פעולות לוגיות שקשורות ל- employy
    /// </summary>
    public interface IEmployeeBL
    {
        void AddNewEmployee(EmployeeDTO newEmployee);
        List<EmployeeDTO> GetEmployees(  );
         
    }
}
