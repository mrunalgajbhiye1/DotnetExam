using DotNetAnswer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetAnswer.Controllers
{
    public class ProductsController : Controller
    {
       
  
        // GET: Products
        public ActionResult Index()
        {
          
            List<Products> prdList = new List<Products>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Products;Integrated Security=True";
            cn.Open();

            SqlCommand show = new SqlCommand();
            show.Connection = cn;
            show.CommandType = System.Data.CommandType.StoredProcedure;
            show.CommandText = "Procedure";
            try
            {
                SqlDataReader dr = show.ExecuteReader();
                while(dr.Read())
                {
                    prdList.Add(new Products
                    { ProductId = (int)dr["ProductId"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName = (string)dr["CategoryName"]});
                }

                dr.Close();

                return View(prdList);
            }


            catch 
            {
                return View();

            }
            




           
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int ? id)
        {
           
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Products;Integrated Security=True";
            cn.Open();
            SqlCommand edit = new SqlCommand();
            edit.Connection = cn;
            edit.CommandType = System.Data.CommandType.Text;
            edit.CommandText = "SELECT * from Products where ProductId = @ProductId";
            edit.Parameters.AddWithValue("ProductId", id);
            SqlDataReader dr = edit.ExecuteReader();

            Products ed = new Products();
            if(dr.Read())
            {
                 ed = new Products

                { ProductId = (int)dr["ProductId"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName = (string)dr["CategoryName"]};

            
            }
                return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Products obj)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Products;Integrated Security=True";
                cn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUpdate.CommandText = "ProductUpdate";
                cmdUpdate.Parameters.AddWithValue("@ProductId", obj.ProductId);
                cmdUpdate.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmdUpdate.Parameters.AddWithValue("@Rate", obj.Rate);
                cmdUpdate.Parameters.AddWithValue("@Description", obj.Description);
                cmdUpdate.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
                cmdUpdate.ExecuteNonQuery();
               


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
