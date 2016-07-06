using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharePoint2013.cWebpart
{
    class DM_CSYT_2
    {
        public string MaBoNganh { get; set; }
        public string TenBoNganh { get; set; }
        public string CanCu { get; set; }
        public string HieuLucTuNgay { get; set; }
        public string NgayHetHieuLuc { get; set; }
        public void Print()
        {
            Console.WriteLine(MaBoNganh + "\t" + TenBoNganh + "\t" + CanCu + "\t" + HieuLucTuNgay + "\t" + NgayHetHieuLuc);
        }
    }
}
