using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_oop
{
    [Serializable]
    public class Clean_solo : Solo
    {
        public bool clean { get; set; }
        public Clean_solo(bool[] options)
            :base (options)
        {
            clean = options[3];
            filepath = "clean_solo.wav";
        }

        public Clean_solo() { }
    }
}
