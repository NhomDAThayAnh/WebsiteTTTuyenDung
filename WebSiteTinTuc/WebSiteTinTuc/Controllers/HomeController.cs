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
        [HttpGet]
        public ActionResult TrangNopDon(int IDTT)
        {
            var tttd = td.TinTucTuyenDung.SingleOrDefault(n => n.IDTT == IDTT);
            Session["IDTD"] = IDTT;

            return View(tttd);
        }

        [HttpPost]
        public ActionResult TrangNopDon(TinTucTuyenDung tttd, FormCollection f)
        {
            string sNguoiNop = f.Get("name").ToString();
            string sEmail = f.Get("email").ToString();
            string sSDT = f.Get("sdt").ToString();
            string sGT = f.Get("message").ToString();
            // commit nop don
            Session["sNguoiNop"] = sNguoiNop;
            Session["sEmail"] = sEmail;
            Session["sSDT"] = sSDT;
            Session["sGT"] = sGT;
            int id = int.Parse(Session["IDTD"].ToString());
            tttd = td.TinTucTuyenDung.SingleOrDefault(n => n.IDTT == id);
            var nd = new NOPDON();

            nd.IDTT = tttd.IDTT;
            nd.CongTy = tttd.TenCT;
            nd.NgayNop = DateTime.Now;
            nd.NguoiNop = Session["sNguoiNop"].ToString();
            nd.Hanchot = tttd.Thoihan;
            nd.Yeucau = tttd.Yeucau;
            nd.Vitri = tttd.Vitri;
            nd.Email = Session["sEmail"].ToString();
            nd.SDT = Session["sSDT"].ToString();
            nd.Gioithieubanthan = sGT;
            td.NOPDON.Add(nd);
            td.SaveChanges();

            return RedirectToAction("TrangChu", "Home");
        }
        //Xem lich su ho so da nop
        public ActionResult DonNguoiDung()
        {
            string ht = Session["Tenkhachhang"].ToString();
            var ds = td.NOPDON.Where(x => x.NguoiNop == ht).ToList();
            if (ds.Count == 0)
            {
                ViewBag.ThongBao = "Bạn không có nào";
            }
            ViewBag.ThongBao = "Bạn có " + ds.Count() + " đơn";
            return View(ds);
        }
        public ActionResult KetQuaTimKiem(FormCollection f)
        {

            string sTuKhoa = f["txtTimKiem"].ToString();
            var lstKQTK = td.TinTucTuyenDung.Where(n => n.Vitri.Contains(sTuKhoa)).ToList();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy vị trí bạn muốn tìm";
                return View(td.TinTucTuyenDung.OrderBy(n => n.Vitri));

            }
            ViewBag.Thongbao = "Đã tìm thấy " + lstKQTK.Count() + " kết quả";
            return View(lstKQTK.OrderBy(n => n.Vitri));
        }
        public ActionResult XoaDonNguoiDung(int IDTT)
        {
            //Lấy Đối tượng sách theo mã
            NOPDON don = td.NOPDON.SingleOrDefault(n => n.IDTT == IDTT);




            if (don == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(don);

        }
        [HttpPost, ActionName("XoaDonNguoiDung")]
        public ActionResult XacNhanXoa(int IDTT)
        {

            NOPDON don = td.NOPDON.SingleOrDefault(n => n.IDTT == IDTT);
            if (don == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            td.NOPDON.Remove(don);
            td.SaveChanges();
            return Redirect("~/Home/DonNguoiDung");
        }

    }
}