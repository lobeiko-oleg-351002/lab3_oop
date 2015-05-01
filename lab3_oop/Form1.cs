using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;

namespace lab3_oop
{
    public partial class Form1 : Form
    {
        string currentClass = "";
        Creater creater = new Creater();
        List<Guitar> guitarList = new List<Guitar>();
        SoundPlayer player = new SoundPlayer();
        bool[] options = new bool[7];
        bool[] checkBoxes_Clean_lead = new bool[] { false, false, true, true, false, false, false };
        bool[] checkBoxes_Overdrive_lead = new bool[] { false, false, true, false, false, true, true };
        bool[] checkBoxes_Distortion_lead = new bool[] { false, false, true, false, true, false, true};
        bool[] checkBoxes_Clean_solo = new bool[] { true, true, false, true, false, false, false };
        bool[] checkBoxes_Distortion_solo = new bool[] { true, true, false, false, true, false, false };
        bool[] checkBoxes_Lead = new bool[] { false, false, true, false, false, false, false };
        bool[] checkBoxes_Solo = new bool[] { true, true, false, false, false, false, false };

        Dictionary<int, CheckBox> checkDictionary = new Dictionary<int, CheckBox>();

        public Form1()
        {
            InitializeComponent();
            checkDictionary.Add(1, checkBox1);
            checkDictionary.Add(2, checkBox2);
            checkDictionary.Add(3, checkBox3);
            checkDictionary.Add(4, checkBox4);
            checkDictionary.Add(5, checkBox5);
            checkDictionary.Add(6, checkBox6);
            checkDictionary.Add(7, checkBox7);
            
            for (int i = 1; i <= 7; i++)
            {
                checkDictionary[i].Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void setCheckDictionary(bool[] state)
        {
            for (int i = 1; i <= checkDictionary.Count; i++)
            {
                checkDictionary[i].Enabled = state[i-1];
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            setCheckDictionary(checkBoxes_Solo);

            currentClass = typeof(Solo).AssemblyQualifiedName;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            setCheckDictionary(checkBoxes_Clean_solo);

            currentClass = typeof(Clean_solo).AssemblyQualifiedName;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            setCheckDictionary(checkBoxes_Distortion_solo);

            currentClass = typeof(Distortion_solo).AssemblyQualifiedName;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            setCheckDictionary(checkBoxes_Lead);

            currentClass = typeof(Lead).AssemblyQualifiedName;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            setCheckDictionary(checkBoxes_Clean_lead);

            currentClass = typeof(Clean_lead).AssemblyQualifiedName;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            setCheckDictionary(checkBoxes_Distortion_lead);

            currentClass = typeof(Distortion_lead).AssemblyQualifiedName;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            setCheckDictionary(checkBoxes_Overdrive_lead);

            currentClass = typeof(Overdrive_lead).AssemblyQualifiedName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= checkDictionary.Count; i++)
            {
                options[i-1] = checkDictionary[i].Checked;
            }
            Type type = Type.GetType(currentClass);
            Guitar guitar = (Guitar)Activator.CreateInstance(type, options);
            guitarList.Add(guitar);
            listBox1.Items.Add(guitar.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                int currentItem = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(currentItem);
                guitarList.RemoveAt(currentItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Guitar>));
                using (FileStream stream = new FileStream("data.xml", FileMode.Create))
                {
                     serializer.Serialize(stream, guitarList);
                }
            }
            catch (IOException)
            {

            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (Stream stream = File.Open("data.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Guitar>));
                    guitarList.Clear();
                    guitarList = (List<Guitar>)serializer.Deserialize(stream);
                    listBox1.Items.Clear();                   
                    foreach (Guitar guitar in guitarList)
                    {
                        listBox1.Items.Add(guitar.ToString());
                    }
                }
            }
            catch (IOException)
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            player.SoundLocation = guitarList[listBox1.SelectedIndex].filepath;
            player.Load();
            player.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
    }
}
