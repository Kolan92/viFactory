using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.IRepo;
using Repository;
using Repository.Models;
using PagedList;

namespace viFactory.Controllers
{
    public class HomeController : Controller
    {
        private INewsRepo _newsRepo;
        private IUserRepo _userRepo;
        
        public HomeController(INewsRepo newsRepo, IUserRepo userRepo)
        {
            _newsRepo = newsRepo;
            _userRepo = userRepo;
        }

        public ActionResult Index(int? page)
        {
            var currentPage = page ?? 1;
            var news = _newsRepo.GetAll().OrderByDescending(x => x.PublishDate);
            var users = _userRepo.GetAllUsers();
            var model = new NewsUsersViewModel()
            {
                NewsPagedList = new PagedList<News>(news, currentPage, Constants.NewsPerPage),
                PartnerUser = users
            };  //new PagedList<News>(news, currentPage, Constants.NewsPerPage);
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();

            var news = _newsRepo.GetById((int) id);
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