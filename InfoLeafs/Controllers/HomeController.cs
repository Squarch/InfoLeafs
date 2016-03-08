using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoLeafs.Models;

namespace InfoLeafs.Controllers
{
    /// <summary>
    /// Контроллер, отвечающий за шапку и быстрый переход по сайту
    ///
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult News()
        {
            return View();
        }
        public ActionResult MyProfile()
        {
            return View();
        }
        public ActionResult Subscription()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult AnotherProfile()
        {
            return View();
        }
    }
}