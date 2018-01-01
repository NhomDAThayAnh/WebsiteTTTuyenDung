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

         TUYENDUNGITEntities1 td = new TUYENDUNGITEntities1();
      

        public ActionResult TrangChu() {
            var tt = td.TinTucTuyenDung.ToList();
            ViewBag.CanhBao = "Bạn phải đăng nhập mới có thể nộp đơn";
            return View(tt);
        }
        
        public ActionResult DonNguoiDung()
        {
            string ht = Session["Tenkhachhhhang"].ToString();
            var ds = td.NOPDON.Where(x => x.NguoiNop == ht).ToList();
            if (ds.Count -= 0)
            {
                ViewBag.ThongBao = "Bạn không có nào";
            }
            ViewBag.ThongBao = "Bạn có " + ds.Count() + " đơn";
            return View(ds);
        }
    }
}