using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_oop
{
    [Serializable]
    public class Solo : Guitar
    {
        public bool chorus { get; set; }
        public bool reverb { get; set; }
        public Solo(bool[] options)
        {
            chorus = options[0];
            reverb = options[1];
        }
        public Solo()
        {

        }
    }
}
