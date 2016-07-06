using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DemoThangSharePoint
{
    public partial class ucTest : UserControl
    {
        public string ten = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ten = "Hungnc";
        }
    }
}
