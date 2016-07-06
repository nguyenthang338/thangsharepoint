using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace DemoThangSharePoint
{
    [ToolboxItemAttribute(false)]
    public class wpTest : WebPart
    {
        protected override void CreateChildControls()
        {
            string url = "/UserControl/ucTest.ascx";
            string urlDemo = "/UserControl/ucDemo.ascx";
            if (1 > 2)
            {
                ucTest userControl = (ucTest)this.Page.LoadControl(url);
                this.Controls.Add(userControl);
            }
            else {
                ucDemo userControl = (ucDemo)this.Page.LoadControl(urlDemo);
                this.Controls.Add(userControl);
            }
        }
    }
}
