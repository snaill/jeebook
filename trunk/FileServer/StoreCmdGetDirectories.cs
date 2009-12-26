using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeebook.FileServer;
using System.Web;

namespace Jeebook.Store
{
    class CmdGetDirectories : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string strPath = context.Request.QueryString["path"];

            //
            FileServerBase fs = new FileServerBase(context.Server.MapPath(".."), VirtualPathMode.Zip);
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
