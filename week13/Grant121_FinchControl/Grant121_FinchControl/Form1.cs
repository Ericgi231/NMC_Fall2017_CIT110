using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinchAPI;

namespace Grant121_FinchControl
{
    public partial class Form1 : Form
    {

        Finch tina = new Finch();
        static int speed = 200;

        public Form1()
        {
            InitializeComponent();

            if (tina.connect())
            {
                txtConnected.Text = "True";
            } else
            {
                txtConnected.Text = "False";
            }

            nudSpeed.Value = speed;
        }

        private void ButtFor_Click(object sender, EventArgs e)
        {
            tina.setMotors(speed, speed);
        }

        private void ButtLef_Click(object sender, EventArgs e)
        {
            tina.setMotors(-speed, speed);
        }

        private void ButtSto_Click(object sender, EventArgs e)
        {
            tina.setMotors(0, 0);
        }

        private void ButtRig_Click(object sender, EventArgs e)
        {
            tina.setMotors(speed, -speed);
        }

        private void ButtBac_Click(object sender, EventArgs e)
        {
            tina.setMotors(-speed, -speed);
        }

        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            speed = (int)nudSpeed.Value;
        }

        private void ButtExi_Click(object sender, EventArgs e)
        {
            tina.disConnect();
            Application.Exit();
        }

    }
}
