using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class UploadController : Controller
    {
        DataSet1TableAdapters.MoviesTableAdapter adapter = new DataSet1TableAdapters.MoviesTableAdapter();
        DataSet1.MoviesDataTable table = new DataSet1.MoviesDataTable();

        DataSet1TableAdapters.TableTableAdapter adapter2 = new DataSet1TableAdapters.TableTableAdapter();
        DataSet1.TableDataTable table2 = new DataSet1.TableDataTable();

        DataSet1TableAdapters.ArticleTableAdapter adapter3 = new DataSet1TableAdapters.ArticleTableAdapter();
        DataSet1.ArticleDataTable table3 = new DataSet1.ArticleDataTable();
        // GET: Upload
        public ActionResult ViewUpload()
        {

           
            string name;
            adapter.FillBy2(table, 1);
            if (table.Rows.Count > 0)
            {
                ViewBag.UserName = table[0][1];
                name = table[0][1].ToString();
                ViewBag.UserBokeName = table[0][1] + "的博客";
                ViewBag.UserNameHref = "http://localhost:2090/Menu/ViewMenu";
                ViewBag.Scan = "注销";
                ViewBag.ScanHref = "http://localhost:2090/Menu/OutOff?UserName=" + table[0][1];
   
            }
            else
            {
                ViewBag.UserName = "登录";
                ViewBag.UserBokeName = "博客";
                ViewBag.UserNameHref = "http://localhost:2090/Login/ViewLogin";
                ViewBag.Scan = "注册";
                ViewBag.ScanHref = "http://localhost:2090/Scan/ViewScan";
            }

            return View();
        }
        public void AddArt(string title,string content)
        {

            
            
            adapter.FillBy2(table, 1);
           if (table.Rows.Count > 0)
            {
                adapter3.InsertQuery(table[0][1].ToString(),title, content, 0, 0);
                adapter3.Fill(table3);
                Response.Write("<script>alert('上传成功!');window.location.href ='http://localhost:2090/Menu/ViewMenu'</script>");
           }
        }
    }
}