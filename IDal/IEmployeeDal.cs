using EntitiesAPI;

namespace IDal
{
    public interface IEmployeeDal
    {
        void AddNewEmployee(EmployeeEntityApi employee);
        List< EmployeeEntityApi > GetEmployees();
    }
}