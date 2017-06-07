using System.Web;
using System.Web.Mvc;

namespace Ser_Web_CRUD_01
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
