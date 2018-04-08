using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using CuteWebUI;
using ExactAssignment.BLL;
using System.Threading.Tasks;
using System.Threading;
using BLL.DBEntity;

namespace ExactAssignment
{
    public partial class _Default : Page
    {
        protected string DownloadFilePath;
        protected string strExactOnlineAuthParam;
        protected string strSiteBaseURL;

        protected async void Page_Load(object sender, EventArgs e)
        {            
            //*** First Time
            if (!Page.IsPostBack)
            {
                //*** Initialization
                divDropBoxAlert.Visible = false;
                lnkbtnConnectDropBox.Visible = false;
                lnkbtnDisconnectDropBox.Visible = false;
                DivDropBoxFileGrid.Visible = false;
                pnlDownload.Visible = false;

                strSiteBaseURL = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
                if (HttpContext.Current.Request.Url.Port > 0) { strSiteBaseURL += ":" + HttpContext.Current.Request.Url.Port.ToString(); };
                
                //*** Adjust Drop Box Call Back URL for 
                if (HttpContext.Current.Session["dropBoxReturnBackURL"] == null)
                {
                    HttpContext.Current.Session["dropBoxReturnBackURL"] = strSiteBaseURL;
                    HttpContext.Current.Session["dropBoxReturnBackURL"] += "/" + System.Configuration.ConfigurationManager.AppSettings["dropBoxAuthReturnPage"];                                         
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
                        lblDropBoxAccountName.Text = DropBoxConnector.objDropBoxUser.AccountDisplayName;

                        DropBoxGridDataBind((List<string>)Session["FolderPath"]);
                    }
                }
            }

            //******************************************************************************************************
            //*** Exact Online Part
            //******************************************************************************************************            
            //*** First Time
            if (!Page.IsPostBack)            
            {
                //*** Initialization
                divExactOnlineAlert.Visible = false;
                lnkbtnConnectExactOnline.Visible = false;
                lnkbtnDisconnectExactOnline.Visible = false;
                DivDropBoxFileGrid.Visible = false;

                //*** Adjust Drop Box Call Back URL for 
                if (HttpContext.Current.Session["exactOnlineReturnBackURL"] == null)
                {
                    HttpContext.Current.Session["exactOnlineReturnBackURL"] = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
                    if (HttpContext.Current.Request.Url.Port > 0) { HttpContext.Current.Session["exactOnlineReturnBackURL"] += ":" + HttpContext.Current.Request.Url.Port.ToString(); };
                    HttpContext.Current.Session["exactOnlineReturnBackURL"] += "/" + System.Configuration.ConfigurationManager.AppSettings["exactOnlineReturnPage"];
                }

                //*** Check If Code returned into Connection String
                if (Application["ExactOnlineAccessToken"] == null && Session["ExactOnlineReturnCode"] !=null)
                {
                    //**** Initialize Session Folder Path
                    List<string> Dump = new List<string> { };
                    Session["ExactOnlineFolderPath"] = Dump;

                    //**** Construct Exact Online Class
                    ExactOnlineConnector objExactOnlineConnector = new ExactOnlineConnector(System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientId"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientSecret"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineEndPoint"], new Uri(HttpContext.Current.Session["exactOnlineReturnBackURL"].ToString()), Session["ExactOnlineReturnCode"].ToString());
                    
                    Application["ExactOnlineAccessToken"] =  objExactOnlineConnector.GetAccessToken();

                    if (objExactOnlineConnector.MsgError != "")                    
                    {   //*** If Error returned
                        lblExactOnlineMsg.Text = objExactOnlineConnector.MsgError;

                        //*** Show Error
                        divExactOnlineAlert.Visible = true;

                        return;
                    }
                }
                //******************************************************
                
                //*** Check ExactOnline Aurhentication Token
                if (Application["ExactOnlineAccessToken"] == null)
                {

                    //***************************
                    //*** access token is empty
                    //***************************
                    //*** 1. Check first for ExactOnline App Key & App secret
                    if (String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientId"]) ||
                        String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientSecret"]) ||
                        String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["exactOnlineEndPoint"]))
                    {
                        //*** Show Error Message
                        lblExactOnlineMsg.Text = "Please set client id, client secret and end point URL into this project's Web.config file and restart. " +
                                               "client id/secret can be found in the ExactOnline App Console, here: " +
                                               "https://start.exactonline.co.uk";

                        //*** Show Error
                        divExactOnlineAlert.Visible = true;

                        return;
                    }
                    else   //*** AppKey & secret exist
                    {
                        //*** Set URL Parameters
                        //strExactOnlineAuthParam = "";

                        //*** Show Connect to ExactOnline button
                        lnkbtnConnectExactOnline.Visible = true;
                    }

                }

                if (Session["ExactOnlineReturnCode"] != null)
                {
                   
                    //**** Construct Exact Online Class
                    ExactOnlineConnector objExactOnlineConnector = new ExactOnlineConnector(System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientId"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientSecret"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineEndPoint"], new Uri(HttpContext.Current.Session["exactOnlineReturnBackURL"].ToString()), Session["ExactOnlineReturnCode"].ToString());

                    if (Application["ExactOnlineAccessToken"] != null)
                    {
                        objExactOnlineConnector.AccessToken = Application["ExactOnlineAccessToken"].ToString();
                    }
                    //*** Get User Info                    
                    lblExactOnlineAccountName.Text = objExactOnlineConnector.getUserInfo().FullName;

                    if (objExactOnlineConnector.MsgError != "")
                    {   //*** If Error returned
                        lblExactOnlineMsg.Text = objExactOnlineConnector.MsgError;

                        //*** Show Error
                        divExactOnlineAlert.Visible = true;

                        return;
                    }
                    else
                    {
                        //*** Bind Folder Grid View
                        ExactOnlineGridDataBind();                        
                    }
                }
         
            }
            //*********************************************************************************************************
        }

