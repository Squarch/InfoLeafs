using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Interfaces;
//using Logic;

namespace InfoLeafs.Models
{
    public class UserRepo
    {
        public static IUserLogic repo = new IUserLogic();
        //static IUserLogic repo = new IUserLogic();

    }
}