using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shree_agro
{
    public partial class Item_mst : Form
    {
        DataTable dt_item = new DataTable();
        public Item_mst()
        {
            InitializeComponent();
            bind_data();
        }
        private void bind_data()
        {
            dt_item = sp_sqlconnection.get_sp("item_detail", "qtype=select|c_id=" + UserDetail.c_id + "");
            gridControl1.DataSource = dt_item;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            #region validation
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                for (int j = i + 1; j < gridView1.RowCount - 1; j++)
                {

                    if (gridView1.GetRowCellValue(i, "i_name").ToString() == gridView1.GetRowCellValue(j, "i_name").ToString())
                    {
                        MessageBox.Show("Please Check Your Item Name, Duplicate Name Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            #endregion
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                if (gridView1.GetRowCellValue(i, "i_name").ToString() == "")
                {
                    MessageBox.Show("Please Enter Item Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (gridView1.GetRowCellValue(i, "type").ToString() == "")
                {
                    MessageBox.Show("Please Enter Type", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (gridView1.GetRowCellValue(i, "measurement").ToString() == "")
                {
                    MessageBox.Show("Please Enter Measurement", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (gridView1.GetRowCellValue(i, "bag_weight").ToString() != "")
                {
                    if (Convert.ToDecimal(gridView1.GetRowCellValue(i, "bag_weight").ToString()) == 0)
                    {
                        MessageBox.Show("Please Enter Proper Bag Weight", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (gridView1.GetRowCellValue(i, "edit").ToString() == "")
                {
                    gridView1.SetRowCellValue(i, "edit", 0);
                }
                int k = Convert.ToInt32(gridView1.GetRowCellValue(i, "edit").ToString());
                if (k == 1)
                {
                    string ins_id = "";
                    if (gridView1.GetRowCellValue(i, "i_id").ToString() == "")
                    {
                       ins_id = sp_sqlconnection.dml_sp_id("item_detail", "qtype=insert|i_name=" + gridView1.GetRowCellValue(i, "i_name").ToString() + "|measurement=" + gridView1.GetRowCellValue(i, "measurement").ToString() + "|bag_weight=" + gridView1.GetRowCellValue(i, "bag_weight").ToString() + "|type=" + gridView1.GetRowCellValue(i, "type").ToString() + "|c_id=" +UserDetail.c_id + "|u_id=" + UserDetail.user_id + "");
                    }
                    else
                    {
                       ins_id = sp_sqlconnection.dml_sp("item_detail", "qtype=update|i_name=" + gridView1.GetRowCellValue(i, "i_name").ToString() + "|measurement=" + gridView1.GetRowCellValue(i, "measurement").ToString() + "|bag_weight=" + gridView1.GetRowCellValue(i, "bag_weight").ToString() + "|type=" + gridView1.GetRowCellValue(i, "type").ToString() + "|c_id=" + UserDetail.c_id + "|u_id=" + UserDetail.user_id + "|i_id=" + gridView1.GetRowCellValue(i, "i_id").ToString() + "");
                    }
                }
            }
            MessageBox.Show("Data Save Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bind_data();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                object[] ids = GetSelectedValues(gridView1, "i_id");
                if (ids.Length > 0)
                {
                    DialogResult result = MessageBox.Show("Are You Sure You Want To Delete This Entry?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        for (int i = 0; i < ids.Length; i++)
                        {
                            sp_sqlconnection.dml_sp("item_detail","qtype=delete|i_id="+ ids[i].ToString() + "");
                        }
                        if (ids.Length > 0)
                        {
                            MessageBox.Show("Data Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        bind_data();
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

        private void btn_reset_Click(object sender, EventArgs e)
        {
            bind_data();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            gridView1.Columns["edit"].ClearFilter();
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "edit", 1);
        }
    }
}
