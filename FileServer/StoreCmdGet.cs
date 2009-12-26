using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Jeebook.FileServer;

namespace Jeebook.Store
{
    class CmdGet : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string strPath = context.Request.QueryString["path"];

            //
            FileServerBase fs = new FileServerBase(context.Server.MapPath(".."), VirtualPathMode.Zip);
            string dirs = fs.GetRealPath(strPath);

            context.Response.WriteFile(dirs);
        }

        public void OnCheckCacheFolder(string strSource, string strDir, string strFn)
        {
            if (!System.IO.Directory.Exists(strDir))
            {
                ICSharpCode.SharpZipLib.Zip.FastZip fz = new ICSharpCode.SharpZipLib.Zip.FastZip();
                fz.ExtractZip(strSource, strDir, "");
            }
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
