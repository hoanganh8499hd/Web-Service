using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Demo02
{
    /// <summary>
    /// Summary description for Demo02
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Demo02 : System.Web.Services.WebService
    {

        //[WebMethod]
        //public List<Category> GetCategory()
        //{
        //    using (var context = new DemoWebServiceEntities())
        //    {
        //        var query = from st in context.Categories                                                      select st;

        //        var category = query.ToList();
        //        return category;
        //    }
        //    return null;
        //}

        [WebMethod]

        public List<Category> GetAllCategory()
        {
            WebServiceDemoDataContext context = new WebServiceDemoDataContext();
            List<Category> listCategory = context.Categories.ToList();
            foreach (var item in listCategory)
            {
                item.Products.Clear();
            }
            return listCategory;
        }
    }
}
