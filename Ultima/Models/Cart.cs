using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ultima.Models.Interface;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Ultima.Models
{

    public class Cart : ICart
    {
        string q = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\source\repos\Ultima\Ultima\App_Data\Ultima.mdf;Integrated Security=True";
        public CartModel Model { get; set; }

        public Cart()
        {
            Model = new CartModel();
        }

        public string SaveCart()
        {
            SqlConnection sql = new SqlConnection(q);
            sql.Open();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" declare @Name varchar(50)");
            strSql.Append("set @Name ='" + Model.Pname + "'  ");
            strSql.Append("if (exists(select * from shop where pname = @name)) begin ");
            strSql.Append(" print 'duplicate data'");
            strSql.Append("end ");
            strSql.Append("else begin ");
            strSql.Append("insert into shop(Pname , Price , Quantity) values('" + Model.Pname + "', '" + Model.Price + "', '" + Model.Quantity + "')");
            strSql.Append("end");



            SqlCommand cmd = new SqlCommand(strSql.ToString(), sql);
            cmd.ExecuteNonQuery();
            return q;

        }


        public List<CartModel> showalldata()
        {
            SqlConnection sql = new SqlConnection(q);
            sql.Open();
            StringBuilder strSql = new StringBuilder();
            List<CartModel> lst = new List<CartModel>();
            strSql.Append("select * from shop");
            SqlCommand cmd = new SqlCommand(strSql.ToString(), sql);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new CartModel
                {
                    Id = Convert.ToInt32(dr[0]),
                    Pname =Convert.ToString(dr[1]),
                    Price = Convert.ToString(dr[2]),
                    Quantity = Convert.ToString(dr[3])
                });
            }
            return lst;
        }

    }

    public class CartModel
    {
        public int Id { get; set; }
        public string Pname { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
    }
}