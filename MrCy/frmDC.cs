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
    public partial class frmDC : Form
    {
        public frmDC()
        {
            InitializeComponent();
        }
        public string RName;
        private void frmDC_Load(object sender, EventArgs e)
        {
            this.Text = RName + "点/加菜";
            TreeNode newnode1 = tvFood.Nodes.Add("新菜");
            TreeNode newnode2 = tvFood.Nodes.Add("小炒");
            TreeNode newnode3 = tvFood.Nodes.Add("火锅和汤类");
            TreeNode newnode4 = tvFood.Nodes.Add("主食");
            TreeNode newnode5 = tvFood.Nodes.Add("酒类");
            TreeNode newnode6 = tvFood.Nodes.Add("香烟");
            TreeNode newnode7 = tvFood.Nodes.Add("饮料");
            string strCon = "server=(local);database=db_MrCy;Integrated security=true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_food where foodty='新菜'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode1.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='小炒'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode2.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='火锅和汤类'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode3.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='主食'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode4.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='酒类'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode5.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='香烟'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode6.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='饮料'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode7.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();

            cmd = new SqlCommand("select * from tb_Waiter",conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                cbWaiter.Items.Add(sdr["WaiterName"].ToString().Trim());
            }
            cbWaiter.SelectedIndex = 0;
            sdr.Close();
            cmd = new SqlCommand("select RoomZT from tb_Room where RoomName='"+RName+"'",conn);
            string zt = Convert.ToString(cmd.ExecuteScalar());
            if (zt.Trim() == "待用")
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
            }
            conn.Close();
            GetData();
            tvFood.ExpandAll();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            string foodname = tvFood.SelectedNode.Text;
            if (foodname == "新菜" || foodname == "小炒" || foodname == "凉菜和火锅类" || foodname == "主食" || foodname == "酒类" || foodname == "香烟" || foodname == "饮料")
            {

            }
            else
            {
                string strCon = "server=(local);database=db_MrCy;Integrated security=true";
                SqlConnection conn = new SqlConnection(strCon);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from tb_food where foodname='" + foodname + "'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                txtNum.Text = sdr["foodnum"].ToString().Trim();
                txtName.Text = foodname;
                txtprice.Text = sdr["foodprice"].ToString().Trim();
                conn.Close();
                if (txtpnum.Text == "")
                {
                    MessageBox.Show("数量不能为空");
                    return;
                }
                else
                {
                    txtallprice.Text = Convert.ToString(Convert.ToInt32(txtprice.Text) * Convert.ToInt32(txtpnum.Text));
                }
            }
        }

        private void txtpnum_TextChanged(object sender, EventArgs e)
        {
            if (txtpnum.Text == "")
            {
                MessageBox.Show("数量不能为空");
                return;
            }
            else
            {
                if (Convert.ToInt32(txtpnum.Text) < 1)
                {
                    MessageBox.Show("不能为小于1的数字");
                    return;
                }
                else
                {
                    txtallprice.Text = Convert.ToString(Convert.ToInt32(txtprice.Text) * Convert.ToInt32(txtpnum.Text));
                }
            }
        }
        private void GetData()
        {
            string strCon = "server=(local);database=db_MrCy;Integrated security=true";
            SqlConnection conn = new SqlConnection(strCon);
            SqlDataAdapter sda = new SqlDataAdapter("select foodname,foodsum,foodallprice,waitername,beizhu,roomname,datatime from tb_GuestFood where roomname='" + RName + "'order by ID desc", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvFoods.DataSource = ds.Tables[0];
        }

        private void txtpnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字");
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFoods.SelectedRows.Count > 0)
            {
                string names = dgvFoods.SelectedCells[0].Value.ToString();
                string strCon = "server=(local);database=db_MrCy;Integrated security=true";
                SqlConnection conn = new SqlConnection(strCon);
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from tb_GuestFood where foodname='" + names + "' and roomname='" + RName + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                GetData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtNum.Text == ""|| txtprice.Text == "")
            {
                MessageBox.Show("请将选择菜系");
                return;
            }
            else
            {
                if (txtpnum.Text == "")
                {
                    MessageBox.Show("数量不能为空");
                    return;
                }
                else
                {
                    if (Convert.ToInt32(txtpnum.Text) <= 0)
                    {
                        MessageBox.Show("请输入消费数量");
                        return;
                    }
                    else
                    {
                        string strCon = "server=(local);database=db_MrCy;Integrated security=true";
                        SqlConnection conn = new SqlConnection(strCon);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("insert into tb_GuestFood" +
                            "(foodnum,foodname,foodsum,foodallprice,waitername,beizhu,roomname,datatime)" +
                            " values('" + txtNum.Text.Trim() + "','" + txtName.Text.Trim() + "','" + 
                            txtpnum.Text.Trim() + "','" + Convert.ToDecimal(txtallprice.Text.Trim()) + 
                            "','" + cbWaiter.SelectedItem.ToString() + "','" + txtbz.Text.Trim() + "','" +
                            RName + "','" + DateTime.Now.ToString() + "')", conn);
                        if(txtNum.Text == "101")
                        { 
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - "+txtpnum.Text+" "+
                                "where 序号 = 1001 or 序号 = 1002", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if(txtNum.Text == "102")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1003 or 序号 = 1004", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "201")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1005 or 序号 = 1006", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "202")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1007", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "301")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1008 or 序号 = 1009", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "302")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1010", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "401")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1011", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "402")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1015", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "501")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1012", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "601")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1016", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "701")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1013", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "403")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1015", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "203")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1015 or 序号 = 1011", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "204")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set 存货量 = 存货量 - " + txtpnum.Text + " " +
                                "where 序号 = 1014", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        GetData();
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvFood_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}