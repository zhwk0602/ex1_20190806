using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using ex1_20190806.Models;

namespace ex1_20190806.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index(string param = null)

        {
            DataTable dt = new DataTable();
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NorthwindConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT [CustomerID],[CompanyName] FROM Customers";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            var result = new List<SqlViewModel>();
            foreach (DataRow x in dt.Rows)
            {
                var item = new SqlViewModel();

                item.CompanyName = x["CompanyName"].ToString();
                item.CustomerID = x["CustomerID"].ToString();
                result.Add(item);
            }

            return View(result);

            //    var result = new MemberViewModel
            //    {
            //    Name = "機器人",
            //        Email = "robot@gmail.com",
            //        Phone = "0912345678",
            //        Car = new List<string>
            //        {
            //            "toyota","benz","benzz"
            //        }
            //    };

            //    return View(result);
        }

        [HttpPost]
        public ActionResult Index(MemberViewModel viewModle)
        {
            if (!this.ModelState.IsValid)

            {
                return this.View(viewModle);
            }
            return this.View(viewModle);
        }
    }
}