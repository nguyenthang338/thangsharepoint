using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DemoThangSharePoint
{
    public partial class ucDemo : UserControl
    {
        public string ten = "";
        public int tuoi = 0;
        public static string fileContents = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ten = "thangnv";
            tuoi = 23;
            DataTable dt1 = CreateDataTable();

            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
        protected void UploadFile(object sender, EventArgs e)
        {
            
            if (FileUpload1.HasFile)
            {
                fileContents = ""; 
                string nameFile = FileUpload1.FileName;
                StreamReader streamReader = new StreamReader(FileUpload1.PostedFile.InputStream);

                while (!streamReader.EndOfStream)
                {
                    fileContents = streamReader.ReadToEnd();
                }
                Label1.Text = "File Update";
                ReadFileToListSharePoint(fileContents);
                FillToGridView(fileContents);
            }
            else
            {
                Label1.Text = "file not Uploads";
            }
        
            //Add json toList
            
        }
       
        protected void SaveToExcel(object sender, EventArgs e)
        {
            ExportToExcel(); 
        }
        public void ExportToExcel()
        {

            string fileName = "FileName.json";
            string SITE_URl = "http://thangnv:1000/"; 
             string LIST_NAME = "DM_CSYT_2";


             string str; 
            str = Rootobject.GetALLItemFromList(SITE_URl, LIST_NAME); //.ToString();

            Response.Clear();
            Response.AddHeader("content-disposition",
                     "attachment;filename="+fileName);
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.json";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite =
                          new HtmlTextWriter(stringWrite);

            Response.Write(str.ToString());
            Response.End();

        } 
        private void FillToGridView(string fileContents)
        {
            List<DM_CSYT_2> list = Rootobject.ListObject(fileContents);
            DataTable dt = CreateDataTable();

            foreach (var item in list)
            {
                dt.Rows.Add(item.MaBoNganh, item.TenBoNganh, item.CanCu, item.HieuLucTuNgay, item.NgayHetHieuLuc);
                dt.AcceptChanges();
                //GridView1.DataSource = dt;
                //GridView1.DataBind(); 
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        
        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaBoNganh");
            dt.Columns.Add("TenBoNganh");
            dt.Columns.Add("CanCu");
            dt.Columns.Add("HieuLucTuNgay");
            dt.Columns.Add("NgayHetHieuLuc");
            dt.AcceptChanges();
            return dt;

        }
        public void InsertRecords()
        {


        }
        protected void ReadFileToListSharePoint(string fileContents)
        {
            string SITE_URl = "http://thangnv:1000/";
            string LIST_NAME = "DM_CSYT_2";
            Rootobject.AddToList(SITE_URl, LIST_NAME, fileContents);
        }
        void SaveFile(HttpPostedFile file)
        {
            // Specify the path to save the uploaded file to.
            //string url = "/UserControl/ucTest.ascx";
            string savePath = "C:\\temp\\uploads\\";

            // Get the name of the file to upload.
            string fileName = FileUpload1.FileName;

            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                    //StatusLabel.Text = "File Update da ton tai !!"; 
                }

                fileName = tempfileName;

                // Notify the user that the file name was changed.
                //UploadStatusLabel.Text = "A file with the same name already exists." +
                //    "<br />Your file was saved as " + fileName;
            }
            else
            {
                //// Notify the user that the file was saved successfully.
                //UploadStatusLabel.Text = "Your file was uploaded successfully.";
            }

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            FileUpload1.SaveAs(savePath);

        }




    }
}
