using cSharePoint2013.cWebpart;
using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace ThangSharePoint.Test
{
    [ToolboxItemAttribute(false)]

    public partial class Test : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Test()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {

            if (IdFileUpload.HasFile)
            {
                SaveFile(IdFileUpload.PostedFile);
                // IdFileUpload.SaveAs(Server.)
                StatusLabel.Text = "File Update";

            }
            else
            {
                StatusLabel.Text = "file not Uploads";
            }
            string nameFile = IdFileUpload.FileName;

            string dictoryFile = "@C:\\temp\\uploads\\" + nameFile;

            //Add json toList
            ReadFile(dictoryFile);

        }


        void ReadFile(string fileName)
        {
               string SITE_URl = "http://thangnv:1000/";

            string LIST_NAME = "DM_CSYT_2"; 
            Rootobject.AddToList(SITE_URl, LIST_NAME, fileName);
        }


        void SaveFile(HttpPostedFile file)
        {
            // Specify the path to save the uploaded file to.
            string savePath = "c:\\temp\\uploads\\";

            // Get the name of the file to upload.
            string fileName = IdFileUpload.FileName;

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
            IdFileUpload.SaveAs(savePath);

        }








    }
}
