using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _20._04hm_process
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 3000;
            timer1.Enabled = true;
        }

        Process[] processes = Process.GetProcesses();

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;

            listView1.View = View.Details;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.Sorting = SortOrder.Ascending;
            timer1.Tick += timer1_Tick;

            foreach (Process p in processes)
            {
                listView1.Items.Add($"{p.ProcessName}");
            }

            listView1.Columns.Add("Name:", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Id:", 90, HorizontalAlignment.Left);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process.GetCurrentProcess();
        }
    }
}

