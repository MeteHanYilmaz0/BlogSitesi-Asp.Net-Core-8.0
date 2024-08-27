using Microsoft.AspNetCore.Mvc;






namespace BlogSitesi.Areas.Admin.Controllers
{
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
