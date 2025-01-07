using BL_API;
using DBEntities.Models;
using DTO;
using IDal;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Logging;

namespace BLL;

public  class CustomerBL :  ICustomerBL
{
    private readonly ILogger<CustomerBL >  _logger;

    private readonly ICustomerDal  _customerDal;
    AutoMapper.MapperConfiguration configCustomerConverter;
    public CustomerBL(ICustomerDal customerDal , ILogger<CustomerBL> logger)
    {
        _logger = logger;
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
        _logger.LogError($"ארעה שגיא קריטית בפונקציה {nameof (GetCustomers )}");
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

    async void doAsin()
    {
       int numOfOKMails= await sendMailToAllCustomers();
    }

    private async Task<int> sendMailToAllCustomers()
    {
        await SendEmailAsync("", "", "");
         
        return 0; 

    }

    public static async Task<int> SendEmailAsync(string toAddress, string subject, string body)
    {
        try
        {
            // הגדרת פרטי השרת SMTP
            var smtpClient = new SmtpClient("smtp.example.com")  // כתובת השרת של SMTP
            {
                Port = 587,  // מספר הפורט (לרוב 587 או 465)
                Credentials = new NetworkCredential("your-email@example.com", "your-password"),  // פרטי התחברות
                EnableSsl = true  // להשתמש בהצפנה
            };

            // יצירת ההודעה
            var mailMessage = new MailMessage
            {
                From = new MailAddress("your-email@example.com"),  // כתובת השולח
                Subject = subject,  // נושא המייל
                Body = body,  // תוכן המייל
                IsBodyHtml = false  // אם התוכן ב-HTML (אם יש לך תגי HTML במייל, תעשה את זה true)
            };

            // הוספת כתובת הנמען
            mailMessage.To.Add(toAddress);

            // שליחת המייל
           //await  smtpClient.Send  (mailMessage );
            await smtpClient.SendMailAsync(mailMessage);


            Console.WriteLine("ההודעה נשלחה בהצלחה!");

            return 0;   
        }
        catch (Exception ex)
        {
            Console.WriteLine($"שגיאה בשליחת המייל: {ex.Message}");
            return -1;
        }
    }
}
