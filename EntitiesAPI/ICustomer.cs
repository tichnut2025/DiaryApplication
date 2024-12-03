namespace EntitiesAPI
{
    public interface  ICustomer
    {
          int CustId { get; set; }
         
          string? CustName { get; set; }
         
          string? CustAddress { get; set; }
         
          string? CustCity { get; set; }
         
          string? CustPhone { get; set; }
         
          string? CustFax { get; set; }
         
          int? EmpId { get; set; }
         
       
    }
}
