using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Text;
using DotNetOpenAuth.OAuth2;
using Example.Domain;

namespace Example.Service
{
	public class WebClientGlAccountService : WebClientServiceBase
	{
		#region Properties

		public static Uri ServiceUri
		{
			get { return new Uri(BaseUri, string.Format("api/v1/{0}/financial/", Me.CurrentCompany)); }
		}

		#endregion

		#region Constructor

		public WebClientGlAccountService(IAuthorizationState authorizationState) : base(authorizationState)
		{
		}

		#endregion

		#region Public Methods

		public void Create(GlAccount glAccount)
		{
			WebClient.UploadString(
				ResourceUri(),
				"POST",
				FormatJson(glAccount));
		}

		public GlAccount Read(Guid glAccountId)
		{
			string jsonResponse = WebClient.DownloadString(ResourceUri(glAccountId));

			GlAccount glAccount = ParseJsonSingle(jsonResponse);
			return glAccount;
		}

		public void Update(GlAccount glAccount)
		{
			WebClient.UploadString(
				ResourceUri(glAccount.Id),
				"PUT",
				FormatJson(glAccount));
		}

		public void Delete(Guid glAccountId)
		{
			WebClient.UploadString(
				ResourceUri(glAccountId),
				"DELETE",
				"");
		}

		public IEnumerable<GlAccount> GetList(string filter)
		{
			var uriBuilder = new UriBuilder(ResourceUri());

			var sb = new StringBuilder("$select=ID,Code,Description");
			sb.AppendFormat("&$filter=substringof('{0}',Code)+eq+true+or+substringof('{0}',Description)+eq+true", filter);
			sb.Append("&$orderby=Code");
			uriBuilder.Query = sb.ToString();

			string jsonResponse = this.WebClient.DownloadString(uriBuilder.Uri);
			IEnumerable<GlAccount> glAccounts = ParseJsonList(jsonResponse);

			return glAccounts;
		}

		#endregion

		#region Private Methods

		private Uri ResourceUri()
		{
			return ResourceUri(null);
		}

		private Uri ResourceUri(Guid? glAccountId)
		{
			Uri serviceUri = ServiceUri;
			if (glAccountId != null)
			{
				string resourceLocation = String.Format("GLAccounts(guid'{0}')", glAccountId);
				return new Uri(serviceUri, resourceLocation);
			}
			return new Uri(serviceUri, "GLAccounts");
		}

		private string FormatJson(GlAccount glAccount)
		{
			var sb = new StringBuilder();
			const string jsonFormat = "\"{0}\":\"{1}\"";

			sb.Append("{");
			sb.AppendFormat(jsonFormat, "Code", glAccount.Code);
			sb.Append(",");
			sb.AppendFormat(jsonFormat, "Description", glAccount.Description);
			sb.Append("}");

			return sb.ToString();
		}

		private GlAccount ConvertJsonDictionary(Dictionary<string, object> glAccountJson)
		{
			GlAccount glAccount = null;

			if ((glAccountJson != null) && (glAccountJson.Count > 0))
			{
				glAccount = new GlAccount
					{
						Id = new Guid((string) glAccountJson["ID"]),
						Code = (string) glAccountJson["Code"],
						Description = (string) glAccountJson["Description"]
					};
			}

			return glAccount;
		}

		private IEnumerable<GlAccount> ParseJsonList(string jsonString)
		{
			var serializer = new JavaScriptSerializer();
			var jsonObject = serializer.DeserializeObject(jsonString) as Dictionary<string, object>;
			var document = (Dictionary<string, object>)jsonObject["d"];
			var resultList = (Array)document["results"];

			var glAccounts = new List<GlAccount>();
			foreach (Dictionary<string, object> glAccountJson in resultList)
			{
				glAccounts.Add(ConvertJsonDictionary(glAccountJson));
			}
			return glAccounts;
		}

		private GlAccount ParseJsonSingle(string jsonString)
		{
			var serializer = new JavaScriptSerializer();
			var jsonObject = serializer.DeserializeObject(jsonString) as Dictionary<string, object>;
			var glAccountJson = (Dictionary<string, object>)jsonObject["d"];

			return ConvertJsonDictionary(glAccountJson);
		}

		#endregion

	}
}