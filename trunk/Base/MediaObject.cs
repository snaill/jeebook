using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jeebook.Base
{
    public class MediaObject
    {
        public static MediaObject Create(XElement xe)
        {
            MediaObject mo = new MediaObject();
            mo.Objects = new List<ImageObject>();
            foreach (XElement elem in xe.Elements(ImageObject.LocalName))
            {
                ImageObject io = ImageObject.Create(elem);
                mo.Objects.Add(io);
            }
            return mo;
        }

        public XElement ToXElement()
        {
            XElement xe = new XElement(LocalName);
            foreach ( ImageObject io in Objects )
            {
                xe.Add(io.ToXElement());
            }
            return xe;
        }

        public const string LocalName = "mediaobject";
        public List<ImageObject> Objects { get; set; }
    }
}
