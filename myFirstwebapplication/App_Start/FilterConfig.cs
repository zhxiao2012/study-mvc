using System.Web;
using System.Web.Mvc;
using myFirstwebapplication.Filters;

namespace myFirstwebapplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());//ExceptionFilter
            filters.Add(new EmployeeExceptionFilter());
        }
    }
}
