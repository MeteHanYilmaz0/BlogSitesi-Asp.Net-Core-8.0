using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic4:ViewComponent
    {
        Context c=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1= c.Admins.Where(x=>x.AdminID==1).Select(y=>y.Name).FirstOrDefault();
            ViewBag.v2=c.Admins.Where(x => x.AdminID == 1).Select(y=>y.ImageURL).FirstOrDefault();
            return View(); 
        }
    }
}
