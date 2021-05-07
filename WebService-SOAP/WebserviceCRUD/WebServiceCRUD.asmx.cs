using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebserviceCRUD.Model;

namespace WebserviceCRUD
{
    /// <summary>
    /// Summary description for WebServiceCRUD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebServiceCRUD : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Category> GetAllCategories()
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
        public List<Category> AddCategory(int CategoryID, string CategoryName)
        {

            DemoWebServiceEntities db = new DemoWebServiceEntities();
            List<Category> listCategory = db.Categories.ToList();
            try
            {
                Category category = new Category();
                category.CategoryID = CategoryID;
                category.CategoryName = CategoryName;
                db.Categories.Add(category);
                db.SaveChanges();
                listCategory.Add(category);
                return listCategory;

            }
            catch (Exception)
            {
            }
            return listCategory;
        }


        [WebMethod]
        public List<Category> EditCategory(int id, string name)
        {
            DemoWebServiceEntities db = new DemoWebServiceEntities();
            Category category = db.Categories.FirstOrDefault(x => x.CategoryID == id);
            if (category != null)
            {
                category.CategoryName = name;
            }

            db.SaveChanges();
            List<Category> listCategory = db.Categories.ToList();
            return listCategory;
        }
        [WebMethod]
        public List<Category> DeleteCategory(int id)
        {
            DemoWebServiceEntities db = new DemoWebServiceEntities();
            Category category = db.Categories.FirstOrDefault(x => x.CategoryID == id);
            if (category != null)
            {
                db.Categories.Remove(category);
            }

            db.SaveChanges();
            List<Category> listCategory = db.Categories.ToList();
            return listCategory;
        }
    }
}

