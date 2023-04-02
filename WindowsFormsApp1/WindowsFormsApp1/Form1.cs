using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream soubor = new FileStream("texty.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter zapisovac = new BinaryWriter(soubor, Encoding.GetEncoding("windows-1250"));
            BinaryReader ctenar = new BinaryReader(soubor, Encoding.GetEncoding("windows-1250"));
            for(int i =1; i <= 10;i++)
            {
                zapisovac.Write("This is věta číslo " + i + ".");
            }
            ctenar.BaseStream.Position = 0;
            while (ctenar.BaseStream.Position < ctenar.BaseStream.Length)
            {
                listBox1.Items.Add(ctenar.ReadString());
            }
            soubor.Close();
            soubor = new FileStream("texty.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            zapisovac = new BinaryWriter(soubor, Encoding.GetEncoding("windows-1250"));
            foreach (string str in listBox1.Items)
            {
                zapisovac.Write(str.Replace('.', '!'));
            }
            ctenar = new BinaryReader(soubor, Encoding.GetEncoding("windows-1250"));
            ctenar.BaseStream.Position = 0;
            while (ctenar.BaseStream.Position < ctenar.BaseStream.Length)
            {
                listBox2.Items.Add(ctenar.ReadString());
            }
            soubor.Close();
        }

    }
}
