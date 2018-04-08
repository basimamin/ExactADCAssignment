using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ExactAssignment
{
    /// <summary>
    /// Summary description for getSyncStatus
    /// </summary>
    public class getSyncStatus : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Session["SyncAllNumbers"] != null)
                context.Response.Write(context.Session["SyncAllNumbers"].ToString());
            else
                context.Response.Write("");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}