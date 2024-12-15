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

        public LoaiMon(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string getId() { return id; }
        public string getName() { return name; }
    }
}
