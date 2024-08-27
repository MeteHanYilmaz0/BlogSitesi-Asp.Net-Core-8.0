using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogSitesi.Controllers
{
  
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        [AllowAnonymous]
        public IActionResult InBox()
        {
            int id = 2;

            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }
   
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);
          
            return View(value);
        }
    }
}
