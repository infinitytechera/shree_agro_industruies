using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace shree_agro
{
    public partial class frm_login : Form
    {


        string msg = "";
        public frm_login()
        {
            InitializeComponent();

        }
        //=========================== Check Login Data And Allow if Data is Match ============================================//
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_login = sp_sqlconnection.get_sp("userdetail","qtype=checkadmin|u_name="+ txtusername.Text.Trim().ToUpper() + "|status=2");//sqlconnection.fetchdatatable("select * from user_tbl where user_status=2 and user_name='" + txtusername.Text.Trim().ToUpper() + "'");
                //if (txtusername.Text.Trim().ToUpper() == "ADMIN" && panelControl1.Visible == false)
                if (dt_login.Rows.Count > 0 && panelControl1.Visible == false)
                {
                    //new Create_Party().Show();
                    //goto jump;
                    bind_country();
                    panelControl1.Visible = true;
                    cmb_country.Focus();

                    return;
                 
                }
                if (this.txtusername.Text == "")
                {
                    MessageBox.Show("Please Insert UserName", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtusername.Focus();
                    return;
                }
                if (this.txtpassword.Text == "")
                {
                    MessageBox.Show("Please Insert PassWord", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtpassword.Focus();
                    return;
                }
            jump:
                if (usermanagement.login(txtusername.Text, txtpassword.Text, (Convert.ToInt32(cmb_country.SelectedValue)).ToString()) != 0)
                {
                    this.Hide();
                    //UserDetail.user_id = 0;
                    //UserDetail.status = 0;
                    //UserDetail.c_id = 0;
                    //UserDetail.name = txtusername.Text.Trim().ToUpper();
                    //UserDetail.type = "";



                    //Please Modify below MDIParent Form Name and Parameter as Our Project Need.
                    MDIParent1 mdi = new MDIParent1();
                    //mdi.Text = UserDetail.c_id.ToString();
                    //msg = activation.remainingdays(this);
                    if (UserDetail.user_id != null && UserDetail.user_id != 0)
                    {
                        mdi.ShowDialog();
                    }
                    //if (msg != "")
                    //{
                    //    if (msg == "OK")
                    //    {
                    //        mdi.ShowDialog();                           
                    //    }

                    //    else
                    //    {
                    //        //mdi.lbldemo.Text = msg;

                    //        // Here Modify Controlname and Strip Menu Item as Your Project Need For Visible Activation Link on Menustrip
                    //        // OR
                    //        // Give Your menustrip,ToolStripMenuItem and MDIparent name as below type(As per passing parameter).

                    //        //activation.enableactivation(mdi, "menuStrip1", "activationToolStripMenuItem");
                    //        mdi.ShowDialog();
                    //    }
                    //}


                }

                else
                {
                    MessageBox.Show("UserName And PassWord Incorrect" + Environment.NewLine + " Please Enter Valid UserName And Password");
                    //this.txtusername.Text = "";
                    //this.txtpassword.Text = "";
                    this.txtusername.Focus();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void bind_country()
        {
            DataTable dt_cnt = sp_sqlconnection.get_sp("company_detail","qtype=select");//sqlconnection.fetchdatatable("select * from country_mst_tbl order by party asc");
            cmb_country.DataSource = dt_cnt;
            cmb_country.DisplayMember = "c_name";
            cmb_country.ValueMember = "c_id";
        }
        //===========================KeyDown Event============================================//
        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtpassword.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnlogin.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnlogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnlogin.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        //=========================== Open Forgot Password Form on Link Click ============================================//
        private void forgotpwdlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Plese Just Uncomment Below Code for access Forgotpassword Form.

            //frm_forgotpassword frgtpwd = new frm_forgotpassword();
            //frgtpwd.Show();
            //return;
        }

        private void forgotpwdlink_MouseHover(object sender, EventArgs e)
        {
            forgotpwdlink.LinkColor = Color.Black;
        }

        private void forgotpwdlink_MouseLeave(object sender, EventArgs e)
        {
            forgotpwdlink.LinkColor = Color.Teal;
        }

        private void frm_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
