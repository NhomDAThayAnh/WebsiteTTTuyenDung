using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteTinTuc.Models;

namespace WebSiteTinTuc.Areas.ADMIN.Controllers
{
    public class QuanLyADController : Controller
    {
        TUYENDUNGITEntities1 td = new TUYENDUNGITEntities1();

        // GET: ADMIN/QuanLyAD
        public ActionResult TrangChuAdmin()
        {
            return View();
        }

//
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
     
        [HttpGet]
        public ActionResult DeleteTaiKhoanNguoiDung(int IDND)
        {
            //L?y ??i t??ng s�ch theo m�
            KHACHHANG kh = td.KHACHHANG.SingleOrDefault(n => n.IDND == IDND);




            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost, ActionName("DeleteTaiKhoanNguoiDung")]
        public ActionResult XacNhanXoaTaiKhoanNguoiDung(int IDND)
        {
            KHACHHANG kh = td.KHACHHANG.SingleOrDefault(n => n.IDND == IDND);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            td.KHACHHANG.Remove(kh);
            td.SaveChanges();
            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanNguoiDung");

        }

        [HttpGet]
        public ActionResult EditTaiKhoanNguoiDung(int IDND)
        {
            KHACHHANG kh = td.KHACHHANG.SingleOrDefault(n => n.IDND == IDND);

            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(kh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTaiKhoanNguoiDung(KHACHHANG kh)
        {

            if (ModelState.IsValid)
            {
                //Th?c hi?n c?p nh?p trong Model
                td.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                td.SaveChanges();
            }

            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanNguoiDung");
        }

	

    }
}