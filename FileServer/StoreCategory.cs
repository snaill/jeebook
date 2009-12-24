using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeebook.FileServer;
using System.Web;

namespace Jeebook.Store.ROA
{
    class Category : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string strPath = context.Request.QueryString["path"];

            //
            FileServerBase fs = new FileServerBase(context.Server.MapPath(".."));
            string dirs = fs.GetDirectories(strPath);

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
