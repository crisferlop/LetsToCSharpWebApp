using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhiselV3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getProducts() {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            var data = new List<object>();
            try
            {
                cn = new SqlConnection(
                    "Data Source=GAMER-PC\\UNDERGROUND;"
                    + "Initial Catalog=test;Integrated Security=True"
                    );
                cn.Open();
                cmd = new SqlCommand("SELECT Nombre,Id FROM PERSONA",cn);
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    data.Add(new { Nombre = dr["Nombre"] });
                }
                cn.Close();
            }
            catch (SqlException sqle) {
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}