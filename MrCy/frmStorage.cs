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
    public partial class frmStorage : Form
    {
        public frmStorage()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            string strCon = "server=(local);database=db_MrCy;Integrated security=true";
            SqlConnection conn = new SqlConnection(strCon);
            SqlDataAdapter sda = new SqlDataAdapter("select 序号,材料名,存货量,供应商,材料单价" +
                " from tb_foodStorage order by 序号 asc",conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            storageCheck.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strCon = "server=(local);database=db_MrCy;Integrated security=true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            if (materialNum.Text == "")
            {
                SqlCommand cmd = new SqlCommand("select * from tb_foodStorage", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                materialName.Text = sdr["材料名"].ToString().Trim();
                materialSup.Text = sdr["供应商"].ToString().Trim();
                materialPrice.Text = sdr["材料单价"].ToString().Trim();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("select * from tb_foodStorage where 序号=" +
                    materialNum.Text, conn);
                SqlDataReader sdr = cmd1.ExecuteReader();
                sdr.Read();
                materialName.Text = sdr["材料名"].ToString().Trim();
                materialSup.Text = sdr["供应商"].ToString().Trim();
                materialPrice.Text = sdr["材料单价"].ToString().Trim();
            }
            conn.Close();
            GetData();
        }

        private void inStorage_Click(object sender, EventArgs e)
        {
            string strCon = "server=(local);database=db_MrCy;Integrated security=true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 + "+ materialCount.Text +
                 " where 序号 = "+materialNum.Text, conn);
            cmd.ExecuteNonQuery();
            double count = Convert.ToDouble(materialCount.Text) * Convert.ToDouble(materialPrice.Text);
            totalPrice.Text = count.ToString().Trim();
            conn.Close();
            GetData();
        }
    }
}
