using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shree_agro
{
    public partial class MDIParent1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
            rpg_warehouse.Visible = false;
        }
        public int? searchindex(string text)
        {
            int? index = null;

            foreach (TabPage tabpage in tabControl1.TabPages)
            {
                if (tabpage.Text == text)
                {
                    index = tabControl1.TabPages.IndexOf(tabpage);
                }
            }

            return index;

        }
        #region Master Tab
        private void btn_item_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UserDetail.status >=2)
            {
                var myForm = new Item_mst() { TopLevel = false, AutoScroll = true, WindowState = FormWindowState.Maximized, FormBorderStyle = FormBorderStyle.None };
                TabPage myTabPage = new TabPage(myForm.Text);
                myForm.Dock = DockStyle.Fill;
                myTabPage.Controls.Add(myForm);
                int? index = searchindex(myForm.Text);
                if (index == null)
                {
                    tabControl1.TabPages.Add(myTabPage);
                    tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                    myForm.Show();
                }
                else
                {
                    tabControl1.SelectedIndex = Convert.ToInt32(index);
                }
            }
        }
        private void btn_party_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UserDetail.status >= 2)
            {
                var myForm = new Party_mst() { TopLevel = false, AutoScroll = true, WindowState = FormWindowState.Maximized, FormBorderStyle = FormBorderStyle.None };
                TabPage myTabPage = new TabPage(myForm.Text);
                myForm.Dock = DockStyle.Fill;
                myTabPage.Controls.Add(myForm);
                int? index = searchindex(myForm.Text);
                if (index == null)
                {
                    tabControl1.TabPages.Add(myTabPage);
                    tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                    myForm.Show();
                }
                else
                {
                    tabControl1.SelectedIndex = Convert.ToInt32(index);
                }
            }
        }
        private void btn_year_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UserDetail.status >= 2)
            {
                var myForm = new Year_mst() { TopLevel = false, AutoScroll = true, WindowState = FormWindowState.Maximized, FormBorderStyle = FormBorderStyle.None };
                TabPage myTabPage = new TabPage(myForm.Text);
                myForm.Dock = DockStyle.Fill;
                myTabPage.Controls.Add(myForm);
                int? index = searchindex(myForm.Text);
                if (index == null)
                {
                    tabControl1.TabPages.Add(myTabPage);
                    tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                    myForm.Show();
                }
                else
                {
                    tabControl1.SelectedIndex = Convert.ToInt32(index);
                }
            }
        }
        private void btn_warehouse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UserDetail.status >= 2)
            {
                var myForm = new warehouse_mst() { TopLevel = false, AutoScroll = true, WindowState = FormWindowState.Maximized, FormBorderStyle = FormBorderStyle.None };
                TabPage myTabPage = new TabPage(myForm.Text);
                myForm.Dock = DockStyle.Fill;
                myTabPage.Controls.Add(myForm);
                int? index = searchindex(myForm.Text);
                if (index == null)
                {
                    tabControl1.TabPages.Add(myTabPage);
                    tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                    myForm.Show();
                }
                else
                {
                    tabControl1.SelectedIndex = Convert.ToInt32(index);
                }
            }
        }
        private void btn_company_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UserDetail.status >= 2)
            {
                var myForm = new Company_mst() { TopLevel = false, AutoScroll = true, WindowState = FormWindowState.Maximized, FormBorderStyle = FormBorderStyle.None };
                TabPage myTabPage = new TabPage(myForm.Text);
                myForm.Dock = DockStyle.Fill;
                myTabPage.Controls.Add(myForm);
                int? index = searchindex(myForm.Text);
                if (index == null)
                {
                    tabControl1.TabPages.Add(myTabPage);
                    tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                    myForm.Show();
                }
                else
                {
                    tabControl1.SelectedIndex = Convert.ToInt32(index);
                }
            }
        }
        #endregion

        #region Pur & Sale
        private void btn_purchase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UserDetail.status >= 2)
            {
                var myForm = new Purchase() { TopLevel = false, AutoScroll = true, WindowState = FormWindowState.Maximized, FormBorderStyle = FormBorderStyle.None };
                TabPage myTabPage = new TabPage(myForm.Text);
                myForm.Dock = DockStyle.Fill;
                myTabPage.Controls.Add(myForm);
                int? index = searchindex(myForm.Text);
                if (index == null)
                {
                    tabControl1.TabPages.Add(myTabPage);
                    tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                    myForm.Show();
                }
                else
                {
                    tabControl1.SelectedIndex = Convert.ToInt32(index);
                }
            }
        }
        #endregion

        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void MDIParent1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            bind_master.bind_mst();
        }
    }
}
