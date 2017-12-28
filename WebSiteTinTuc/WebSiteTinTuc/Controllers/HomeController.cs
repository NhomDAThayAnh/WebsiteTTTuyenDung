using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteTinTuc.Models;

namespace WebSiteTinTuc.Controllers
{
    public class HomeController : Controller
    {

         TUYENDUNGITEntities td = new TUYENDUNGITEntities();
      

        public ActionResult TrangChu() {
            return View();
        }

        
    }
}