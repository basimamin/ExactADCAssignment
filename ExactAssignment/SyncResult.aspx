<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SyncResult.aspx.cs" Inherits="ExactAssignment.SyncResult" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <webopt:bundlereference runat="server" path="~/Content/css" />
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <script type="text/javascript">

                    function SyncUpdateStatus() {
                        $.ajax({
                            url: "<%=strSiteBaseURL%>/getSyncStatus.ashx",
                    contentType: "application/json; charset=utf-8",
                    data: {},
                    success: OnComplete,
                    error: OnFail
                });

                return false;
            }

            //*** Http Call Success
            function OnComplete(result) {
                alert(result);
                if (result) {
                    var ArrNum = result.split(",");

                    //*** Display Result
                    document.getElementById('StatusMsg').innerHTML = document.getElementById('StatusMsgHidden').innerHTML.replace("{0}", ArrNum[1]).replace("{1}", ArrNum[0]).replace("{2}", ArrNum[2]).replace("{3}", ArrNum[3])

                    if (parseInt(ArrNum[2]) + parseInt(ArrNum[3]) == parseInt(ArrNum[0]))
                    {
                        document.location.href = 'default.aspx';
                        return false;
                    }
                }

                //*** Recursive
                setTimeout(SyncUpdateStatus, 10000); //wait two seconds before continuing  
            }

            function OnFail(error) {
                if (error) {
                    // alert(error.get_message());
                    alert(error.get_message());
                }
            }

            //*** Call Result Function 
            SyncUpdateStatus();
        </script>
         <div class="col-md-1" style="vertical-align:middle;">
         <div style="vertical-align:middle;" runat="server" id="divSync" CssClass="DynamicPanel">
             <%--<asp:Panel ID="pnlSync" runat="server" CssClass="DynamicPanel" Visible="false">--%>
                <table style="width: 100%">
                    <tr align="center">
                        <td><img src="/images/loading.gif" id="imgLoading" alt="Loading..." width="48" height="48" /></td>
                        </tr> 
                    <tr>
                        <td align="center">
                            <div id="StatusMsgHidden" style="visibility:hidden" class="DynamicPanel">Now process synchronizing {0} out of {1} items <br/>
                                Success: {2}  <br/>
                                Failed: {3}

                            </div>
                            <div id="StatusMsg" class="DynamicPanel">Now process synchronizing all Files / Folders</div>                           
                            <br/><br/>
                        </td>
                    </tr>                               
                    <tr>
                        <td align="center">                                        
                            <div id="SubmitControls" style="visibility:hidden">
                                <asp:Button ID="btnSyncAllStart" runat="server" Text="  OK  " />
                                <asp:Button ID="btnCloseSyncAll" runat="server" Text="  Close  " Enabled="false" />
                            </div> 
                        </td>
                    </tr>
                </table>
           <%-- </asp:Panel>  --%>      </div>
        
    </form> 
</body>
</html>
