using AutoMapper;
using BL_API;
using DBEntities.Models;
using DTO;
using IDal;

namespace BLL
{

    public  class EmployeeBL : IEmployeeBL
    {
        readonly IEmployeeDal _employeeDal;
 
        MapperConfiguration configEmployeeConverter;
        public EmployeeBL(IEmployeeDal employeeDal )
        {
            _employeeDal= employeeDal;
           

            configEmployeeConverter = new MapperConfiguration(a =>
                     a.CreateMap<Employee, EmployeeDTO>()
                     .ForMember(x => x.FullName, s => s.MapFrom(p => $"{ p.FirstName} {p.LastName  }"))
                      .ReverseMap()
                      );
        }
       
        public void AddNewEmployee(EmployeeDTO newEmployee)
        {
            AutoMapper.Mapper  mapper = new Mapper(configEmployeeConverter);
            Employee  employeeEntityApi = mapper.Map<Employee>(newEmployee);
           
            _employeeDal.AddNewEmployee(employeeEntityApi);
        }


        public List<EmployeeDTO> GetEmployees()
        {
            Mapper mapper = new Mapper(configEmployeeConverter);

            var list = _employeeDal.GetEmployees();
            List<EmployeeDTO > convertedList = new List<EmployeeDTO >();

           // list.ForEach(item => convertedList.Add( convert(item )));
            list.ForEach(item => convertedList.Add(mapper.Map<EmployeeDTO>(item)));

            return convertedList;
        }


       
    }
}
