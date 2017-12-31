using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSiteTinTuc.Areas.ADMIN.Controllers
{
    public class QuanLyADController : Controller
    {
        // GET: ADMIN/QuanLyAD
        public ActionResult TrangChuAdmin()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ThemTaiKhoanNguoiDung()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemTaiKhoanNguoiDung(KHACHHANG kh)
        {
            td.KHACHHANG.Add(kh);
            td.SaveChanges();
            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanNguoiDung");
        }
        public ActionResult DanhSachNopDon() {
            var ds = td.NOPDON.ToList();
            return View(ds);
        }

	

    }
}