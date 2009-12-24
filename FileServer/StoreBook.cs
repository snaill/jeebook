using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Jeebook.FileServer;

namespace Jeebook.Store.ROA
{
    class Book : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string strPath = context.Request.QueryString["path"];

            //
            FileServerBase fs = new FileServerBase(context.Server.MapPath(".."));
            string dirs = fs.GetFiles(strPath);

            context.Response.WriteFile(dirs);
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
