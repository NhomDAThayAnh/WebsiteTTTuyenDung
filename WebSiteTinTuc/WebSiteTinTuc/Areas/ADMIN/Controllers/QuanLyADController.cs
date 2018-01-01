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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TrangChuAdmin()
        {
            return View();
        }
        public ActionResult Xemtin(FormCollection f)
        {
            //Xem tin tuyen dung
            string uutien = f.Get("uutien");
            Session["uutien"] = uutien;
            var tt = td.TinTuc.ToList();
            return View(tt);
        }
        [HttpGet]
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


            TinTuc tt = td.TinTuc.SingleOrDefault(n => n.IDTT == IDTT);
            TinTucTuyenDung tttd = new TinTucTuyenDung();
            if (tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            tttd.TenCT = tt.TenCT;
            tttd.Vitri = tt.Vitri;
            tttd.Mucluong = tt.Mucluong;
            tttd.Khuvuc = tt.Khuvuc;
            tttd.Thoihan = tt.Thoihan;
            tttd.Yeucau = tt.Yeucau;
            tttd.Hinhanh = tt.Hinhanh;
            tttd.Uutien = "1";
            td.TinTucTuyenDung.Add(tttd);

            td.TinTuc.Remove(tt);
            td.SaveChanges();
            return Redirect("~/ADMIN/QuanLyAD/TrangChuAdmin");

        }
        [HttpGet]
        public ActionResult Themtintuc()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Themtintuc(TinTuc tt)
        {
            td.TinTuc.Add(tt);
            td.SaveChanges();
            return Redirect("~/ADMIN/QuanLyAD/Xemtin");
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
            //Chức năng xem tài khoản người dùng
            var ttnd = td.KHACHHANG.ToList();
            return View(ttnd);
        }
        public ActionResult QuanLyTaiKhoanCongTy()
        {
            var ttct = td.CONGTY.ToList();
            return View(ttct);
        }
        [HttpGet]
        public ActionResult EditTaiKhoanCongTy(int IDCT)
        {
            CONGTY ct = td.CONGTY.SingleOrDefault(n => n.IDCT == IDCT);

            if (ct == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(ct);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTaiKhoanCongTy(CONGTY ct)
        {

            if (ModelState.IsValid)
            {
                //Thực hiện cập nhạp trong Model
                td.Entry(ct).State = System.Data.Entity.EntityState.Modified;
                td.SaveChanges();
            }

            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanCongTy");
        }
        [HttpGet]
        public ActionResult DeleteTaiKhoanCongTy(int IDCT)
        {
            //Lấy Đối tượng sách theo mã
            CONGTY ct = td.CONGTY.SingleOrDefault(n => n.IDCT == IDCT);




            if (ct == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ct);
        }
        [HttpPost, ActionName("DeleteTaiKhoanCongTy")]
        public ActionResult XacNhanXoaTaiKhoanCongTy(int IDCT)
        {
            CONGTY ct = td.CONGTY.SingleOrDefault(n => n.IDCT == IDCT);
            if (ct == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            td.CONGTY.Remove(ct);
            td.SaveChanges();
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
            td.CONGTY.Add(ct);
            td.SaveChanges();
            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanCongTy");
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
                //Thực hiện cập nhạp trong Model
                td.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                td.SaveChanges();
            }

            return Redirect("~/ADMIN/QuanLyAD/QuanLyTaiKhoanNguoiDung");
        }
        [HttpGet]
        public ActionResult DeleteTaiKhoanNguoiDung(int IDND)
        {
            //Lấy Đối tượng sách theo mã
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
        public ActionResult DanhSachNopDon()
        {
            var ds = td.NOPDON.ToList();
            return View(ds);
        }

        [HttpGet]
        public ActionResult EditDonNguoiDung(int IDND)
        {
            NOPDON don = td.NOPDON.SingleOrDefault(n => n.IDDon == IDND);

            if (don == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(don);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditDonNguoiDung(NOPDON don)
        {

            if (ModelState.IsValid)
            {
                //Thực hiện cập nhạp trong Model
                td.Entry(don).State = System.Data.Entity.EntityState.Modified;
                td.SaveChanges();
            }

            return Redirect("~/ADMIN/QuanLyAD/DanhSachNopDon");
        }


    }
}