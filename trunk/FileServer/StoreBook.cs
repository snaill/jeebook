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

            try
            {
                if (context.Request.HttpMethod == "GET")
                    do_Get(context, strPath);
                else if (context.Request.HttpMethod == "POST")
                    do_Post(context, strPath);
                else if (context.Request.HttpMethod == "PUT")
                    do_Put(context, strPath);
                else if (context.Request.HttpMethod == "DELETE")
                    do_Delete(context, strPath);
            }
            catch (FileServerException)
            {

            }
        }

        public void do_Get(HttpContext context, string strPath)
        {
            //
            FileServerBase fs = new FileServerBase(context.Server.MapPath("../data/"));
            string dirs = fs.GetFiles(strPath);

            context.Response.WriteFile(dirs);
        }

        public void do_Post(HttpContext context, string strPath)
        {

        }

        public void do_Put(HttpContext context, string strPath)
        {
        }

        public void do_Delete(HttpContext context, string strPath)
        {
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
