using ExactOnline.Client.Models;
using ExactOnline.Client.Sdk.Controllers;
using System;
using System.Diagnostics;
using System.Linq;

using ExactOnline.Client.Sdk.Helpers;

namespace ConsoleApplication
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			// These are the authorisation properties of your app.
			// You can find the values in the App Center when you are maintaining the app.
            const string clientId = "9f07c7c4-e4ce-46fc-99a3-90e5740c0a51";
            const string clientSecret = "kGDPCuAvcN23";

			// This can be any url as long as it is identical to the callback url you specified for your app in the App Center.
            var callbackUrl = new Uri("http://localhost:57319/default.aspx"); 

			var connector = new Connector(clientId, clientSecret, callbackUrl);
			var client = new ExactOnlineClient(connector.EndPoint, connector.GetAccessToken);

            
			// Get the Code and Name of a random account in the administration
			var fields = new[] { "Code", "Name" };
			var account = client.For<Account>().Top(1).Select(fields).Get().FirstOrDefault();

            //*** My POC to get Documents
            ApiConnector objAPIConnector = new ApiConnector(connector.GetAccessToken);
            ApiConnection objApiConnection = new ApiConnection(objAPIConnector, connector.EndPoint + "/api/v1/" + client.GetDivision().ToString() + "/documents/Documents");
            string Response = objApiConnection.Get("$select=ID,Created,DocumentFolder,DocumentFolderCode,Modified,Subject,Type,TypeDescription");
            //*** Get result into Array List
            var document = client.For<Document>().Select(new string[] { "ID", "Created", "Subject" }).Get();

			//Debug.WriteLine("Account {0} - {1}", account.Code.TrimStart(), account.Name);
            Console.WriteLine("Account {0} - {1}", account.Code.TrimStart(), account.Name);
		}
	}
}
