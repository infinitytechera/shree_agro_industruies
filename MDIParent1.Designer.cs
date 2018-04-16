namespace shree_agro
{
    partial class MDIParent1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_item = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_party = new DevExpress.XtraBars.BarButtonItem();
            this.btn_warehouse = new DevExpress.XtraBars.BarButtonItem();
            this.btn_company = new DevExpress.XtraBars.BarButtonItem();
            this.btn_year = new DevExpress.XtraBars.BarButtonItem();
            this.btn_purchase = new DevExpress.XtraBars.BarButtonItem();
            this.btn_sale = new DevExpress.XtraBars.BarButtonItem();
            this.rp_master = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpg_item = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpg_party = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpg_warehouse = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpg_year = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpg_company = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rp_pur_sale = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpg_pur = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpg_sale = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rp_manufacturing = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rp_account = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rp_report = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rp_utility = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.user_panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btn_item,
            this.barButtonItem2,
            this.btn_party,
            this.btn_warehouse,
            this.btn_company,
            this.btn_year,
            this.btn_purchase,
            this.btn_sale});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 13;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rp_master,
            this.rp_pur_sale,
            this.rp_manufacturing,
            this.rp_account,
            this.rp_report,
            this.rp_utility});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.ribbonControl1.Size = new System.Drawing.Size(1320, 143);
            // 
            // btn_item
            // 
            this.btn_item.Caption = "Item";
            this.btn_item.Id = 2;
            this.btn_item.Name = "btn_item";
            this.btn_item.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_item_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btn_party
            // 
            this.btn_party.Caption = "Party";
            this.btn_party.Id = 4;
            this.btn_party.Name = "btn_party";
            this.btn_party.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_party.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_party_ItemClick);
            // 
            // btn_warehouse
            // 
            this.btn_warehouse.Caption = "Warehouse";
            this.btn_warehouse.Id = 8;
            this.btn_warehouse.Name = "btn_warehouse";
            this.btn_warehouse.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_warehouse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_warehouse_ItemClick);
            // 
            // btn_company
            // 
            this.btn_company.Caption = "Company";
            this.btn_company.Id = 9;
            this.btn_company.Name = "btn_company";
            this.btn_company.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_company.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_company_ItemClick);
            // 
            // btn_year
            // 
            this.btn_year.Caption = "Year";
            this.btn_year.Id = 10;
            this.btn_year.Name = "btn_year";
            this.btn_year.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_year.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_year_ItemClick);
            // 
            // btn_purchase
            // 
            this.btn_purchase.Caption = "Purchase";
            this.btn_purchase.Id = 11;
            this.btn_purchase.Name = "btn_purchase";
            this.btn_purchase.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_purchase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_purchase_ItemClick);
            // 
            // btn_sale
            // 
            this.btn_sale.Caption = "Sale";
            this.btn_sale.Id = 12;
            this.btn_sale.Name = "btn_sale";
            this.btn_sale.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // rp_master
            // 
            this.rp_master.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpg_item,
            this.rpg_party,
            this.rpg_warehouse,
            this.rpg_year,
            this.rpg_company});
            this.rp_master.Name = "rp_master";
            this.rp_master.Text = "Master";
            // 
            // rpg_item
            // 
            this.rpg_item.AllowTextClipping = false;
            this.rpg_item.ItemLinks.Add(this.btn_item);
            this.rpg_item.Name = "rpg_item";
            this.rpg_item.ShowCaptionButton = false;
            // 
            // rpg_party
            // 
            this.rpg_party.AllowTextClipping = false;
            this.rpg_party.ItemLinks.Add(this.btn_party);
            this.rpg_party.Name = "rpg_party";
            this.rpg_party.ShowCaptionButton = false;
            // 
            // rpg_warehouse
            // 
            this.rpg_warehouse.AllowTextClipping = false;
            this.rpg_warehouse.ItemLinks.Add(this.btn_warehouse);
            this.rpg_warehouse.Name = "rpg_warehouse";
            this.rpg_warehouse.ShowCaptionButton = false;
            // 
            // rpg_year
            // 
            this.rpg_year.AllowTextClipping = false;
            this.rpg_year.ItemLinks.Add(this.btn_year);
            this.rpg_year.Name = "rpg_year";
            this.rpg_year.ShowCaptionButton = false;
            // 
            // rpg_company
            // 
            this.rpg_company.AllowTextClipping = false;
            this.rpg_company.ItemLinks.Add(this.btn_company);
            this.rpg_company.Name = "rpg_company";
            this.rpg_company.ShowCaptionButton = false;
            // 
            // rp_pur_sale
            // 
            this.rp_pur_sale.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpg_pur,
            this.rpg_sale});
            this.rp_pur_sale.Name = "rp_pur_sale";
            this.rp_pur_sale.Text = "Purchase & Sale";
            // 
            // rpg_pur
            // 
            this.rpg_pur.AllowTextClipping = false;
            this.rpg_pur.ItemLinks.Add(this.btn_purchase);
            this.rpg_pur.Name = "rpg_pur";
            this.rpg_pur.ShowCaptionButton = false;
            // 
            // rpg_sale
            // 
            this.rpg_sale.AllowTextClipping = false;
            this.rpg_sale.ItemLinks.Add(this.btn_sale);
            this.rpg_sale.Name = "rpg_sale";
            this.rpg_sale.ShowCaptionButton = false;
            // 
            // rp_manufacturing
            // 
            this.rp_manufacturing.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.rp_manufacturing.Name = "rp_manufacturing";
            this.rp_manufacturing.Text = "Manufacturing";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            // 
            // rp_account
            // 
            this.rp_account.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.rp_account.Name = "rp_account";
            this.rp_account.Text = "Account";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // rp_report
            // 
            this.rp_report.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.rp_report.Name = "rp_report";
            this.rp_report.Text = "Report";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            // 
            // rp_utility
            // 
            this.rp_utility.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.rp_utility.Name = "rp_utility";
            this.rp_utility.Text = "Utility";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.AllowTextClipping = false;
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1320, 546);
            this.panel1.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.tabControl1.ItemSize = new System.Drawing.Size(88, 20);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1320, 546);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.DoubleClick += new System.EventHandler(this.tabControl1_DoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.user_panel);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1312, 518);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // user_panel
            // 
            this.user_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.user_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_panel.Location = new System.Drawing.Point(0, 0);
            this.user_panel.Name = "user_panel";
            this.user_panel.Size = new System.Drawing.Size(1312, 518);
            this.user_panel.TabIndex = 1;
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 689);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "MDIParent1";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDIParent1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDIParent1_FormClosed);
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rp_master;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_item;
        private DevExpress.XtraBars.BarButtonItem btn_item;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btn_party;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel user_panel;
        private DevExpress.XtraBars.Ribbon.RibbonPage rp_pur_sale;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_pur;
        private DevExpress.XtraBars.Ribbon.RibbonPage rp_manufacturing;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage rp_account;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage rp_report;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage rp_utility;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_party;
        private DevExpress.XtraBars.BarButtonItem btn_warehouse;
        private DevExpress.XtraBars.BarButtonItem btn_company;
        private DevExpress.XtraBars.BarButtonItem btn_year;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_warehouse;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_year;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_company;
        private DevExpress.XtraBars.BarButtonItem btn_purchase;
        private DevExpress.XtraBars.BarButtonItem btn_sale;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_sale;
    }
}



