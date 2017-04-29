using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox2.Text = "";

            try
            {

                IPHostEntry hostInfo = Dns.GetHostEntry(textBox1.Text.Trim());

                textBox2.Text = "主机名：" + Dns.GetHostName() + "\r\n";

                foreach (IPAddress ipadd in hostInfo.AddressList)
                {

                    textBox2.Text += ipadd.ToString() + "\r\n";

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }

        }


    }
}
