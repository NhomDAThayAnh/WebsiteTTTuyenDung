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
<<<<<<< HEAD
        TUYENDUNGITEntities td = new TUYENDUNGITEntities();
=======
         TUYENDUNGITEntities6 td = new TUYENDUNGITEntities6();
      
>>>>>>> 3bc7c0df065b5bbeb30ab78c7d37eb997c76d2e8
        public ActionResult TrangChu() {
            var tt = td.TinTucTuyenDung.ToList();
            ViewBag.CanhBao = "Bạn phải đăng nhập mới có thể nộp đơn";
            return View(tt);
        }

        
    }
}