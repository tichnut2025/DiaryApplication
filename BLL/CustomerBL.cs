﻿using BL_API;

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
    public  class CustomerBL :  ICustomerBL
    {
        private readonly ICustomerDal  _customerDal;
        AutoMapper.MapperConfiguration configCustomerConverter;
        public CustomerBL(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
              configCustomerConverter = new AutoMapper.MapperConfiguration(a =>
                       a.CreateMap<ICustomer, CustomerDTO>()
                       .ForMember(x => x.CustomerId,s=>s.MapFrom(p=>p.CustId))
                      // .ForMember(x => x.CustCity, s => s.MapFrom(p =>int.Parse( p.CustCity) ))
                       .ReverseMap()
                       .ForMember(x => x.CustId, s => s.MapFrom(p => p.CustomerId ))
                      // .ForMember(x => x.CustCity, s => s.MapFrom(p =>  p.CustCity.ToString() ))
                       );
        }
       
        public List<CustomerDTO> GetCustomers(string name="")
        {
            //CustomerDal dal = new();
            //return dal.GetAllCustomers();

            var customers = _customerDal .GetAllCustomers(name);
            //כאן אמורה להיות לוגיקה
            //למשל של איתור הלקוחות שמחלקת השיווק שלי מתאימה לעיסוק שלהם
            //לפי הדף שלהם בפיסבוק

            //המרה של האוביקטים מ- customer ל- customerDTO
            List<CustomerDTO> convertedList = new List<CustomerDTO>();
            
            customers.ForEach(c => convertedList.Add(convertCustomer(c)));

            return convertedList    ;
        }

        private CustomerDTO  convertCustomer(ICustomer source)
        {
            //הגדרות ההמרה : מאיזו מחלקה לאיזו מחלקה. וגם הפוך
            
            AutoMapper.Mapper mapper = new  (configCustomerConverter);

            CustomerDTO customer=mapper.Map<CustomerDTO>(source);

            return customer;

        }

        private ICustomer  convertCustomer(CustomerDTO source)
        {
            //הגדרות ההמרה : מאיזו מחלקה לאיזו מחלקה. וגם הפוך

            AutoMapper.Mapper mapper = new(configCustomerConverter);

            ICustomer  customer = mapper.Map<ICustomer >(source);

            return customer;

        }

    }
}
