<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlAccountList.aspx.cs"
	Inherits="Example.GlAccountList" %>

<!DOCTYPE html>
<html>
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
		<form id="form1" runat="server" defaultbutton="RefreshButton">
		<asp:Button class="button" ID="RefreshButton" runat="server" Text="Refresh" />
		<asp:Button class="button" ID="NewButton" runat="server" Text="New" PostBackUrl="~/GlAccountEdit.aspx" />
		<div class="filter">
			<span class="label">Search</span><input class="input-text" id="SearchFilter" runat="server" />
		</div>
		<div class="list">
			<span class="list-title">General ledger accounts</span>
			<div class="list-title-separator">
			</div>
			<asp:GridView runat="server" ID="glAccountsGrid" EmptyDataText="No data available."
				AutoGenerateColumns="false">
				<Columns>
					<asp:HyperLinkField HeaderText="Code" DataTextField="Code" DataNavigateUrlFields="ID"
						DataNavigateUrlFormatString="~/GLAccountEdit.aspx?Action=Read&GLAccountID={0}" />
					<asp:BoundField HeaderText="Description" DataField="Description" />
				</Columns>
			</asp:GridView>
		</div>
		</form>
	</div>
</body>
</html>
