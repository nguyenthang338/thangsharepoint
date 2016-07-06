using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace SharePoint
{
    public class SharePointWeb
    {
        public static String siteUrl = "http://thangnv:1000/";
        public static List<String> LoadTitleofListSharePoint(String siteUrl)
        {
            List<string> listSharePoint = new List<string>();
            using (ClientContext myContext = new ClientContext(siteUrl))
            {
                myContext.Load(myContext.Web, web => web.Lists.Include(list => list.Title).Where(field => field.Hidden == false));
                myContext.ExecuteQuery();

                //List listSharePoint; 
                // =  myContext.Web.Lists; 
                foreach (List list in myContext.Web.Lists)
                {
                    Console.WriteLine("\n" + list.Title);
                    // listSharePoint.AddItem(list.Title); 
                    //list = lbMyListBox.Items.OfType<string>().ToList();
                    listSharePoint.Add(list.Title);
                }

                return listSharePoint;
            }
        }


        //public  static  List<String> listField (String title)
        //{

        //    //List<string> listSharePoint = new List<string>();
        //    //using (ClientContext myContext = new ClientContext(siteUrl))
        //    //{
        //    //    myContext.Load(myContext.Web, web => web.Lists.Include(list => list.Title).Where(field => field.Hidden == true));
        //    //    myContext.ExecuteQuery();

        //    //    //List listSharePoint; 
        //    //    // =  myContext.Web.Lists; 
        //    //    foreach (List list in myContext.Web.Lists)
        //    //    {
        //    //        Console.WriteLine("\n" + list.Title.);
        //    //        // listSharePoint.AddItem(list.Title); 
        //    //        //list = lbMyListBox.Items.OfType<string>().ToList();
        //    //        listSharePoint.Add(list.Title);
        //    //    }

        //    //    return listSharePoint;
        //    //}


        //}


         
        public static void AddRecord(String siteUrl)
        {
            SPList list = OpenListProduct(siteUrl);

            //  Msv
            //Tengiangvien
            //Diachi
            SPListItem listitem = list.Items.Add();
            listitem["Msv"] = 100;
            listitem["Tengiangvien"] = "Nguyen Van Thang";
            listitem["Diachi"] = "Thanh Oai-Ha Noi";
            listitem.Update();

            Console.WriteLine("Add records have added");

        }

        private static SPList OpenListProduct(String siteUrl)
        {
            SPSite site = new SPSite(siteUrl);
            SPWeb web = site.OpenWeb();
            SPList list = web.Lists["Giangvien"];
            return list;
        }
        public static List<string>  ReadListItem(String siteUrl)
        {
            SPList list = OpenListProduct(siteUrl);
            List<string>  listItem = new List<string>() ; 
            foreach (SPListItem item in list.Items)
            {
                //Console.WriteLine("Giang vien:{0} Ten giang vien{1} Dia chi{2}", item["Msv"], item["Tengiangvien"], item["Diachi"]);
                listItem.Add((String) item["Msv"] +item["Tengiangvien"]+ item["Diachi"]); 

            }
            return listItem; 
        }

        //Delete Item of SharePoint 
        public static void DeleteItem(String siteUrl)
        {
            SPList list = OpenListProduct(siteUrl);

            foreach (SPListItem item in list.Items)
            {

                item.Delete();
                item.Update();
            }

        }


        //Edit List SharePoint
        public static void EditItem(String siteUrl)
        {
            SPList list = OpenListProduct(siteUrl);

            //SPListItem listitem = list.Items.Add();

            foreach (SPListItem item in list.Items)
            {
                if (Convert.ToInt32(item["Msv"]) == 100)
                {

                    item["Msv"] = 200;
                    item["Tengiangvien"] = "Hello World";
                    item["Diachi"] = "Thanh Oai-Ha Noi";
                    item.Update();
                }
                //Console.WriteLine("Giang vien:{0} Ten giang vien{1} Dia chi{2}", item["Msv"], item["Tengiangvien"], item["Diachi"]);
            }

        }


    }
}