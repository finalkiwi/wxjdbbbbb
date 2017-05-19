using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class MenuController : Controller
    {
        DataSet1TableAdapters.MoviesTableAdapter adapter = new DataSet1TableAdapters.MoviesTableAdapter();
        DataSet1.MoviesDataTable table = new DataSet1.MoviesDataTable();

        DataSet1TableAdapters.TableTableAdapter adapter2 = new DataSet1TableAdapters.TableTableAdapter();
        DataSet1.TableDataTable table2 = new DataSet1.TableDataTable();

        DataSet1TableAdapters.ArticleTableAdapter adapter3 = new DataSet1TableAdapters.ArticleTableAdapter();
        DataSet1.ArticleDataTable table3 = new DataSet1.ArticleDataTable();
        // GET: Menu
        public ActionResult ViewMenu()
        {

            string name;
            adapter.FillBy2(table, 1);
            if (table.Rows.Count>0)
            {
                ViewBag.UserName = table[0][1];
                name = table[0][1].ToString();
                ViewBag.UserBokeName = table[0][1] + "的博客";
                ViewBag.UserNameHref = "http://localhost:2090/Menu/ViewMenu";
                ViewBag.Scan = "注销";
                ViewBag.ScanHref = "http://localhost:2090/Menu/OutOff?UserName="+ table[0][1];
                adapter2.FillBy(table2,name);
                ViewBag.Level = table2[0][2];
                ViewBag.Point = table2[0][3];
                ViewBag.Visit = table2[0][4];
                ViewBag.Visit = ViewBag.Visit+1;
                ViewBag.Like = table2[0][5];
                int vis = ViewBag.Visit;
                int like = ViewBag.Like;
                adapter2.UpdateQuery(0, 0, vis, like, table[0][1].ToString());
                adapter2.Fill(table2);

                adapter3.FillBy(table3, name);
                if (table3.Rows.Count>0)
                {
                    ViewBag.ArtCount = table3.Rows.Count;
                    for (int i = 0; i < table3.Rows.Count; i++)
                    {
                        ViewData["Title"+i]= table3[i][2];
                        ViewData["Art" + i]=table3[i][3].ToString().Substring(0,60);
                        ViewData["Href" + i] = "http://localhost:2090/Articel/ViewArticel/"+table3[i][0].ToString();
                        ViewData["Count" + i] = table3[i][5].ToString();
                    }
                    
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
                ViewBag.Point =0;
                ViewBag.Visit =0;
                ViewBag.Like =0;
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
    }
}