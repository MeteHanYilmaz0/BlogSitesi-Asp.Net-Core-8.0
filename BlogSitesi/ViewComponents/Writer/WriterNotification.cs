using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
