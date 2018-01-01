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
        TUYENDUNGITEntities td = new TUYENDUNGITEntities();
        // GET: ADMIN/QuanLyAD
        public ActionResult TrangChuAdmin()
        {
            return View();
        }
        public ActionResult Xemtin(FormCollection f)
        {
            string uutien = f.Get("uutien");
            Session["uutien"] = uutien;
            var tt = td.TinTuc.ToList();
            return View(tt);
        }
        [HttpGet]
 
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int IDTT)
        {
            TinTuc tt = td.TinTuc.SingleOrDefault(n => n.IDTT == IDTT);

            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(tt);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TinTuc tt)
        {

            if (ModelState.IsValid)
            {
                //Thực hiện cập nhạp trong Model
                td.Entry(tt).State = System.Data.Entity.EntityState.Modified;
                td.SaveChanges();
            }

            return Redirect("~/ADMIN/QuanLyAD/Xemtin");
        }

        //Xoá tin tức
        [HttpGet]
        public ActionResult Delete(int IDTT)
        {
            //Lấy Đối tượng sách theo mã
            TinTuc tt = td.TinTuc.SingleOrDefault(n => n.IDTT == IDTT);




            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tt);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult XacNhanXoa(int IDTT)
        {
            TinTuc tt = td.TinTuc.SingleOrDefault(n => n.IDTT == IDTT);
            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            td.TinTuc.Remove(tt);
            td.SaveChanges();
            return Redirect("~/ADMIN/QuanLyAD/Xemtin");

        }

        public ActionResult DangTin(int IDTT, FormCollection f)
        {


            return View();
        }
        [HttpGet]
        public ActionResult Themtintuc()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Themtintuc(TinTuc tt)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Themtindadang()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Themtindadang(TinTucTuyenDung tt)
        {
            td.TinTucTuyenDung.Add(tt);
            td.SaveChanges();
            return Redirect("~/ADMIN/QuanLyAD/Tindadang");
        }
        public ActionResult QuanLyDonNop()
        {
            return View();
        }
        public ActionResult Tindadang()
        {
            var tt = td.TinTucTuyenDung.ToList();
            return View(tt);
        }
        //Sửa tin đã đăng
        public ActionResult EditTinDaDang(int IDTT)
        {
            TinTucTuyenDung tt = td.TinTucTuyenDung.SingleOrDefault(n => n.IDTT == IDTT);

            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(tt);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTinDaDang(TinTucTuyenDung tt)
        {

            if (ModelState.IsValid)
            {
                //Thực hiện cập nhạp trong Model
                td.Entry(tt).State = System.Data.Entity.EntityState.Modified;
                td.SaveChanges();
            }

            return Redirect("~/ADMIN/QuanLyAD/Tindadang");
        }
        [HttpGet]
        public ActionResult DeleteTinDaDang(int IDTT)
        {
            //Lấy Đối tượng sách theo mã
            TinTucTuyenDung tt = td.TinTucTuyenDung.SingleOrDefault(n => n.IDTT == IDTT);




            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tt);
        }
        //xoa tin da dang
        [HttpPost, ActionName("DeleteTinDaDang")]
        public ActionResult XacNhanXoaTinDaDang(int IDTT)
        {
            TinTucTuyenDung tt = td.TinTucTuyenDung.SingleOrDefault(n => n.IDTT == IDTT);
            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            td.TinTucTuyenDung.Remove(tt);
            td.SaveChanges();
            return Redirect("~/ADMIN/QuanLyAD/Tindadang");

        }
        public ActionResult QuanLyTaiKhoan()
        {
            return View();
        }
        public ActionResult QuanLyTaiKhoanNguoiDung()
        {
           
            return View();
        }
        public ActionResult QuanLyTaiKhoanCongTy()
        {
          
            return View();
        }
        [HttpGet]
        public ActionResult EditTaiKhoanCongTy(int IDCT)
        {
           

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTaiKhoanCongTy(CONGTY ct)
        {

            return View();
        }
        [HttpGet]
        public ActionResult DeleteTaiKhoanCongTy(int IDCT)
        {
            //Lấy Đối tượng sách theo mã
            return View();
        }
        [HttpPost, ActionName("DeleteTaiKhoanCongTy")]
        public ActionResult XacNhanXoaTaiKhoanCongTy(int IDCT)
        {
           
            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanCongTy");

        }
        [HttpGet]
        public ActionResult ThemTaiKhoanCongTy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemTaiKhoanCongTy(CONGTY ct)
        {

            return View();
        }

        [HttpGet]
        public ActionResult EditTaiKhoanNguoiDung(int IDND)
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTaiKhoanNguoiDung(KHACHHANG kh)
        {

            return View();
        }
        [HttpGet]
        public ActionResult DeleteTaiKhoanNguoiDung(int IDND)
        {
            //Lấy Đối tượng sách theo mã
       
            return View();
        }
        [HttpPost, ActionName("DeleteTaiKhoanNguoiDung")]
        public ActionResult XacNhanXoaTaiKhoanNguoiDung(int IDND)
        {
           
            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanNguoiDung");

        }
        [HttpGet]
        public ActionResult ThemTaiKhoanNguoiDung()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemTaiKhoanNguoiDung(KHACHHANG kh)
        {
           
            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanNguoiDung");
        }
        //public ActionResult DanhSachNopDon()
        //{
           
        //    return View(ds);
        //}

        //[HttpGet]
        //public ActionResult EditDonNguoiDung(int IDND)
        //{
         

        //    return View(don);
        //}
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult EditDonNguoiDung(NOPDON don)
        //{

            
        //}
    }
}
