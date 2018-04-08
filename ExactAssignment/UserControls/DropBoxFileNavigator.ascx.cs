using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using CuteWebUI;
using ExactAssignment.BLL;

namespace ExactAssignment.Controls
{
    public partial class DropBoxFileNavigator : System.Web.UI.UserControl
    {
        

        protected async void Page_Load(object sender, EventArgs e)
        {
            //*** Initialization
            divDropBoxAlert.Visible = false;
            lnkbtnConnectDropBox.Visible = false;
            lnkbtnDisconnectDropBox.Visible = false;
            divFileGrid.Visible = false;
            pnlDownload.Visible = false;

            //*** First Time
            if (!Page.IsPostBack)
            {
                //*** Check If Code returned into Connection String
                if (Application["dropBoxAccessToken"] == null && !String.IsNullOrEmpty(Request.QueryString["Code"]))
                {
                    //**** Initialize Session Folder Path
                    List<string> Dump = new List<string> { };
                    Session["FolderPath"] = Dump;

                    await DropBoxConnector.getAccessTokenFromResponse(Request.QueryString["Code"], System.Configuration.ConfigurationManager.AppSettings["dropBoxAppKey"], System.Configuration.ConfigurationManager.AppSettings["dropBoxAppSecret"], HttpContext.Current.Session["returnBackURL"].ToString());

                    if (DropBoxConnector.MsgError == "")
                    {
                        //*** Get Token
                        Application["dropBoxAccessToken"] = DropBoxConnector.dropBoxAccessToken;
                    }
                    else   //*** If Error returned
                    {
                        lblDropBoxMsg.Text = DropBoxConnector.MsgError;

                        //*** Show Error
                        divDropBoxAlert.Visible = true;
                    }
                }
                //******************************************************


                //*** Check dropBox Aurhentication Token
                if (Application["dropBoxAccessToken"] == null)
                {

                    //***************************
                    //*** access token is empty
                    //***************************
                    //*** 1. Check first for dropBox App Key & App secret
                    if (String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["dropBoxAppKey"]) ||
                        String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["dropBoxAppSecret"]))
                    {
                        //*** Show Error Message
                        lblDropBoxMsg.Text = "Please set app key and secret in this project's Web.config file and restart. " +
                                               "App key/secret can be found in the Dropbox App Console, here: " +
                                               "https://www.dropbox.com/developers/apps";

                        //*** Show Error
                        divDropBoxAlert.Visible = true;

                        return;
                    }
                    else   //*** AppKey & secret exist
                    {
                        //*** Show Connect to DropBox button
                        lnkbtnConnectDropBox.Visible = true;
                    }

                }
                else
                {
                    //*** Get DropBox Client Object
                    Application["dropBoxClientObj"] = DropBoxConnector.getDropboxClient(Application["dropBoxAccessToken"].ToString());

                    if (DropBoxConnector.MsgError != "")    //*** If error
                    {
                        lblDropBoxMsg.Text = DropBoxConnector.MsgError;

                        //*** Show Error
                        divDropBoxAlert.Visible = true;
                    }
                    else
                    {
                        //*** Get User Info
                        await DropBoxConnector.getUserInfo(Application["dropBoxClientObj"]);
                        lblAccountName.Text = DropBoxConnector.objDropBoxUser.AccountDisplayName;

                        DropBoxGridDataBind((List<string>)Session["FolderPath"]);
                    }
                }
            }
        }

        //**** Connect to dropBox Button Handler
        protected void lnkbtnConnectDropBox_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["returnBackURL"] == null)
            {
                HttpContext.Current.Session["returnBackURL"] = HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("?") <= 0 ? HttpContext.Current.Request.Url.AbsoluteUri.ToLower() : HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("?") + 1).ToLower();
            }
            //*** get access token                        
            Response.Redirect(DropBoxConnector.getAccessTokenURL(System.Configuration.ConfigurationManager.AppSettings["dropBoxAppKey"], System.Configuration.ConfigurationManager.AppSettings["dropBoxAppSecret"], HttpContext.Current.Session["returnBackURL"].ToString()));

            return;
        }

        /// <summary>
        //*** Bind DropBox Data Grid
        /// </summary>
        /// <param name="FolderPath">Folder Path in Array Format</param>
        /// <returns></returns>
        private async void DropBoxGridDataBind(List<string> FolderPath = null)
        { 
            //*** Constract Path String
            string strFolderpath = "";
            if (FolderPath != null)
            {
                foreach (var item in FolderPath)
                {
                    strFolderpath += "/" + item;
                }
            }
            
            //*** Bind the Grid & Bread Crumb
            //*** Get Files & Folders List
            List<DropBoxFile> lstDropBoxFile = await DropBoxConnector.ListFolder(Application["dropBoxClientObj"], strFolderpath);

            if (DropBoxConnector.MsgError != "")    //*** If error
            {
                lblDropBoxMsg.Text = DropBoxConnector.MsgError;

                //*** Show Error
                divDropBoxAlert.Visible = true;
            }
            else
            {
                grdVWFilesFolderList.DataSource = lstDropBoxFile;
                grdVWFilesFolderList.DataBind();
                rptFolderBreadCrumb.DataSource = (List<string>)Session["FolderPath"];
                rptFolderBreadCrumb.DataBind();
                divFileGrid.Visible = true;
            }
        }
        //*****************************************************************

        //*****************************************************************
        //*** Drop Box Files Grid Functions
        //*****************************************************************
        //**** Datagrid item bound function
        protected void grdVWFilesFolderList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //*** Add Javascript code for Check boxes on Data Item
            if (e.Row.RowType == DataControlRowType.Header)
            {
                CheckBox cb = (CheckBox)e.Row.Cells[0].FindControl("chkHeader");
                cb.Attributes.Add("onclick", "FileManager.ToggleSelectionForAllItems(event);");
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cb = (CheckBox)e.Row.Cells[0].FindControl("chkItem");
                cb.Attributes.Add("onclick", "FileManager.UnselectHeaderCheckBox(event);");

                LinkButton lb = (LinkButton)e.Row.Cells[1].FindControl("lnkbtnFileName");
                if (lb.Text != "[Root]" && lb.Text != "[Parent]")
                {
                    //lb.Attributes.Add("onmousemove", "FileManager.BeginShowItemInfo(event);");
                    //lb.Attributes.Add("onmouseout", "FileManager.HideItemInfo();");
                    //lb.Attributes.Add("onmouseleave", "FileManager.BeginShowItemInfo(event);");
                }
                else
                {
                    e.Row.Cells[0].Controls.Clear();
                }
            }
        }

        //*** Action on Any Row (Click on Folder Link)
        protected void grdVWFilesFolderList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //*** Construct Folder Path
            ((List<string>)Session["FolderPath"]).Add(e.CommandArgument.ToString());

            //*** Rebind Data Grid Again
            DropBoxGridDataBind(((List<string>)Session["FolderPath"]));
        }
                        
        //*** Action on Any Row of Bread Crumb (Click on Parent Folder Link)
        protected void rptFolderBreadCrumb_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            //*** Make New List
            List<string> tmpFolders = new List<string> { };
            foreach (var item in (List<string>)Session["FolderPath"])
            {
                tmpFolders.Add(item);

                if(item.ToLower() == e.CommandArgument.ToString().ToLower())
                {
                    break;
                }
            }
            Session["FolderPath"] = tmpFolders;

            //*** Rebind Data Grid Again
            DropBoxGridDataBind(((List<string>)Session["FolderPath"]));
        }
        
        //**** Root Button
        protected void lnkbtnRoot_Click(object sender, EventArgs e)
        {
            //*** Empty Construct Folder Path            
            ((List<string>)Session["FolderPath"]).Clear();

            //*** Rebind Data Grid Again
            DropBoxGridDataBind(((List<string>)Session["FolderPath"]));
        }

        //**** Create Folder Button
        protected async void btnPanel2Yes_Click(object sender, EventArgs e)
        {
            //*** Check First if Folder Exist/ Fitsh             
            foreach (GridViewRow row in grdVWFilesFolderList.Rows)
            {
                if(((Label)row.FindControl("lblFileName")).Text.ToLower() == txtFolderName.Text.ToLower() && bool.Parse(((Label)row.FindControl("lblisFolder")).Text.ToLower()))
                {
                    //*** Folder Already Exist
                    lblDropBoxMsg.Text = "Folder already exists with same name";

                    //*** Show Error with grid
                    divDropBoxAlert.Visible = true;
                    divFileGrid.Visible = true;

                    //*** Exit from function
                    return;
                }
            }
            
            //*** Construct Parent Folder Path String            
            string strFolderpath = "";
            if ((List<string>)Session["FolderPath"] != null)
            {
                foreach (var item in (List<string>)Session["FolderPath"])
                {
                    strFolderpath += "/" + item;
                }
            }
            strFolderpath += "/" + txtFolderName.Text;

            //*** Create Folder Function
            bool fnResult = await DropBoxConnector.CreateFolder(Application["dropBoxClientObj"], strFolderpath);

            if (!fnResult)    //*** If error
            {
                lblDropBoxMsg.Text = DropBoxConnector.MsgError;

                //*** Show Error
                divDropBoxAlert.Visible = true;

            }
            else
            {
                //*** Success & Rebind Data Grid Again & Initialize
                txtFolderName.Text = "";
                DropBoxGridDataBind(((List<string>)Session["FolderPath"]));
            }
        }

        //*** Delete Button
        protected async void lnkbtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            //*** Construct Parent Folder Path String            
            string strParentFolderpath = "";
            if ((List<string>)Session["FolderPath"] != null)
            {
                foreach (var item in (List<string>)Session["FolderPath"])
                {
                    strParentFolderpath += "/" + item;
                }
            }            

            //*** Loop on Items to see who is checked to delete 
            foreach (GridViewRow row in grdVWFilesFolderList.Rows)
            {
                if (((CheckBox)row.FindControl("chkItem")).Checked)
                {
                    string strPath = strParentFolderpath + "/" + ((Label)row.FindControl("lblFileName")).Text;

                    //*** Create Folder Function
                    bool fnResult = await DropBoxConnector.DeleteFileOrFolder(Application["dropBoxClientObj"], strPath);

                    if (!fnResult)    //*** If error
                    {
                        lblDropBoxMsg.Text = DropBoxConnector.MsgError;

                        //*** Show Error
                        divDropBoxAlert.Visible = true;

                        //*** Exit loop function
                        break;
                    }                    
                }
            }
            
            //*** Rebind Data Grid Again                
            DropBoxGridDataBind(((List<string>)Session["FolderPath"]));

        }

        //*** Download Button
        protected async void lnkbtnDownload_Click(object sender, ImageClickEventArgs e)
        {
            //*** Construct Parent Folder Path String            
            string strParentFolderpath = "";
            if ((List<string>)Session["FolderPath"] != null)
            {
                foreach (var item in (List<string>)Session["FolderPath"])
                {
                    strParentFolderpath += "/" + item;
                }
            }

            //*** Loop on Items to see file is checked to download 
            foreach (GridViewRow row in grdVWFilesFolderList.Rows)
            {
                if (((CheckBox)row.FindControl("chkItem")).Checked)
                {
                    //*** Check if Selected is Folder
                    if (bool.Parse(((Label)row.FindControl("lblisFolder")).Text))
                    {
                        //*** Folder Already Exist
                        lblDropBoxMsg.Text = "Only Files can be downloaded";

                        //*** Show Error with grid
                        divDropBoxAlert.Visible = true;
                        divFileGrid.Visible = true;

                        //*** Exit from function
                        return;
                    }
                    else
                    {
                        //*** Checked is Files
                        string strPath = strParentFolderpath + "/" + ((Label)row.FindControl("lblFileName")).Text;

                        //*** Create Folder Function
                        Stream fnStreamResult = await DropBoxConnector.Download(Application["dropBoxClientObj"], strPath);

                        if (DropBoxConnector.MsgError != "")    //*** If error
                        {
                            lblDropBoxMsg.Text = DropBoxConnector.MsgError;

                            //*** Show Error
                            divDropBoxAlert.Visible = true;

                            //*** Exit from function
                            return;
                        }
                        else 
                        { 
                            //*** Save file to tmp Folder and direct user to it
                            // Create a FileStream object to write a stream to a file                            
                            using (var fileStream = new FileStream(HttpContext.Current.Request.PhysicalApplicationPath + System.Configuration.ConfigurationManager.AppSettings["downloadFolderRelPath"] + ((Label)row.FindControl("lblFileName")).Text, FileMode.Create, FileAccess.Write))
                            {
                                fnStreamResult.CopyTo(fileStream);
                            }

                            //*** Then redirect to that file to download it
                            DownloadFilePath = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
                            if (HttpContext.Current.Request.Url.Port > 0) { DownloadFilePath += ":" + HttpContext.Current.Request.Url.Port.ToString(); };
                            DownloadFilePath += "/" + System.Configuration.ConfigurationManager.AppSettings["downloadFolderRelPath"].Replace("\\","/") + ((Label)row.FindControl("lblFileName")).Text;
                            divFileGrid.Visible = true;
                            pnlDownload.Visible = true;
                            
                            //*** Exit from function
                            return;
                        }
                    }                    
                }
            }
            
        }


        //*** Upload File Button
        protected async void Uploader1_UploadCompleted(object sender, UploaderEventArgs[] args)
        {            
             //*** Construct Parent Folder + File Path String            
            string strUploadedFilePath = "";
            if ((List<string>)Session["FolderPath"] != null)
            {
                foreach (var item in (List<string>)Session["FolderPath"])
                {
                    strUploadedFilePath += "/" + item;
                }
            }
            strUploadedFilePath += "/" + args[0].FileName;

            //*** Upload File to DropBox Function
            bool blnUploadResult = await DropBoxConnector.Upload(Application["dropBoxClientObj"], strUploadedFilePath, args[0].OpenStream());

            if (!blnUploadResult)    //*** If error
            {
                lblDropBoxMsg.Text = DropBoxConnector.MsgError;

                //*** Show Error
                divDropBoxAlert.Visible = true;

                //*** Exit from function
                return;
            }
            else   //**** Success
            {

                //*** Rebind Data Grid Again                
                DropBoxGridDataBind(((List<string>)Session["FolderPath"]));
            }        
        }
        //*****************************************************************    
    }
}