        //*****************************************************************
        //*** Drop Box Files Grid Functions
        //*****************************************************************
        /// <summary>
        //*** Bind DropBox Data Grid
        /// </summary>
        /// <param name="FolderPath">Folder Path in Array Format</param>
        /// <returns></returns>
        private async void DropBoxGridDataBind(List<string> FolderPath = null)
        {
            //*** Constract Path String
            string strFolderpath = "";
            string strFolderName = "";
            if (FolderPath != null)
            {
                foreach (var item in FolderPath)
                {
                    strFolderpath += "/" + item;
                    strFolderName = item;
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
                grdVWDropBoxFilesFolderList.DataSource = lstDropBoxFile;
                grdVWDropBoxFilesFolderList.DataBind();
                rptDropBoxFolderBreadCrumb.DataSource = (List<string>)Session["FolderPath"];
                rptDropBoxFolderBreadCrumb.DataBind();
                DivDropBoxFileGrid.Visible = true;
                if (divExactOnlineFileGrid.Visible) divSync.Visible = true;

                //****************************************************************
                //**** Bind Exact Rebind Online Part
                //****************************************************************
                string strFolderGUID = "";
                if (divExactOnlineFileGrid.Visible)     //**** If Exact Online Grid Shown
                { 
                    //*** 1. Get Folder Guid (If not root)
                    if (strFolderName != "")
                    { 
                        //*** Fitch Grid to get GUID
                        foreach (GridViewRow row in grdVWExactOnlineFilesFolderList.Rows)
                        { 
                            //*** Check if name & Is Folcder
                            if (bool.Parse(((Label)row.FindControl("lblisFolder")).Text) && ((Label)row.FindControl("lblFileName")).Text.ToLower() == strFolderName.ToLower())
                            {
                                strFolderGUID = ((Label)row.FindControl("lblFolderID")).Text;
                                break;
                            }
                        }
                    }

                    Session["CurrentExactFolderGUID"] = strFolderGUID;

                    //*** Then Rebind ExactOnline Grid
                    ExactOnlineGridDataBind(strFolderGUID);
                }
                //****************************************************************
            }
        }
      
        //**** Datagrid item bound function
        protected void grdVWDropBoxFilesFolderList_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void grdVWDropBoxFilesFolderList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //*** Construct Folder Path
            ((List<string>)Session["FolderPath"]).Add(e.CommandArgument.ToString());

            //*** Rebind Data Grid Again
            DropBoxGridDataBind(((List<string>)Session["FolderPath"]));
        }

