using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Demo03
{
    /// <summary>
    /// Summary description for WebServiceDemo03
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebServiceDemo03 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Category> GetCategories()
        {
            DemoWebServiceEntities entity = new DemoWebServiceEntities();
            List<Category> listCategory = entity.Categories.ToList();
            //foreach (var item in listCategory)
            //{
            //    item.Products.Clear();
            //}
            return listCategory;
        }

        [WebMethod]
        public List<Product> GetListProductsByCategoryID(int id)
        {
            DemoWebServiceEntities demoWebServiceEntities = new DemoWebServiceEntities();
            List<Product> listProducts = demoWebServiceEntities.Products.Where(x => x.CategoryID == id).ToList();
            return listProducts;
        }
    }
}
