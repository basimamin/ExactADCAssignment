using System;
using System.Web;
using Example.Domain;
using Example.Service;

namespace Example
{
	public partial class GlAccountEdit : System.Web.UI.Page
	{
		private static readonly ExactOnlineOAuthClient OAuthClient = new ExactOnlineOAuthClient();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (AuthorizeClient())
			{
				if (!IsPostBack)
				{
					GetUrlParameters();
				}

				ExecuteAction();
			}
		}

		private Boolean AuthorizeClient()
		{		
			OAuthClient.Authorize(Session, "GlAccountEdit.aspx");

			return (OAuthClient.Authorization != null);
		}

		private void GetUrlParameters()
		{
			Action.Value = HttpContext.Current.Request.QueryString["Action"];
			GLAccountID.Value = HttpContext.Current.Request.QueryString["GLAccountID"];
		}

		private void ExecuteAction()
		{
			using (var glAccountService = new WebClientGlAccountService(OAuthClient.Authorization))
			{
				switch (Action.Value)
				{
					case "Read":
						ReadGlAccount(glAccountService);
						break;

					case "Update":
						if (String.IsNullOrEmpty(GLAccountID.Value))
						{
							CreateGlAccount(glAccountService);
						}
						else
						{
							UpdateGlAccount(glAccountService);
						}
						break;

					case "Delete":
						DeleteGlAccount(glAccountService);
						break;
				}
			}
		}


		private void CreateGlAccount(WebClientGlAccountService service)
		{
			var newGlAccount = new GlAccount
			{
				Code = this.Code.Value,
				Description = this.Description.Value
			};
			service.Create(newGlAccount);
			NavigateToGlAccountList();
		}

		private void ReadGlAccount(WebClientGlAccountService service)
		{
			var glAccountId = new Guid(GLAccountID.Value);
			GlAccount glAccount = service.Read(glAccountId);
			Code.Value = glAccount.Code;
			Description.Value = glAccount.Description;
		}

		private void DeleteGlAccount(WebClientGlAccountService service)
		{
			var glAccountId = new Guid(this.GLAccountID.Value);
			service.Delete(glAccountId);

			NavigateToGlAccountList();
		}

		private void UpdateGlAccount(WebClientGlAccountService service)
		{
			var glAccount = new GlAccount()
			{
				Id = new Guid(this.GLAccountID.Value),
				Code = this.Code.Value,
				Description = this.Description.Value
			};
			service.Update(glAccount);
			NavigateToGlAccountList();
		}

		private void NavigateToGlAccountList()
		{
			Server.Transfer("~/GlAccountList.aspx");
		}

	}
}