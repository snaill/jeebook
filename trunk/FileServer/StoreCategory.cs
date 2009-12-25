using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeebook.FileServer;
using System.Web;
using Jeebook.ROA;

namespace Jeebook.Store.ROA
{
    class Category : BaseHandler
    {
        public override void do_Get(HttpContext context)
        {
            string strPath = context.Request.QueryString["path"];

            //
            FileServerBase fs = new FileServerBase(context.Server.MapPath("../data/"));
            string dirs = fs.GetDirectories(strPath);

            context.Response.WriteFile(dirs);
        }

        //public void do_Post(HttpContext context)
        //{
            
        //}

        //public void do_Put(HttpContext context)
        //{
        //}

        //public void do_Delete(HttpContext context)
        //{
        //}
    }
}
