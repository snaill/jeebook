using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace Jeebook.Base
{
    public class ZipProxy : Proxy
    {
        ZipFile _zf = null;

        public ZipProxy(string uri)
        {
            _zf = new ZipFile(uri);
        }

        public System.IO.Stream GetFileStream(string fn)
        {
            fn = fn.Replace('\\', '/');
            return _zf.GetInputStream( _zf.FindEntry(fn, true) );
        }
    }
}
