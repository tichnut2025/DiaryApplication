using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALByEFCore
{
    public  interface IGenDal<T>
    {
        List<T> GetAll();
        //T GetEntity();
    }
}
