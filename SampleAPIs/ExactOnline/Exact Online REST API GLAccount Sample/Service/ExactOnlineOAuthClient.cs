﻿using System;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;
using DotNetOpenAuth.OAuth2;
using Example.Domain;

namespace Example.Service
{
    /// <summary>
    /// Our pages (SalesInvoiceNew.aspx, SalesInvoiceEdit.aspx, SalesInvoiceList.aspx) each contain an instance of this class.
    /// The authorization state is shared through the session.
    /// </summary>
    public class ExactOnlineOAuthClient : WebServerClient
    {
        #region Properties

        public IAuthorizationState Authorization { get; set; }

        #endregion

        #region Constructor

        public ExactOnlineOAuthClient()
            : base(CreateAuthorizationServerDescription(), MyClientIdentifier(), MyClientSecret())
        {
            // initialization is already done through the base constructor
            ClientCredentialApplicator = ClientCredentialApplicator.PostParameter(MyClientSecret());
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Handle OAuth2 authorization and store the authorization in the session so it's available on all our pages
        /// </summary>
        public void Authorize(HttpSessionState session, string returnUri)
        {
            Authorization = (IAuthorizationState)session["Authorization"];
            var uri = new Uri(GetUrlRoot() + returnUri);
            Authorize(uri);
            session["Authorization"] = Authorization;

            RetrieveCurrentCompany();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This method takes care of getting and refreshing the access token 
        /// </summary>
        private void Authorize(Uri returnUri)
        {
            if (Authorization == null)
            {
                Authorization = ProcessUserAuthorization();
                if (Authorization == null)
                {
                    // Kick off authorization request
                    RequestUserAuthorization(null, returnUri);
                }
            }
            else
            {
                if (AccessTokenHasToBeRefreshed())
                {
                    RefreshAuthorization(Authorization);
                }
            }
        }

        /// <summary>
        /// Check if the access token is expired or will soon expire.
        /// </summary>
        private Boolean AccessTokenHasToBeRefreshed()
        {
            TimeSpan timeToExpire = Authorization.AccessTokenExpirationUtc.Value.Subtract(DateTime.UtcNow);

            return (timeToExpire.Minutes < 1);
        }

        private static string MyClientIdentifier()
        {
            return WebConfigurationManager.AppSettings["ClientId"];
        }

        private static string MyClientSecret()
        {
            return WebConfigurationManager.AppSettings["ClientSecret"];
        }

        private static AuthorizationServerDescription CreateAuthorizationServerDescription()
        {
            var baseUri = WebConfigurationManager.AppSettings["BaseUri"];
            var uri = new Uri(baseUri.EndsWith("/") ? baseUri : baseUri + "/");
            var serverDescription = new AuthorizationServerDescription
            {
                AuthorizationEndpoint = new Uri(uri, "api/oauth2/auth"),
                TokenEndpoint = new Uri(uri, "api/oauth2/token")
            };

            return serverDescription;
        }

        private static string GetUrlRoot()
        {
            string port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            port = port == null || port == "80" || port == "443" ? "" : ":" + port;

            string protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
            protocol = protocol == null || protocol == "0" ? "http://" : "https://";

            return protocol + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + port + HttpContext.Current.Request.ApplicationPath;
        }

        private void RetrieveCurrentCompany()
        {
            if (Me.CurrentCompany == 0)
            {
                using (var meService = new WebClientMeService(Authorization))
                {
                    Me.CurrentCompany = meService.GetCurrentCompany();
                }
            }
        }

        #endregion
    }
}