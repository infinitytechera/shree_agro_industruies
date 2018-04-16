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
    public partial class Year_mst : Form
    {
        DataTable dt_year = new DataTable();
        public Year_mst()
        {
            InitializeComponent();
            bindgrid();
            //DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Calibri", 10);
            //gridView1.OptionsSelection.MultiSelect = true;
            //gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
        }
        private void bindgrid()
        {
            try
            {
                dt_year = sp_sqlconnection.get_sp("year_detail", "qtype=select|c_id="+UserDetail.c_id+"");//sqlconnection.fetchdatatable("select y_id,y_name,status,f_date,t_date,0 as 'edit' from year_tbl where c_id=" + UserDetail.c_id + "");//Bind_Data.bind_gen();
                gridControl1.DataSource = dt_year;
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
                    if (gridView1.GetRowCellValue(i, "y_name").ToString() == "")
                    {
                        MessageBox.Show("Please Check Year Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (gridView1.GetRowCellValue(i, "f_date").ToString() == "")
                    {
                        MessageBox.Show("Please Enter From Date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (gridView1.GetRowCellValue(i, "t_date").ToString() == "")
                    {
                        MessageBox.Show("Please Enter To Date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    for (int j = i + 1; j < gridView1.RowCount - 1; j++)
                    {
                        if (gridView1.GetRowCellValue(i, "y_name").ToString() != "" && gridView1.GetRowCellValue(j, "y_name").ToString() != "")
                        {
                            if (gridView1.GetRowCellValue(i, "y_name").ToString() == gridView1.GetRowCellValue(j, "y_name").ToString())
                            {
                                MessageBox.Show("Please Check Year Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        if (gridView1.GetRowCellValue(i, "f_date").ToString() != "" && gridView1.GetRowCellValue(j, "f_date").ToString() != "")
                        {
                            if (gridView1.GetRowCellValue(i, "f_date").ToString() == gridView1.GetRowCellValue(j, "f_date").ToString())
                            {
                                MessageBox.Show("Please Check From Date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        if (gridView1.GetRowCellValue(i, "t_date").ToString() != "" && gridView1.GetRowCellValue(j, "t_date").ToString() != "")
                        {
                            if (gridView1.GetRowCellValue(i, "t_date").ToString() == gridView1.GetRowCellValue(j, "t_date").ToString())
                            {
                                MessageBox.Show("Please Check To Date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    string f_date = Convert.ToDateTime(gridView1.GetRowCellValue(i, "f_date")).ToString("MM-dd-yyyy");
                    string t_date = Convert.ToDateTime(gridView1.GetRowCellValue(i, "t_date")).ToString("MM-dd-yyyy");
                    if (gridView1.GetRowCellValue(i, "edit").ToString() == "")
                    {
                        gridView1.SetRowCellValue(i, "edit", 0);
                    }
                    string ins_id = "";
                    if (gridView1.GetRowCellValue(i, "y_id").ToString() == "" || gridView1.GetRowCellValue(i, "y_id").ToString() == "0")
                    {
                        if (gridView1.GetRowCellValue(i, "status").ToString() == "")
                        {
                            gridView1.SetRowCellValue(i, "status", 0);
                        }
                        if (gridView1.GetRowCellValue(i, "y_id").ToString() == "")
                        {
                            gridView1.SetRowCellValue(i, "y_id", 0);
                        }
                        ins_id = sp_sqlconnection.dml_sp_id("year_detail", "qtype=insert|y_name=" + gridView1.GetRowCellValue(i, "y_name").ToString().ToUpper() + "|c_id=" + UserDetail.c_id + "|f_date=" + f_date + "|t_date=" + t_date + "|status=" + gridView1.GetRowCellValue(i, "status").ToString() + "");
                    }
                    else if (gridView1.GetRowCellValue(i, "edit").ToString() == "1" && gridView1.GetRowCellValue(i, "y_id").ToString() != "")
                    {

                        if (gridView1.GetRowCellValue(i, "status").ToString() == "")
                        {
                            gridView1.SetRowCellValue(i, "status", 0);
                        }
                        if (gridView1.GetRowCellValue(i, "y_id").ToString() == "")
                        {
                            gridView1.SetRowCellValue(i, "y_id", gridView1.GetRowCellValue(i, "id"));
                        }
                        if (gridView1.GetRowCellValue(i, "y_id").ToString() == "")
                        {
                            gridView1.SetRowCellValue(i, "y_id", 0);
                        }
                        ins_id = sp_sqlconnection.dml_sp("year_detail", "qtype=update|y_name=" + gridView1.GetRowCellValue(i, "y_name").ToString().ToUpper() + "|c_id=" + UserDetail.c_id + "|f_date=" + f_date + "|t_date=" + t_date + "|status=" + gridView1.GetRowCellValue(i, "status").ToString() + "|y_id=" + gridView1.GetRowCellValue(i, "y_id").ToString() + "");
                        //ins_id = sqlconnection.insertdata(string.Format("update year_tbl set name='{0}',status={1},y_id={2},f_date='{4}',t_date='{5}' where id='{3}'", gridView1.GetRowCellValue(i, "name"), gridView1.GetRowCellValue(i, "status"), gridView1.GetRowCellValue(i, "y_id"), gridView1.GetRowCellValue(i, "id"), gridView1.GetRowCellValue(i, "f_date"), gridView1.GetRowCellValue(i, "t_date")));

                    }

                }
                MessageBox.Show("Data Save Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindgrid();
                //bind_master.bind_general();
                //bind_master.bind_mst();
            }
            catch (Exception ex)
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
                object[] ids = GetSelectedValues(gridView1, "y_id");
                object[] c_ids = GetSelectedValues(gridView1, "y_id");
                if (ids.Length > 0)
                {
                    DialogResult result = MessageBox.Show("Are You Sure You Want To Delete This Entry?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string del = "";
                        for (int i = 0; i < ids.Length; i++)
                        {
                            del = sp_sqlconnection.dml_sp("year_detail", "qtype=delete|y_id=" + ids[i].ToString() + "");//sqlconnection.insertdata("delete from year_tbl where y_id=" + ids[i].ToString() + "");
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

        private void txt_previous_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypress.AllowOnlyInt(sender, e);
        }



        private void Year_mst_Load(object sender, EventArgs e)
        {

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
