using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService_SOAP
{
    /// <summary>
    /// Summary description for SOAP_Demo01
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SOAP_Demo01 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int TongHaiSo(int a, int b)
        {
            return a + b;
        }
        [WebMethod]
        public string YourName(string name)
        {
            return name;
        }

        /// <summary>
        /// So Luong San Pham Theo Ma Danh Muc
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        [WebMethod]
        public int GetNumberOfProductsByCategoryID(int CategoryID)
        {
            string connectionString = null;
            SqlConnection cnn;
            SqlCommand cmd;
            string sql = null;
            connectionString = @"Data Source=HUYNHANH\SQLEXPRESS;Initial Catalog=DemoWebService;Integrated Security=True";
            sql = "select count(*) from Product where CategoryID=" + CategoryID.ToString();
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                cnn.Close();
                return count;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
            //return 0;
        }

        
    }
}
