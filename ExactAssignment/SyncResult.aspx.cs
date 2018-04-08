using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExactAssignment
{
    public partial class SyncResult : System.Web.UI.Page
    {
        protected string strSiteBaseURL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                strSiteBaseURL = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
                if (HttpContext.Current.Request.Url.Port > 0) { strSiteBaseURL += ":" + HttpContext.Current.Request.Url.Port.ToString(); };
            }
        }
    }
}