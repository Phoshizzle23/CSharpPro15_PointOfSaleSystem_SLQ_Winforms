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
    public partial class FrmPay : Form
    {
        FrmMain f = new FrmMain();
        public FrmPay(FrmMain f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnCash_Click(object sender, EventArgs e)
        {
            db._TypeOrder = BtnCash.Text;
            this.f.DoPay();
            Dispose();
        }
    }
}
