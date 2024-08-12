using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
