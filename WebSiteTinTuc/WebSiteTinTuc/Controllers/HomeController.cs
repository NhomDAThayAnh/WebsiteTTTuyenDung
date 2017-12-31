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
            var tt = td.TinTucTuyenDungs.ToList();
            ViewBag.CanhBao = "Bạn phải đăng nhập mới có thể nộp đơn";
            return View(tt);
        }
        [HttpGet]
        public ActionResult TrangNopDon(int IDTT)
        {
            var tttd = td.TinTucTuyenDungs.SingleOrDefault(n => n.IDTT == IDTT);
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

            Session["sNguoiNop"] = sNguoiNop;
            Session["sEmail"] = sEmail;
            Session["sSDT"] = sSDT;
            Session["sGT"] = sGT;
            int id = int.Parse(Session["IDTD"].ToString());
            tttd = td.TinTucTuyenDungs.SingleOrDefault(n => n.IDTT == id);
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
            td.NOPDONs.Add(nd);
            td.SaveChanges();

            return RedirectToAction("TrangChu", "Home");
        }


    }
}