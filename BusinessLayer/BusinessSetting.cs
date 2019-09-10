using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myFirstwebapplication.Data_Access_Layer;

namespace BusinessLayer
{
    public class BusinessSetting
    {
        public static void SetBusiness()
        {
            DatabaseSettings.SetDatabase();
        }
    }
}
