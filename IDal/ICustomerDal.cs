using DALByEFCore.Models;
using EntitiesAPI;

namespace IDal
{
    

    public interface  ICustomerDal
    {
        public List<ICustomer> GetAllCustomers(string? name = "");

    }
}
