using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class ArticelController : Controller
    {
        DataSet1TableAdapters.MoviesTableAdapter adapter = new DataSet1TableAdapters.MoviesTableAdapter();
        DataSet1.MoviesDataTable table = new DataSet1.MoviesDataTable();

        DataSet1TableAdapters.TableTableAdapter adapter2 = new DataSet1TableAdapters.TableTableAdapter();
        DataSet1.TableDataTable table2 = new DataSet1.TableDataTable();

        DataSet1TableAdapters.ArticleTableAdapter adapter3 = new DataSet1TableAdapters.ArticleTableAdapter();
        DataSet1.ArticleDataTable table3 = new DataSet1.ArticleDataTable();
        // GET: Articel
        public ActionResult ViewArticel(String id)
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
                adapter2.FillBy(table2, name);
                ViewBag.Level = table2[0][2];
                ViewBag.Point = table2[0][3];
                ViewBag.Visit = table2[0][4];
                ViewBag.Visit = ViewBag.Visit + 1;
                ViewBag.Like = table2[0][5];
                int vis = ViewBag.Visit;
                int like = ViewBag.Like;
                adapter2.UpdateQuery(0, 0, vis, like, table[0][1].ToString());
                adapter2.Fill(table2);

                adapter3.FillBy1(table3, int.Parse(id));
                if (table3.Rows.Count > 0)
                {
                    ViewData["Title"] = table3[0][2];
                    ViewData["Art"] = table3[0][3].ToString();
                    ViewBag.Love = table3[0][5].ToString();
                    ViewBag.AddLove = "http://localhost:2090/Articel/Add?id=" + table3[0][0].ToString();
                    int count = int.Parse(table3[0][4].ToString())+1;
                    adapter3.UpdateQuery1(count, int.Parse(id));
                }
            }
            else
            {
                ViewBag.UserName = "登录";
                ViewBag.UserBokeName = "博客";
                ViewBag.UserNameHref = "http://localhost:2090/Login/ViewLogin";
                ViewBag.Scan = "注册";
                ViewBag.ScanHref = "http://localhost:2090/Scan/ViewScan";
                ViewBag.Level = 0;
                ViewBag.Point = 0;
                ViewBag.Visit = 0;
                ViewBag.Like = 0;
                ViewBag.AddLove = "http://localhost:2090/Login/ViewLogin";
                ViewBag.Love = 0;
            }
            return View();
        }
        public void OutOff(String UserName)
        {
            adapter.Fill(table);
            adapter.UpdateQuery1(0, UserName);
            adapter.Fill(table);
            Response.Write("<script>alert('注销成功!');window.location.href ='http://localhost:2090/Menu/ViewMenu'</script>");
        }
        public void Add(String id)
        {
            adapter3.FillBy2(table3, int.Parse(id));
            if (table3.Rows.Count > 0)
            {
                int love = int.Parse(table3[0][5].ToString());
                string username = table3[0][1].ToString().Trim(); ;
                
                adapter3.UpdateQuery(love + 1, int.Parse(id));
                adapter3.Fill(table3);
                adapter2.FillBy(table2,username);
                int num = int.Parse(table2[0][5].ToString()) + 1;
                adapter2.UpdateQuery1(num, username);
                adapter2.Fill(table2);
                string href = "http://localhost:2090/Articel/ViewArticel/" + id;
                Response.Write("<script>alert('点赞成功!');</script>");
                Response.Redirect(href);
            }
        }
    }
        
}