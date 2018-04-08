<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExactAssignment._Default" Async="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
    var FileManager;

    function pageLoad() {
        FileManager = new BinaryIntellect.Web.UI.FileManager();     
    }
        
    //*** Trigger Variable
    boolCallSyncOnetime = true;
    
    function SyncUpdateStatus()
    {
        if (boolCallSyncOnetime)
        {
            boolCallSyncOnetime = false;
            document.getElementById('<%=btnSyncAllStart.ClientID%>').click();
        }
        
        $.ajax({
            url: "<%=strSiteBaseURL%>/getSyncStatus.ashx",
            contentType: "application/json; charset=utf-8",
            data: { },
            success: OnComplete,
            error: OnFail
        });
        return false;              
    }

    //*** Http Call Success
    function OnComplete(result)
    {
        if (result)
        {            
            var ArrNum = result.split(",");

            //*** Display Result
            //document.getElementById('StatusMsg').innerHTML = document.getElementById('StatusMsgHidden').innerHTML.replace("{0}", ArrNum[1]).replace("{1}", ArrNum[0]).replace("{2}", ArrNum[2]).replace("{3}", ArrNum[3])
        }

        //*** Recursive
        setTimeout(SyncUpdateStatus, 2000); //wait two seconds before continuing  
    }

    function OnFail(error)
    {
        if (error)
        {
            // alert(error.get_message());
            alert(error.get_message());
        }
    }     
</script>

<!-- FileManager Class Begin -->
<script type="text/javascript">

    //*** This function open XDrop Box Authentication window
    function DropBoxAuth() {
        window.open('DropBoxAuth.aspx', 'mywindow', 'location=200, scrollbars=1, width=800,height=600');
        return false;
    }

    //*** This function open Exact online Authentication window
    function ExactOnlineAuth()
    {
        window.open('ExactOnlineAuth.aspx', 'mywindow', 'location=200, scrollbars=1, width=600,height=300');   
        return false;
    }

    Type.registerNamespace("BinaryIntellect.Web.UI");

    BinaryIntellect.Web.UI.FileManager = function () {
        this._x;
        this._y;
    }

    BinaryIntellect.Web.UI.FileManager.prototype =
    {


        ClickButton: function (srcElement) {
            FileManager.HideContextMenu();
            document.getElementById(srcElement).click();
            return false;
        },

        ToggleSelectionForAllItems: function (evt) {
            var count = 0;
            var items = document.getElementsByTagName("input");
            for (i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    if (evt.srcElement) {
                        if (items[i].id != evt.srcElement.id) {
                            items[i].checked = evt.srcElement.checked;
                            count++;
                        }
                    }
                    else {
                        if (items[i].id != evt.target.id) {
                            items[i].checked = evt.target.checked;
                            count++;
                        }
                    }
                }
            }
        },

        UnselectHeaderCheckBox: function (evt) {
            if (evt.srcElement) {
                if (event.srcElement.checked == false) {
                    var count = 0;
                    var items = document.getElementsByTagName("input");
                    for (i = 0; i < items.length; i++) {
                        if (items[i].type == "checkbox") {
                            if (items[i].id.indexOf('chkHeader') > 0) {
                                items[i].checked = false;
                            }
                        }
                    }
                }
            }
            else {
                if (evt.target.checked == false) {
                    var count = 0;
                    var items = document.getElementsByTagName("input");
                    for (i = 0; i < items.length; i++) {
                        if (items[i].type == "checkbox") {
                            if (items[i].id.indexOf('chkHeader') > 0) {
                                items[i].checked = false;
                            }
                        }
                    }
                }
            }
        },

        GetSelectedItemCount: function () {
            var count = 0;
            var items = document.getElementsByTagName("input");
            for (i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    if (items[i].checked) {
                        if (items[i].id != 'chkSmartTips' && items[i].id.indexOf('chkItem') > 0) {
                            //alert(items[i].id);
                            count++;
                        }
                    }
                }
            }
            return count;
        },

        Create: function () {
            if (document.getElementById('<%=txtFolderName.ClientID%>').value.trim() == "") {
                alert("Please enter folder name!");
                return false;
            }
            else {
                return true;
            }
        },

        Delete: function () {
            var count = 0;
            var items = document.getElementsByTagName("input");
            count = FileManager.GetSelectedItemCount();
            if (count == 0) {
                alert("Please select items to delete");
                return false;
            }
            else {
                if (confirm('Are you sure that you need to delete ' + count + ' Files/Folders?'))
                    return true;
                else
                    return false;
            }
        },

        Download: function () {
            var count = 0;
            var items = document.getElementsByTagName("input");
            count = FileManager.GetSelectedItemCount();
           // alert(count);
            if (count == 0) {
                alert("Please select files to download");
                return false;
            }
            else if (count > 1) {
                alert('Please be notified that only 1 file only can be downloaded at a time');
                return false;
            }
            else {
                return true;
            }
        },

        ShowLoadingImage: function () {
            document.getElementById('imgLoading').style = "visibility:visible";
            document.getElementById('<%=btnPanel3Cancel.ClientID%>').disabled = true;   //*** Hide Cancel Button
            return true;
        },

        hideImageLoading: function () {
            document.getElementById('imgLoading').style = "visibility:hidden";
            return true;
        }

    }

    BinaryIntellect.Web.UI.FileManager.registerClass('BinaryIntellect.Web.UI.FileManager', null, Sys.IDisposable);


