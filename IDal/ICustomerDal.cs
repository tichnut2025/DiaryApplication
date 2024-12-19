
using DBEntities.Models;

namespace IDal
{

    public interface  ICustomerDal
    {
        public List<Customer> GetAllCustomers(string? name = "");

    }
}
