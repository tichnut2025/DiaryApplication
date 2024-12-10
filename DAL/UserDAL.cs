using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 


namespace DAL
{
    public  class UserDAL
    {
        
         

        public List<User> GetUsers()
        {
            SqlConnection myConnection = new SqlConnection();
            
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            myConnection.ConnectionString = cs;
            SqlCommand com = new SqlCommand();

            com.Connection = myConnection;
            com.CommandText = $"select * from Users";
            List<User> users = new List<User>();
            try
            {
                myConnection.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    User u = new User();
                    u.Id = reader.GetInt32(0);
                    u.LastName = reader.GetString(1);
                    u.FirstName = reader.GetString(2);
                    u.Password = reader.GetString(3);
                    users.Add(u);
                }

                Debug.WriteLine(" השליפה  מסד הנתונים הסתימה בהצלחה!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ארעה שגיאה בשליפה ממסד הנתונים");

                Debug.WriteLine(ex.Message);

                if (ex.InnerException != null)
                    Debug.WriteLine(ex.InnerException.Message);
            }

            finally
            {
                myConnection.Close();
            }

            return users;
        }
    }
}
