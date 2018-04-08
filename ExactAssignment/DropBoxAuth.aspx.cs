using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ExactAssignment.BLL;

namespace ExactAssignment
{
    public partial class DropBoxAuth : System.Web.UI.Page
    {
        protected string CodeReturned = "false";

        protected async void Page_Load(object sender, EventArgs e)
        {
            //*** Check If it's called from Site Page
            if (Request.QueryString["Code"] == null)
            {
                //*** get access token                        
                Response.Redirect((DropBoxConnector.getAccessTokenURL(System.Configuration.ConfigurationManager.AppSettings["dropBoxAppKey"], System.Configuration.ConfigurationManager.AppSettings["dropBoxAppSecret"], HttpContext.Current.Session["dropBoxReturnBackURL"].ToString())).ToLower(), false);
            }
            else   //**** Get Code from Auth Provider
            {
                //*** Check If Code returned into Connection String
                if (Application["dropBoxAccessToken"] == null && !String.IsNullOrEmpty(Request.QueryString["Code"]))
                {
                    //**** Initialize Session Folder Path
                    List<string> Dump = new List<string> { };
                    Session["FolderPath"] = Dump;

                    await DropBoxConnector.getAccessTokenFromResponse(Request.QueryString["Code"], System.Configuration.ConfigurationManager.AppSettings["dropBoxAppKey"], System.Configuration.ConfigurationManager.AppSettings["dropBoxAppSecret"], HttpContext.Current.Session["dropBoxReturnBackURL"].ToString().ToLower());

                    if (DropBoxConnector.MsgError == "")
                    {
                        //*** Get Token
                        Application["dropBoxAccessToken"] = DropBoxConnector.dropBoxAccessToken;

                        //**** Close & Refresh parent
                        CodeReturned = "true";
                    }
                    else   //*** If Error returned
                    {
                        Response.Write(DropBoxConnector.MsgError);
                    }
                }                
            }
        }
    }
}