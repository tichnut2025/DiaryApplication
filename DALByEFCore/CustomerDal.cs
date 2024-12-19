using DBEntities;
using DBEntities.Models;
using IDal;

namespace DALByEFCore;

public class CustomerDal :    ICustomerDal
{
    public List<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAllCustomers(string? name = "")
    {
        try
        {
            using DiaryContext context = new DiaryContext()  ;
            if (string.IsNullOrEmpty(name))
              //  return context.Customers.ToList();
               return context.Customers.Select(c => (Customer)c).ToList();

            else
                return context.Customers.Where(a => a.CustName.Contains(name)).Select(c => (Customer)c).ToList();

        }
        catch (Exception)
        {
            // write to log information about the error
            return null;
        }
         
    }

    List<Customer> ICustomerDal.GetAllCustomers(string? name)
    {
        throw new NotImplementedException();
    }
}
