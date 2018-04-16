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
    public partial class Purchase : Form
    {
        string pur_id = "";
        public Purchase()
        {
            InitializeComponent();
            dtp_date.MinDate = UserDetail.f_date;
            dtp_date.MaxDate = UserDetail.t_date;
            txt_inv_no.Text = gen_inv_voucher.gen_invoice_no_pur_sale("PUR").ToString();
            cmb_category.Text = "REGULAR";
            cmb_type.Text = "LOCAL";
            bind_party_broker();

        }

        private void decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void bind_party_broker()
        {
            cmb_party.DataSource = UserDetail.dt_party;
            cmb_party.DisplayMember = "p_name";
            cmb_party.ValueMember = "p_id";

            cmb_broker.DataSource = UserDetail.dt_broker;
            cmb_broker.DisplayMember = "p_name";
            cmb_broker.ValueMember = "p_id";

        }

        private void reset()
        {
            pur_id = "";
            txt_inv_no.Text = gen_inv_voucher.gen_invoice_no_pur_sale("PUR").ToString();
            txt_voucher.Text = "";
            txt_ser_voucher.Text = "";
            txt_ser_inv_no.Text = "";
            cmb_party.Text = "";
            cmb_category.Text = "REGULAR";
            cmb_type.Text = "LOCAL";
            cmb_broker.Text = "";
            txt_remark.Text = "";
            txt_amount.Text = "0.00";
            txt_cgst_per.Text = "0.00";
            txt_cgst_amount.Text = "0.00";
            txt_sgst_per.Text = "0.00";
            txt_sgst_amount.Text = "0.00";
            txt_igst_per.Text = "0.00";
            txt_igst_amount.Text = "0.00";
            txt_final_amount.Text = "0.00";

            for (int i = 0; i < dgv_detail.RowCount-1; )
            {
                dgv_detail.Rows.RemoveAt(i);
            }

            //dtp_date.Value = DateTime.Today;
        }
        private void search()
        {
            DataTable dt_inv = new DataTable();
            DataTable dt_inv_detail = new DataTable();
            if (txt_ser_inv_no.Text != "")
            {
                dt_inv = sp_sqlconnection.get_sp("pur_sale_detail", "qtype=search_inv_type|c_id=" + UserDetail.c_id + "|inv_type=PUR|inv_no=" + txt_ser_inv_no.Text + "");
            }
            else if (txt_ser_voucher.Text != "")
            {
                dt_inv = sp_sqlconnection.get_sp("pur_sale_detail", "qtype=search_voucher_type|c_id=" + UserDetail.c_id + "|inv_type=PUR|voucher=" + txt_ser_voucher.Text + "");
            }

            if (dt_inv.Rows.Count > 0)
            {
                dt_inv_detail = sp_sqlconnection.get_sp("pur_sale_tran_detail", "qtype=get_pur_sale_detail|ps_id=" + dt_inv.Rows[0]["ps_id"] + "");

                if (dt_inv_detail.Rows.Count > 0)
                {
                    dgv_detail.DataSource = dt_inv_detail;
                    pur_id = dt_inv.Rows[0]["ps_id"].ToString();
                    dtp_date.Value = Convert.ToDateTime(dt_inv.Rows[0]["date"].ToString());
                    txt_voucher.Text = dt_inv.Rows[0]["voucher"].ToString();
                    txt_inv_no.Text = dt_inv.Rows[0]["inv_no"].ToString();
                    cmb_party.Text = dt_inv.Rows[0]["party"].ToString();
                    cmb_category.Text = dt_inv.Rows[0]["category"].ToString();
                    cmb_type.Text = dt_inv.Rows[0]["type"].ToString();
                    cmb_broker.Text = dt_inv.Rows[0]["broker"].ToString();
                    txt_remark.Text = dt_inv.Rows[0]["remark"].ToString();
                    txt_amount.Text = dt_inv.Rows[0]["amount"].ToString();
                    txt_cgst_per.Text = dt_inv.Rows[0]["cgst_per"].ToString();
                    txt_cgst_amount.Text = dt_inv.Rows[0]["cgst_amt"].ToString();
                    txt_sgst_per.Text = dt_inv.Rows[0]["sgst_per"].ToString();
                    txt_sgst_amount.Text = dt_inv.Rows[0]["sgst_amt"].ToString();
                    txt_igst_per.Text = dt_inv.Rows[0]["igst_per"].ToString();
                    txt_igst_amount.Text = dt_inv.Rows[0]["igst_amt"].ToString();
                    txt_final_amount.Text = dt_inv.Rows[0]["final_amt"].ToString();
                }
            }




        }

        private void dgv_detail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt_decimal = e.Control as TextBox;//Create object of Textbox
            TextBox txt_int = e.Control as TextBox;//Create object of Textbox
            TextBox txt = e.Control as TextBox;//Create object of Textbox
            var source = new AutoCompleteStringCollection();
            if (dgv_detail.Columns[dgv_detail.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "ITEM")
            {
                String[] stringArray = Array.ConvertAll<DataRow, String>(UserDetail.dt_item.Select(), delegate (DataRow row) { return (String)row["i_name"]; });
                source.AddRange(stringArray);
            }

            if (dgv_detail.Columns[dgv_detail.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "QTY" || dgv_detail.Columns[dgv_detail.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "RATE" || dgv_detail.Columns[dgv_detail.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "AMOUNT" || dgv_detail.Columns[dgv_detail.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "BROKERAGE")
            {
                txt_decimal.KeyPress += txt_KeyPress_other;
            }
            if (dgv_detail.Columns[dgv_detail.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "BAG")
            {
                txt_int.KeyPress += txt_KeyPress;
            }
            if (txt != null)
            {
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteCustomSource = source;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }
        void txt_KeyPress_other(object sender, KeyPressEventArgs e)
        {
            if (dgv_detail.Columns[dgv_detail.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "CARAT" || dgv_detail.Columns[dgv_detail.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "RATE" || dgv_detail.Columns[dgv_detail.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "AMOUNT")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
        }
        void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv_detail.Columns[dgv_detail.CurrentCell.ColumnIndex].HeaderText.ToUpper() == "PCS")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
        }

        private void dgv_detail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_detail.Columns[e.ColumnIndex].HeaderText.ToUpper() == "ITEM")
                {
                    Set_Comboas_Null.Set_null_If_Null_GridCell(dgv_detail, dgv_detail.CurrentRow.Index, "item");
                    Set_Comboas_Null.Set_null_If_Null_GridCell(dgv_detail, dgv_detail.CurrentRow.Index, "measure");

                    dgv_detail.CurrentRow.Cells["measure"].Value = stock.get_measurement(dgv_detail.CurrentRow.Cells["item"].Value.ToString().ToUpper());

                    if (dgv_detail.CurrentRow.Cells["lotno"].Value.ToString() == "")
                    {
                        dgv_detail.CurrentCell = dgv_detail.CurrentRow.Cells["item"];
                    }
                }
                if (dgv_detail.Columns[e.ColumnIndex].HeaderText.ToUpper() == "QTY")
                {
                    Set_Comboas_Null.Set_null_If_Null_GridCell(dgv_detail, dgv_detail.CurrentRow.Index, "item");
                    Set_Comboas_Null.Set_null_If_Null_GridCell(dgv_detail, dgv_detail.CurrentRow.Index, "measure");
                    Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_detail, dgv_detail.CurrentRow.Index, "rate");
                    Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_detail, dgv_detail.CurrentRow.Index, "qty");
                    Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_detail, dgv_detail.CurrentRow.Index, "brokerage");



                    if (dgv_detail.Rows[dgv_detail.CurrentRow.Index].Cells["measure"].Value.ToString() == "MT")
                    {
                        int bag_count = 0;
                        decimal bag_weight = 0.00M;
                        bag_weight = stock.get_bag_weight(dgv_detail.CurrentRow.Cells["item"].Value.ToString().ToUpper());
                        decimal qty = 0.00M;
                        qty = Convert.ToDecimal(dgv_detail.CurrentRow.Cells["qty"].Value.ToString());
                        if (qty > 0 && bag_weight > 0)
                            bag_count = Convert.ToInt32((qty * 1000) / bag_weight);
                        dgv_detail.CurrentRow.Cells["bag"].Value = bag_count.ToString();

                    }
                    if (dgv_detail.Rows[dgv_detail.CurrentRow.Index].Cells["measure"].Value.ToString() != "MT")
                    {
                        int bag_count = 0;
                        decimal bag_weight = 0.00M;
                        bag_weight = stock.get_bag_weight(dgv_detail.CurrentRow.Cells["item"].Value.ToString().ToUpper());
                        decimal qty = 0.00M;
                        qty = Convert.ToDecimal(dgv_detail.CurrentRow.Cells["qty"].Value.ToString());
                        if (qty > 0 && bag_weight > 0)
                            bag_count = Convert.ToInt32(Math.Floor((qty) / bag_weight));
                        dgv_detail.CurrentRow.Cells["bag"].Value = bag_count.ToString();

                    }
                    if (Convert.ToDecimal(dgv_detail.CurrentRow.Cells["rate"].Value.ToString()) > 0.00M)
                    {
                        decimal qty_rate = 0.00M;
                        qty_rate = Convert.ToDecimal(dgv_detail.CurrentRow.Cells["rate"].Value.ToString().ToUpper());
                        decimal qty = 0.00M;
                        qty = Convert.ToDecimal(dgv_detail.CurrentRow.Cells["qty"].Value.ToString());
                        decimal qty_amount = qty * qty_rate;
                        dgv_detail.CurrentRow.Cells["amount"].Value = qty_amount.ToString("0.00");
                        count_amount();
                    }



                    //dgv_detail.CurrentRow.Cells["lotno"].Value = stock.get_lotno(dgv_detail.CurrentRow.Cells["refno"].Value.ToString().ToUpper());
                    ////if (dgv_detail.CurrentRow.Cells["kapan"].Value.ToString() == "")
                    //{
                    //    dgv_detail.CurrentRow.Cells["kapan"].Value = stock.get_kapan(dgv_detail.CurrentRow.Cells["refno"].Value.ToString().ToUpper());
                    //}
                    //if (dgv_detail.CurrentRow.Cells["lotno"].Value.ToString() == "")
                    //{
                    //    dgv_detail.CurrentCell = dgv_detail.CurrentRow.Cells["refno"];
                    //}
                }
                if (dgv_detail.Columns[e.ColumnIndex].HeaderText.ToUpper() == "RATE")
                {
                    decimal qty_rate = 0.00M;
                    qty_rate = Convert.ToDecimal(dgv_detail.CurrentRow.Cells["rate"].Value.ToString().ToUpper());
                    decimal qty = 0.00M;
                    qty = Convert.ToDecimal(dgv_detail.CurrentRow.Cells["qty"].Value.ToString());
                    decimal qty_amount = qty * qty_rate;
                    dgv_detail.CurrentRow.Cells["amount"].Value = qty_amount.ToString("0.00");
                    count_amount();
                }
            }
            catch (Exception)
            { }
        }

        private void count_amount()
        {
            decimal total_amount = 0.00M;
            for (int i = 0; i < dgv_detail.RowCount - 1; i++)
            {
                Set_Comboas_Null.Set_Zero_If_Null_GridCell(dgv_detail, i, "amount");
                if (Convert.ToDecimal(dgv_detail.Rows[i].Cells["amount"].Value.ToString()) > 0.00M)
                {
                    total_amount = total_amount + Convert.ToDecimal(dgv_detail.Rows[i].Cells["amount"].Value.ToString());
                }
            }
            txt_amount.Text = total_amount.ToString("0.00");
            count_gst_final();
        }
        private void count_gst_final()
        {
            Set_Comboas_Null.Set_Zero_If_Null_Textbox(txt_amount);
            Set_Comboas_Null.Set_Zero_If_Null_Textbox(txt_cgst_per);
            Set_Comboas_Null.Set_Zero_If_Null_Textbox(txt_sgst_per);
            Set_Comboas_Null.Set_Zero_If_Null_Textbox(txt_igst_per);


            decimal total_amount = 0.00M;
            decimal cgst_per = 0.00M;
            decimal cgst_amt = 0.00M;
            decimal sgst_per = 0.00M;
            decimal sgst_amt = 0.00M;
            decimal igst_per = 0.00M;
            decimal igst_amt = 0.00M;


            total_amount = Convert.ToDecimal(txt_amount.Text);
            cgst_per = Convert.ToDecimal(txt_cgst_per.Text);
            sgst_per = Convert.ToDecimal(txt_sgst_per.Text);
            igst_per = Convert.ToDecimal(txt_igst_per.Text);
            if (total_amount > 0.00M)
            {
                cgst_amt = (total_amount * cgst_per) / 100;
                sgst_amt = (total_amount * sgst_per) / 100;
                igst_amt = (total_amount * igst_per) / 100;
            }
            if (cgst_per > 0.000M && cgst_amt > 0.000M)
                txt_cgst_amount.Text = cgst_amt.ToString("0.00");
            else
                txt_cgst_amount.Text = "0.00";
            if (sgst_per > 0.000M && sgst_amt > 0.000M)
                txt_sgst_amount.Text = sgst_amt.ToString("0.00");
            else
                txt_sgst_amount.Text = "0.00";
            if (igst_per > 0.000M && igst_amt > 0.000M)
                txt_igst_amount.Text = igst_amt.ToString("0.00");
            else
                txt_igst_amount.Text = "0.00";

            Set_Comboas_Null.Set_Zero_If_Null_Textbox(txt_cgst_amount);
            Set_Comboas_Null.Set_Zero_If_Null_Textbox(txt_sgst_amount);
            Set_Comboas_Null.Set_Zero_If_Null_Textbox(txt_igst_amount);



            txt_final_amount.Text = (total_amount + cgst_amt + sgst_amt + igst_amt).ToString("0.00");


        }

        private void txt_cgst_per_Leave(object sender, EventArgs e)
        {
            count_gst_final();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                #region validation
                Set_Comboas_Null.Set_Zero_If_Null_Textbox(txt_due_days);
                Set_Comboas_Null.Check_Item_Exist_In_Combo(cmb_party);
                if (cmb_party.Text.Trim() == "")
                {
                    MessageBox.Show("Please Select Party", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb_party.Focus();
                    return;
                }
                Set_Comboas_Null.Check_Item_Exist_In_Combo(cmb_category);
                if (cmb_category.Text.Trim() == "")
                {
                    MessageBox.Show("Please Select category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb_category.Focus();
                    return;
                }
                Set_Comboas_Null.Check_Item_Exist_In_Combo(cmb_type);
                if (cmb_type.Text.Trim() == "")
                {
                    MessageBox.Show("Please Select category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb_type.Focus();
                    return;
                }
                //Set_Comboas_Null.Check_Item_Exist_In_Combo(cmb_broker);
                //if (cmb_broker.Text.Trim() == "")
                //{
                //    MessageBox.Show("Please Select Broker", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cmb_party.Focus();
                //    return;
                //}
                #endregion

                #region insert & update
                txt_inv_no.Text = gen_inv_voucher.gen_invoice_no_pur_sale("PUR").ToString();

                string date = Convert.ToDateTime(dtp_date.Value.Date).ToString("MM-dd-yyyy");
                string due_date = Convert.ToDateTime(dtp_date.Value.Date).ToString("MM-dd-yyyy");


                if (pur_id == "")
                {
                    pur_id = sp_sqlconnection.dml_sp_id("pur_sale_detail", "qtype=insert|inv_type=PUR|date=" + date + "|inv_no=" + txt_inv_no.Text + "|voucher=" + txt_voucher.Text.Trim().ToUpper() + "|party=" + cmb_party.Text.ToUpper().Trim() + "|type=" + cmb_type.Text.ToUpper().Trim() + "|category=" + cmb_category.Text.ToUpper().Trim() + "|broker=" + cmb_broker.Text.ToUpper().Trim() + "|due_days=0|due_date=" + due_date + "|remark=" + txt_remark.Text + "|amount=" + txt_amount.Text + "|cgst_per=" + txt_cgst_per.Text + "|cgst_amt=" + txt_cgst_amount.Text + "|sgst_per=" + txt_sgst_per.Text + "|sgst_amt=" + txt_sgst_amount.Text + "|igst_per=" + txt_igst_per.Text + "|igst_amt=" + txt_igst_amount.Text + "|final_amt=" + txt_final_amount.Text + "|remain_amt=" + txt_final_amount.Text + "|cursor_amt=0.00|c_id=" + UserDetail.c_id + "|y_id=" + UserDetail.y_id + "|u_id=" + UserDetail.user_id + "|w_id=" + UserDetail.w_id + "");
                    string ins_detail = "";
                    for (int i = 0; i < dgv_detail.RowCount - 1; i++)
                    {
                        ins_detail = ins_detail + "insert into pur_sale_tran_tbl (ps_id, date, inv_type, type, item, bag, qty, rate, measure, brokerage, amount, c_id, y_id, u_id, w_id) output inserted.pst_id values (" + pur_id + ",'" + date + "','PUR','" + cmb_type.Text.ToUpper() + "','" + dgv_detail.Rows[i].Cells["item"].Value.ToString() + "'," + dgv_detail.Rows[i].Cells["bag"].Value.ToString() + "," + dgv_detail.Rows[i].Cells["qty"].Value.ToString() + "," + dgv_detail.Rows[i].Cells["rate"].Value.ToString() + ",'" + dgv_detail.Rows[i].Cells["measure"].Value.ToString() + "'," + dgv_detail.Rows[i].Cells["brokerage"].Value.ToString() + "," + dgv_detail.Rows[i].Cells["amount"].Value.ToString() + "," + UserDetail.c_id + "," + UserDetail.y_id + "," + UserDetail.user_id + "," + UserDetail.w_id + "); ";
                    }
                    sqlconnection.insertdata_id(ins_detail);
                }
                else
                {

                    sp_sqlconnection.dml_sp("pur_sale_detail", "qtype=update|ps_id=" + pur_id + "|inv_type=PUR|date=" + date + "|inv_no=" + txt_inv_no.Text + "|voucher=" + txt_voucher.Text.Trim().ToUpper() + "|party=" + cmb_party.Text.ToUpper().Trim() + "|type=" + cmb_type.Text.ToUpper().Trim() + "|category=" + cmb_category.Text.ToUpper().Trim() + "|broker=" + cmb_broker.Text.ToUpper().Trim() + "|due_days=|due_date=" + due_date + "|remark=" + txt_remark.Text + "|amount=" + txt_amount.Text + "|cgst_per=" + txt_cgst_per.Text + "|cgst_amt=" + txt_cgst_amount.Text + "|sgst_per=" + txt_sgst_per.Text + "|sgst_amt=" + txt_sgst_amount.Text + "|igst_per=" + txt_igst_per.Text + "|igst_amt=" + txt_igst_amount.Text + "|final_amt=" + txt_final_amount.Text + "|remain_amt=" + txt_final_amount.Text + "|cursor_amt=0.00|c_id=" + UserDetail.c_id + "|y_id=" + UserDetail.y_id + "|u_id=" + UserDetail.user_id + "|w_id=" + UserDetail.w_id + "");
                    string ins_detail = "";
                    sp_sqlconnection.dml_sp("pur_sale_tran_detail", "qtype=delete|ps_id=" + pur_id + "");
                    for (int i = 0; i < dgv_detail.RowCount - 1; i++)
                    {
                        ins_detail = ins_detail + "insert into pur_sale_tran_tbl (ps_id, date, inv_type, type, item, bag, qty, rate, measure, brokerage, amount, c_id, y_id, u_id, w_id) output inserted.pst_id values (" + pur_id + ",'" + date + "','PUR','" + cmb_type.Text.ToUpper() + "','" + dgv_detail.Rows[i].Cells["item"].Value.ToString() + "'," + dgv_detail.Rows[i].Cells["bag"].Value.ToString() + "," + dgv_detail.Rows[i].Cells["qty"].Value.ToString() + "," + dgv_detail.Rows[i].Cells["rate"].Value.ToString() + ",'" + dgv_detail.Rows[i].Cells["measure"].Value.ToString() + "'," + dgv_detail.Rows[i].Cells["brokerage"].Value.ToString() + "," + dgv_detail.Rows[i].Cells["amount"].Value.ToString() + "," + UserDetail.c_id + "," + UserDetail.y_id + "," + UserDetail.user_id + "," + UserDetail.w_id + "); ";
                    }
                    sqlconnection.insertdata_id(ins_detail);
                }
                #endregion

                MessageBox.Show("Data Save Successfully.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                reset();
            }
            catch (Exception)
            { }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void txt_ser_inv_no_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }

        }

        private void txt_due_days_TextChanged(object sender, EventArgs e)
        {
            if(txt_due_days.Text!="")
            {
                dtp_due_date.Value = dtp_date.Value.AddDays(Convert.ToInt32(txt_due_days.Text));
            }
            else
            {
                dtp_due_date.Value = dtp_date.Value;
            }
        }

        private void txt_due_days_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypress.AllowOnlyInt(sender, e);
        }
    }
}
