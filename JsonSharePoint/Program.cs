using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Include ; 

using Newtonsoft;

//Include 
using System.IO;
using System.Web.Script.Serialization;
using System.Dynamic;
using System.Collections;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.SharePoint;
using System.Data;


namespace JsonSharePoint
{

    public class Rootobject
    {
        public DM_CSYT_2[] DM_CSYT_2 { get; set; }
    }
    public class DM_CSYT_2
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

    class Program
    {

        static string SITE_URl = "http://thangnv:1000/";

        static string LIST_NAME = "DM_CSYT_2";     
        static void Main(string[] args)
        {
            //AddToList(SITE_URl, LIST_NAME); 
          
            //Get all Item and nghi to FileJson
            //GetALLItemFromList(SITE_URl, LIST_NAME);          
            Console.ReadKey();
        }    
        //Return listObject DM_CSYT_2 ; 
        private static List<DM_CSYT_2> ListObject()
        {
            string json = File.ReadAllText(@"E:\\DM_BoNganhVietNam.json");
            List<DM_CSYT_2> list = new List<DM_CSYT_2>();
            JObject o = JObject.Parse(json);
            List<JToken> result = o["DM_CSYT_2"].ToList();
            foreach (JToken item in result)
            {
                JObject obj = JObject.Parse(item.ToString());

                DM_CSYT_2 user = new DM_CSYT_2();
                user.MaBoNganh = (string)obj["Mã Bộ, Ngành"];
                user.TenBoNganh = (string)obj["Tên Bộ, Ngành"];
                user.CanCu = (string)obj["Căn cứ"];
                user.HieuLucTuNgay = (string)obj["Hiệu lực từ ngày"];
                user.NgayHetHieuLuc = (string)obj["Ngày hết hiệu lực"];

                //user.Print();

                list.Add(user);
            }
            return list;
        }
        public static void GetALLItemFromList(string siteUrl, string listName)
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[listName];
            //Get all item from ListName

            List<DM_CSYT_2> listOject = new List<DM_CSYT_2>();           
            SPListItemCollection collItem = list.Items;

            Rootobject root = new Rootobject();
            root.DM_CSYT_2 = new DM_CSYT_2[list.ItemCount];

            //DM_CSYT_2[] array = new DM_CSYT_2[list.ItemCount];

            int indexItem = 0;
            foreach (SPListItem item in collItem)
            {
                DM_CSYT_2 user = new DM_CSYT_2();
                user.MaBoNganh = item["Ma"].ToString();
                user.TenBoNganh = item["Ten"].ToString();

                user.CanCu = item["Cancu"].ToString();
                user.HieuLucTuNgay = item["Hieuluc"].ToString();
                user.NgayHetHieuLuc = item["Ngayhet"].ToString();
                                                                                   
                root.DM_CSYT_2[indexItem] = user;
                indexItem++; 
            }
                                  
            string output = JsonConvert.SerializeObject(root, Formatting.Indented);          
           
            File.AppendAllText(@"E:\DM_CSYT_2.json", output);

            



        }
        public static void AddToList(string siteUrl, string listName)
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists[listName];
            //return list;                         
            List<DM_CSYT_2> listOject = ListObject(); 


            //sinhVien.HeDaoTao1 = textBox4.Text;
            foreach (var item in listOject)
            {
                SPListItem listitem = list.Items.Add();
                listitem["Ma"] = item.MaBoNganh;
                listitem["Ten"] = item.TenBoNganh;
                listitem["Cancu"] = item.CanCu;
                listitem["Hieuluc"] = item.HieuLucTuNgay;
                listitem["Ngayhet"] = item.NgayHetHieuLuc;
                listitem.Update(); 

            }        
           
        }


    }


}
