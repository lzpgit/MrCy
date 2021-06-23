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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public SqlDataReader sdr;
        public string power;
        public string Names;
        public string Times;
        private void frmMain_Load(object sender, EventArgs e)
        {
                switch (power)
                {
                    case "0": toolStripStatusLabel13.Text = "��������Ա"; break;
                    case "1": toolStripStatusLabel13.Text = "����"; break;
                    case "�μ�����": toolStripStatusLabel13.Text = "�μ�����"; break;
            //        case "2": toolStripStatusLabel13.Text = "һ���û�"; break;
                    default :   toolStripStatusLabel13.Text="һ���û�";break;
                }
            toolStripStatusLabel10.Text = Names;
            toolStripStatusLabel16.Text = Times;
         /*   if (power == "2")
            {
                ϵͳά��SToolStripMenuItem.Enabled = false;
                ������ϢMToolStripMenuItem.Enabled = false;
            }
         */
            if (power == "0" || power == "�μ�����")
            { 
            
            }
        //    if (power == "�μ�����")
        //    { 
            
         //   }
            else if (power == "1")
            {
                ϵͳά��SToolStripMenuItem.Enabled = false;
            }

            else
            {
                ϵͳά��SToolStripMenuItem.Enabled = false;
                ������ϢMToolStripMenuItem.Enabled = false;

            }

            
        }
        private void AddItems(string rzt)
        {
            if (rzt == "ʹ��")
            {
                lvDesk.Items.Add(sdr["RoomName"].ToString(), 1);
            }
            else
            {
                lvDesk.Items.Add(sdr["RoomName"].ToString(), 0);
            }
        }


        private void ��̨ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {

                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                frmOpen openroom = new frmOpen();
                openroom.name = names;
                openroom.ShowDialog();
            }
            else
            {
                MessageBox.Show("��ѡ����̨");
            }
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            string strCon = "server=(local);database=db_MrCy0;Integrated security=true";
            SqlConnection conn = new SqlConnection(strCon);
            lvDesk.Items.Clear();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_Room", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string zt = sdr["RoomZT"].ToString().Trim();
                AddItems(zt);
            }
            conn.Close();
        }
        private void ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {
                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                frmDC dc = new frmDC();
                dc.RName = names;
                dc.ShowDialog();
            }
            else
            {
                MessageBox.Show("��ѡ����̨");
            }
        }

        private void ���Ѳ�ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {
                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                frmSerch serch = new frmSerch();
                serch.RName = names;
                serch.ShowDialog();
            }
            else
            {
                MessageBox.Show("��ѡ����̨");
            }
        }
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {
                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                frmJZ jz = new frmJZ();
                jz.Rname = names;
                jz.ShowDialog();
            }
            else
            {
                MessageBox.Show("��ѡ����̨");
            }

        }
        private void lvDesk_DoubleClick(object sender, EventArgs e)
        {
            frmDetails details = new frmDetails();
            details.TableName = lvDesk.SelectedItems[0].SubItems[0].Text;
            details.ShowDialog();
        }
        private void lvDesk_Click(object sender, EventArgs e)
        {
            string names = lvDesk.SelectedItems[0].SubItems[0].Text;
            string strCon = "server=(local);database=db_MrCy;Integrated security=true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_Room where RoomName='" + names + "'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string zt = sdr["RoomZT"].ToString().Trim();
            sdr.Close();
            if (zt == "ʹ��")
            {
                this.contextMenuStrip1.Items[0].Enabled = false;
                this.contextMenuStrip1.Items[1].Enabled = true;
                this.contextMenuStrip1.Items[3].Enabled = true;
                this.contextMenuStrip1.Items[5].Enabled = true;
                this.contextMenuStrip1.Items[6].Enabled = true;
            }
            if (zt == "����")
            {
                this.contextMenuStrip1.Items[0].Enabled = true;
                this.contextMenuStrip1.Items[1].Enabled = false;
                this.contextMenuStrip1.Items[3].Enabled = false;
                this.contextMenuStrip1.Items[5].Enabled = false;
                this.contextMenuStrip1.Items[6].Enabled = false;
            }
            conn.Close();
        }

        private void ȡ����̨toolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (lvDesk.SelectedItems.Count != 0)
            {
                string strCon = "server=(local);database=db_MrCy;Integrated security=true";
                SqlConnection conn = new SqlConnection(strCon);
                conn.Open();

                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                SqlCommand cmd = new SqlCommand("Select * from tb_guestfood where roomname='" + names + "'", conn);
                int i = Convert.ToInt32(cmd.ExecuteScalar());

                if (i > 0)
                {
                    MessageBox.Show("���Ƚ���!!");

                }
            

               else
              {



                cmd = new SqlCommand("update tb_Room set RoomZT='����',Num=0 where RoomName='" + names + "'", conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("delete from tb_GuestFood where roomname='" + names + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                frmMain_Activated(sender, e);
              }
            }
            else
            {
                MessageBox.Show("��ѡ����̨");

            }
            }
           
        
        private void ��̨��ϢToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDesk desk = new frmDesk();
            desk.ShowDialog();
        }

        private void ְԱ��ϢToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUser users = new frmUser();
            users.ShowDialog();
        }

        private void ����ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCalender calender = new frmCalender();
            calender.ShowDialog();
        }

        private void ���±�ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void ������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void Ȩ�޹���ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void ϵͳ����ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBF bf = new frmBF();
            bf.ShowDialog();
        }

        private void ϵͳ�ָ�ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmHF hf = new frmHF();
            hf.ShowDialog();
        }

        private void ��������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPwd pwd = new frmPwd();
            pwd.names = Names;
            pwd.ShowDialog();
        }

        private void ����ϵͳToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLock locksystem = new frmLock();
            locksystem.Owner = this;
            locksystem.ShowDialog();
        }

        private void ����ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void �˳�ϵͳToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ȷ���˳���ϵͳ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void ϵͳά��SToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void �޸��û�Ȩ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXgQx qx = new frmXgQx();
            qx.ShowDialog();
        }

        private void ע�����û�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmZc zc = new FrmZc();
            zc.ShowDialog();
        }

        private void ɾ���û�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSch sch = new FrmSch();
            sch.ShowDialog();
        }

        private void ʳƷ��ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFood food = new FrmFood();
            food.ShowDialog();
        }

        private void ��ѯͳ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void �����ձ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmZhangDan zhdan = new frmZhangDan();
            zhdan.ShowDialog();
        }

        private void lvDesk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void storage_Click(object sender, EventArgs e)
        {
            frmStorage cailiaocangku = new frmStorage();
            cailiaocangku.ShowDialog();
        }
    }
}