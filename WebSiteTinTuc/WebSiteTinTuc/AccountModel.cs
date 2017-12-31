using DAWEB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAWEB
{
    public class AccountModel

    {
        private TUYENDUNGITEntities6 td = null;
        public AccountModel() {
            td = new TUYENDUNGITEntities6();
        }
        public bool Login(string Tendangnhap, string Matkhau) {
            var sqlParmas = new SqlParameter[]{
                new SqlParameter("Tendangnhap",Tendangnhap),
                new SqlParameter("Matkhau",Matkhau),
            };

            var res = td.Database.SqlQuery<bool>("NGUOIDUNG Tendangnhap,Matkhau", sqlParmas).SingleOrDefault();
            return res;
        }
    }
}