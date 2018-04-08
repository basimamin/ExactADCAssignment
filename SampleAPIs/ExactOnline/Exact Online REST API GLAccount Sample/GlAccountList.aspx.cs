using System;
using Example.Service;

namespace Example
{
	public partial class GlAccountList : System.Web.UI.Page
	{
		private static readonly ExactOnlineOAuthClient OAuthClient = new ExactOnlineOAuthClient();

		protected void Page_Load(object sender, EventArgs e)
		{
			MakeSessionPersistent();

			if (AuthorizeClient())
			{
				InitializeGrid();
			}
		}

		private void MakeSessionPersistent()
		{
			if (Session.Keys.Count == 0)
			{
				// Initialize a session object so the session remains persistent. 
				// Otherwise DotNetOpenAuth will throw a Protocolexception on ProcessUserAuthorization.
				// http://stackoverflow.com/questions/2874078/asp-net-session-sessionid-changes-between-requests
				Session["Init"] = 0;
			}
		}

		private Boolean AuthorizeClient()
		{
			OAuthClient.Authorize(Session, "GlAccountList.aspx");

			return (OAuthClient.Authorization != null);
		}

		private void InitializeGrid()
		{
			using (var glAccountService = new WebClientGlAccountService(OAuthClient.Authorization))
			{
				glAccountsGrid.DataSource = glAccountService.GetList(SearchFilter.Value);
			}
			glAccountsGrid.DataBind();
		}

	}
}