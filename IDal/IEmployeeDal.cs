using EntitiesAPI;

namespace IDal
{
    public interface IEmployeeDal
    {
        void AddNewEmployee(IEmployee employee);
        List< IEmployee > GetEmployees();
    }
}