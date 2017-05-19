using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class LoginController : Controller
    {
        DataSet1TableAdapters.MoviesTableAdapter adapter = new DataSet1TableAdapters.MoviesTableAdapter();
        DataSet1.MoviesDataTable table = new DataSet1.MoviesDataTable();
        // GET: Login
        public ActionResult ViewLogin()
        {
            MovieDBContext db = new MovieDBContext();
            //string a = ViewBag.name;
            return View(db.Movies.ToList());
        }

        public void Check(String name,String password)
        {
            adapter.FillBy(table, name, password);
            if (table.Count>0)
            {
                adapter.UpdateQuery(1, name);
                adapter.Fill(table);
                Response.Write("<script>alert('登录成功!');window.location.href ='http://localhost:2090/Menu/ViewMenu'</script>");
               // Response.Redirect("http://localhost:2090/Menu/ViewMenu");
            }
            else
            {
                Response.Write("<script>alert('账号密码错误!');window.location.href ='http://localhost:2090/Login/ViewLogin'</script>");
                //ViewBag.state=""
              //  Response.Redirect("http://localhost:2090/Login/ViewLogin");
            }
          
           
        }
       
    }
}