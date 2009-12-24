using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Jeebook.FileServer;
using Jeebook.ROA;

namespace Jeebook.Store.ROA
{
    class Meta : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string strPath = context.Request.QueryString["path"];

            try
            {
                if (context.Request.HttpMethod == "GET")
                    do_Get(context, strPath);
                else
                    context.Response.StatusCode = HttpStatusCode.HTTP_501_NotImplemented;

            }
            catch (FileServerException)
            {

            }
        }

        public void do_Get(HttpContext context, string strPath)
        {
            //
            context.Response.StatusCode = HttpStatusCode.HTTP_501_NotImplemented;
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
