using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab3_oop
{
    [XmlRoot("listRoot")]
    [XmlInclude(typeof(Guitar))]
    public class Pack
    {
  
        [XmlArray("guitarList")]
        [XmlArrayItem("list")]
        public List<Guitar> guitarList { get; set; }
    }
}
