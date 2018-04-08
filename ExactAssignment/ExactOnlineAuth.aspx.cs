using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExactAssignment
{
    public partial class ExactOnlineAuth : System.Web.UI.Page
    {
        protected string CodeReturned = "false";

        protected void Page_Load(object sender, EventArgs e)
        {
            //*** Check If it's called from Site Page
            if (Request.QueryString["Code"] == null)
            {                           
                Uri AuthorizationEndpoint = new Uri(string.Format("{0}/api/oauth2/auth?client_id={1}&redirect_uri={2}&response_type=code&force_login=1", System.Configuration.ConfigurationManager.AppSettings["exactOnlineEndPoint"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientId"], HttpUtility.UrlEncode(HttpContext.Current.Session["exactOnlineReturnBackURL"].ToString())));
                 
                //*** Open Authentication window
                Response.Redirect(AuthorizationEndpoint.AbsoluteUri);
            }
            else   //**** Get Code from Auth Provider
            {
                Session["ExactOnlineReturnCode"] = HttpContext.Current.Request.Url.AbsoluteUri;       
     
                //**** Close & Refresh parent
                CodeReturned = "true";
            }
        }
    }
}