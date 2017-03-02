using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace getmanager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = int.Parse(textBox1.Text);
            for(int i=0;i<count;i++)
            {
                Process myProcess = new Process();
                //Process.Start(System.Environment.CurrentDirectory + "\\runget.exe ");
                Process.Start(System.Environment.CurrentDirectory + "\\run.bat");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            Process.Start(System.Environment.CurrentDirectory + "\\kill.bat");
        }
    }
}
