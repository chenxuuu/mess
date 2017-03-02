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

namespace AutoShutdown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
            int st = 0;
            if(checkBox1.Checked == true)
                st += (ConvertToInt(textBox1.Text) - ConvertToInt(DateTime.Now.Hour.ToString()) + 24) * 3600;
            else
                st += (ConvertToInt(textBox1.Text) - ConvertToInt(DateTime.Now.Hour.ToString())) * 3600;

            st += (ConvertToInt(textBox2.Text) - ConvertToInt(DateTime.Now.Minute.ToString())) * 60;
            if(st < 0)
                label6.Text = "时间小于当前时间";
            else
                label6.Text = st.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int st = 0;
            if (checkBox1.Checked == true)
                st += (ConvertToInt(textBox1.Text) - ConvertToInt(DateTime.Now.Hour.ToString()) + 24) * 3600;
            else
                st += (ConvertToInt(textBox1.Text) - ConvertToInt(DateTime.Now.Hour.ToString())) * 3600;
            st += (ConvertToInt(textBox2.Text) - ConvertToInt(DateTime.Now.Minute.ToString())) * 60;

            Process myProcess = new Process();
            Process.Start("cmd.exe","/k shutdown -s -t " + st.ToString());

        }
        private int ConvertToInt(string InStr)
        {
            try
            {
                return Convert.ToInt32(InStr);
            }
            catch
            {
                return 0; 
            }
        }
    }
}
