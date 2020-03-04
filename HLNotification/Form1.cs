using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HLNotification
{
    public partial class Form1 : Form
    {

        bool isRunning = false;
        string hightlightPath = "Temp\\Highlights\\Escape From Tarkov";

        int count = 0;
        bool initCount = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;
            if(isRunning)
            {
                label1.Text = "Notifications: ON";
                button1.Text = "Stop";
                checkTmr.Start();
            }
            else
            {
                label1.Text = "Notifications: OFF";
                button1.Text = "Start";
                checkTmr.Stop();
                initCount = false;
            }

        }

        private void checkTmr_Tick(object sender, EventArgs e)
        {
            if(!initCount)
            {
                //set count to amount of files
                count = Directory.GetFiles(hightlightPath, "*").Length;
                initCount = true;
            }

            int nCount = Directory.GetFiles(hightlightPath, "*").Length;

            if(nCount > count)
            {
                Console.Beep();
            }

            count = nCount;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hightlightPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), hightlightPath);
        }
    }
}
