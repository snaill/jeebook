using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Jeebook.FileServer;
using Jeebook.ROA;

namespace Jeebook.Store.ROA
{
    class Meta : BaseHandler
    {
        public override void do_Get(HttpContext context)
        {
            //
            context.Response.StatusCode = HttpStatusCode.HTTP_501_NotImplemented;
        }
    }
}
