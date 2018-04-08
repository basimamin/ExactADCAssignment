<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlAccountEdit.aspx.cs"
	Inherits="Example.GlAccountEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Exact Online REST API G/L Account Sample</title>
	<link rel="stylesheet" type="text/css" href="css/style.css" />
</head>
<body>
	<div class="header">
		<div class="developer-portal">
			<a id="developer-portal" href="https://start.exactonline.nl/docs/HlpDocument.aspx?Mode=0&HelpFile=DocPortalHome.EN.HLP">
				Developers portal</a>
		</div>
		<div class="logo">
		</div>
	</div>
	<div class="section-header">
		Exact Online REST API G/L Account Sample</div>
	<div class="form">
		<form id="form1" runat="server">
		<input id="Action" runat="server" type="hidden" />
		<input id="GLAccountID" runat="server" type="hidden" />
		<asp:Button class="button" ID="SaveButton" runat="server" Text="Save" OnClientClick="SetAction('Update');" />
		<asp:Button class="button" ID="DeleteButton" runat="server" Text="Delete" OnClientClick="SetAction('Delete');" />
		<asp:Button class="button" ID="CloseButton" runat="server" Text="Close" OnClientClick="return GoBack();" />
		<div class="separator">
		</div>
		<table cellspacing="0" style="border-collapse: collapse">
			<tr>
				<td class="edit">
					Code
				</td>
				<td class="edit">
					<input class="input-text" id="Code" runat="server" />
				</td>
			</tr>
			<tr>
				<td class="edit">
					Description
				</td>
				<td class="edit">
					<input class="input-text" id="Description" runat="server" />
				</td>
			</tr>
		</table>
		</form>
	</div>
	<script type="text/javascript">
		function SetAction(actionValue) {
			document.getElementById("Action").value = actionValue;
		}

		function GoBack() {
			window.history.back();
			return false;
		}
	</script>
</body>
</html>
