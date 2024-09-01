using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BlogSitesi.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic1:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1=bm.GetList().Count();
            ViewBag.v2=c.Contacts.Count();
            ViewBag.v3=c.Comments.Count();

            string api = "0fced4a2378908ecf6586a74b1744f0f";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&appid="+api;

            XDocument document = XDocument.Load(connection);

            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
