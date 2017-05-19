using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class ScanController : Controller
    {
        DataSet1TableAdapters.MoviesTableAdapter adapter = new DataSet1TableAdapters.MoviesTableAdapter();
        DataSet1.MoviesDataTable table = new DataSet1.MoviesDataTable();

        DataSet1TableAdapters.TableTableAdapter adapter2 = new DataSet1TableAdapters.TableTableAdapter();
        DataSet1.TableDataTable table2 = new DataSet1.TableDataTable();
        // GET: Scan
        public ActionResult ViewScan()
        {
            return View();
        }
        public void Scan(String UserName,String Tel,String PassWord)
        {
            adapter.FillBy1(table, UserName,Tel);
            if (table.Count==0)
            {
                adapter.InsertQuery(UserName, PassWord,Tel, 0);
                adapter.Fill(table);
                adapter2.InsertQuery(UserName, 0, 0, 0, 0);
                adapter2.Fill(table2);
                Response.Write("<script>alert('注册成功!');window.location.href ='http://localhost:2090/Login/ViewLogin'</script>");
            }
            else
            {
                Response.Write("<script>alert('账户手机号码已存在!');window.location.href ='http://localhost:2090/Scan/ViewScan'</script>");
            }
           
        }
    }
}