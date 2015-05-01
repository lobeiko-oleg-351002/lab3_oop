using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_oop
{
    [Serializable]
    public class Lead : Guitar
    {
        public bool doubletrack_level1 { get; set; }
        public Lead(bool[] options)
        {
            doubletrack_level1 = options[2];
        }

        public Lead() { }
    }
}
