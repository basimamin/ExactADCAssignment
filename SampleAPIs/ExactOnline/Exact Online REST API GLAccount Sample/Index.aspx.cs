using System;
using System.Web.UI;
using System.Web.Configuration;

namespace Example
{
	public partial class Start : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ClientIdValue.Text = WebConfigurationManager.AppSettings["ClientId"];
				ClientSecretValue.Text = WebConfigurationManager.AppSettings["ClientSecret"];
				BaseUriValue.SelectedValue = WebConfigurationManager.AppSettings["BaseUri"];
			}
		}

		protected void StartButton_Click(object sender, EventArgs e)
		{
			Server.Transfer("~/GlAccountList.aspx");
		}

		protected void SaveButton_Click(object sender, EventArgs e)
		{
			var configuration = WebConfigurationManager.OpenWebConfiguration("~");

			configuration.AppSettings.Settings.Remove("ClientId");
			configuration.AppSettings.Settings.Add("ClientId", ClientIdValue.Text);

			configuration.AppSettings.Settings.Remove("ClientSecret");
			configuration.AppSettings.Settings.Add("ClientSecret", ClientSecretValue.Text);

			configuration.AppSettings.Settings.Remove("BaseUri");
			configuration.AppSettings.Settings.Add("BaseUri", BaseUriValue.SelectedValue);

			configuration.Save();
		}

	}
}