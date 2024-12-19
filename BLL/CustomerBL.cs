using BL_API;
using DBEntities.Models;
using DTO;
using IDal;

namespace BLL;

public  class CustomerBL :  ICustomerBL
{
    private readonly ICustomerDal  _customerDal;
    AutoMapper.MapperConfiguration configCustomerConverter;
    public CustomerBL(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
          configCustomerConverter = new AutoMapper.MapperConfiguration(a =>
                   a.CreateMap<Customer, CustomerDTO>()
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

    private CustomerDTO  convertCustomer(Customer source)
    {
        //הגדרות ההמרה : מאיזו מחלקה לאיזו מחלקה. וגם הפוך
        
        AutoMapper.Mapper mapper = new  (configCustomerConverter);

        CustomerDTO customer=mapper.Map<CustomerDTO>(source);

        return customer;

    }

    private Customer  convertCustomer(CustomerDTO source)
    {
        //הגדרות ההמרה : מאיזו מחלקה לאיזו מחלקה. וגם הפוך

        AutoMapper.Mapper mapper = new(configCustomerConverter);

        Customer  customer = mapper.Map<Customer >(source);

        return customer;

    }

}
