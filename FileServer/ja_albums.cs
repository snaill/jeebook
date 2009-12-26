using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Jeebook.FileServer;

namespace Jeebook.Alumb
{
    public class albums : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string strPath = context.Request.QueryString["path"];

            //
            FileServerBase dc = new FileServerBase(context.Server.MapPath("../data/"), VirtualPathMode.Zip);
            string dirs = dc.GetDirectories(strPath);

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
