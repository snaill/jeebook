using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeebook.Base
{
    public class FileProxy : Proxy
    {
        private string _base = "";

        public FileProxy(string uri)
        {
            _base = uri;
            if (!_base.EndsWith("\\"))
                _base += '\\';
        }

        public System.IO.Stream GetFileStream(string fn)
        {
            return System.IO.File.Open(_base + fn, System.IO.FileMode.Open);
        }
    }
}
