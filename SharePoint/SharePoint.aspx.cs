using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SharePoint
{
    public partial class SharePoint : System.Web.UI.Page
    {
        // int a; 
        static string siteUrl = "http://thangnv:1000/";

        static string ObjectList = "";
        static string DIEM = "Diem";
        static string MONHOC = "Monhoc";

        static string SINHVIEN = "Sinhvien";
        protected void Page_Load(object sender, EventArgs e)
        {
            //ListBox1 = LoadTitleofListSharePoint(SharePointWeb.siteUrl);     


        }



        //add items
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


            if (ObjectList == MONHOC)
            {

                SPSite site = new SPSite(siteUrl);
                SPWeb web = site.OpenWeb();
                SPList list = web.Lists[MONHOC];

                SPListItem listitem = list.Items.Add();

                MonHoc monHoc = new MonHoc();
                monHoc.MaMonHoc1 = Convert.ToInt32(TextBox1.Text);
                monHoc.TenMonHoc1 = TextBox2.Text;
                monHoc.SoTinChi1 = Convert.ToInt32(TextBox3.Text);


                listitem["Mamonhoc"] = monHoc.MaMonHoc1;
                listitem["TenMonHoc"] = monHoc.TenMonHoc1;
                listitem["Sotinchi"] = monHoc.SoTinChi1;
                //listitem["Hedaotao"] = sinhVien.HeDaoTao1;


                listitem.Update();



            }

            if (ObjectList == DIEM)
            {


                SPSite site = new SPSite(siteUrl);
                SPWeb web = site.OpenWeb();
                SPList list = web.Lists[MONHOC];

                SPListItem listitem = list.Items.Add();

                Diem diem = new Diem();
                diem.MaMonHoc1 = Convert.ToInt32(TextBox1.Text);
                diem.MaSinhVien1 = Convert.ToInt32(TextBox2.Text);
                diem.DiemTrungBinh1 = Convert.ToDouble(TextBox3.Text);
                diem.HocKy1 = TextBox4.Text;

                listitem["Mamonhoc"] = diem.MaMonHoc1;

                listitem["Msv"] = diem.MaSinhVien1;
                listitem["DiemTrungBinh"] = diem.DiemTrungBinh1;
                listitem["Hocky"] = diem.HocKy1;
                //listitem["Hedaotao"] = sinhVien.HeDaoTao1;

                listitem.Update();

            }

        }

        //Edit items 
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (ObjectList == SINHVIEN)
            {


                SPSite site = new SPSite(siteUrl);
                SPWeb web = site.OpenWeb();
                SPList list = web.Lists[SINHVIEN];

                //SPListItem listitem = list.Items.Add();

                SPListItem listitem = list.Items[0];

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

                //Updat Listbox 
                ListBox2.DataBind();

                //foreach (SinhVien title in listItem)
                //{
                //    ListBox2.Items.Add(Convert.ToString(title.Msv1 + "\t" + title.Tensinhvien1 + "\t" + title.Khoa1 + "\t" + title.HeDaoTao1));

                //}

            }
            if (ObjectList == SINHVIEN)
            {

            }
            if (ObjectList == SINHVIEN)
            {

            }


        }

        //Delete items
        protected void Button3_Click(object sender, EventArgs e)
        {

            if (ObjectList == SINHVIEN)
            {


                SPSite site = new SPSite(siteUrl);
                SPWeb web = site.OpenWeb();
                SPList list = web.Lists[SINHVIEN];

                //SPListItem listitem = list.Items.Add();

                SPListItem listitem = list.Items[0];

                //SinhVien sinhVien = new SinhVien();
                //sinhVien.Msv1 = Convert.ToInt32(TextBox1.Text);
                //sinhVien.Tensinhvien1 = TextBox2.Text;
                //sinhVien.Khoa1 = TextBox3.Text;
                //sinhVien.HeDaoTao1 = TextBox4.Text;


                //listitem["Msv"] = sinhVien.Msv1;
                //listitem["Tensinhvien"] = sinhVien.Tensinhvien1;
                //listitem["Khoa"] = sinhVien.Khoa1;
                //listitem["Hedaotao"] = sinhVien.HeDaoTao1;


                listitem.Delete();

                //Updat Listbox 
                ListBox2.DataBind();

                //foreach (SinhVien title in listItem)
                //{
                //    ListBox2.Items.Add(Convert.ToString(title.Msv1 + "\t" + title.Tensinhvien1 + "\t" + title.Khoa1 + "\t" + title.HeDaoTao1));

                //}


            }
            if (ObjectList == SINHVIEN)
            {

            }
            if (ObjectList == SINHVIEN)
            {

            }

        }

        //Selected item 
        protected void Button4_Click(object sender, EventArgs e)
        {

            if (ObjectList == SINHVIEN)
            {


                string text = ListBox2.SelectedItem.ToString();

                //MessageBox.Show(listBoxTopics.SelectedValue.ToString());
                text = ListBox2.SelectedValue.ToString();
                string[] split = text.Split('\t');
                TextBox1.Text = split[0];
                TextBox2.Text = split[1];
                TextBox3.Text = split[2];
                TextBox4.Text = split[3];


            }
            if (ObjectList == SINHVIEN)
            {

            }
            if (ObjectList == SINHVIEN)
            {

            }

        }

        //click SinhVien

        protected void Button5_Click(object sender, EventArgs e)
        {
            
                ObjectList = SINHVIEN;
                ListBox2.Items.Clear();

                //ListBox2 = null;
                List<SinhVien> listItem = new List<SinhVien>();


                SPSecurity.RunWithElevatedPrivileges(delegate()
                   {

                SPSite site = new SPSite(siteUrl);
                SPWeb web = site.OpenWeb();
                SPList list = web.Lists[SINHVIEN];
                //return list;             

                foreach (SPListItem item in list.Items)
                {
                    SinhVien g1 = new SinhVien();
                    g1.Msv1 = Convert.ToInt32(item["Msv"]);
                    g1.Tensinhvien1 = Convert.ToString(item["Tensinhvien"]);
                    g1.Khoa1 = Convert.ToString(item["Khoa"]);
                    g1.HeDaoTao1 = Convert.ToString(item["Hedaotao"]);
                    //Console.WriteLine("Giang vien:{0} Ten giang vien{1} Dia chi{2}", item["Msv"], item["Tengiangvien"], item["Diachi"]);
                    listItem.Add(g1);
                }

                });

                //Listitem to Listbox2 
                foreach (SinhVien title in listItem)
                {
                    ListBox2.Items.Add(Convert.ToString(title.Msv1 + "\t" + title.Tensinhvien1 + "\t" + title.Khoa1 + "\t" + title.HeDaoTao1));

                }
            
          
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //Click MonHoc
            ObjectList = MONHOC;
            ListBox2.Items.Clear();
            // ListBox2 = null;
            List<MonHoc> listItem = new List<MonHoc>();


            SPSecurity.RunWithElevatedPrivileges(delegate()
               {

                   SPSite site = new SPSite(siteUrl);
                   SPWeb web = site.OpenWeb();
                   SPList list = web.Lists[MONHOC];
                   //return list;             

                   foreach (SPListItem item in list.Items)
                   {
                       MonHoc g1 = new MonHoc();
                       g1.MaMonHoc1 = Convert.ToInt32(item["Mamonhoc"]);
                       g1.TenMonHoc1 = Convert.ToString(item["TenMonHoc"]);
                       g1.SoTinChi1 = Convert.ToInt32(item["Sotinchi"]);
                       ///g1.HeDaoTao1 = Convert.ToString(item["Hedaotao"]);
                       //Console.WriteLine("Giang vien:{0} Ten giang vien{1} Dia chi{2}", item["Msv"], item["Tengiangvien"], item["Diachi"]);
                       listItem.Add(g1);
                   }

               });

            //Listitem to Listbox2 
            foreach (MonHoc title in listItem)
            {
                ListBox2.Items.Add(Convert.ToString(title.MaMonHoc1 + "\t" + title.TenMonHoc1 + "\t" + title.SoTinChi1));
            }


        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            //Click Diem 

            ObjectList = DIEM;
            ListBox2.Items.Clear();
            //ListBox2 = null;
            List<Diem> listItem = new List<Diem>();


            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                SPSite site = new SPSite(siteUrl);
                SPWeb web = site.OpenWeb();
                SPList list = web.Lists[DIEM];
                //return list;             

                foreach (SPListItem item in list.Items)
                {
                    Diem g1 = new Diem();
                    //  g1.MaMonHoc1 = Convert.ToInt32(item["Mamonhoc"]);
                    SPFieldLookupValue value = new SPFieldLookupValue(item["Mamonhoc"].ToString());
                    g1.MaMonHoc1 = (int)Convert.ToDouble(value.LookupValue);
                    //string abd = value.LookupValue;


                    SPFieldLookupValue value1 = new SPFieldLookupValue(item["Msv"].ToString());

                    g1.MaSinhVien1 = (int)Convert.ToDouble(value1.LookupValue);

                    g1.DiemTrungBinh1 = Convert.ToDouble(item["DiemTrungBinh"]);
                    g1.HocKy1 = Convert.ToString(item["HocKy"]);
                    ///g1.HeDaoTao1 = Convert.ToString(item["Hedaotao"]);
                    //Console.WriteLine("Giang vien:{0} Ten giang vien{1} Dia chi{2}", item["Msv"], item["Tengiangvien"], item["Diachi"]);
                    listItem.Add(g1);
                }

            });

            //Listitem to Listbox2 

            foreach (Diem title in listItem)
            {
                ListBox2.Items.Add(Convert.ToString(title.MaMonHoc1 + "\t" + title.MaSinhVien1 + "\t" + title.DiemTrungBinh1 + "\t" + title.HocKy1));
            }


        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        //Connecddt to ListSharePoint 
        //  SPList list = OpenList(); 


        //Get all Listitem from ListSharePoint 
        //    List<GiangVien> listItem = new List<GiangVien>();

        //        if (curItem == GIANGVIEN)
        //        {
        //             SPSecurity.RunWithElevatedPrivileges(delegate()
        //                {

        //                    SPSite site = new SPSite(siteUrl);
        //                    SPWeb web = site.OpenWeb();
        //                    SPList list = web.Lists[GIANGVIEN];
        //                    //return list;             

        //                    foreach (SPListItem item in list.Items)
        //                    {
        //                        GiangVien g1 = new GiangVien();
        //                        g1.Msv1 = Convert.ToInt32(item["Msv"]);  
        //                        g1.Tengiangvien1 = Convert.ToString(item["Tengiangvien"]) ; 
        //                        g1.Diachi1 = Convert.ToString (item["Diachi"]); 
        //                        //Console.WriteLine("Giang vien:{0} Ten giang vien{1} Dia chi{2}", item["Msv"], item["Tengiangvien"], item["Diachi"]);
        //                        listItem.Add(g1);
        //                    }

        //                });

        //        }




        //    //Listitem to Listbox2 
        //    foreach (GiangVien title in listItem)
        //    {
        //        ListBox2.Items.Add(Convert.ToString(title.Msv1  +"\t"  +title.Tengiangvien1 + "\t" +title.Diachi1));
        //    }
        //}


        // }


    }



}