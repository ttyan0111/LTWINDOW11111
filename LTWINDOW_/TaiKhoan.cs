using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTWINDOW_
{
    internal class TaiKhoan
    {
        string _strUserName, _strPassword, _strTenNhanVien;

        public TaiKhoan(string strUserName, string strPassword,string strTenNhanVien)
        {
            _strUserName = strUserName;
            _strPassword = strPassword;
            _strTenNhanVien = strTenNhanVien;
        }

        public string UserName { get { return _strUserName; } }
        public string Password { get { return _strPassword; } }

        public string TenNhanVien { get { return _strTenNhanVien; } }
    }
}
