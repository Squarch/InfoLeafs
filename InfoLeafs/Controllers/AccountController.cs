using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfoLeafs.Controllers
{
    /// <summary>
    /// Взаимодействия с акаунтом: регистрация и вход 
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// Первая страница которую видит пользователь
        /// На ней расположенна форма входа с возможностью перехода на форму регистрации
        /// Так же приветствие и небольшое описание проекта
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Форма входа
        /// </summary>
        /// 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        /// <summary>
        /// Форма регистрации
        /// </summary>
        public ActionResult Registration()
        {
            return View();
        }
        
    }
}