using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharePointForm
{
    public partial class Form1 : Form
    {

        static string siteUrl = "http://thangnv:1000/";

        static string ObjectList = "";
        static string DIEM = "Diem";
        static string MONHOC = "Monhoc";

        static string SINHVIEN = "Sinhvien";

        public Form1()
        {
            InitializeComponent();
        }

        //AddItem 
        private void button1_Click(object sender, EventArgs e)
        {

            if (ObjectList == SINHVIEN)
            {

                AddSinhVien();

            }

            if (ObjectList == MONHOC)
            {

                AddMonHoc();

            }
            if (ObjectList == DIEM)
            {

                AddDiem();

            }

        }

        private void AddMonHoc()
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[MONHOC];
            //return list;             
            SPListItem listitem = list.Items.Add();

            MonHoc monHoc = new MonHoc();
            monHoc.MaMonHoc1 = Convert.ToInt32(textBox1.Text);
            monHoc.TenMonHoc1 = textBox2.Text;
            monHoc.SoTinChi1 = Convert.ToInt32(textBox3.Text);
            //sinhVien.HeDaoTao1 = textBox4.Text;

            listitem["Mamonhoc"] = monHoc.MaMonHoc1;
            listitem["TenMonHoc"] = monHoc.TenMonHoc1;
            listitem["Sotinchi"] = monHoc.SoTinChi1;

            listitem.Update();
            MessageBox.Show("Them Thanh cong ");
            ListMonHoc();
        }

        private void AddDiem()
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();


            //SPList listSinhvien= web.Lists[SINHVIEN];
            //SPListItem sinhVien = listSinhvien.GetItems(); 




            SPList listDiem = web.Lists[DIEM];
            SPListItem listitem = listDiem.AddItem();



            Diem diem = new Diem();
            // diem.MaMonHoc1 = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            // diem.MaSinhVien1 = Convert.ToInt32(comboBox2.SelectedItem.ToString()); 
            diem.DiemTrungBinh1 = Convert.ToDouble(textBox5.Text);
            diem.HocKy1 = Convert.ToString(textBox6.Text);
            // SPFieldLookupValue value = new SPFieldLookupValue(Convert.ToInt32(comboBox1.SelectedItem.ToString()), comboBox1.Text);
            //listitem["Mamonhoc"] = new SPFieldLookupValue(item.ID, item.Title);



            string textMonHoc = comboBox1.SelectedItem.ToString();
            string[] splitMonHoc = textMonHoc.Split('\t');
            int ID = Convert.ToInt32(splitMonHoc[1]);
            string valueMonHoc = splitMonHoc[0];


            string textSinhVien = comboBox2.SelectedItem.ToString();
            string[] splitSinhVien = textSinhVien.Split('\t');
            int IDSinhVien = Convert.ToInt32(splitSinhVien[1]);
            string valueSinhvien = splitSinhVien[0];



            listitem["Mamonhoc"] = new SPFieldLookupValue(ID, valueMonHoc);
            listitem["Msv"] = new SPFieldLookupValue(IDSinhVien, valueSinhvien);


            listitem["DiemTrungBinh"] = diem.DiemTrungBinh1;
            listitem["HocKy"] = diem.HocKy1;

            listitem.Update();

            //cap nhap lai danh sach 
            ListDiem();
            MessageBox.Show("Them Thanh cong ");


        }

        private void AddSinhVien()
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();

            SPList list = web.Lists[SINHVIEN];

            SPListItem listitem = list.Items.Add();


            SinhVien sinhVien = new SinhVien();
            sinhVien.Msv1 = Convert.ToInt32(textBox1.Text);
            sinhVien.Tensinhvien1 = textBox2.Text;
            sinhVien.Khoa1 = textBox3.Text;
            sinhVien.HeDaoTao1 = textBox4.Text;


            listitem["Msv"] = sinhVien.Msv1;
            listitem["Tensinhvien"] = sinhVien.Tensinhvien1;
            listitem["Khoa"] = sinhVien.Khoa1;
            listitem["Hedaotao"] = sinhVien.HeDaoTao1;

            listitem.Update();
            MessageBox.Show("Them Thanh cong ");
        }
        //List Sinh Vien 
        private void button5_Click(object sender, EventArgs e)
        {

            ListSinhVien();


        }
        private void AddMaSinhVientoComBox()
        {

            comboBox2.Items.Clear();

            List<SinhVien> listItem = new List<SinhVien>();


            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[SINHVIEN];

            foreach (SPListItem item in list.Items)
            {
                SinhVien g1 = new SinhVien();
                g1.Msv1 = Convert.ToInt32(item["Msv"]);
                //add Id 
                g1.Id1 = Convert.ToInt32(item.ID.ToString());
                listItem.Add(g1);
            }
            foreach (SinhVien sinhVien in listItem)
            {
                comboBox2.Items.Add(Convert.ToString(sinhVien.Msv1 + "\t" + sinhVien.Id1));
            }
        }


        private void ListSinhVien()
        {
            ObjectList = SINHVIEN;
            listBox1.Items.Clear();

            List<SinhVien> listItem = new List<SinhVien>();


            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[SINHVIEN];

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

            //listBox1.DataSource = listItem;
            //  listBox1.DataBindings = listItem;  
            //Listitem to listBox1 
            foreach (SinhVien title in listItem)
            {

                listBox1.Items.Add(Convert.ToString(title.Msv1 + "\t" + title.Tensinhvien1 + "\t" + title.Khoa1 + "\t" + title.HeDaoTao1));

            }
        }
        //List MonHoc
        private void button6_Click(object sender, EventArgs e)
        {

            ListMonHoc();


        }

        private void ListMonHoc()
        {
            //Click MonHoc
            ObjectList = MONHOC;
            listBox1.Items.Clear();
            // listBox1 = null;
            List<MonHoc> listItem = new List<MonHoc>();

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



            //Listitem to listBox1 
            foreach (MonHoc title in listItem)
            {
                listBox1.Items.Add(Convert.ToString(title.MaMonHoc1 + "\t" + title.TenMonHoc1 + "\t" + title.SoTinChi1));
            }
        }

        //List Diem
        private void button7_Click(object sender, EventArgs e)
        {

            ListDiem();
            AddMaMonHoctoComboBox();
            AddMaSinhVientoComBox();
        }

        private void AddMaMonHoctoComboBox()
        {
            comboBox1.Items.Clear();
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();

            List<MonHoc> listItem = new List<MonHoc>();
            SPList list = web.Lists[MONHOC];

            foreach (SPListItem item in list.Items)
            {
                MonHoc g1 = new MonHoc();
                g1.MaMonHoc1 = Convert.ToInt32(item["Mamonhoc"]);

                g1.Id1 = Convert.ToInt32(item.ID.ToString());
                listItem.Add(g1);
            }
            //Listitem to listBox1 
            foreach (MonHoc a in listItem)
            {

                comboBox1.Items.Add(Convert.ToString(a.MaMonHoc1 + "\t" + a.Id1));
            }
        }

        private void ListDiem()
        {
            //Click Diem 
            ObjectList = DIEM;
            listBox1.Items.Clear();



            List<Diem> listItem = new List<Diem>();
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[DIEM];



            foreach (SPListItem item in list.Items)
            {
                Diem g1 = new Diem();
                SPFieldLookupValue valueMaMonHoc = new SPFieldLookupValue(item["Mamonhoc"].ToString());
                g1.MaMonHoc1 = (int)Convert.ToDouble(valueMaMonHoc.LookupValue);
                ////string abd = value.LookupValue;

                try
                {
                    // Do not initialize this variable here.
                    SPFieldLookupValue value1 = new SPFieldLookupValue(item["Msv"].ToString());
                    g1.MaSinhVien1 = (int)Convert.ToDouble(value1.LookupValue);
                }
                catch (System.Exception)
                {
                }
                // Error: Use of unassigned local variable 'n'.



                g1.DiemTrungBinh1 = Convert.ToDouble(item["DiemTrungBinh"]);
                g1.HocKy1 = Convert.ToString(item["HocKy"]);

                //listItem.Add(g1);

                listBox1.Items.Add(g1.MaMonHoc1 + "\t" + g1.MaSinhVien1 + "\t" + g1.DiemTrungBinh1 + "\t" + g1.HocKy1);

            }



            //Listitem to listBox1 

            //foreach (Diem title in listItem)
            //{
            //    listBox1.Items.Add(Convert.ToString(title.MaMonHoc1 + "\t" + title.MaSinhVien1 + "\t" + title.DiemTrungBinh1 + "\t" + title.HocKy1));
            //}


        }

        //SelectedIndexChanged --Listbox item 
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObjectList == SINHVIEN)
            {

                //TextBoxNull(); 
                string text = listBox1.SelectedItem.ToString();

                //MessageBox.Show(listBoxTopics.SelectedValue.ToString());
                //text = listBox1.SelectedValue.ToString();
              
                    string[] split = text.Split('\t');
                    textBox1.Text = split[0];
                    textBox2.Text = split[1];
                    textBox3.Text = split[2];
                    textBox4.Text = split[3];
               

            }
            if (ObjectList == MONHOC)
            {
                string text = listBox1.SelectedItem.ToString();

                //MessageBox.Show(listBoxTopics.SelectedValue.ToString());
                //text = listBox1.SelectedValue.ToString();
               
                    string[] split = text.Split('\t');
                    textBox1.Text = split[0];
                    textBox2.Text = split[1];
                    textBox3.Text = split[2];
             

            }
            if (ObjectList == DIEM)
            {

                string text = listBox1.SelectedItem.ToString();
                

                //string[] splitTextCombobox = textCombobox.Split('\t'); 
                //MessageBox.Show(listBoxTopics.SelectedValue.ToString());
                //text = listBox1.SelectedValue.ToString();
                
                try
                {
                    string[] split = text.Split('\t');
                    //textBox1.Text = split[0];
                    //textBox2.Text = split[1];
                    textBox5.Text = split[2];
                    textBox6.Text = split[3];
                }
                catch (SystemException)
                {

                }
                

            }
        }

        //Edit item 
        private void button2_Click(object sender, EventArgs e)
        {
            if (ObjectList == SINHVIEN)
            {
                EditSinhVien();

            }
            if (ObjectList == MONHOC)
            {

                EditMonHoc();
            }

            //Edit Diem 
            if (ObjectList == DIEM)
            {
                EditDiem();
            }
        }

        private void EditSinhVien()
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[SINHVIEN];

            //SPListItem listitem = list.Items.Add();

            SPListItem listitem = list.Items[listBox1.SelectedIndex];

            SinhVien sinhVien = new SinhVien();
            sinhVien.Msv1 = Convert.ToInt32(textBox1.Text);
            sinhVien.Tensinhvien1 = textBox2.Text;
            sinhVien.Khoa1 = textBox3.Text;
            sinhVien.HeDaoTao1 = textBox4.Text;

            listitem["Msv"] = sinhVien.Msv1;
            listitem["Tensinhvien"] = sinhVien.Tensinhvien1;
            listitem["Khoa"] = sinhVien.Khoa1;
            listitem["Hedaotao"] = sinhVien.HeDaoTao1;


            listitem.Update();


            ObjectList = SINHVIEN;
            listBox1.Items.Clear();
            List<SinhVien> listItem = new List<SinhVien>();
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


            foreach (SinhVien title in listItem)
            {
                listBox1.Items.Add(Convert.ToString(title.Msv1 + "\t" + title.Tensinhvien1 + "\t" + title.Khoa1 + "\t" + title.HeDaoTao1));

            }
        }

        private void EditMonHoc()
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[MONHOC];
            //return list;             
            SPListItem listitem = list.Items[listBox1.SelectedIndex];

            MonHoc monHoc = new MonHoc();
            monHoc.MaMonHoc1 = Convert.ToInt32(textBox1.Text);
            monHoc.TenMonHoc1 = textBox2.Text;
            monHoc.SoTinChi1 = Convert.ToInt32(textBox3.Text);
            //sinhVien.HeDaoTao1 = textBox4.Text;

            listitem["Mamonhoc"] = monHoc.MaMonHoc1;
            listitem["TenMonHoc"] = monHoc.TenMonHoc1;
            listitem["Sotinchi"] = monHoc.SoTinChi1;




            listitem.Update();

            //Edit MonHoc
            ObjectList = MONHOC;
            listBox1.Items.Clear();
            List<MonHoc> listItem = new List<MonHoc>();
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



            //Listitem to listBox1 
            foreach (MonHoc title in listItem)
            {
                listBox1.Items.Add(Convert.ToString(title.MaMonHoc1 + "\t" + title.TenMonHoc1 + "\t" + title.SoTinChi1));
            }
        }

        private void EditDiem()
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[DIEM];

            //SPListItem listitem = list.Items.Add();

            SPListItem listitem = list.Items[listBox1.SelectedIndex];

            Diem diem = new Diem();

            diem.DiemTrungBinh1 = Convert.ToDouble(textBox5.Text);
            diem.HocKy1 = Convert.ToString(textBox6.Text);


            string textMonHoc = comboBox1.SelectedItem.ToString();
            string[] splitMonHoc = textMonHoc.Split('\t');
            int ID = Convert.ToInt32(splitMonHoc[1]);
            string valueMonHoc = splitMonHoc[0];


            string textSinhVien = comboBox2.SelectedItem.ToString();
            string[] splitSinhVien = textSinhVien.Split('\t');
            int IDSinhVien = Convert.ToInt32(splitSinhVien[1]);
            string valueSinhvien = splitSinhVien[0];

            listitem["Mamonhoc"] = new SPFieldLookupValue(ID, valueMonHoc);
            listitem["Msv"] = new SPFieldLookupValue(IDSinhVien, valueSinhvien);


            listitem["DiemTrungBinh"] = diem.DiemTrungBinh1;
            listitem["HocKy"] = diem.HocKy1;


            listitem.Update();

            ObjectList = DIEM;
            listBox1.Items.Clear();
            List<Diem> listItem = new List<Diem>();
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


            foreach (Diem title in listItem)
            {
                listBox1.Items.Add(Convert.ToString(title.MaMonHoc1 + "\t" + title.MaSinhVien1 + "\t" + title.DiemTrungBinh1 + "\t" + title.HocKy1));
            }
        }

        //Delete Item from list 
        private void button3_Click(object sender, EventArgs e)
        {
            if (ObjectList == SINHVIEN)
            {
                DeleteSinhVien();

            }


            if (ObjectList == MONHOC)
            {
                DeleteMonHoc();


            }
            if (ObjectList == DIEM)
            {
                DeleteDiem();
            }

        }

        private void DeleteSinhVien()
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[SINHVIEN];
            //SPListItem listitem = list.Items.Add();

            SPListItem listitem = list.Items[listBox1.SelectedIndex];

            listitem.Delete();
            TextBoxNull();

            ObjectList = SINHVIEN;
            listBox1.Items.Clear();
            List<SinhVien> listItem = new List<SinhVien>();
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

            //listBox1.DataSource = listItem;
            //  listBox1.DataBindings = listItem;  
            //Listitem to listBox1 
            foreach (SinhVien title in listItem)
            {
                listBox1.Items.Add(Convert.ToString(title.Msv1 + "\t" + title.Tensinhvien1 + "\t" + title.Khoa1 + "\t" + title.HeDaoTao1));

            }
        }

        private void DeleteMonHoc()
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[MONHOC];
            //SPListItem listitem = list.Items.Add();
            SPListItem listitem = list.Items[listBox1.SelectedIndex];
            listitem.Delete();
            TextBoxNull();

            ObjectList = MONHOC;
            listBox1.Items.Clear();
            // listBox1 = null;

            List<MonHoc> listItem = new List<MonHoc>();
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

            //Listitem to listBox1 
            foreach (MonHoc title in listItem)
            {
                listBox1.Items.Add(Convert.ToString(title.MaMonHoc1 + "\t" + title.TenMonHoc1 + "\t" + title.SoTinChi1));
            }
        }

        private void DeleteDiem()
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[DIEM];


            SPListItem listitem = list.Items[listBox1.SelectedIndex];
            listitem.Delete();
            TextBoxNull();

            ObjectList = DIEM;
            listBox1.Items.Clear();
            ListDiem();
            //List<Diem> listItem = new List<Diem>();

            ////return list;            
            //foreach (SPListItem item in list.Items)
            //{
            //    Diem g1 = new Diem();
            //    //  g1.MaMonHoc1 = Convert.ToInt32(item["Mamonhoc"]);
            //    SPFieldLookupValue value = new SPFieldLookupValue(item["Mamonhoc"].ToString());
            //    g1.MaMonHoc1 = (int)Convert.ToDouble(value.LookupValue);
            //    //string abd = value.LookupValue;

            //    SPFieldLookupValue value1 = new SPFieldLookupValue(item["Msv"].ToString());

            //    g1.MaSinhVien1 = (int)Convert.ToDouble(value1.LookupValue);

            //    g1.DiemTrungBinh1 = Convert.ToDouble(item["DiemTrungBinh"]);
            //    g1.HocKy1 = Convert.ToString(item["HocKy"]);

            //    listItem.Add(g1);
            //}

            ////Listitem to listBox1 

            //foreach (Diem title in listItem)
            //{
            //    listBox1.Items.Add(Convert.ToString(title.MaMonHoc1 + "\t" + title.MaSinhVien1 + "\t" + title.DiemTrungBinh1 + "\t" + title.HocKy1));
            //}
        }

        private void TextBoxNull()
        {
            textBox1 = null;
            textBox2 = null;
            textBox3 = null;
            textBox4 = null;
        }


    }
}
