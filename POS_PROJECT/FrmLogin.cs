using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_PROJECT
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void GetNumber(object sender, EventArgs e)
        {
            string number = (sender as Button).Text;
            TxtPassword.Text = TxtPassword.Text == "0" ? number : TxtPassword.Text += number;
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtPassword.Clear();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            GetNumber(sender, e);
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            GetNumber(sender, e);
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            GetNumber(sender, e);
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            GetNumber(sender, e);
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            GetNumber(sender, e);
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            GetNumber(sender, e);
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            GetNumber(sender, e);
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            GetNumber(sender, e);
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            GetNumber(sender, e);
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            GetNumber(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblDate.Text = DateTime.Now.ToString();
        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
            FrmMain f = new FrmMain();
            f.Show();
            this.Hide();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
