using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Jeebook.ROA
{
    class BaseHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "GET")
                do_Get(context);
            else if (context.Request.HttpMethod == "PUT")
                do_Put(context);
            else if (context.Request.HttpMethod == "DELETE")
                do_Delete(context);
            else if (context.Request.HttpMethod == "POST")
            {
                string strMethod = context.Request.QueryString["method"];
                if ( strMethod == "PUT" )
                    do_Put(context);
                else if ( strMethod == "DELTE" )
                    do_Delete(context);
                else
                    do_Post(context);
            }
        }

        public virtual void do_Get(HttpContext context)
        {
            context.Response.StatusCode = HttpStatusCode.HTTP_501_NotImplemented;
        }

        public virtual void do_Post(HttpContext context)
        {
            context.Response.StatusCode = HttpStatusCode.HTTP_501_NotImplemented;
        }

        public virtual void do_Put(HttpContext context)
        {
            context.Response.StatusCode = HttpStatusCode.HTTP_501_NotImplemented;
        }

        public virtual void do_Delete(HttpContext context)
        {
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

