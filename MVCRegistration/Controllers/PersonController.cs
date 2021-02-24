using MVCRegistration.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRegistration.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Registration()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Registration(Person p)
        {
           

            return View("Preview",p);
        }

        public ActionResult Submit(Person p)
        {
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=PersonDatabase;trusted_connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("PersonSave", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Place", p.Place);
            cmd.Parameters.AddWithValue("@Email", p.Email);
            cmd.Parameters.AddWithValue("@Mobile", p.Mobile);
            cmd.ExecuteNonQuery();
            connect.Close();
            return View("Result");
        }
    }
}