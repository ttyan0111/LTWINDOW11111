using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTWINDOW_.MenuQuanLy
{
    internal class LoaiMon
    {
        string id;
        string name;
        bool TrangThai;
        public LoaiMon(string id, string name, bool status)
        {
            this.id = id;
            this.name = name;
            TrangThai = status;
        }

        public string getId() { return id; }
        public string getName() { return name; }
        public bool getTrangThai() { return TrangThai; }
    }
}
