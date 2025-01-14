﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Writer
{
   
    public class WriterAboutOnDashboard :ViewComponent
    {
        WriterManager writermanager = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
         
            var writerID=c.Writers.Where(x=>x.WriterMail==usermail).Select(x=>x.WriterID).FirstOrDefault();

            var values = writermanager.GetWriterById(writerID);
        return View(values); 
        }
    }
}
