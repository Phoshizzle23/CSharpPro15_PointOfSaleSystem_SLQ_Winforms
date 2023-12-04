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
    public partial class FrmQty : Form
    {
        public FrmQty()
        {
            InitializeComponent();
        }
        private void GetNumber(object sender, EventArgs e)
        {
            string number = (sender as Button).Text;
            LblCount.Text = LblCount.Text == "0" ? number : LblCount.Text += number;
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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            LblCount.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnOk_Click(object sender, EventArgs e) 
        {
            if(Convert.ToInt32(LblCount.Text) > 0)
            {
                db._qty = Convert.ToInt32(LblCount.Text);
            }
            Dispose();
        }
    }
}
