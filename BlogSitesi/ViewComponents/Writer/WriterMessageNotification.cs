using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
