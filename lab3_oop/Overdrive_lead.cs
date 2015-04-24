using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_oop
{
    [Serializable]
    public class Overdrive_lead : Lead
    {

        public bool overdrive { get; set; }
        public bool doubletrack_level2 { get; set; }
        public Overdrive_lead(bool[] options)
            : base(options)
        {
            overdrive = options[5];
            doubletrack_level2 = options[6];
        }
    }
}
