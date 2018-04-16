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
    public partial class warehouse_mst : Form
    {
        DataTable dt_warehouse = new DataTable();
        public warehouse_mst()
        {
            InitializeComponent();
            bindgrid();
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Calibri", 10);
            //gridView1.OptionsSelection.MultiSelect = true;
            //gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
        }
        private void bindgrid()
        {
            try
            {
                dt_warehouse = sp_sqlconnection.get_sp("warehouse_detail", "qtype=select|c_id=" + UserDetail.c_id + "");//sqlconnection.fetchdatatable("select *,'' as edit from warehouse_tbl where c_id="+UserDetail.c_id+"");//Bind_Data.bind_master("COLOR");
                gridControl1.DataSource = dt_warehouse;
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
                        //if (gridView1.GetRowCellValue(i, "priority").ToString() == gridView1.GetRowCellValue(j, "priority").ToString())
                        //{
                        //    MessageBox.Show("Please Check Your priority", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                        if (gridView1.GetRowCellValue(i, "w_name").ToString() == gridView1.GetRowCellValue(j, "w_name").ToString())
                        {
                            MessageBox.Show("Please Check Your WareHouse Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //return;
                        }
                        //if (gridView1.GetRowCellValue(i, "gia").ToString() != "" && gridView1.GetRowCellValue(j, "gia").ToString() != "")
                        //{
                        //    if (gridView1.GetRowCellValue(i, "gia").ToString() == gridView1.GetRowCellValue(j, "gia").ToString())
                        //    {
                        //        MessageBox.Show("Please Check Your GIA Color", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        return;
                        //    }
                        //}
                    }
                }
                #endregion
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellValue(i, "w_name").ToString() == "")
                    {
                        MessageBox.Show("Please Enter WareHouse Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (gridView1.GetRowCellValue(i, "address").ToString() == "")
                    {
                        MessageBox.Show("Please Enter Address", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //if (gridView1.GetRowCellValue(i, "tax").ToString() != "")
                    //{
                    //    if (Convert.ToDecimal(gridView1.GetRowCellValue(i, "priority").ToString()) == 0.00M)
                    //    {
                    //        MessageBox.Show("Please Enter Proper Tax", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }
                    //}
                    if (gridView1.GetRowCellValue(i, "edit").ToString() == "")
                    {
                        gridView1.SetRowCellValue(i, "edit", 0);
                    }
                    int k = Convert.ToInt32(gridView1.GetRowCellValue(i, "edit").ToString());
                    if (k == 1)
                    {
                        string ins_id = "";
                        if (gridView1.GetRowCellValue(i, "w_id").ToString() == "")
                        {
                            ins_id = sp_sqlconnection.dml_sp_id("warehouse_detail", "qtype=insert|w_name=" + gridView1.GetRowCellValue(i, "w_name").ToString().ToUpper() + "|address=" + gridView1.GetRowCellValue(i, "address").ToString().ToUpper() + "|status=" + gridView1.GetRowCellValue(i, "status").ToString().ToUpper() + "|c_id=" + UserDetail.c_id+"");
                            //ins_id = sqlconnection.insertdata_id("insert into warehouse_mst_tbl  (w_name, address, c_id) output inserted.w_id values ('" + gridView1.GetRowCellValue(i, "w_name").ToString().ToUpper() + "','" + gridView1.GetRowCellValue(i, "address").ToString().ToUpper() + "'," + UserDetail.c_id + ")");
                        }
                        else
                        {
                            ins_id = sp_sqlconnection.dml_sp("warehouse_detail", "qtype=update|w_name=" + gridView1.GetRowCellValue(i, "w_name").ToString().ToUpper() + "|address=" + gridView1.GetRowCellValue(i, "address").ToString().ToUpper() + "|status=" + gridView1.GetRowCellValue(i, "status").ToString().ToUpper() + "|c_id=" + UserDetail.c_id + "|w_id="+ gridView1.GetRowCellValue(i, "w_id").ToString() + "");
                            //ins_id = sqlconnection.insertdata("update warehouse_mst_tbl set w_name='" + gridView1.GetRowCellValue(i, "w_name").ToString().ToUpper() + "',address='" + gridView1.GetRowCellValue(i, "address").ToString().ToUpper() + "' where w_id='" + gridView1.GetRowCellValue(i, "w_id").ToString() + "'");
                        }
                    }
                }
                MessageBox.Show("Data Save Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindgrid();
                bind_master.bind_warehouse_mst();
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
                object[] ids = GetSelectedValues(gridView1, "w_id");
                if (ids.Length > 0)
                {
                    DialogResult result = MessageBox.Show("Are You Sure You Want To Delete This Entry?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        for (int i = 0; i < ids.Length; i++)
                        {
                            sp_sqlconnection.dml_sp("warehouse_detail", "qtype=delete|w_id=" + ids[i].ToString() + "");
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

        private void warehouse_mst_Load(object sender, EventArgs e)
        {

        }
    }
}