        //*** Action on Any Row of Bread Crumb (Click on Parent Folder Link)
        protected void rptDropBoxFolderBreadCrumb_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            //*** Make New List
            List<string> tmpFolders = new List<string> { };
            foreach (var item in (List<string>)Session["FolderPath"])
            {
                tmpFolders.Add(item);

                if (item.ToLower() == e.CommandArgument.ToString().ToLower())
                {
                    break;
                }
            }
            Session["FolderPath"] = tmpFolders;

            //*** Rebind Data Grid Again
            DropBoxGridDataBind(((List<string>)Session["FolderPath"]));
        }

        //**** Root Button
        protected void lnkbtnDropBoxRoot_Click(object sender, EventArgs e)
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
            foreach (GridViewRow row in grdVWDropBoxFilesFolderList.Rows)
            {
                if (((Label)row.FindControl("lblFileName")).Text.ToLower() == txtFolderName.Text.ToLower() && bool.Parse(((Label)row.FindControl("lblisFolder")).Text.ToLower()))
                {
                    //*** Folder Already Exist
                    lblDropBoxMsg.Text = "Folder already exists with same name";

                    //*** Show Error with grid
                    divDropBoxAlert.Visible = true;
                    DivDropBoxFileGrid.Visible = true;

                    //*** Exit from function
                    return;
                }
            }

