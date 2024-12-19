
using DBEntities.Models;

namespace IDal
{
    public interface IEmployeeDal
    {
        void AddNewEmployee(Employee employee);
        List< Employee > GetEmployees();
    }
}