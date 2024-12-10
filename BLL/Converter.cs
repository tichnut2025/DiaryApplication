using DTO;
using EntitiesAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class Converter 
    {
        //public static ICustomer Convert (CustomerDTO dto)
        //{
        //    ICustomer  c  = new Customer();
        //    c.CustCity = dto.CustCity.ToString();
        //    c.CustAddress=dto.CustAddress;

        //    //................
        //    //can use reflection
        //    return c;

        //}

        public static void CopyMatchingFields(object source, object target)
        {
            // וודא שהאובייקטים הם מאותו סוג
            //if (source.GetType() != target.GetType())
            //{
            //    throw new ArgumentException("המקור והיעד חייבים להיות מאותו סוג.");
            //}

            // קבל את כל השדות של האובייקטים (כולל שדות פרטיים, עם או בלי יכולת קריאה/כתיבה)
            FieldInfo[] sourceFields = source.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] targetFields = target.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            // עבור על כל שדה של האובייקט המקורי
            foreach (FieldInfo sourceField in sourceFields)
            {
                // חפש שדה תואם באובייקט היעד
                FieldInfo targetField = Array.Find(targetFields, field => field.Name == sourceField.Name);

                if (targetField != null)
                {
                    // וודא שהשדה ניתן לקריאה וכתיבה
                    //if (sourceField.CanRead && targetField.CanWrite)
                    {
                        // קבל את הערך מהשדה של המקור
                        object value = sourceField.GetValue(source);

                        // העתק את הערך לשדה ביעד
                        targetField.SetValue(target, value);
                    }
                }
            }
        }

    }
}
