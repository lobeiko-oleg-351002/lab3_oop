using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab3_oop
{
    [Serializable]
    [XmlRoot("Pack")]
    [XmlInclude(typeof(Solo)), XmlInclude(typeof(Lead)), XmlInclude(typeof(Distortion_lead)), XmlInclude(typeof(Distortion_solo)), XmlInclude(typeof(Clean_solo)), XmlInclude(typeof(Clean_lead)), XmlInclude(typeof(Overdrive_lead))]
    public class Guitar
    {
        public string filepath { get; set; }
    }
}
