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
    public partial class frmOpen : Form
    {
        public frmOpen()
        {
            InitializeComponent();
        }


        public string name;
        //public SqlConnection conn;
        private void frmOpen_Load(object sender, EventArgs e)
        {
            string strCon = "server=(local);database=db_MrCy;Integrated security=true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_Room",conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
               cbNum.Items.Add(sdr["RoomName"].ToString().Trim());
            }
            cbNum.SelectedItem= name.Trim();
            sdr.Close();
            cmd = new SqlCommand("select * from tb_Waiter",conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                cbWaiter.Items.Add(sdr["WaiterName"].ToString().Trim());
            }
            cbWaiter.SelectedIndex = 0;
            sdr.Close();
            conn.Close();
        }



        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字");
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNum.Text == ""||Convert.ToInt32(txtNum.Text)<=0)
            {
                MessageBox.Show("请输入用餐人数");
            }
            else
            {
                string strCon = "server=(local);database=db_MrCy;Integrated security=true";
                SqlConnection conn = new SqlConnection(strCon);
                conn.Open();
                string RoomName = cbNum.SelectedItem.ToString();
                SqlCommand cmd1 = new SqlCommand("update tb_Room set GuestName='" + txtName.Text + "',zhangdanDate='" + dateTimePicker1.Value.ToShortDateString()+ "',Num='" + Convert.ToInt32(txtNum.Text) + "',WaiterName='" + cbWaiter.SelectedItem.ToString() + "',RoomZT='使用' where RoomName='" + name + "'", conn);
                cmd1.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}