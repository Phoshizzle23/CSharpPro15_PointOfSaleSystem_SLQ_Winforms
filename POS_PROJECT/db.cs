using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS_PROJECT
{
    internal class db
    {
        public static SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\SQLEXPRESS;Initial Catalog=POS_Project;Integrated Security=True");
        public static SqlCommand cm = new SqlCommand();
        public static SqlDataReader dr = null;
        public static string FullName;
        public static int _id;
        public static int _qty = 1;
        public static int _orderNumber = 1;
        public static String _TypeOrder;

        public static void LoadForm(Form f, FlowLayoutPanel Pan)
        {
            // Load from inside FlowLayoutPanel
            f.TopLevel = false;
            Pan.Controls.Add(f);
            f.BringToFront();
            f.Show();

        }

        public static void LoadForm(Form f, Panel Pan)
        {
            // Load from inside Panel
            f.TopLevel = false;
            Pan.Controls.Add(f);
            f.BringToFront();
            f.Show();

        }
    }
}
