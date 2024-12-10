using BL_API;
using DALByEFCore.Models;
using EntitiesAPI;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALByEFCore;
//public interface ICustomerDal:IGenDal<ICustomer>
//{
//    public List<Customer> GetAllCustomers(string? name = "");

//}
public class CustomerDal :    ICustomerDal
{
    public List<ICustomer> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<ICustomer> GetAllCustomers(string? name = "")
    {
        try
        {
            using  EmployeesContext context = new EmployeesContext()  ;
            if (string.IsNullOrEmpty(name))
              //  return context.Customers.ToList();
               return context.Customers.Select(c => (ICustomer)c).ToList();

            else
                return context.Customers.Where(a => a.CustName.Contains(name)).Select(c => (ICustomer)c).ToList();

        }
        catch (Exception)
        {
            // write to log information about the error
            return null;
        }
         
    }

    List<ICustomer> ICustomerDal.GetAllCustomers(string? name)
    {
        throw new NotImplementedException();
    }
}
