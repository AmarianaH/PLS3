using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Dynamic;

namespace DynamicXml
{
    public class DynamicXElement : DynamicObject
    {
        public XElement _element { get; }

        public DynamicXElement(XElement element)
        {
            _element = element;
        }


        internal static dynamic Create(XElement xElement)
        {

            if (xElement != null)
            {
                return new DynamicXElement(xElement);
            }
            return null;
        }



        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            DynamicXElement d = new DynamicXElement(_element.Element(binder.Name));
            result = d;
            if (d != null)
            {
                return true;
            }
            return false;
        }


        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            result = "";
            if (indexes.Length == 2)
            {
                if ((indexes[0].GetType().Equals(Type.GetType("System.String"))) && (indexes[1].GetType().Equals(Type.GetType("System.Int32"))))
                {
                    var elements = _element.Elements((string)indexes[0]);
                    var e = elements.ElementAt((int)indexes[1]);
                    DynamicXElement d = new DynamicXElement(e);
                    result = d;
                    if (d != null) return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"|| Name => {_element.Name} || Value => {_element.Value} ||\n";
        }
    }
}
