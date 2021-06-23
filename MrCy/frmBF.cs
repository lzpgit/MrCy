using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MrCy
{
    public partial class frmBF : Form
    {
        public frmBF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBF_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string strg = Application.StartupPath.ToString();
                strg = strg.Substring(0, strg.LastIndexOf("\\"));
                strg = strg.Substring(0, strg.LastIndexOf("\\"));
                strg += @"\Data";
                string sqltxt = @"BACKUP DATABASE db_MrCy TO Disk='" + strg + "\\" + txtpath.Text +".bak"+ "'";
                string strCon = "server=(local);database=db_MrCy;Integrated security=true";
                SqlConnection conn = new SqlConnection(strCon);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqltxt, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                if (MessageBox.Show("备份成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void txtpath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}