            //*** Construct Parent Folder Path String            
            string strFolderpath = "";
            string strFolderName = "";
            if ((List<string>)Session["FolderPath"] != null)
            {
                foreach (var item in (List<string>)Session["FolderPath"])
                {
                    strFolderpath += "/" + item;
                    strFolderName = item;
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
                //****************************************************************
                //**** Exact Online Part
                //****************************************************************            
                if (divExactOnlineFileGrid.Visible)     //**** If Exact Online Grid Shown
                {
                    //*** Create Folder on Exact Online also
                    //**** Construct Exact Online Class
                    ExactOnlineConnector objExactOnlineConnector = new ExactOnlineConnector(System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientId"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientSecret"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineEndPoint"], new Uri(HttpContext.Current.Session["exactOnlineReturnBackURL"].ToString()), Session["ExactOnlineReturnCode"].ToString());

                    if (Application["ExactOnlineAccessToken"] != null)
                    {
                        objExactOnlineConnector.AccessToken = Application["ExactOnlineAccessToken"].ToString();
                    }

                    string strFolderGUID = objExactOnlineConnector.CreateDocumentFolder(txtFolderName.Text, Session["CurrentExactFolderGUID"].ToString());
                    if (strFolderGUID == "")
                    {
                        //*** If Error returned
                        lblExactOnlineMsg.Text = objExactOnlineConnector.MsgError;

                        //*** Show Error
                        divExactOnlineAlert.Visible = true;
                    }
                    else  //*** Add Entry To DB
                    {
                        FilesDocumentsEntities  objFilesDocumentsEntities = new FilesDocumentsEntities();

                        DropBoxExactOnline objRecord = new DropBoxExactOnline();
                        objRecord.DropBoxPath = strFolderpath;
                        objRecord.ExactOnlineGUID = strFolderGUID;
                        objRecord.isFile = 0;

                        objFilesDocumentsEntities.DropBoxExactOnlines.Add(objRecord);
                        objFilesDocumentsEntities.SaveChanges();                        
                    }
                }
                //***************************************************************************   

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
            string strFolderName = "";
            bool isFolder = false;
            if ((List<string>)Session["FolderPath"] != null)
            {
                foreach (var item in (List<string>)Session["FolderPath"])
                {
                    strParentFolderpath += "/" + item;                    
                }
            }

            //*** Loop on Items to see who is checked to delete 
            foreach (GridViewRow row in grdVWDropBoxFilesFolderList.Rows)
            {
                if (((CheckBox)row.FindControl("chkItem")).Checked)
                {
                    //*** Check if file or Folder
                    isFolder = bool.Parse(((Label)row.FindControl("lblisFolder")).Text);

                    string strPath = strParentFolderpath + "/" + ((Label)row.FindControl("lblFileName")).Text;
                    strFolderName = ((Label)row.FindControl("lblFileName")).Text;

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

                    //****************************************************************
                    //**** Exact Online Part
                    //****************************************************************
                    string strFileFolderGUID = "";
                    if (divExactOnlineFileGrid.Visible)     //**** If Exact Online Grid Shown
                    {
                        //*** 1. Get Folder Guid (If not root)
                        if (strFolderName != "")
                        {
                            //*** Fitch Grid to get GUID
                            foreach (GridViewRow itemRow in grdVWExactOnlineFilesFolderList.Rows)
                            {
                                if (isFolder)   //**** If Folder
                                {
                                    //*** Check if name & Is Folcder
                                    if (bool.Parse(((Label)itemRow.FindControl("lblisFolder")).Text) && ((Label)itemRow.FindControl("lblFileName")).Text.ToLower() == strFolderName.ToLower())
                                    {
                                        strFileFolderGUID = ((Label)itemRow.FindControl("lblFolderID")).Text;
                                        break;
                                    }
                                }
                                else
                                {
                                    //*** Check if name & Is File
                                    if (!bool.Parse(((Label)itemRow.FindControl("lblisFolder")).Text) && ((Label)itemRow.FindControl("lblFileName")).Text.ToLower() == strFolderName.ToLower())
                                    {
                                        strFileFolderGUID = ((Label)itemRow.FindControl("lblFolderID")).Text;
                                        break;
                                    }
                                }
                            }
                        }

                        if (strFileFolderGUID != "")
                        {
                            //*** Create Folder on Exact Online also
                            //**** Construct Exact Online Class
                            ExactOnlineConnector objExactOnlineConnector = new ExactOnlineConnector(System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientId"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientSecret"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineEndPoint"], new Uri(HttpContext.Current.Session["exactOnlineReturnBackURL"].ToString()), Session["ExactOnlineReturnCode"].ToString());

                            if (Application["ExactOnlineAccessToken"] != null)
                            {
                                objExactOnlineConnector.AccessToken = Application["ExactOnlineAccessToken"].ToString();
                            }

                            if (isFolder)        //*** This is Folder
                            {
                                //*** Call Delete Folder
                                if (!objExactOnlineConnector.DeleteDocumentFolder(strFileFolderGUID))
                                {
                                    //*** If Error returned
                                    lblExactOnlineMsg.Text = objExactOnlineConnector.MsgError;

                                    //*** Show Error
                                    divExactOnlineAlert.Visible = true;
                                }
                            }
                            else  //**** If File
                            {
                                //**** Call Delete Document
                                if (!objExactOnlineConnector.DeleteDocument(strFileFolderGUID))
                                {
                                    //*** If Error returned
                                    lblExactOnlineMsg.Text = objExactOnlineConnector.MsgError;

                                    //*** Show Error
                                    divExactOnlineAlert.Visible = true;
                                }
                            }
                        }                     
                    }
                    //***************************************************************************    

                    //*** Then Delete Records from DB                    
                    FilesDocumentsEntities objFilesDocumentsEntities = new FilesDocumentsEntities();

                    //*** Check First if File Already exisit into DB
                    DropBoxExactOnline objRecord = objFilesDocumentsEntities.DropBoxExactOnlines.Where(i => i.DropBoxPath == strPath).FirstOrDefault();
                    if (objRecord != null)
                    {
                        objFilesDocumentsEntities.DropBoxExactOnlines.Remove(objRecord);
                        objFilesDocumentsEntities.SaveChanges();
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
            foreach (GridViewRow row in grdVWDropBoxFilesFolderList.Rows)
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
                        DivDropBoxFileGrid.Visible = true;

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
                            DownloadFilePath += "/" + System.Configuration.ConfigurationManager.AppSettings["downloadFolderRelPath"].Replace("\\", "/") + ((Label)row.FindControl("lblFileName")).Text;
                            DivDropBoxFileGrid.Visible = true;
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
            string strFolderName = "";
            string DocumentGUID = "";

            if ((List<string>)Session["FolderPath"] != null)
            {
                foreach (var item in (List<string>)Session["FolderPath"])
                {
                    strUploadedFilePath += "/" + item;
                    strFolderName = item;
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
                //****************************************************************
                //**** Exact Online Part
                //****************************************************************                
                if (divExactOnlineFileGrid.Visible)     //**** If Exact Online Grid Shown
                {
                    //*** Create Folder on Exact Online also
                    //**** Construct Exact Online Class
                    ExactOnlineConnector objExactOnlineConnector = new ExactOnlineConnector(System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientId"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientSecret"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineEndPoint"], new Uri(HttpContext.Current.Session["exactOnlineReturnBackURL"].ToString()), Session["ExactOnlineReturnCode"].ToString());

                    if (Application["ExactOnlineAccessToken"] != null)
                    {
                        objExactOnlineConnector.AccessToken = Application["ExactOnlineAccessToken"].ToString();
                    }
                    
                    DocumentGUID = objExactOnlineConnector.CreateDocumentWithAttachment(args[0].FileName, Session["CurrentExactFolderGUID"].ToString(), Common.ConvertStreamtoByteArr(args[0].OpenStream()));
                    if (DocumentGUID == "")
                    {
                        //*** If Error returned
                        lblExactOnlineMsg.Text = objExactOnlineConnector.MsgError;

                        //*** Show Error
                        divExactOnlineAlert.Visible = true;
                    }
                    else
                    { 
                        //*** Add Entity to DB
                        FilesDocumentsEntities objFilesDocumentsEntities = new FilesDocumentsEntities();

                        //*** Check First if File Already exisit into DB
                        DropBoxExactOnline objRecord = objFilesDocumentsEntities.DropBoxExactOnlines.Where(i => i.DropBoxPath == strUploadedFilePath).FirstOrDefault();
                        if (objRecord != null)
                        { 
                            //**** Update DB
                            objRecord.DropBoxPath = strUploadedFilePath;
                            objRecord.ExactOnlineGUID = DocumentGUID;
                            objRecord.isFile = 1;
                                                        
                            objFilesDocumentsEntities.SaveChanges();
                        }
                        else
                        {
                            //*** add to DB
                            DropBoxExactOnline objRecordNew = new DropBoxExactOnline();
                            objRecordNew.DropBoxPath = strUploadedFilePath;
                            objRecordNew.ExactOnlineGUID = DocumentGUID;
                            objRecordNew.isFile = 1;

                            objFilesDocumentsEntities.DropBoxExactOnlines.Add(objRecordNew);
                            objFilesDocumentsEntities.SaveChanges();
                         }
                    }
                }
                //***************************************************************************   

                //*** Rebind Data Grid Again                
                DropBoxGridDataBind(((List<string>)Session["FolderPath"]));
            }
        }
        //*****************************************************************    


        //*****************************************************************
        //*** Exact Online Files Grid Functions
        //*****************************************************************
        /// <summary>
        //*** Bind ExactOnline Data Grid
        /// </summary>
        /// <param name="ParentFolderGUID">Parent Folder GUID</param>
        /// <returns></returns>
        private void ExactOnlineGridDataBind(string ParentFolderGUID = "")
        {
            //*** Bind the Grid & Bread Crumb            
            //**** Construct Exact Online Class
            ExactOnlineConnector objExactOnlineConnector = new ExactOnlineConnector(System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientId"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientSecret"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineEndPoint"], new Uri(HttpContext.Current.Session["exactOnlineReturnBackURL"].ToString()), Session["ExactOnlineReturnCode"].ToString());

            if (Application["ExactOnlineAccessToken"] != null)
            {
                objExactOnlineConnector.AccessToken = Application["ExactOnlineAccessToken"].ToString();
            }

            //*** Get documents & Folders List         
            List<ExactOnlineFile> lstExactOnlineFile =  objExactOnlineConnector.ListDocumentsFolders(ParentFolderGUID);
                     
            if (objExactOnlineConnector.MsgError != "")
            {   //*** If Error returned
                lblExactOnlineMsg.Text = objExactOnlineConnector.MsgError;

                //*** Show Error
                divExactOnlineAlert.Visible = true;

                return;
            }
            else
            {
                //**** Create Folder for test               
                grdVWExactOnlineFilesFolderList.DataSource = lstExactOnlineFile;
                grdVWExactOnlineFilesFolderList.DataBind();
                divExactOnlineFileGrid.Visible = true;
                if (DivDropBoxFileGrid.Visible) divSync.Visible = true;
            }           
        }


        /// <summary>
        /// *** This function is Syncing all folders and files from Drop Box to Exact Online
        /// *** Regarding File, it download file from dropbox to tmp folder then upload it to ExactOnline again
        /// </summary>        
        /// <returns></returns>
        protected async void btnSyncAllStart_Click(object sender, EventArgs e)
        {
             await SyncAllFilesFolders();             
        }

        private async Task SyncAllFilesFolders()
        {
            try
            {
                //*** Set Variables
                int intCount = 0, intSuccess = 0, intFailed = 0;
                Session["SyncAllNumbers"] = "";
                string strFolderGUID = "";
                string strFolderpath = "";

                //*** Loop on All Objects on DropBox Grid View
                foreach (GridViewRow itemRow in grdVWDropBoxFilesFolderList.Rows)
                {
                    strFolderpath = "";

                    //*** Refresh Counts
                    intCount += 1;

                    //*** set Session Variable (Shared Variable)
                    Session["SyncAllNumbers"] = grdVWDropBoxFilesFolderList.Rows.Count.ToString() + "," + intCount.ToString() + "," + intSuccess.ToString() + "," + intFailed.ToString();

                    //*** Check on Drop Box Enity
                    if (bool.Parse(((Label)itemRow.FindControl("lblisFolder")).Text))   //**** If Folder
                    {
                        //************************************
                        //**** Create Folder on ExactOnline
                        //************************************
                        //**** Construct Exact Online Class
                        ExactOnlineConnector objExactOnlineConnector = new ExactOnlineConnector(System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientId"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientSecret"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineEndPoint"], new Uri(HttpContext.Current.Session["exactOnlineReturnBackURL"].ToString()), Session["ExactOnlineReturnCode"].ToString());

                        if (Application["ExactOnlineAccessToken"] != null)
                        {
                            objExactOnlineConnector.AccessToken = Application["ExactOnlineAccessToken"].ToString();
                        }

                        strFolderGUID = objExactOnlineConnector.CreateDocumentFolder(((Label)itemRow.FindControl("lblFileName")).Text, Session["CurrentExactFolderGUID"].ToString());
                        if (strFolderGUID == "")
                        {
                            //*** If Error returned
                            intFailed += 1;
                        }
                        else
                        {
                            intSuccess += 1;
                        }
                    }
                    else  //**** If File
                    {
                        //******************************************************************
                        //**** Get File Stream then upload it to ExactOnline & Flush
                        //******************************************************************
                        //*** Construct Parent Folder Path String            
                        string strParentFolderpath = "";
                        if ((List<string>)Session["FolderPath"] != null)
                        {
                            foreach (var item in (List<string>)Session["FolderPath"])
                            {
                                strParentFolderpath += "/" + item;
                            }
                        }

                        string strPath = strParentFolderpath + "/" + ((Label)itemRow.FindControl("lblFileName")).Text;
                        strFolderpath = strPath;

                        //*** Create Folder Function
                        Stream fnStreamResult = await DropBoxConnector.Download(Application["dropBoxClientObj"], strPath);

                        if (DropBoxConnector.MsgError != "")    //*** If error
                        {
                            intFailed += 1;
                        }
                        else
                        {
                            //*************************************************************
                            //*** Convert File to Byte Array and upload it to Exact Online
                            //*************************************************************
                            //**** Construct Exact Online Class
                            ExactOnlineConnector objExactOnlineConnector = new ExactOnlineConnector(System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientId"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineClientSecret"], System.Configuration.ConfigurationManager.AppSettings["exactOnlineEndPoint"], new Uri(HttpContext.Current.Session["exactOnlineReturnBackURL"].ToString()), Session["ExactOnlineReturnCode"].ToString());

                            if (Application["ExactOnlineAccessToken"] != null)
                            {
                                objExactOnlineConnector.AccessToken = Application["ExactOnlineAccessToken"].ToString();
                            }

                            strFolderGUID = objExactOnlineConnector.CreateDocumentWithAttachment(((Label)itemRow.FindControl("lblFileName")).Text, Session["CurrentExactFolderGUID"].ToString(), Common.ConvertStreamtoByteArr(fnStreamResult));
                            if (strFolderGUID == "")
                            {
                                intFailed += 1;
                            }
                            else
                            {
                                intSuccess += 1;
                            }
                        }
                        //******************************************************************                    
                    }

                    //*** The Add to update record into DB
                    if (bool.Parse(((Label)itemRow.FindControl("lblisFolder")).Text))    //*** If Folder
                    {  
                        if ((List<string>)Session["FolderPath"] != null)
                        {
                            foreach (var item in (List<string>)Session["FolderPath"])
                            {
                                strFolderpath += "/" + item;
                            }
                        }
                        strFolderpath += "/" + ((Label)itemRow.FindControl("lblFileName")).Text;
                    }

                    FilesDocumentsEntities objFilesDocumentsEntities = new FilesDocumentsEntities();

                    //*** Check First if File Already exisit into DB
                    DropBoxExactOnline objRecord = objFilesDocumentsEntities.DropBoxExactOnlines.Where(i => i.DropBoxPath == strFolderpath).FirstOrDefault();
                    if (objRecord != null)
                    {
                        //**** Update DB
                        objRecord.DropBoxPath = strFolderpath;
                        objRecord.ExactOnlineGUID = strFolderGUID;
                        if (bool.Parse(((Label)itemRow.FindControl("lblisFolder")).Text))
                            objRecord.isFile = 0;
                        else
                            objRecord.isFile = 1;

                        objFilesDocumentsEntities.SaveChanges();
                    }
                    else
                    {
                        //*** add to DB
                        DropBoxExactOnline objRecordNew = new DropBoxExactOnline();
                        objRecordNew.DropBoxPath = strFolderpath;
                        objRecordNew.ExactOnlineGUID = strFolderGUID;
                        if (bool.Parse(((Label)itemRow.FindControl("lblisFolder")).Text))
                            objRecordNew.isFile = 0;
                        else
                            objRecordNew.isFile = 1;
                        
                        objFilesDocumentsEntities.DropBoxExactOnlines.Add(objRecordNew);
                        objFilesDocumentsEntities.SaveChanges();
                    }
                    //*******************************************************************************
                    
                    //*** set Session Variable (Shared Variable)
                    Session["SyncAllNumbers"] = grdVWDropBoxFilesFolderList.Rows.Count.ToString() + "," + intCount.ToString() + "," + intSuccess.ToString() + "," + intFailed.ToString();
                }

                //*** Rebind Exact Online Grid
                ExactOnlineGridDataBind(Session["CurrentExactFolderGUID"].ToString());
            }
            catch (Exception e)
            {
                lblExactOnlineMsg.Text = e.ToString();

                //*** Show Error
                divExactOnlineAlert.Visible = true;

            }
        }

        //*****************************************************************

    }
}