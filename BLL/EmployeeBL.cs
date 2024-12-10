using AutoMapper;
using BL_API;
using DTO;
using EntitiesAPI;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    internal class EmployeeBL : IEmployeeBL
    {
        readonly IEmployeeDal _employeeDal;

        MapperConfiguration configEmployeeConverter;
        public EmployeeBL(IEmployeeDal employeeDal)
        {
            _employeeDal= employeeDal;


            configEmployeeConverter = new MapperConfiguration(a =>
                     a.CreateMap<IEmployee, EmployeeDTO>()
                     .ForMember(x => x.FullName, s => s.MapFrom(p => $"{ p.FirstName} {p.LastName  }"))
                      .ReverseMap()
                      );
        }
       
        public void AddNewEmployee(EmployeeDTO newEmployee)
        {
            AutoMapper.Mapper  mapper = new Mapper(configEmployeeConverter);
            IEmployee emp = mapper.Map<IEmployee>(newEmployee);
           
            _employeeDal.AddNewEmployee(  emp);
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
