using DTO;

namespace BL_API
{
    public interface ICustomerBL
    {
        List<CustomerDTO> GetCustomers(string name = "");
    }
}
