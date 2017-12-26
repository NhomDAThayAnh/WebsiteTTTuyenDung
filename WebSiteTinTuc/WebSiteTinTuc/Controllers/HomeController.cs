using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSiteTinTuc.Controllers
{
    public class HomeController : Controller
    {
         TUYENDUNGITEntities6 td = new TUYENDUNGITEntities6();
      
        public ActionResult TrangChu() {
            var tt = td.TinTucTuyenDung.ToList();
            ViewBag.CanhBao = "Bạn phải đăng nhập mới có thể nộp đơn";
            return View(tt);
        }

        
    }
}