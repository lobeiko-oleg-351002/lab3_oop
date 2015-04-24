using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_oop
{
    [Serializable]
    public class Distortion_lead : Lead
    {

        public bool distortion { get; set; }
        public bool doubletrack_level2 { get; set; }
        public Distortion_lead(bool[] options)
            :base (options)
        {
            distortion = options[4];
            doubletrack_level2 = options[6];
        }
    }
}
