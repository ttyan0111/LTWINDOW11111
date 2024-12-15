using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTWINDOW_
{
    internal class TaiKhoan
    {
        string _strUserName, _strPassword, _strTenNhanVien,_strMaNhanVien;

        public TaiKhoan(string strUserName, string strPassword,string strTenNhanVien,string strMaNhanVien)
        {
            this._strUserName = strUserName;
            this._strPassword = strPassword;
            this._strTenNhanVien = strTenNhanVien;
            this._strMaNhanVien = strMaNhanVien;
        }

        public string UserName { get { return _strUserName; } }
        public string Password { get { return _strPassword; } }

        public string TenNhanVien { get { return _strTenNhanVien; } }
        public string MaNhanVien { get { return _strMaNhanVien; } }
    }
}
