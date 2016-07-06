using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharePointForm
{
     class Diem
    {
        int MaMonHoc;

        public int MaMonHoc1
        {
            get { return MaMonHoc; }
            set { MaMonHoc = value; }
        }
        int MaSinhVien;

        public int MaSinhVien1
        {
            get { return MaSinhVien; }
            set { MaSinhVien = value; }
        }
        string HocKy;

        public string HocKy1
        {
            get { return HocKy; }
            set { HocKy = value; }
        }
        double DiemTrungBinh;

        public double DiemTrungBinh1
        {
            get { return DiemTrungBinh; }
            set { DiemTrungBinh = value; }
        } 
    }
}