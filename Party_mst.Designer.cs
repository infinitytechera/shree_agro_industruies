namespace shree_agro
{
    partial class Party_mst
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_party_name = new System.Windows.Forms.TextBox();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_pan_no = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_bank_acc_no = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_bank_address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_bank_ifsc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_gst = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_mob_no = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_broker = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gc_bank = new DevExpress.XtraEditors.GroupControl();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_bank_name = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_category = new System.Windows.Forms.ComboBox();
            this.btn_exit = new DevExpress.XtraEditors.SimpleButton();
            this.btndelete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_reset = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_state = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_city = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gc_bank)).BeginInit();
            this.gc_bank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txt_party_name
            // 
            this.txt_party_name.Location = new System.Drawing.Point(63, 28);
            this.txt_party_name.Name = "txt_party_name";
            this.txt_party_name.Size = new System.Drawing.Size(218, 20);
            this.txt_party_name.TabIndex = 0;
            this.txt_party_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_party_name_KeyDown);
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(63, 54);
            this.txt_address.Multiline = true;
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(218, 46);
            this.txt_address.TabIndex = 2;
            this.txt_address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            // 
            // txt_pan_no
            // 
            this.txt_pan_no.Location = new System.Drawing.Point(63, 106);
            this.txt_pan_no.Name = "txt_pan_no";
            this.txt_pan_no.Size = new System.Drawing.Size(218, 20);
            this.txt_pan_no.TabIndex = 5;
            this.txt_pan_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pan No";
            // 
            // txt_bank_acc_no
            // 
            this.txt_bank_acc_no.Location = new System.Drawing.Point(67, 54);
            this.txt_bank_acc_no.Name = "txt_bank_acc_no";
            this.txt_bank_acc_no.Size = new System.Drawing.Size(127, 21);
            this.txt_bank_acc_no.TabIndex = 1;
            this.txt_bank_acc_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Acc No";
            // 
            // txt_bank_address
            // 
            this.txt_bank_address.Location = new System.Drawing.Point(67, 80);
            this.txt_bank_address.Name = "txt_bank_address";
            this.txt_bank_address.Size = new System.Drawing.Size(127, 21);
            this.txt_bank_address.TabIndex = 2;
            this.txt_bank_address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Address";
            // 
            // txt_bank_ifsc
            // 
            this.txt_bank_ifsc.Location = new System.Drawing.Point(67, 106);
            this.txt_bank_ifsc.Name = "txt_bank_ifsc";
            this.txt_bank_ifsc.Size = new System.Drawing.Size(127, 21);
            this.txt_bank_ifsc.TabIndex = 3;
            this.txt_bank_ifsc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "IFSC Code";
            // 
            // txt_gst
            // 
            this.txt_gst.Location = new System.Drawing.Point(358, 106);
            this.txt_gst.Name = "txt_gst";
            this.txt_gst.Size = new System.Drawing.Size(218, 20);
            this.txt_gst.TabIndex = 6;
            this.txt_gst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "GST No";
            // 
            // txt_mob_no
            // 
            this.txt_mob_no.Location = new System.Drawing.Point(63, 132);
            this.txt_mob_no.Name = "txt_mob_no";
            this.txt_mob_no.Size = new System.Drawing.Size(218, 20);
            this.txt_mob_no.TabIndex = 7;
            this.txt_mob_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Mob No";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(63, 158);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(218, 20);
            this.txt_email.TabIndex = 9;
            this.txt_email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Email";
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(358, 158);
            this.txt_remark.Multiline = true;
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(218, 48);
            this.txt_remark.TabIndex = 10;
            this.txt_remark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(311, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Remark";
            // 
            // txt_broker
            // 
            this.txt_broker.Location = new System.Drawing.Point(63, 184);
            this.txt_broker.Name = "txt_broker";
            this.txt_broker.Size = new System.Drawing.Size(218, 20);
            this.txt_broker.TabIndex = 11;
            this.txt_broker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Broker";
            // 
            // gc_bank
            // 
            this.gc_bank.Controls.Add(this.label12);
            this.gc_bank.Controls.Add(this.txt_bank_name);
            this.gc_bank.Controls.Add(this.txt_bank_acc_no);
            this.gc_bank.Controls.Add(this.label4);
            this.gc_bank.Controls.Add(this.label5);
            this.gc_bank.Controls.Add(this.txt_bank_address);
            this.gc_bank.Controls.Add(this.label6);
            this.gc_bank.Controls.Add(this.txt_bank_ifsc);
            this.gc_bank.Location = new System.Drawing.Point(623, 29);
            this.gc_bank.Name = "gc_bank";
            this.gc_bank.Size = new System.Drawing.Size(199, 140);
            this.gc_bank.TabIndex = 12;
            this.gc_bank.Text = "Bank Detail";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Name";
            // 
            // txt_bank_name
            // 
            this.txt_bank_name.Location = new System.Drawing.Point(67, 27);
            this.txt_bank_name.Name = "txt_bank_name";
            this.txt_bank_name.Size = new System.Drawing.Size(127, 21);
            this.txt_bank_name.TabIndex = 0;
            this.txt_bank_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(306, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Category";
            // 
            // cmb_category
            // 
            this.cmb_category.FormattingEnabled = true;
            this.cmb_category.Items.AddRange(new object[] {
            "CAPITAL",
            "LOAN",
            "CREDITORS",
            "DEBITORS",
            "CASH",
            "BANK",
            "EXPENSE",
            "BROKER"});
            this.cmb_category.Location = new System.Drawing.Point(358, 28);
            this.cmb_category.Name = "cmb_category";
            this.cmb_category.Size = new System.Drawing.Size(218, 21);
            this.cmb_category.TabIndex = 1;
            this.cmb_category.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // btn_exit
            // 
            this.btn_exit.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btn_exit.Appearance.Options.UseFont = true;
            this.btn_exit.Location = new System.Drawing.Point(289, 16);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 26;
            this.btn_exit.Text = "Exit";
            this.btn_exit.Visible = false;
            this.btn_exit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // btndelete
            // 
            this.btndelete.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btndelete.Appearance.Options.UseFont = true;
            this.btndelete.Location = new System.Drawing.Point(208, 16);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 29;
            this.btndelete.Text = "Delete";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            this.btndelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // btn_reset
            // 
            this.btn_reset.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btn_reset.Appearance.Options.UseFont = true;
            this.btn_reset.Location = new System.Drawing.Point(127, 16);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 27;
            this.btn_reset.Text = "Reset";
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            this.btn_reset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // btn_save
            // 
            this.btn_save.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btn_save.Appearance.Options.UseFont = true;
            this.btn_save.Location = new System.Drawing.Point(46, 16);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 28;
            this.btn_save.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            this.btn_save.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btndelete);
            this.panelControl1.Controls.Add(this.btn_exit);
            this.panelControl1.Controls.Add(this.btn_save);
            this.panelControl1.Controls.Add(this.btn_reset);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 239);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(848, 62);
            this.panelControl1.TabIndex = 13;
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(358, 132);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(218, 20);
            this.txt_phone.TabIndex = 8;
            this.txt_phone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(300, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Phone No";
            // 
            // txt_state
            // 
            this.txt_state.Location = new System.Drawing.Point(358, 80);
            this.txt_state.Name = "txt_state";
            this.txt_state.Size = new System.Drawing.Size(218, 20);
            this.txt_state.TabIndex = 4;
            this.txt_state.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(323, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "State";
            // 
            // txt_city
            // 
            this.txt_city.Location = new System.Drawing.Point(358, 55);
            this.txt_city.Name = "txt_city";
            this.txt_city.Size = new System.Drawing.Size(218, 20);
            this.txt_city.TabIndex = 3;
            this.txt_city.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allkeydown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(331, 58);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "City";
            // 
            // Party_mst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(848, 301);
            this.Controls.Add(this.txt_state);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_city);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.cmb_category);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.gc_bank);
            this.Controls.Add(this.txt_remark);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_broker);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_mob_no);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_gst);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_pan_no);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_party_name);
            this.Controls.Add(this.label1);
            this.Name = "Party_mst";
            this.Text = "Party Mst";
            ((System.ComponentModel.ISupportInitialize)(this.gc_bank)).EndInit();
            this.gc_bank.ResumeLayout(false);
            this.gc_bank.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_party_name;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_pan_no;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_bank_acc_no;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_bank_address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_bank_ifsc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_gst;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_mob_no;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_broker;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.GroupControl gc_bank;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_bank_name;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmb_category;
        private DevExpress.XtraEditors.SimpleButton btn_exit;
        private DevExpress.XtraEditors.SimpleButton btndelete;
        private DevExpress.XtraEditors.SimpleButton btn_reset;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_state;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_city;
        private System.Windows.Forms.Label label16;
    }
}