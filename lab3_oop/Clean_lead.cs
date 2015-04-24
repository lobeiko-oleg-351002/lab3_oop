using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_oop
{
    [Serializable]
    public class Clean_lead : Lead
    {

        public bool clean { get; set; }
        public bool chorus { get; set; }
        public bool reverb { get; set; }

        public Clean_lead(bool[] options)
            : base(options)
        {
            clean = options[3];
            chorus = options[0];
            reverb = options[1];
        }
    }
}