</script>
<!-- FileManager Class End -->

    <div class="col-md-6">
        <div class="row"><h2>DropBox Part</h2></div> 
        <div class="row">
            <div runat="server" id="divDropBoxAlert" class="custom-alert alert alert-danger">
                <span class="close" data-dismiss="alert">×</span>
                <asp:Label runat="server" ID="lblDropBoxMsg"></asp:Label>
            </div>  
            <asp:LinkButton runat="server" ID="lnkbtnConnectDropBox" CssClass="btn btn-default" Text="Connect to Dropbox" OnClientClick="return DropBoxAuth();"></asp:LinkButton>               
            <asp:LinkButton runat="server" ID="lnkbtnDisconnectDropBox" CssClass="btn btn-default" Text="Disconnect to Dropbox"></asp:LinkButton>
            <div runat="server" id="DivDropBoxFileGrid" visible="false">
                <div><img src="/images/user.png"  width="32" height="32"/><b>&nbsp;&nbsp;&nbsp;Welcome <asp:Label runat="server" ID="lblDropBoxAccountName"></asp:Label></b> </div><br /> 
                <div>
                        <asp:Panel ID="pnlCreateFolder" runat="server" CssClass="DynamicPanel">
                        <table style="width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Enter the folder name to create :"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:TextBox ID="txtFolderName" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;<asp:Button ID="btnPanel2Yes" runat="server" Text="  OK  " OnClientClick="return FileManager.Create();" OnClick="btnPanel2Yes_Click" />
                                    <asp:Button ID="btnPanel2No" runat="server" Text="Cancel" /></td>
                            </tr>
                        </table>
                    </asp:Panel>       
                    <asp:Panel ID="pnlDownload" runat="server" Visible="false">
                            <script type="text/javascript">
                                window.open('<%=DownloadFilePath%>', 'download_window', 'toolbar=0,location=no,directories=0,status=0,scrollbars=0,resizeable=0,width=400,height=80,top=0,left=0');
                                window.focus();
                            </script>
                    </asp:Panel>                
                    <asp:Panel ID="pnlUpload" runat="server" CssClass="DynamicPanel">
                        <table style="width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Select file to be uploaded :"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center">
                                        <asp:Button runat="server" ID="btnUploadBrowse" Text="  Browse  " />                                                        
                                        <asp:Panel runat="server" ID="Uploader1Progress" BorderColor="Orange" BorderStyle="dashed"
                                            BorderWidth="2" Style="padding:4px">
                                            <asp:Label ID="Uploader1ProgressText" runat="server" ForeColor="Firebrick"></asp:Label>
                                        </asp:Panel>                                                
                                        <img src="/images/loading.gif" id="imgLoading" alt="Loading..." style="visibility:hidden;" width="22" height="22" />
                                        <asp:Button runat="server" ID="btnUploadCancel" Text="  Cancel  " />                                                          
                                        <CuteWebUI:Uploader runat="server" ID="Uploader1" InsertButtonID='btnUploadBrowse'
                                            ProgressCtrlID='Uploader1Progress' ProgressTextID='Uploader1ProgressText' CancelButtonID='btnUploadCancel'
                                                OnUploadCompleted="Uploader1_UploadCompleted" ShowProgressBar="true" ShowProgressInfo="true" ButtonOnClickScript="FileManager.ShowLoadingImage();" >
                                            <ValidateOption MaxSizeKB="50000" />
                                        </CuteWebUI:Uploader>
                                </td>
                            </tr>
                            <tr><td>
                                &nbsp;
                                </td></tr> 
                            <tr>
                                <td align="center"><asp:Button ID="btnPanel3Cancel" runat="server" Text="  Cancel   " OnClientClick="FileManager.hideImageLoading();" /></td>
                            </tr>
                        </table>
                    </asp:Panel>   
                        <table>
                            <tr><td style="width:100%">
                                <asp:Repeater ID="rptDropBoxFolderBreadCrumb" runat="server" OnItemCommand="rptDropBoxFolderBreadCrumb_ItemCommand">
                                    <HeaderTemplate>
                                        <table>                                          
                                            <tr><td><asp:LinkButton ID="lnkbtnDropBoxRoot" runat="server" Text='DropBox' OnClick="lnkbtnDropBoxRoot_Click"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>                          
                                                > <asp:LinkButton ID="lnkbtnDropBoxFileName" runat="server" CommandArgument='<%# Container.DataItem.ToString() %>' Text='<%# Container.DataItem.ToString() %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>      
                                            </td></tr>                               
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </td>                                
                            <td><asp:ImageButton runat="server" id="lnkbtnCreateFolder" AlternateText="Create Folder" ToolTip="Create a new folder" ImageUrl="/images/createfolder.png" Width="26" Height="26" Style="visibility:hidden;" /> </td>
                            <td><asp:ImageButton runat="server" id="lnkbtnDownload" AlternateText="Download" ToolTip="Download File" ImageUrl="/images/download.png" Width="26" Height="26" OnClientClick="return FileManager.Download();" OnClick="lnkbtnDownload_Click"  /> </td>
                            <td><asp:ImageButton runat="server" id="lnkbtnUpload" AlternateText="Upload" ToolTip="Upload File" ImageUrl="/images/upload.png" Width="26" Height="26" /> </td>
                            <td><asp:ImageButton runat="server" id="lnkbtnDelete" AlternateText="Delete" ToolTip="Delete File Or Folder" ImageUrl="/images/delete.png" Width="26" Height="26" OnClientClick="return FileManager.Delete();" OnClick="lnkbtnDelete_Click" /> </td>                                                
                            </tr></table>                             
                    <cc1:modalpopupextender id="Modalpopupextender1" runat="server" TargetControlID="lnkbtnCreateFolder" PopupControlID="pnlCreateFolder" CancelControlID="btnPanel2No" DropShadow="true" BackgroundCssClass="modalBackground"></cc1:modalpopupextender>
                    <cc1:modalpopupextender id="Modalpopupextender2" runat="server" TargetControlID="lnkbtnUpload" PopupControlID="pnlUpload" CancelControlID="btnPanel3Cancel" DropShadow="true" BackgroundCssClass="modalBackground"></cc1:modalpopupextender>
                </div> 
                <div>
                    <asp:GridView ID="grdVWDropBoxFilesFolderList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="Vertical" Width="100%" OnRowCommand="grdVWDropBoxFilesFolderList_RowCommand" Font-Names="Verdana" Font-Size="12px" OnRowDataBound="grdVWDropBoxFilesFolderList_RowDataBound">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkHeader" runat="server"  />
                            </HeaderTemplate>
                            <ItemStyle Width="1%" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFileFolderName" runat="server" Text='<%# Bind("FileName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <img src="<%# bool.Parse(Eval("isFolder").ToString()) ? "/images/folder.png" : "/images/file.png" %>" width="32" height="32">&nbsp;
                                <asp:LinkButton ID="lnkbtnFileName" runat="server" CommandArgument='<%# Eval("FileName") %>' Text='<%# Eval("FileName") %>' Visible='<%# bool.Parse(Eval("isFolder").ToString()) ? true : false %>'></asp:LinkButton>
                                <asp:label ID="lblFileName" runat="server" Text='<%# Eval("FileName") %>' Visible='<%# bool.Parse(Eval("isFolder").ToString()) ? false : true %>'></asp:label>
                                <asp:label ID="lblisFolder" runat="server" Text='<%# Eval("isFolder") %>' Visible='false'></asp:label>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Modified">                                                                
                                <ItemStyle HorizontalAlign="center" Width="20%" Wrap="False" />
                            <ItemTemplate>
                                <asp:Label ID="lblModified" runat="server" Text='<%# DateTime.Parse(Eval("ModificationDate").ToString()) <= DateTime.Parse("1/1/1900") ? "" : DateTime.Parse(Eval("ModificationDate").ToString()).ToString("dd MMM yyyy HH:mm tt") %>'></asp:Label>                                
                            </ItemTemplate>
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Size (KB)">     
                            <ItemStyle HorizontalAlign="center" Width="10%" Wrap="False" />                      
                            <ItemTemplate>
                                <asp:Label ID="lblSize" runat="server" Text='<%# String.Format("{0:#,###,###.##}", ulong.Parse(Eval("FileSizeInBytes").ToString()) / 1000)  %>'></asp:Label>                                
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>   
                </div> 
            </div>              
        </div>
    </div>
    <div class="col-md-1" style="vertical-align:middle;">
         <div style="vertical-align:middle" runat="server" id="divSync" visible="false">
             <asp:Panel ID="pnlSync" runat="server" CssClass="DynamicPanel">
                <table style="width: 100%">
                    <tr align="center">
                        <td><img src="/images/loading.gif" id="imgLoading" alt="Loading..." width="48" height="48" /></td>
                        </tr> 
                    <tr>
                        <td align="center">
                            <div id="StatusMsgHidden" style="visibility:hidden">Now process synchronizing {0} out of {1} items <br/>
                            Success: {2}  <br/>
                            Failed: {3}</div>
                            <div id="StatusMsg">Now process synchronizing all Files / Folders</div>                           
                            <br/><br/>
                        </td>
                    </tr>                               
                    <tr>
                        <td align="center">                                        
                            <div id="SubmitControls" style="visibility:hidden">
                                <asp:Button ID="btnSyncAllStart" runat="server" Text="  OK  " OnClick="btnSyncAllStart_Click" />
                                <asp:Button ID="btnCloseSyncAll" runat="server" Text="  Close  " Enabled="false" />
                            </div> 
                        </td>
                    </tr>
                </table>
            </asp:Panel>      
             <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
             <asp:ImageButton runat="server" id="imgbtnSyncAll" AlternateText="Sync All" ToolTip="Sync All" ImageUrl="/images/syncall.png" Width="64" Height="64" OnClientClick="return SyncUpdateStatus();" />
             <cc1:modalpopupextender id="Modalpopupextender4" runat="server" TargetControlID="imgbtnSyncAll" PopupControlID="pnlSync" CancelControlID="btnCloseSyncAll" DropShadow="true" BackgroundCssClass="modalBackground"></cc1:modalpopupextender>

         </div>
    </div>     
    <div class="col-md-5">
        <div class="row"><h2>ExactOnline Part</h2></div> 
            <div class="row">
                <div runat="server" id="divExactOnlineAlert" class="custom-alert alert alert-danger">
                    <span class="close" data-dismiss="alert">×</span>
                    <asp:Label runat="server" ID="lblExactOnlineMsg"></asp:Label>
                </div>  
                <asp:LinkButton runat="server" ID="lnkbtnConnectExactOnline" CssClass="btn btn-default" Text="Connect to ExactOnline" OnClientClick="return ExactOnlineAuth();"></asp:LinkButton>               
                <asp:LinkButton runat="server" ID="lnkbtnDisconnectExactOnline" CssClass="btn btn-default" Text="Disconnect From ExactOnline"></asp:LinkButton>
                <div runat="server" id="divExactOnlineFileGrid" visible="false">
                    <div><img src="/images/user.png"  width="32" height="32"/><b>&nbsp;&nbsp;&nbsp;Welcome <asp:Label runat="server" ID="lblExactOnlineAccountName"></asp:Label></b> </div><br /> 
                    <div>                                
                        <table>
                            <tr><td style="width:100%">
                                <asp:Repeater ID="rptExactOnlineFolderBreadCrumb" runat="server">
                                    <HeaderTemplate>
                                        <table>                                          
                                            <tr><td><asp:LinkButton ID="lnkbtnExactOnlineRoot" runat="server" Text='ExactOnline'></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>                          
                                                > <asp:LinkButton ID="lnkbtnExactOnlineFileName" runat="server" CommandArgument='<%# Container.DataItem.ToString() %>' Text='<%# Container.DataItem.ToString() %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>      
                                            </td></tr>                               
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </td>                                                            
                            </tr>
                        </table> <br />                                                                       
                    </div> 
                    <div>
                        <asp:GridView ID="grdVWExactOnlineFilesFolderList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="Vertical" Width="100%" Font-Names="Verdana" Font-Size="12px" >
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--<asp:CheckBox ID="chkItem" runat="server" Visible="false" />--%>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <%--<asp:CheckBox ID="chkHeader" runat="server" Visible="false"  />--%>
                                </HeaderTemplate>
                                <ItemStyle Width="1%" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFileFolderName" runat="server" Text='<%# Bind("FileName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <img src="<%# bool.Parse(Eval("isFolder").ToString()) ? "/images/folder.png" : "/images/file.png" %>" width="32" height="32">&nbsp;
                                    <asp:LinkButton ID="lnkbtnFileName" runat="server" CommandArgument='<%# Eval("FileName") %>' Text='<%# Eval("FileName") %>' Visible='<%# bool.Parse(Eval("isFolder").ToString()) ? true : false %>'></asp:LinkButton>
                                    <a href='<%# Eval("FileURL") == "" ? "javascript: void(0);" :  Eval("FileURL") %>' target="_blank"><asp:label ID="lblFileName" runat="server" Text='<%# Eval("FileName") %>' Visible='<%# bool.Parse(Eval("isFolder").ToString()) ? false : true %>'></asp:label></a> 
                                    <asp:label ID="lblisFolder" runat="server" Text='<%# Eval("isFolder") %>' Visible='false'></asp:label>
                                    <asp:label ID="lblFolderID" runat="server" Text='<%# Eval("ID") %>' Visible='false'></asp:label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Modified">                                                                
                                    <ItemStyle HorizontalAlign="center" Width="20%" Wrap="False" />
                                <ItemTemplate>
                                    <asp:Label ID="lblModified" runat="server" Text='<%# DateTime.Parse(Eval("ModificationDate").ToString()) <= DateTime.Parse("1/1/1900") ? "" : DateTime.Parse(Eval("ModificationDate").ToString()).ToString("dd MMM yyyy HH:mm tt") %>'></asp:Label>                                
                                </ItemTemplate>
                            </asp:TemplateField>  
                            <asp:TemplateField HeaderText="Size (KB)">     
                                <ItemStyle HorizontalAlign="center" Width="10%" Wrap="False" />                      
                                <ItemTemplate>
                                    <asp:Label ID="lblSize" runat="server" Text='<%# String.Format("{0:#,###,###.##}", ulong.Parse(Eval("FileSizeInBytes").ToString()) / 1000)  %>'></asp:Label>                                
                                </ItemTemplate>
                            </asp:TemplateField> 
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>   
                    </div> 
                </div>              
            </div>
        </div>        
    
</asp:Content>
