<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DropBoxFileNavigator.ascx.cs" Inherits="ExactAssignment.Controls.DropBoxFileNavigator" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>

<script language="javascript" type="text/javascript">
    var FileManager;

    function pageLoad() {
        FileManager = new BinaryIntellect.Web.UI.FileManager();

    }
</script>

<!-- FileManager Class Begin -->
<script type="text/javascript">

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
                        if (items[i].id != 'chkSmartTips') {
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
            if (count == 0) {
                alert("Please select files to download");
                return false;
            }
            else if (count > 1)
            {
                alert('Please be notified that only 1 file only can be downloaded at a time');
                return false;
            }
            else
            {   return true;
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
        <asp:LinkButton runat="server" ID="lnkbtnConnectDropBox" CssClass="btn btn-default" Text="Connect to Dropbox" OnClick="lnkbtnConnectDropBox_Click"></asp:LinkButton>               
        <asp:LinkButton runat="server" ID="lnkbtnDisconnectDropBox" CssClass="btn btn-default" Text="Disconnect to Dropbox"></asp:LinkButton>
        <div runat="server" id="divFileGrid" visible="false">
            <div><img src="/images/user.png"  width="32" height="32"/><b>&nbsp;&nbsp;&nbsp;Welcome <asp:Label runat="server" ID="lblAccountName"></asp:Label></b> </div><br /> 
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
                            <asp:Repeater ID="rptFolderBreadCrumb" runat="server" OnItemCommand="rptFolderBreadCrumb_ItemCommand">
                                <HeaderTemplate>
                                    <table>                                          
                                        <tr><td><asp:LinkButton ID="lnkbtnRoot" runat="server" Text='DropBox' OnClick="lnkbtnRoot_Click"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>                          
                                            > <asp:LinkButton ID="lnkbtnFileName" runat="server" CommandArgument='<%# Container.DataItem.ToString() %>' Text='<%# Container.DataItem.ToString() %>'></asp:LinkButton>
                                </ItemTemplate>
                                <FooterTemplate>      
                                        </td></tr>                               
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>                                
                        <td><asp:ImageButton runat="server" id="lnkbtnCreateFolder" AlternateText="Create Folder" ToolTip="Create a new folder" ImageUrl="/images/createfolder.png" Width="26" Height="26"  /> </td>
                        <td><asp:ImageButton runat="server" id="lnkbtnDownload" AlternateText="Download" ToolTip="Download File" ImageUrl="/images/download.png" Width="26" Height="26" OnClientClick="return FileManager.Download();" OnClick="lnkbtnDownload_Click"  /> </td>
                        <td><asp:ImageButton runat="server" id="lnkbtnUpload" AlternateText="Upload" ToolTip="Upload File" ImageUrl="/images/upload.png" Width="26" Height="26" /> </td>
                        <td><asp:ImageButton runat="server" id="lnkbtnDelete" AlternateText="Delete" ToolTip="Delete File Or Folder" ImageUrl="/images/delete.png" Width="26" Height="26" OnClientClick="return FileManager.Delete();" OnClick="lnkbtnDelete_Click" /> </td>                                                
                        </tr></table>                             
                <cc1:modalpopupextender id="Modalpopupextender1" runat="server" TargetControlID="lnkbtnCreateFolder" PopupControlID="pnlCreateFolder" CancelControlID="btnPanel2No" DropShadow="true" BackgroundCssClass="modalBackground"></cc1:modalpopupextender>
                <cc1:modalpopupextender id="Modalpopupextender2" runat="server" TargetControlID="lnkbtnUpload" PopupControlID="pnlUpload" CancelControlID="btnPanel3Cancel" DropShadow="true" BackgroundCssClass="modalBackground"></cc1:modalpopupextender>
            </div> 
            <div>
                <asp:GridView ID="grdVWFilesFolderList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="Vertical" Width="100%" OnRowCommand="grdVWFilesFolderList_RowCommand" Font-Names="Verdana" Font-Size="12px" OnRowDataBound="grdVWFilesFolderList_RowDataBound">
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