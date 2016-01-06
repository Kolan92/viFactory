using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.IRepo;

namespace viFactory.Controllers
{
    public class HomeController : Controller
    {
        private INewsRepo _newsRepo;
        public HomeController(INewsRepo newsRepo)
        {
            _newsRepo = newsRepo;
        }

        public ActionResult Index()
        {
            var news = _newsRepo.GetAll();
            return View(news);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}