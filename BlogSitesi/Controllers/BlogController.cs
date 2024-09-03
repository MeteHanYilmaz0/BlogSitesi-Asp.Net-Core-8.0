using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogSitesi.Controllers
{

	[AllowAnonymous]

	public class BlogController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
      
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);

        }

        public IActionResult BlogListByWriter()
        {
          
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
           
            var values=bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }
        [HttpGet] 
        public IActionResult BlogAdd()
        {
         
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text =x.CategoryName,
                                                       Value=x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
          
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
            BlogValidator  bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
           
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        public IActionResult DeleteBlog(int id) 
        { 
            var blogvalue=bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue=bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [HttpPost]

        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
            p.WriterID = writerID;
            p.BlogStatus=true;
            p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());    
            bm.TUpdate(p);
           
            return RedirectToAction("BlogListByWriter");
        }



    }
}
