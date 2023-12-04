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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            LoadRight();
            LoadLeft();
            loadFrmDown();
            loadFrmTop();
        }

        public void DoPay()
        {
            
                foreach(DataGridViewRow row in Dgv.Rows)
                {
                db.cn.Open();
                db.cm = new System.Data.SqlClient.SqlCommand("insert into TransTb (TranNames,TPrice,Tqty,TTotal,OrderNumber,TypeOrder) values (@TranNames,@TPrice,@Tqty,@TTotal,@OrderNumber,@TypeOrder)", db.cn);
                    
                    db.cm.Parameters.AddWithValue("@TranNames", row.Cells[1].Value);
                    db.cm.Parameters.AddWithValue("@TPrice", row.Cells[2].Value);
                    db.cm.Parameters.AddWithValue("@Tqty", row.Cells[3].Value);
                    db.cm.Parameters.AddWithValue("@TTotal", row.Cells[4].Value);
                    db.cm.Parameters.AddWithValue("@TypeOrder", db._TypeOrder);
                    db.cm.Parameters.AddWithValue("@OrderNumber", Convert.ToInt32(label2.Text));
                    db.cm.ExecuteNonQuery();
                db.cn.Close();
            }
           
            db._orderNumber += 1;
            label2.Text = db._orderNumber.ToString();
            button2_Click(null, null);
        }
        public void Counts()
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                row.Cells[4].Value = Convert.ToInt32(row.Cells[2].Value) * Convert.ToInt32(row.Cells[3].Value);
            }
            double GrandTotal = 0.0;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                GrandTotal += Convert.ToDouble(row.Cells[4].Value);
            }
            LblTotal.Text = GrandTotal.ToString();
        }

        private void LoadRight()
        {
            db.cn.Open();
            db.cm = new System.Data.SqlClient.SqlCommand("select * from rightitem",db.cn);
            db.dr = db.cm.ExecuteReader();
            while (db.dr.Read())
            {
                Button Btnitem = new Button();
                Btnitem.Height = 100;
                Btnitem.Width = 125;
                Btnitem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
                Btnitem.FlatStyle = FlatStyle.Flat;
                Btnitem.Cursor = Cursors.Hand;
                Btnitem.ForeColor = Color.White;
                Btnitem.Text = db.dr[1].ToString();
                Btnitem.Tag = db.dr[0].ToString();

                RightPan.Controls.Add(Btnitem);

                Btnitem.Click += Btnitem_Click_Right;
            }
            db.cn.Close();
        }

        private void Btnitem_Click_Right(object sender, EventArgs e)
        {
            MainPan.Controls.Clear();
            Cheese();
        }

        private void Cheese()
        {
            db.cn.Open();
            db.cm = new System.Data.SqlClient.SqlCommand("select * from cheese", db.cn);
            db.dr = db.cm.ExecuteReader();
            while (db.dr.Read())
            {
                Button Btnitem = new Button();
                Btnitem.Height = 100;
                Btnitem.Width = 125;
                Btnitem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
                Btnitem.FlatStyle = FlatStyle.Flat;
                Btnitem.Cursor = Cursors.Hand;
                Btnitem.ForeColor = Color.White;
                Btnitem.Text = db.dr[1].ToString();
                Btnitem.Tag = db.dr[0].ToString();

                MainPan.Controls.Add(Btnitem);

                Btnitem.Click += Btnitem_Click_Cheese;
            }
            db.cn.Close();
        }

        private void Btnitem_Click_Cheese(object sender, EventArgs e)
        {
            MainPan.Controls.Clear();
            Sandwich();
            
        }

        private void Sandwich()
        {
            db.cn.Open();
            db.cm = new System.Data.SqlClient.SqlCommand("select * from sandwich", db.cn);
            db.dr = db.cm.ExecuteReader();
            while (db.dr.Read())
            {
                Button Btnitem = new Button();
                Btnitem.Height = 100;
                Btnitem.Width = 125;
                Btnitem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
                Btnitem.FlatStyle = FlatStyle.Flat;
                Btnitem.Cursor = Cursors.Hand;
                Btnitem.ForeColor = Color.White;
                Btnitem.Text = db.dr[1].ToString();
                Btnitem.Tag = db.dr[0].ToString();

                MainPan.Controls.Add(Btnitem);

                Btnitem.Click += Btnitem_Click_Sandwich;
            }
            db.cn.Close();
        }

        private void Btnitem_Click_Sandwich(object sender, EventArgs e)
        {
            MainPan.Controls.Clear();
            Typesandwich();
        }

        private void Typesandwich()
        {
            db.cn.Open();
            db.cm = new System.Data.SqlClient.SqlCommand("select * from typesandwich", db.cn);
            db.dr = db.cm.ExecuteReader();
            while (db.dr.Read())
            {
                Button Btnitem = new Button();
                Btnitem.Height = 100;
                Btnitem.Width = 125;
                Btnitem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
                Btnitem.FlatStyle = FlatStyle.Flat;
                Btnitem.Cursor = Cursors.Hand;
                Btnitem.ForeColor = Color.White;
                Btnitem.Text = db.dr[1].ToString();
                Btnitem.Tag = db.dr[0].ToString();

                MainPan.Controls.Add(Btnitem);

                Btnitem.Click += Btnitem_Click_TypeSandwich;
            }
            db.cn.Close();
        }

        private void Btnitem_Click_TypeSandwich(object sender, EventArgs e)
        {
            //MainPan.Controls.Clear();
            string takename = ((Button)sender).Tag.ToString();
            if (Dgv.Rows.Count > 0)
            {
                Counts();
                bool ifound = false;
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) == takename)
                    {
                        row.Cells["qty"].Value = Convert.ToString(db._qty + Convert.ToInt32(row.Cells["qty"].Value));
                        ifound = true;
                        Counts();
                    }
                }
                if (!ifound)
                {
                    db.cn.Open();
                    db.cm = new System.Data.SqlClient.SqlCommand("select * from typesandwich where id=@id", db.cn);
                    db.cm.Parameters.AddWithValue("id", takename);
                    db.dr = db.cm.ExecuteReader();
                    while (db.dr.Read())
                    {
                        Dgv.Rows.Add(db.dr[0], db.dr[1], db.dr[2],db._qty);
                    }
                    db.cn.Close();
                    Counts();
                }
            }
            else 
            {
                db.cn.Open();
                db.cm = new System.Data.SqlClient.SqlCommand("select * from typesandwich where id=@id", db.cn);
                db.cm.Parameters.AddWithValue("id", takename);
                db.dr = db.cm.ExecuteReader();
                while (db.dr.Read())
                {
                    Dgv.Rows.Add(db.dr[0], db.dr[1], db.dr[2], db._qty);
                }
                db.cn.Close();
                Counts();
            }
            db._qty = 1;
        }



        private void LoadLeft()
        {
            db.cn.Open();
            db.cm = new System.Data.SqlClient.SqlCommand("select * from leftitem", db.cn);
            db.dr = db.cm.ExecuteReader();
            while (db.dr.Read())
            {
                Button Btnitem = new Button();
                Btnitem.Height = 100;
                Btnitem.Width = 125;
                Btnitem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
                Btnitem.FlatStyle = FlatStyle.Flat;
                Btnitem.Cursor = Cursors.Hand;
                Btnitem.ForeColor = Color.White;
                Btnitem.Text = db.dr[1].ToString();
                Btnitem.Tag = db.dr[0].ToString();

                LeftPan.Controls.Add(Btnitem);

                Btnitem.Click += Btnitem_Click_Left;
            }
            db.cn.Close();
        }

        private void Btnitem_Click_Left(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string ColName = Dgv.Columns[e.ColumnIndex].Name;
            if(ColName == "BtnVoid")
            {
                
                Dgv.Rows.RemoveAt(Dgv.CurrentRow.Index);
                Counts();
            }
            Counts();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            FrmQty f = new FrmQty();
            f.TopLevel = false;
            MainPan.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e) // Dine in btn
        {
            FrmPay f = new FrmPay(this);
            f.TopLevel = false;
            MainPan.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e) //Takeaway btn
        {
            FrmPay f = new FrmPay(this);
            f.TopLevel = false;
            MainPan.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e) //Void btn
        {
            
            Dgv.Rows.RemoveAt(Dgv.CurrentRow.Index);
            Counts();
        }

        private void button2_Click(object sender, EventArgs e) //Delete all btn
        {
            
            Dgv.Rows.Clear();
            Counts();
        }

        private void BtnRpt_Click(object sender, EventArgs e)
        {
            if (Dgv.CurrentRow.Cells[0].Selected = true)
            {
                Dgv.CurrentRow.Cells["qty"].Value = Convert.ToString(1 + Convert.ToInt32(Dgv.CurrentRow.Cells["qty"].Value));
                   
            }
            Counts();
        }
        private void loadFrmDown()
        {
            FrmDown f = new FrmDown();
            f.TopLevel = false;
            BottomPan.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void loadFrmTop()
        {
            FrmTop f = new FrmTop();
            f.TopLevel = false;
            TopPan.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e) // Delivery Btn
        {
            FrmCredit f = new FrmCredit();
            f.TopLevel = false;
            MainPan.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        

        private void Btn1_Click(object sender, EventArgs e)
        {
            db._qty = Convert.ToInt32(Btn1.Text);
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            db._qty = Convert.ToInt32(Btn2.Text);
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            db._qty = Convert.ToInt32(Btn3.Text);
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            db._qty = Convert.ToInt32(Btn4.Text);
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            db._qty = Convert.ToInt32(Btn5.Text);
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            db._qty = Convert.ToInt32(Btn6.Text);
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            db._qty = Convert.ToInt32(Btn7.Text);
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            db._qty = Convert.ToInt32(Btn8.Text);
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            db._qty = Convert.ToInt32(Btn9.Text);
        }
    }
}
