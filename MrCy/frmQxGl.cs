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
    public partial class frmXgQx : Form
    {
        public frmXgQx()
        {
            InitializeComponent();
        }

        private void frmQxGl_Load(object sender, EventArgs e)
        {
            string strCon = "server=(local);database=db_MrCy;Integrated security=true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_User",conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                comboBox1.Items.Add(sdr["UserName"].ToString().Trim());
            }
            comboBox1.SelectedIndex = 0;
            sdr.Close();
            comboBox2.SelectedIndex = 0;
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userpower="";
            switch (comboBox2.SelectedItem.ToString())
            {
                case "��������Ա": userpower = "0"; break;
                case "����": userpower = "1"; break;
                case "һ���û�": userpower = "2"; break;
            }
            string strCon = "server=(local);database=db_MrCy;Integrated security=true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update tb_User set power='"+userpower+"'",conn);
            cmd.ExecuteNonQuery();
            if (MessageBox.Show("Ȩ���޸ĳɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}