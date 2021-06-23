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
            this.Text = RName + "��/�Ӳ�";
            TreeNode newnode1 = tvFood.Nodes.Add("�²�");
            TreeNode newnode2 = tvFood.Nodes.Add("С��");
            TreeNode newnode3 = tvFood.Nodes.Add("���������");
            TreeNode newnode4 = tvFood.Nodes.Add("��ʳ");
            TreeNode newnode5 = tvFood.Nodes.Add("����");
            TreeNode newnode6 = tvFood.Nodes.Add("����");
            TreeNode newnode7 = tvFood.Nodes.Add("����");
            string strCon = "server=(local);database=db_MrCy;Integrated security=true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_food where foodty='�²�'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode1.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='С��'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode2.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='���������'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode3.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='��ʳ'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode4.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='����'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode5.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='����'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                newnode6.Nodes.Add(sdr[3].ToString().Trim());
            }
            sdr.Close();
            cmd = new SqlCommand("select * from tb_food where foodty='����'", conn);
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
            if (zt.Trim() == "����")
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
            if (foodname == "�²�" || foodname == "С��" || foodname == "���˺ͻ����" || foodname == "��ʳ" || foodname == "����" || foodname == "����" || foodname == "����")
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
                    MessageBox.Show("��������Ϊ��");
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
                MessageBox.Show("��������Ϊ��");
                return;
            }
            else
            {
                if (Convert.ToInt32(txtpnum.Text) < 1)
                {
                    MessageBox.Show("����ΪС��1������");
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
                MessageBox.Show("����������");
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
                MessageBox.Show("�뽫ѡ���ϵ");
                return;
            }
            else
            {
                if (txtpnum.Text == "")
                {
                    MessageBox.Show("��������Ϊ��");
                    return;
                }
                else
                {
                    if (Convert.ToInt32(txtpnum.Text) <= 0)
                    {
                        MessageBox.Show("��������������");
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
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - "+txtpnum.Text+" "+
                                "where ��� = 1001 or ��� = 1002", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if(txtNum.Text == "102")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1003 or ��� = 1004", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "201")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1005 or ��� = 1006", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "202")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1007", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "301")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1008 or ��� = 1009", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "302")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1010", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "401")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1011", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "402")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1015", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "501")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1012", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "601")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1016", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "701")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1013", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "403")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1015", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "203")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1015 or ��� = 1011", conn);
                            cmd2.ExecuteNonQuery();
                        }
                        else if (txtNum.Text == "204")
                        {
                            SqlCommand cmd2 = new SqlCommand("update tb_foodStorage set ����� = ����� - " + txtpnum.Text + " " +
                                "where ��� = 1014", conn);
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