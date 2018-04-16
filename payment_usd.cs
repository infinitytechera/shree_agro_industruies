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
    public partial class payment_usd : Form
    {
        DataTable dt_invoice = new DataTable();
        DataTable dt_on_invoice = new DataTable();
        DataTable dt_inv_disp = new DataTable();
        string p_id = "";
        int check_on_inv = 0;
        public payment_usd()
        {
            InitializeComponent();
            generate_voucher();
            bind_data();
            cmb_main.Text = "";
            cmb_party.Text = "";
            cmb_ser_account.Text = "";
            dtp_from.Value = DateTime.Today.AddDays(-7);
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Calibri", 10);
            cmb_payment.SelectedIndex = 0;
        }

        private void bind_data()
        {
            DataTable dt_party = new DataTable();
            dt_party = sqlconnection.fetchdatatable("select p_name from party_mst_tbl where c_id=" + UserDetail.c_id + "");
            dt_party = sp_sqlconnection.get_sp("party_detail", "qtype=select|c_id=@c_id");
            cmb_party.DisplayMember = "p_name";
            cmb_ser_party.DisplayMember = "p_name";
            cmb_party.DataSource = dt_party;
            cmb_ser_party.DataSource = dt_party;

            //cmb_party.DataSource = sqlconnection.fetchdatatable("select name from party_mst_tbl where c_id=" + UserDetail.c_id + "");
            //cmb_party.DisplayMember = "name";
            DataTable dt_main = new DataTable();
            dt_main = sqlconnection.fetchdatatable("select p_name from party_mst_tbl where category in ('Bank','CASH') and c_id=" + UserDetail.c_id + "");
            dt_main = sp_sqlconnection.get_sp("party_detail", "qtype=select_cash_bank|c_id=" + UserDetail.c_id + "");
            cmb_main.DataSource = dt_main;
            cmb_main.DisplayMember = "p_name";
            cmb_ser_account.DataSource = dt_main;
            cmb_ser_account.DisplayMember = "p_name";
        }
        private void allkeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void generate_voucher()
        {

            txt_voucher.Text = gen_inv_voucher.gen_voucher_payment().ToString();

        }
        private void btn_invoice_Click(object sender, EventArgs e)
        {
            check_on_inv = 1;
            Set_Comboas_Null.Set_Zero_If_Null_Textedit(txt_credit);
            Set_Comboas_Null.Set_Zero_If_Null_Textedit(txt_debit);
            if (Convert.ToDecimal(txt_credit.Text) > 0 || Convert.ToDecimal(txt_debit.Text) > 0)
            {
                //if (dgv_on_invoice.Visible == false)
                {
                    //if (dt_on_invoice.Rows.Count == 0)
                    {
                        if (Convert.ToDecimal(txt_credit.Text) > 0 && Convert.ToDecimal(txt_debit.Text) > 0)
                        {
                            MessageBox.Show("Enter Only 1 Amount Credit/Debit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_credit.Focus();
                            return;
                        }
                        if (Convert.ToDecimal(txt_credit.Text) > 0)
                        {
                            dt_on_invoice = sp_sqlconnection.get_sp("pur_sale_detail", "qtype=payment_remain_invoice|c_id=" + UserDetail.c_id + "|type=SALE|party=" + cmb_party.Text + "");
                        }
                        else if (Convert.ToDecimal(txt_debit.Text) > 0)
                        {
                            dt_on_invoice = sp_sqlconnection.get_sp("pur_sale_detail", "qtype=payment_remain_invoice|c_id=" + UserDetail.c_id + "|type=PUR|party=" + cmb_party.Text + "");
                        }
                        dgv_on_invoice.DataSource = dt_on_invoice;

                        decimal pay_amount = Convert.ToDecimal(txt_credit.Text);
                        if (Convert.ToDecimal(txt_credit.Text) > 0)
                        {
                            pay_amount = Convert.ToDecimal(txt_credit.Text);
                        }
                        else if (Convert.ToDecimal(txt_debit.Text) > 0)
                        {
                            pay_amount = Convert.ToDecimal(txt_debit.Text);
                        }
                        if (dgv_on_invoice.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgv_on_invoice.Rows.Count; i++)
                            {
                                Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, i, "payamt");
                                Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, i, "outamt");
                                if (pay_amount > 0)
                                {
                                    if (pay_amount > Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["outamt"].Value.ToString()))
                                    {
                                        pay_amount = pay_amount - Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["outamt"].Value.ToString());
                                        dgv_on_invoice.Rows[i].Cells["payamt"].Value = dgv_on_invoice.Rows[i].Cells["outamt"].Value.ToString();
                                    }
                                    else
                                    {
                                        dgv_on_invoice.Rows[i].Cells["payamt"].Value = pay_amount;
                                        dgv_on_invoice.Rows[i].Cells["remamt"].Value = Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["outamt"].Value.ToString()) - pay_amount;
                                        pay_amount = 0.00M;
                                    }
                                }
                                else
                                {
                                    dgv_on_invoice.Rows[i].Cells["remamt"].Value = Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["outamt"].Value.ToString());
                                }
                            }
                        }
                        if (pay_amount > 0)
                        {
                            if (dgv_on_invoice.Rows.Count > 0)
                            {
                                for (int i = 0; i < dgv_on_invoice.Rows.Count; i++)
                                {
                                    if (Convert.ToDecimal(dgv_on_invoice.Rows[0].Cells["payamt"].Value.ToString()) > 0)
                                    {
                                        dgv_on_invoice.Rows[i].Cells["cursoramt"].Value = 0 - pay_amount;
                                        break;
                                    }
                                }

                            }
                            //MessageBox.Show("Invoice Outstanding Is Lower than Enter Amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //return;
                        }
                    }
                }
                //if (dgv_on_invoice.Visible == true)
                //{
                dgv_payment.Visible = false;
                dgv_on_invoice.Visible = true;
                //}
                //else
                //{
                //    dgv_on_invoice.Visible = true;
                //    dgv_payment.Visible = false;
                //}
            }
            on_invoice_count();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cmb_main.Text == "")
            {
                MessageBox.Show("Please Select Account.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_main.Focus();
                return;
            }
            if (cmb_party.Text == "")
            {
                MessageBox.Show("Please Select Party.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_party.Focus();
                return;
            }
            if (cmb_main.Text == cmb_party.Text)
            {
                MessageBox.Show("Please Select Another Party.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_party.Focus();
                return;
            }
            if (cmb_payment.Text == "")
            {
                MessageBox.Show("Please Select Payment.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_payment.Focus();
                return;
            }
            decimal pay_amount = 0.00M;
            for (int i = 0; i < dgv_on_invoice.RowCount; i++)
            {
                if (Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["payamt"].Value.ToString()) > 0)
                {
                    pay_amount = pay_amount + Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["payamt"].Value.ToString());
                    if (Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["cursoramt"].Value.ToString()) < 0)
                    {
                        pay_amount = pay_amount - Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["cursoramt"].Value.ToString());
                    }
                }

            }
            generate_voucher();
            Set_Comboas_Null.Set_Zero_If_Null_Textedit(txt_credit);
            Set_Comboas_Null.Set_Zero_If_Null_Textedit(txt_debit);
            string cr_dr = "";
            decimal us = 0.00M;
            if (Convert.ToDecimal(txt_credit.Text) > 0)
            {
                cr_dr = "CREDIT";
                us = Convert.ToDecimal(txt_credit.Text);
            }
            else
            {
                cr_dr = "DEBIT";
                us = Convert.ToDecimal(txt_debit.Text);
            }
            if (check_on_inv == 1)
            {
                //if (us != pay_amount)
                //{
                //    MessageBox.Show("Invoice Amount and Total Amount Not Match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
            }
            if (p_id == "")
            {
                p_id = sp_sqlconnection.dml_sp_id("payment_detail", "qtype=insert|account=" + cmb_main.Text + "|voucher=" + txt_voucher.Text + "|party=" + cmb_party.Text + "|date=" + Convert.ToDateTime(dtp_date.Text).ToString("MM-dd-yyyy") + "|payment_type=" + cmb_payment.Text + "|credit_debit=" + cr_dr + "|currency=USD|usd=" + us + "|rate=1|amount=" + us + "|description=" + txt_description.Text + "|status=0|u_id=" + UserDetail.user_id + "|c_id=" + UserDetail.c_id + "");
                if (p_id != "" && cmb_payment.SelectedIndex == 0)
                {
                    for (int i = 0; i < dgv_on_invoice.RowCount; i++)
                    {
                        Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, i, "payamt");
                        Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, i, "remamt");
                        Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, i, "cursoramt");
                        string inv_no = "";
                        if (Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["payamt"].Value.ToString()) > 0 || Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["cursoramt"].Value.ToString()) > 0)
                        {
                            string[] inv_ = dgv_on_invoice.Rows[i].Cells["invbillno"].Value.ToString().Split('[');
                            string[] bill_ = inv_[1].Split(']');
                            sp_sqlconnection.dml_sp_id("payment_tran_detail", "qtype=insert|inv_type=" + dgv_on_invoice.Rows[i].Cells["type"].Value.ToString() + "|voucher=" + txt_voucher.Text + "|account=" + cmb_main.Text + "|invoice=" + inv_[0] + "|billno=" + bill_[0] + "|credit_debit=" + cr_dr + "|party=" + cmb_party.Text + "|currency=USD|usd=" + dgv_on_invoice.Rows[i].Cells["payamt"].Value.ToString() + "|rate=1|amount=" + dgv_on_invoice.Rows[i].Cells["payamt"].Value.ToString() + "|status=0|u_id=" + UserDetail.user_id + "|c_id=" + UserDetail.c_id + "");
                            sp_sqlconnection.dml_sp("pur_sale_detail", "qtype=update_payment|c_id=" + UserDetail.c_id + "|inv_type=" + dgv_on_invoice.Rows[i].Cells["type"].Value.ToString() + "|inv_no=" + inv_[0] + "|remain_amount_$=" + dgv_on_invoice.Rows[i].Cells["remamt"].Value.ToString() + "|cursor_amount_$=" + dgv_on_invoice.Rows[i].Cells["cursoramt"].Value.ToString() + "");
                        }
                    }
                }
                check_on_inv = 0;
                MessageBox.Show("Data Successfully Save", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            reset();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (p_id != "")
            {
                DialogResult result = MessageBox.Show("Are You Sure You Want To Delete Voucher : " + p_id + "?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string del_id = "";



                    DataTable dt_get_tran = sqlconnection.fetchdatatable("select * from payment_tran_tbl where voucher=" + p_id + " and c_id=" + UserDetail.c_id + "");
                    if (dt_get_tran.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt_get_tran.Rows.Count; i++)
                        {
                            sqlconnection.insertdata("update pur_sale_tbl set remain_amount_$=isnull(remain_amt,0)+isnull(cursor_amt,0)+" + dt_get_tran.Rows[i]["usd"].ToString() + ",cursor_amount_$=0 where inv_no=" + dt_get_tran.Rows[i]["invoice"].ToString() + " and c_id=" + UserDetail.c_id + " and inv_type='" + dt_get_tran.Rows[i]["inv_type"].ToString() + "'");

                        }
                        sqlconnection.insertdata("delete from payment_tran_tbl where voucher=" + p_id + " and c_id=" + UserDetail.c_id + "");
                        del_id = sqlconnection.insertdata("delete from payment_tbl where voucher=" + p_id + " and c_id=" + UserDetail.c_id + "");

                        for (int i = 0; i < dt_inv_disp.Rows.Count;)
                        {
                            dt_inv_disp.Rows.RemoveAt(0);
                        }
                        dgv_invoice.DataSource = null;
                        for (int i = 0; i < dgv_payment.Rows.Count; i++)
                        {
                            if (dgv_payment.Rows[i].Cells["voucher"].Value.ToString() == p_id)
                            {
                                dgv_payment.Rows.RemoveAt(i);
                                break;
                            }
                        }
                        p_id = "";
                    }
                    if (del_id != "" && del_id != "0")
                    {
                        MessageBox.Show("Data Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            reset();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {

        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            string party_ = cmb_ser_party.Text;
            string account_ = cmb_ser_account.Text;
            reset();
            cmb_ser_account.Text = account_;
            cmb_ser_party.Text = party_;
            dgv_payment.Visible = true;
            dgv_on_invoice.Visible = false;
            string from = Convert.ToDateTime(dtp_from.Value).ToString("MM-dd-yyyy");
            string to = Convert.ToDateTime(dtp_to.Value).ToString("MM-dd-yyyy");
            string query = "";
            if (cmb_ser_party.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Party.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (cmb_ser_account.Text.Trim() != "" && cmb_ser_party.Text.Trim() != "")
            //{
            //    MessageBox.Show("Please Select Any Account/Party.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (cmb_ser_account.Text.Trim() != "")
            //{
            //    query = query + "and account='" + cmb_ser_account.Text + "'";
            //}
            //if (cmb_ser_party.Text.Trim() != "")
            //{
            //    query = query + "and party='" + cmb_ser_party.Text + "'";
            //}

            query = "";
            DataTable dt_account_check = sqlconnection.fetchdatatable("select currency from party_mst_tbl where a_g_type in ('BANK','CASH') and name='" + cmb_party.Text.ToUpper().Trim() + "' and c_id=" + UserDetail.c_id + "");



            //DataTable dt_payment = sqlconnection.fetchdatatable("select id,date as p_date,party as account,case when credit_debit='DEBIT' then usd else 0 end as debit,case when credit_debit='CREDIT' then usd else 0 end as credit,description,voucher from payment_tbl where c_id=" + UserDetail.c_id + " and date between '" + from + "' and '" + to + "' and currency='USD'  " + query + "");
            //dt_invoice = sqlconnection.fetchdatatable("select date,voucher as inv_voucher,billno,invoice,(select final_amount_$ from pur_sale_tbl where c_id=pt.c_id and inv_type=pt.inv_type and bill_no=pt.billno and inv_no=pt.invoice) as inv_amount,amount as adjustamount from payment_tran_tbl pt where c_id=" + UserDetail.c_id + " and currency='USD'  " + query + "");
            DataTable dt_payment = sqlconnection.fetchdatatable("select id,date as p_date,case when party='" + cmb_ser_party.Text + "' then account else party end as account,case when ((credit_debit='DEBIT' and account='" + cmb_ser_party.Text + "') or (credit_debit='CREDIT' and party='" + cmb_ser_party.Text + "')) then usd else 0 end as debit,case when ((credit_debit='CREDIT' and account='" + cmb_ser_party.Text + "') or (credit_debit='DEBIT' and party='" + cmb_ser_party.Text + "')) then usd else 0 end as credit,description,voucher from payment_tbl where c_id=" + UserDetail.c_id + " and date between '" + from + "' and '" + to + "' and currency='USD' and (account='" + cmb_ser_party.Text + "' or party='" + cmb_ser_party.Text + "')");
            dt_invoice = sqlconnection.fetchdatatable("select date,voucher as inv_voucher,billno,invoice,(select final_amount_$ from pur_sale_tbl where c_id=pt.c_id and inv_type=pt.inv_type and bill_no=pt.billno and inv_no=pt.invoice) as inv_amount,amount as adjustamount from payment_tran_tbl pt where c_id=" + UserDetail.c_id + " and currency='USD'  and (account='" + cmb_ser_party.Text + "' or party='" + cmb_ser_party.Text + "')");
            dgv_payment.DataSource = dt_payment;

        }
        private void reset()
        {
            check_on_inv = 0;
            txt_credit.Text = "0";
            txt_debit.Text = "0";
            generate_voucher();
            //cmb_main.Text = "";
            cmb_party.Text = "";
            cmb_payment.SelectedIndex = 0;
            txt_description.Text = "";
            cmb_ser_party.Text = "";
            cmb_ser_account.Text = "";
            dt_invoice.Rows.Clear();
            dt_on_invoice.Rows.Clear();
            for (int i = 0; i < dgv_invoice.Rows.Count;)
                dgv_invoice.Rows.RemoveAt(0);
            for (int i = 0; i < dgv_on_invoice.RowCount;)
                dgv_on_invoice.Rows.RemoveAt(0);
            for (int i = 0; i < dgv_payment.Rows.Count;)
                dgv_payment.Rows.RemoveAt(0);
            p_id = "";
            dgv_on_invoice.Visible = false;
            dgv_payment.Visible = true;
            dtp_date.Focus();
            on_invoice_count();
        }
        private void cmb_main_Leave(object sender, EventArgs e)
        {
            Set_Comboas_Null.Check_Item_Exist_In_Combo(cmb_main);
        }

        private void cmb_party_Leave(object sender, EventArgs e)
        {
            Set_Comboas_Null.Check_Item_Exist_In_Combo(cmb_party);
        }

        private void cmb_payment_Leave(object sender, EventArgs e)
        {
            Set_Comboas_Null.Check_Item_Exist_In_Combo(cmb_payment);
        }

        private void cmb_ser_account_Leave(object sender, EventArgs e)
        {
            Set_Comboas_Null.Check_Item_Exist_In_Combo(cmb_ser_account);
        }

        private void dgv_on_invoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_on_invoice_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt_decimal = e.Control as TextBox;//Create object of Textbox
            var source = new AutoCompleteStringCollection();

            if (dgv_on_invoice.Columns[dgv_on_invoice.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "PAYAMT" || dgv_on_invoice.Columns[dgv_on_invoice.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "REMAMT" || dgv_on_invoice.Columns[dgv_on_invoice.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "CURSORAMT")
            {
                txt_decimal.KeyPress += txt_KeyPress_other;
            }

        }
        void txt_KeyPress_other(object sender, KeyPressEventArgs e)
        {
            if (dgv_on_invoice.Columns[dgv_on_invoice.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "PAYAMT" || dgv_on_invoice.Columns[dgv_on_invoice.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "REMAMT" || dgv_on_invoice.Columns[dgv_on_invoice.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "CURSORAMT")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
                // only allow one decimal point
                if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf('-') > -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void dgv_on_invoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_on_invoice.Rows.Count > 0)
            {
                if (dgv_on_invoice.Columns[dgv_on_invoice.CurrentCell.ColumnIndex].HeaderText.ToUpper() != "CURSORAMT")
                {
                    Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, dgv_on_invoice.CurrentRow.Index, "payamt");
                    Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, dgv_on_invoice.CurrentRow.Index, "outamt");
                    Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, dgv_on_invoice.CurrentRow.Index, "remamt");
                    Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, dgv_on_invoice.CurrentRow.Index, "cursoramt");
                    if (dgv_on_invoice.Columns[dgv_on_invoice.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "REMAMT")
                    {
                        //if (Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["remamt"].Value.ToString()) == 0)
                        {
                            dgv_on_invoice.CurrentRow.Cells["cursoramt"].Value = Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["outamt"].Value.ToString()) - Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["payamt"].Value.ToString()) - Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["remamt"].Value.ToString());
                        }
                    }
                    if (Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["payamt"].Value.ToString()) > Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["outamt"].Value.ToString()))
                    {
                        dgv_on_invoice.CurrentRow.Cells["payamt"].Value = dgv_on_invoice.CurrentRow.Cells["outamt"].Value.ToString();
                    }
                    else
                    {
                        dgv_on_invoice.CurrentRow.Cells["remamt"].Value = Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["outamt"].Value.ToString()) - Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["payamt"].Value.ToString()) - Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["cursoramt"].Value.ToString());
                    }



                    decimal pay_amount = 0.00M;
                    decimal set_amount = 0.00M;
                    for (int i = 0; i <= dgv_on_invoice.CurrentRow.Index; i++)
                    {
                        set_amount = set_amount + Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["payamt"].Value.ToString());
                    }
                    if (Convert.ToDecimal(txt_credit.Text) > 0)
                    {
                        pay_amount = Convert.ToDecimal(txt_credit.Text) - set_amount;
                    }
                    if (Convert.ToDecimal(txt_debit.Text) > 0)
                    {
                        pay_amount = Convert.ToDecimal(txt_debit.Text) - set_amount;
                    }
                    if (pay_amount < 0)
                    {
                        dgv_on_invoice.CurrentRow.Cells["payamt"].Value = Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["payamt"].Value.ToString()) + pay_amount;
                        pay_amount = 0;
                        if (dgv_on_invoice.Columns[dgv_on_invoice.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "REMAMT")
                        {
                            //if (Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["remamt"].Value.ToString()) == 0)
                            {
                                dgv_on_invoice.CurrentRow.Cells["cursoramt"].Value = Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["outamt"].Value.ToString()) - Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["payamt"].Value.ToString()) - Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["remamt"].Value.ToString());
                            }
                        }
                        if (Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["payamt"].Value.ToString()) > Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["outamt"].Value.ToString()))
                        {
                            dgv_on_invoice.CurrentRow.Cells["payamt"].Value = dgv_on_invoice.CurrentRow.Cells["outamt"].Value.ToString();
                        }
                        else
                        {
                            dgv_on_invoice.CurrentRow.Cells["remamt"].Value = Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["outamt"].Value.ToString()) - Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["payamt"].Value.ToString()) - Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["cursoramt"].Value.ToString());
                        }
                    }

                    //pay_amount = Convert.ToDecimal(dgv_on_invoice.CurrentRow.Cells["payamt"].Value.ToString());
                    for (int i = dgv_on_invoice.CurrentRow.Index + 1; i < dgv_on_invoice.Rows.Count; i++)
                    {
                        //if (pay_amount > 0)
                        {
                            if (pay_amount > Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["outamt"].Value.ToString()))
                            {
                                pay_amount = pay_amount - Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["outamt"].Value.ToString());
                                dgv_on_invoice.Rows[i].Cells["payamt"].Value = dgv_on_invoice.Rows[i].Cells["outamt"].Value.ToString();
                                dgv_on_invoice.Rows[i].Cells["remamt"].Value = "0";
                                dgv_on_invoice.Rows[i].Cells["cursoramt"].Value = "0";
                            }
                            else
                            {
                                dgv_on_invoice.Rows[i].Cells["payamt"].Value = pay_amount;
                                dgv_on_invoice.Rows[i].Cells["remamt"].Value = Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["outamt"].Value.ToString()) - Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["payamt"].Value.ToString()) - Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["cursoramt"].Value.ToString());
                                pay_amount = 0.00M;
                            }
                        }
                    }
                    if (pay_amount > 0)
                    {
                        if (dgv_on_invoice.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgv_on_invoice.Rows.Count; i++)
                            {
                                if (Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["payamt"].Value.ToString()) > 0)
                                {
                                    dgv_on_invoice.Rows[i].Cells["cursoramt"].Value = Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["cursoramt"].Value.ToString()) - pay_amount;
                                    break;
                                }
                            }

                        }
                        //MessageBox.Show("Invoice Outstanding Is Lower than Enter Amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return;
                    }
                }
                on_invoice_count();
            }
        }
        private void on_invoice_count()
        {
            decimal carat = 0.00M;
            decimal inv_amount = 0.00M;
            decimal out_amount = 0.00M;
            decimal pay_amount = 0.00M;
            decimal rem_amount = 0.00M;
            decimal cur_amount = 0.00M;

            for (int i = 0; i < dgv_on_invoice.Rows.Count; i++)
            {
                Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, i, "carat");
                Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, i, "invcurr");
                Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, i, "outamt");
                Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, i, "remamt");
                Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, i, "payamt");
                Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_on_invoice, i, "cursoramt");
                carat = carat + Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["carat"].Value.ToString());
                inv_amount = inv_amount + Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["invcurr"].Value.ToString());
                out_amount = out_amount + Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["outamt"].Value.ToString());
                pay_amount = pay_amount + Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["payamt"].Value.ToString());
                rem_amount = rem_amount + Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["remamt"].Value.ToString());
                cur_amount = cur_amount + Convert.ToDecimal(dgv_on_invoice.Rows[i].Cells["cursoramt"].Value.ToString());
            }
            txt_carat.Text = carat.ToString();
            txt_inv_amount.Text = inv_amount.ToString();
            txt_out_amt.Text = out_amount.ToString();
            txt_pay_amt.Text = pay_amount.ToString();
            txt_rem_amt.Text = rem_amount.ToString();
            txt_cursor_amt.Text = cur_amount.ToString();
        }

        private void dgv_payment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_payment.RowCount > 0)
            {
                p_id = dgv_payment.CurrentRow.Cells["voucher"].Value.ToString();
                if (dt_invoice.Rows.Count > 0)
                {
                    dt_inv_disp = dt_invoice.Clone();
                    dt_inv_disp.Rows.Clear();
                    DataRow[] dr = dt_invoice.Select("inv_voucher='" + dgv_payment.CurrentRow.Cells["voucher"].Value.ToString() + "'");
                    foreach (var item in dr)
                    {
                        dt_inv_disp.ImportRow(item);
                    }
                    dgv_invoice.DataSource = dt_inv_disp;
                }
            }
        }

        private void payment_usd_Load(object sender, EventArgs e)
        {
            cmb_main.Text = "";
            cmb_party.Text = "";
            cmb_ser_account.Text = "";
            cmb_ser_party.Text = "";
            dtp_from.MaxDate = DateTime.Today;
            dtp_to.MaxDate = DateTime.Today;
            dtp_date.MaxDate = DateTime.Today;
        }

        private void cmb_days_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_Comboas_Null.Check_Item_Exist_In_Combo(cmb_days);
            if (cmb_days.Text != "")
            {
                if (cmb_days.Text.ToUpper() == "TODAY")
                {
                    dtp_from.Value = DateTime.Today;
                    dtp_to.Value = DateTime.Today;
                }
                else if (cmb_days.Text.ToUpper() == "YESTERDAY")
                {
                    dtp_from.Value = DateTime.Today.AddDays(-1);
                    dtp_to.Value = DateTime.Today.AddDays(-1);
                }
                else if (cmb_days.Text.ToUpper() == "THIS WEEK")
                {
                    System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                    DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
                    dtp_from.Value = DateTime.Now.AddDays(-(DateTime.Now.DayOfWeek - fdow)).Date;
                    dtp_to.Value = DateTime.Today;
                }
                else if (cmb_days.Text.ToUpper() == "LAST WEEK")
                {
                    System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                    DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
                    dtp_from.Value = DateTime.Now.AddDays(-(DateTime.Now.DayOfWeek - fdow) - 7).Date;
                    dtp_to.Value = DateTime.Now.AddDays(-(DateTime.Now.DayOfWeek - fdow) - 1).Date;
                }
                else if (cmb_days.Text.ToUpper() == "LAST 2 WEEK")
                {
                    System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                    DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
                    dtp_from.Value = DateTime.Now.AddDays(-(DateTime.Now.DayOfWeek - fdow) - 7).Date;
                    dtp_to.Value = DateTime.Today;
                }
                else if (cmb_days.Text.ToUpper() == "LAST TO LAST WEEK")
                {
                    System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                    DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
                    dtp_from.Value = DateTime.Now.AddDays(-(DateTime.Now.DayOfWeek - fdow) - 14).Date;
                    dtp_to.Value = DateTime.Now.AddDays(-(DateTime.Now.DayOfWeek - fdow) - 8).Date;
                }
                else if (cmb_days.Text.ToUpper() == "THIS MONTH")
                {
                    dtp_from.Value = DateTime.Today.AddDays(-(DateTime.Today.Day - 1));
                    dtp_to.Value = DateTime.Today;
                }
                else if (cmb_days.Text.ToUpper() == "LAST MONTH")
                {
                    DateTime LastMonthLastDate = DateTime.Today.AddDays(0 - DateTime.Today.Day);
                    DateTime LastMonthFirstDate = LastMonthLastDate.AddDays(1 - LastMonthLastDate.Day);
                    dtp_from.Value = LastMonthFirstDate;
                    dtp_to.Value = LastMonthLastDate;
                }
                else if (cmb_days.Text.ToUpper() == "LAST TO LAST MONTH")
                {
                    DateTime LastMonthLastDate = DateTime.Today.AddDays(0 - DateTime.Today.Day);
                    DateTime LastMonthFirstDate = LastMonthLastDate.AddDays(1 - LastMonthLastDate.Day);
                    dtp_from.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 2, 1);
                    dtp_to.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 1).AddDays(-1);
                }
                else if (cmb_days.Text.ToUpper() == "ALL")
                {
                    dtp_from.Value = new DateTime(2016, 8, 1);
                    dtp_to.Value = DateTime.Today;
                }
                btn_load.PerformClick();
            }
        }

        private void txt_description_Leave(object sender, EventArgs e)
        {
            btn_invoice.Focus();
        }

        private void dgv_payment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (p_id != "")
            {
                DataTable dt_voucher = sqlconnection.fetchdatatable("select * from payment_tbl where c_id=" + UserDetail.c_id + " and voucher=" + p_id + "");
                if (dt_voucher.Rows.Count > 0)
                {
                    cmb_party.Text = dt_voucher.Rows[0]["party"].ToString();
                    txt_voucher.Text = dt_voucher.Rows[0]["voucher"].ToString();
                    cmb_main.Text = dt_voucher.Rows[0]["account"].ToString();
                    cmb_payment.Text = dt_voucher.Rows[0]["payment_type"].ToString();
                    if (dt_voucher.Rows[0]["credit_debit"].ToString().ToUpper() == "CREDIT")
                    {
                        txt_credit.Text = dt_voucher.Rows[0]["amount"].ToString();
                    }
                    if (dt_voucher.Rows[0]["credit_debit"].ToString().ToUpper() == "DEBIT")
                    {
                        txt_debit.Text = dt_voucher.Rows[0]["amount"].ToString();
                    }
                    dtp_date.Value = Convert.ToDateTime(dt_voucher.Rows[0]["date"].ToString());
                    //txt_rate.Text = dt_voucher.Rows[0]["rate"].ToString();
                    //txt_usd.Text = dt_voucher.Rows[0]["usd"].ToString();
                    txt_description.Text = dt_voucher.Rows[0]["description"].ToString();

                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (p_id != "")
                {
                    sqlconnection.insertdata("update payment_tbl set description='" + txt_description.Text + "' where voucher=" + txt_voucher.Text + " and c_id=" + UserDetail.c_id + "");
                    MessageBox.Show("Payment Update Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_cancel.PerformClick();
                }
            }
            catch (Exception)
            { }
            reset();
        }

        private void cmb_party_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_on_invoice.RowCount;)
            {
                dgv_on_invoice.Rows.RemoveAt(i);
            }
        }
    }
}
