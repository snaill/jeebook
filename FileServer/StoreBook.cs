using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Jeebook.FileServer;
using Jeebook.ROA;

namespace Jeebook.Store.ROA
{
    class Book : BaseHandler
    {
        public override void do_Get(HttpContext context)
        {
            string strPath = context.Request.QueryString["path"];

            //
            FileServerBase fs = new FileServerBase(context.Server.MapPath("../data/"));
            string dirs = fs.GetFiles(strPath);

            context.Response.WriteFile(dirs);
        }

        //public void do_Post(HttpContext context, string strPath)
        //{

        //}

        //public void do_Put(HttpContext context, string strPath)
        //{
        //}

        //public void do_Delete(HttpContext context, string strPath)
        //{
        //}

    }
}
