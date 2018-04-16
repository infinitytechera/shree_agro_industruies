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
    public partial class Company_mst : Form
    {
        DataTable dt_company = new DataTable();
        public Company_mst()
        {
            InitializeComponent();
            bindgrid();
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Calibri", 10);
            gridView1.OptionsSelection.MultiSelect = true;
            //gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
        }
        private void bindgrid()
        {
            try
            {
                dt_company = sp_sqlconnection.get_sp("company_detail", "qtype=select");//sqlconnection.fetchdatatable("select id,c_id,party,currency,rate,mail,lut_no,0 as 'edit' from country_mst_tbl");//Bind_Data.bind_gen();
                gridControl1.DataSource = dt_company;
            }
            catch
            { }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                #region validation
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    for (int j = i + 1; j < gridView1.RowCount - 1; j++)
                    {
                        if (gridView1.GetRowCellValue(i, "c_name").ToString() != "" && gridView1.GetRowCellValue(j, "c_name").ToString() != "")
                        {
                            if (gridView1.GetRowCellValue(i, "c_name").ToString() == gridView1.GetRowCellValue(j, "c_name").ToString())
                            {
                                MessageBox.Show("Please Check Company Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        //if (gridView1.GetRowCellValue(i, "c_id").ToString() != "" && gridView1.GetRowCellValue(j, "c_id").ToString() != "")
                        //{
                        //    if (gridView1.GetRowCellValue(i, "c_id").ToString() == gridView1.GetRowCellValue(j, "c_id").ToString())
                        //    {
                        //        MessageBox.Show("Please Check Company ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        return;
                        //    }
                        //}
                    }
                }
                #endregion
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellValue(i, "edit").ToString() == "")
                    {
                        gridView1.SetRowCellValue(i, "edit", 0);
                    }
                    decimal disc = 3.50M;
                    string ins_id = "";
                    if (gridView1.GetRowCellValue(i, "c_id").ToString() == "" || gridView1.GetRowCellValue(i, "c_id").ToString() == "0")
                    {
                        //ins_id = sqlconnection.insertdata_id(string.Format("insert into country_mst_tbl(cname,party,currency,rate,c_id) output inserted.id values('{0}','{0}','{1}',{2},{3})", gridView1.GetRowCellValue(i, "party"), gridView1.GetRowCellValue(i, "currency"), gridView1.GetRowCellValue(i, "rate"), gridView1.GetRowCellValue(i, "c_id")));
                        ins_id = sp_sqlconnection.dml_sp_id("company_detail", "qtype=insert|c_name=" + gridView1.GetRowCellValue(i, "c_name").ToString().ToUpper() + "|address=" + gridView1.GetRowCellValue(i, "address").ToString().ToUpper() + "|pan_no=" + gridView1.GetRowCellValue(i, "pan_no").ToString().ToUpper() + "|gst=" + gridView1.GetRowCellValue(i, "gst").ToString().ToUpper() + "|email=" + gridView1.GetRowCellValue(i, "email").ToString().ToUpper() + "|phone_no=" + gridView1.GetRowCellValue(i, "phone_no").ToString().ToUpper() + "|fax_no=" + gridView1.GetRowCellValue(i, "fax_no").ToString().ToUpper() + "|country=" + gridView1.GetRowCellValue(i, "country").ToString().ToUpper() + "|website=" + gridView1.GetRowCellValue(i, "website").ToString().ToUpper() + "|status=" + gridView1.GetRowCellValue(i, "status").ToString().ToUpper() + "");

                    }
                    else if (gridView1.GetRowCellValue(i, "edit").ToString() == "1" && gridView1.GetRowCellValue(i, "c_id").ToString() != "")
                    {
                        ins_id = sp_sqlconnection.dml_sp("company_detail", "qtype=update|c_name=" + gridView1.GetRowCellValue(i, "c_name").ToString().ToUpper() + "|address=" + gridView1.GetRowCellValue(i, "address").ToString().ToUpper() + "|pan_no=" + gridView1.GetRowCellValue(i, "pan_no").ToString().ToUpper() + "|gst=" + gridView1.GetRowCellValue(i, "gst").ToString().ToUpper() + "|email=" + gridView1.GetRowCellValue(i, "email").ToString().ToUpper() + "|phone_no=" + gridView1.GetRowCellValue(i, "phone_no").ToString().ToUpper() + "|fax_no=" + gridView1.GetRowCellValue(i, "fax_no").ToString().ToUpper() + "|country=" + gridView1.GetRowCellValue(i, "country").ToString().ToUpper() + "|website=" + gridView1.GetRowCellValue(i, "website").ToString().ToUpper() + "|status=" + gridView1.GetRowCellValue(i, "status").ToString().ToUpper() + "|c_id=" + gridView1.GetRowCellValue(i, "c_id").ToString().ToUpper() + "");
                        //ins_id = sqlconnection.insertdata(string.Format("update country_mst_tbl set cname='{0}',party='{0}',currency='{1}',rate={2},c_id={3},mail='{5}',lut_no='{6}' where c_id='{4}'", gridView1.GetRowCellValue(i, "party"), gridView1.GetRowCellValue(i, "currency"), gridView1.GetRowCellValue(i, "rate"), gridView1.GetRowCellValue(i, "c_id"), gridView1.GetRowCellValue(i, "c_id"), gridView1.GetRowCellValue(i, "mail"), gridView1.GetRowCellValue(i, "lut_no")));

                    }
                }
                MessageBox.Show("Data Save Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindgrid();
                //bind_master.bind_general();
            }
            catch
            {
            }
        }
        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "edit", 1);
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            bindgrid();
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                object[] ids = GetSelectedValues(gridView1, "c_id");
                //object[] c_ids = GetSelectedValues(gridView1, "c_id");
                if (ids.Length > 0)
                {
                    DialogResult result = MessageBox.Show("Are You Sure You Want To Delete This Entry?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        for (int i = 0; i < ids.Length; i++)
                        {
                            sp_sqlconnection.dml_sp("company_detail", "qtype=delete|c_id=" + ids[i].ToString() + "");
                            //sqlconnection.insertdata("delete from country_mst_tbl where id=" + ids[i].ToString() + "");
                        }
                        if (ids.Length > 0)
                        {
                            MessageBox.Show("Data Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        bindgrid();
                    }
                }
            }
            catch
            { }
        }
        private object[] GetSelectedValues(DevExpress.XtraGrid.Views.Grid.GridView view, string fieldName)
        {
            int[] selectedRows = view.GetSelectedRows();
            object[] result = new object[selectedRows.Length];
            for (int i = 0; i < selectedRows.Length; i++)
            {
                int rowHandle = selectedRows[i];
                if (!gridView1.IsGroupRow(rowHandle))
                {
                    result[i] = view.GetRowCellValue(rowHandle, fieldName);
                }
                else
                    result[i] = -1; // default value
            }
            return result;
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            gridView1.Columns["edit"].ClearFilter();
        }
        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    object[] ids = GetSelectedValues(gridView1, "id");
        //    string message = ConvertToString(ids);
        //    MessageBox.Show(message);
        //}
        //private string ConvertToString(object[] ids)
        //{
        //    return string.Join("; ", ids);
        //}
    }
}
