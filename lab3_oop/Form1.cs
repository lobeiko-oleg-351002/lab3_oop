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
        public Form1()
        {
            InitializeComponent();
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;

            currentClass = typeof(Solo).AssemblyQualifiedName;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = false;
            checkBox4.Enabled = true;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;

            currentClass = typeof(Clean_solo).AssemblyQualifiedName;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = true;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;

            currentClass = typeof(Distortion_solo).AssemblyQualifiedName;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = true;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;

            currentClass = typeof(Lead).AssemblyQualifiedName;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = true;
            checkBox4.Enabled = true;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;

            currentClass = typeof(Clean_lead).AssemblyQualifiedName;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = true;
            checkBox4.Enabled = false;
            checkBox5.Enabled = true;
            checkBox6.Enabled = false;
            checkBox7.Enabled = true;

            currentClass = typeof(Distortion_lead).AssemblyQualifiedName;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = true;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = true;
            checkBox7.Enabled = true;

            currentClass = typeof(Overdrive_lead).AssemblyQualifiedName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            options[0] = checkBox1.Checked;
            options[1] = checkBox2.Checked;
            options[2] = checkBox3.Checked;
            options[3] = checkBox4.Checked;
            options[4] = checkBox5.Checked;
            options[5] = checkBox6.Checked;
            options[6] = checkBox7.Checked;
            Type type = Type.GetType(currentClass);
            var guitar = Activator.CreateInstance(type, options);
            //var newGuitar = creater.CreateObject(currentClass,options);
            guitarList.Add((Guitar)guitar);
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
           // Dispose(guitarList[currentItem]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(List<Guitar>));

            //using (var stream = File.OpenWrite("data.xml"))
            //{
            //    serializer.Serialize(stream, guitarList);
            //}
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream("data.bin", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(stream, guitarList);
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
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    guitarList.Clear();
                    guitarList = (List<Guitar>)formatter.Deserialize(stream);
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
            
            player.SoundLocation = "pretender.mp3";
            player.Load();
            player.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
    }
}
