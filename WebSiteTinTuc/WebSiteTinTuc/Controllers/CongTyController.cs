using DAWEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAWEB.Controllers
{
    public class CongTyController : Controller
    {
        TUYENDUNGITEntities6 td = new TUYENDUNGITEntities6();
        // GET: CongTy
        public ActionResult TrangChuCongTy() {
            return View();
        }
        public ActionResult DanhSachNguoiNop()
        {
            string id = Session["Tenct"].ToString();
            var nd = td.NOPDON.Where(x=>x.CongTy==id).ToList();

            //var ds = from c in td.DANHSACHDON
            //         where c.TenCT == id
            //         select c;
            //return View(ds);
            return View(nd);
        }

        [HttpGet]
        public ActionResult Tintuc() {
            return View();
        }
        
        [HttpPost]
        public ActionResult Tintuc(TinTuc tt , FormCollection f)
        {
            foreach (string fileUpload in Request.Files)
            {
                HttpPostedFileBase fileupload = Request.Files["fileUpload"];
                if (fileUpload == null)
                {
                    ViewBag.ThongBao = "Chọn hình ảnh";
                    return View();
                }
                // Thêm vào csdl 
                if (ModelState.IsValid)
                {
                    var FileName = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/"), FileName );
                    //Kiem tra Hinh Anh da ton tai chưa
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình Ảnh Đã Tồn Tại";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }

                }
            }
           
            tt.NgayGui = DateTime.Now;
            tt.Hinhanh = f["fileUpload"];
            
                td.TinTuc.Add(tt);
            td.SaveChanges();

            return RedirectToAction("TrangChuCongTy", "CongTy");
        }
       
    }
}