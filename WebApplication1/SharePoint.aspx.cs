using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SharePoint : System.Web.UI.Page
    {
        static string siteUrl = "http://thangnv:1000/";

        static string ObjectList = "";
        static string DIEM = "Diem";
        static string MONHOC = "Monhoc";

        static string SINHVIEN = "Sinhvien";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            ObjectList = SINHVIEN;
            if (ObjectList == SINHVIEN)
            {




                SPSite site = new SPSite(siteUrl);
                SPWeb web = site.OpenWeb();

                SPList list = web.Lists[SINHVIEN];

                SPListItem listitem = list.Items.Add();


                SinhVien sinhVien = new SinhVien();
                sinhVien.Msv1 = Convert.ToInt32(TextBox1.Text);
                sinhVien.Tensinhvien1 = TextBox2.Text;
                sinhVien.Khoa1 = TextBox3.Text;
                sinhVien.HeDaoTao1 = TextBox4.Text;


                listitem["Msv"] = sinhVien.Msv1;
                listitem["Tensinhvien"] = sinhVien.Tensinhvien1;
                listitem["Khoa"] = sinhVien.Khoa1;
                listitem["Hedaotao"] = sinhVien.HeDaoTao1;


                listitem.Update();





                //g1.Khoa1 = Convert.ToString(item["Khoa"]);
                //g1.HeDaoTao1 = Convert.ToString(item["Hedaotao"]);
            }
        }
    }
}