using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//Download by http://www.codefans.net
namespace MrCy
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            txtName.Focus(); 
        }

       
        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSubmit_Click(sender, e);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string strCon = "server=(local);database=db_MrCy0;Integrated security=true";
            if (txtName.Text == "")
            {
                MessageBox.Show("请输入用户名", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtPwd.Text == "")
                {
                    MessageBox.Show("请输入密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                 
               
                else
                {
                    SqlConnection conn = new SqlConnection(strCon);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select count(*) from tb_User where UserName='" + txtName.Text + "' and UserPwd='" + txtPwd.Text + "'", conn);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    if (i > 0)
                    {
                        cmd = new SqlCommand("select * from tb_User where UserName='" + txtName.Text + "'", conn);
                        SqlDataReader sdr = cmd.ExecuteReader();
                        sdr.Read();
                        string UserPower = sdr["power"].ToString().Trim();
                        conn.Close();
                        frmMain main = new frmMain();
                        main.power = UserPower;
                        main.Names = txtName.Text;
                        main.Times = DateTime.Now.ToShortDateString();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        txtName.Text = "";
                        txtPwd.Text = "";
                        if (MessageBox.Show("用户名或密码错误!"," 警告",MessageBoxButtons.OK,MessageBoxIcon.Warning)==DialogResult.OK)
                        {
                           
                        
                        }
                    }
                }
            }
        }

        private void btnConcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}