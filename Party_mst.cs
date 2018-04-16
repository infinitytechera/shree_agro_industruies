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
    public partial class Party_mst : Form
    {
        DataTable dt_party = new DataTable();
        DataTable dt_category = new DataTable();
        string Inserted_Value = "";
        string p_id = "";
        public Party_mst()
        {
            InitializeComponent();
            bind_data();
            
        }

        private void bind_data()
        {
            dt_party = sp_sqlconnection.get_sp("party_detail", "qtype=select|c_id=" + UserDetail.c_id + "");
            dt_category = sp_sqlconnection.get_sp("party_detail", "qtype=selectcategory|category=BROKER|c_id=" + UserDetail.c_id + "");
            auto_suggest_party();
            auto_suggest_category();
        }
        private void auto_suggest_party()
        {
            //Get Table Details For Textbox Suggestion
            var source = new AutoCompleteStringCollection();//Create Object of Source for Selected Column Value
            //DataTable dt = new DataTable();
            //dt = sqlconnection.fetchdatatable("select Column1 from TABLE");//Get Column Details for txt Suggestion
            String[] stringArray = Array.ConvertAll<DataRow, String>(dt_party.Select(), delegate (DataRow row) { return (String)row["p_name"]; });
            source.AddRange(stringArray);
            txt_party_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_party_name.AutoCompleteCustomSource = source;
            txt_party_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void auto_suggest_category()
        {

            //Get Table Details For Textbox Suggestion
            var source = new AutoCompleteStringCollection();//Create Object of Source for Selected Column Value
            String[] stringArray = Array.ConvertAll<DataRow, String>(dt_category.Select(), delegate (DataRow row) { return (String)row["p_name"]; });
            source.AddRange(stringArray);
            txt_broker.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_broker.AutoCompleteCustomSource = source;
            txt_broker.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            reset();
           
        }
        private void reset()
        {
            p_id = "";
            Inserted_Value = "";
            txt_party_name.Text = "";
            txt_address.Text = "";
            txt_pan_no.Text = "";
            txt_city.Text = "";
            txt_bank_address.Text = "";
            txt_bank_acc_no.Text = "";
            txt_bank_ifsc.Text = "";
            txt_bank_name.Text = "";
            txt_broker.Text = "";
            txt_email.Text = "";
            txt_gst.Text = "";
            txt_mob_no.Text = "";
            txt_pan_no.Text = "";
            txt_phone.Text = "";
            txt_remark.Text = "";
            txt_state.Text = "";
            cmb_category.Text = "";
            txt_party_name.Focus();
            bind_data();
        }

        private void txt_party_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }


        //Set Keydown For All Controls 
        private void allkeydown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception)
            { }
        }
            

        private void search()
        {
            try
            {
                for (int i = 0; i < dt_party.Rows.Count; i++)
                {
                    if (txt_party_name.Text.ToUpper().Trim() == dt_party.Rows[i]["p_name"].ToString().ToUpper())
                    {
                        p_id = dt_party.Rows[i]["p_id"].ToString();
                        txt_party_name.Text = dt_party.Rows[i]["p_name"].ToString();
                        Inserted_Value = dt_party.Rows[i]["p_name"].ToString();
                        txt_address.Text = dt_party.Rows[i]["address"].ToString();
                        cmb_category.Text = dt_party.Rows[i]["category"].ToString();
                        txt_bank_acc_no.Text = dt_party.Rows[i]["acc_no"].ToString();
                        txt_pan_no.Text = dt_party.Rows[i]["pan_no"].ToString();
                        txt_city.Text = dt_party.Rows[i]["city"].ToString();
                        txt_state.Text = dt_party.Rows[i]["state"].ToString();
                        txt_bank_ifsc.Text = dt_party.Rows[i]["ifsc_code"].ToString();
                        txt_bank_name.Text = dt_party.Rows[i]["bank_name"].ToString();
                        txt_bank_address.Text = dt_party.Rows[i]["bank_address"].ToString();
                        txt_gst.Text = dt_party.Rows[i]["gst"].ToString();
                        txt_email.Text = dt_party.Rows[i]["email"].ToString();
                        txt_phone.Text = dt_party.Rows[i]["phone"].ToString();
                        txt_mob_no.Text = dt_party.Rows[i]["mob_no"].ToString();
                        txt_broker.Text = dt_party.Rows[i]["broker"].ToString();
                        txt_remark.Text = dt_party.Rows[i]["remark"].ToString();
                        return;
                    }

                }
            }
            catch (Exception)
            { }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (p_id != "")
                {
                    string del_id = "";
                    DialogResult result = MessageBox.Show("Are You Sure You Want To Delete This Entry?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        del_id = sp_sqlconnection.dml_sp("party_detail", "qtype=delete|p_id=" + p_id + "");
                        reset();
                    }
                    if (del_id != "")
                    {
                        MessageBox.Show("Details Successfully Deleted..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Data", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            { }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation
                if (txt_party_name.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Party Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_party_name.Focus();
                    return;
                }
                Set_Comboas_Null.Check_Item_Exist_In_Combo(cmb_category);
                if (cmb_category.Text == "")
                {
                    MessageBox.Show("Please Enter Category.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb_category.Focus();
                    return;
                }
                #endregion
                if (txt_broker.Text != "")
                {
                    DataRow[] checkentry = dt_category.Select("p_name='" + txt_broker.Text.Trim().ToUpper() + "'");
                    if (checkentry.Length == 0)
                    {
                        MessageBox.Show("Broker Not Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_broker.Focus();
                        txt_broker.Text = "";
                        return;
                    }
                }

                string ins_id = "";
                #region Insert & Update
                if (p_id == "")
                {
                    ins_id = sp_sqlconnection.dml_sp_id("party_detail", "qtype=insert|p_name=" + txt_party_name.Text.Trim().ToUpper() + "|address=" + txt_address.Text.Trim().ToUpper() + "|category=" + cmb_category.Text.Trim().ToUpper() + "|acc_no=" + txt_bank_acc_no.Text.Trim().ToUpper() + "|pan_no=" + txt_pan_no.Text.Trim().ToUpper() + "|city=" + txt_city.Text.Trim().ToUpper() + "|state=" + txt_state.Text.Trim().ToUpper() + "|ifsc_code=" + txt_bank_ifsc.Text.Trim().ToUpper() + "|bank_name=" + txt_bank_name.Text.Trim().ToUpper() + "|bank_address=" + txt_bank_address.Text.Trim().ToUpper() + "|gst=" + txt_gst.Text.Trim().ToUpper() + "|email=" + txt_email.Text.Trim().ToUpper() + "|phone=" + txt_phone.Text.Trim().ToUpper() + "|mob_no=" + txt_mob_no.Text.Trim().ToUpper() + "|broker=" + txt_broker.Text.Trim().ToUpper() + "|remark=" + txt_remark.Text.Trim().ToUpper() + "|c_id=" + UserDetail.c_id + "|u_id=" + UserDetail.user_id + "|w_id=0");

                }
                else
                {
                    //Update  Section
                    if (Inserted_Value != txt_party_name.Text)
                    {
                        DataRow[] checkentry = dt_party.Select("p_name='" + txt_party_name.Text.Trim().ToUpper() + "'");
                        if (checkentry.Length > 0)
                        {
                            MessageBox.Show("Already Exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_party_name.Focus();
                            return;
                        }
                    }
                    
                    ins_id = sp_sqlconnection.dml_sp("party_detail", "qtype=update|p_name=" + txt_party_name.Text.Trim().ToUpper() + "|address=" + txt_address.Text.Trim().ToUpper() + "|category=" + cmb_category.Text.Trim().ToUpper() + "|acc_no=" + txt_bank_acc_no.Text.Trim().ToUpper() + "|pan_no=" + txt_pan_no.Text.Trim().ToUpper() + "|city=" + txt_city.Text.Trim().ToUpper() + "|state=" + txt_state.Text.Trim().ToUpper() + "|ifsc_code=" + txt_bank_ifsc.Text.Trim().ToUpper() + "|bank_name=" + txt_bank_name.Text.Trim().ToUpper() + "|bank_address=" + txt_bank_address.Text.Trim().ToUpper() + "|gst=" + txt_gst.Text.Trim().ToUpper() + "|email=" + txt_email.Text.Trim().ToUpper() + "|phone=" + txt_phone.Text.Trim().ToUpper() + "|mob_no=" + txt_mob_no.Text.Trim().ToUpper() + "|broker=" + txt_broker.Text.Trim().ToUpper() + "|remark=" + txt_remark.Text.Trim().ToUpper() + "|u_id=" + UserDetail.user_id + "|p_id=" + p_id + "");
                }
                #endregion
                if(ins_id!="")
                {
                    MessageBox.Show("Data Successfully Save.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    reset();
                }
            }
            catch (Exception)
            { }
        }
    }
}
