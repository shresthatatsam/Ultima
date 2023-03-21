using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ultima.Models.Interface;
using System.Data.SqlClient;
using System.Data;

namespace Ultima.Controllers
{
    public class HomeController : Controller
    {
        string q = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\source\repos\Ultima\Ultima\App_Data\Ultima.mdf;Integrated Security=True";

        public ICart _Icart;

        public HomeController(ICart icart)
        {
            _Icart = icart;
        }

        public ActionResult Index()

        {
            return View();
        }

        public ActionResult Shop()
        {
       

            return View();
        }



        //public ActionResult Shop()
        //{


        //    return View();
        //}
        [HttpPost]
        public ActionResult cart(FormCollection frm)
        {
            _Icart.Model.Pname = frm["txtProduct"].ToString();
            _Icart.Model.Price = frm["txtPrice"].ToString();
            _Icart.Model.Quantity = frm["txtQnty"].ToString();


            _Icart.SaveCart();
            var a = _Icart.showalldata();

            //DataTable dt = new DataTable();
            //using (SqlConnection con = new SqlConnection(q))
            //{
            //    con.Open();
            //    string qu = "select * from shop";
            //    SqlDataAdapter da = new SqlDataAdapter(qu,con);
            //    da.Fill(dt);
            //}
           
            return View(a);
        }

        
      

       





    }
}