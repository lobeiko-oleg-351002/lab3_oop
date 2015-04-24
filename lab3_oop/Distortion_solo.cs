using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_oop
{
    [Serializable]
    public class Distortion_solo : Solo
    {
        public bool distortion { get; set; }
        public Distortion_solo(bool[] options)
            :base (options)
        {
            distortion = options[4];
        }
    }
}
