using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;

namespace shree_agro
{
    class Set_Comboas_Null
    {
        public static decimal d = 0.000M;
        public static void Check_Item_Exist_In_Combo(System.Windows.Forms.ComboBox cmb)
        {
            int indx = cmb.FindStringExact(cmb.Text);
            if (indx >= 0) { }
            else { cmb.Text = ""; }
        }

        public static void Set_Zero_If_Point_Textbox(TextBox txt)
        {
            if (txt.Text != "")
            {
                d = decimal.Parse(txt.Text);
                txt.Text = d.ToString("0.000");
            }
        }

        public static void Set_Zero_If_Null_Textbox(TextBox txt)
        {
            if (txt.Text.Trim() == "")
            {
                txt.Text = "0";
            }
        }
        public static void Set_Zero_If_Null_Textedit(TextEdit txt)
        {
            if (txt.Text.Trim() == "")
            {
                txt.Text = "0";
            }
        }
        public static void Set_Zero_If_Null_Label(Label lbl)
        {
            if (lbl.Text.Trim() == "")
            {
                lbl.Text = "0";
            }
        }
        public static void Set_Zero_If_Null_GridCell(DataGridView dgv, int index, string column_name)
        {
            try
            {
                if (dgv.Rows[index].Cells[column_name].Value == null)
                {
                    dgv.Rows[index].Cells[column_name].Value = "0";
                    return;
                }
                int i = 0;
                decimal abc = 0;
                if (int.TryParse(dgv.Rows[index].Cells[column_name].Value.ToString(), out i))
                {
                    return;
                }
                if (decimal.TryParse(dgv.Rows[index].Cells[column_name].Value.ToString(), out abc))
                {
                    return;
                }
                if (dgv.Rows[index].Cells[column_name].Value.ToString() == "" || dgv.Rows[index].Cells[column_name].Value == null || (String)dgv.Rows[index].Cells[column_name].Value == String.Empty)
                {
                    dgv.Rows[index].Cells[column_name].Value = "0";
                }
            }
            catch (Exception)
            { }
        }
        public static void Set_Null_If_Zero_GridCell(DataGridView dgv, int index, string column_name)
        {
            try
            {
                int i = 0;
                decimal abc = 0;
                if (int.TryParse(dgv.Rows[index].Cells[column_name].Value.ToString(), out i))
                {
                    dgv.Rows[index].Cells[column_name].Value = "";
                    return;
                }
                if (decimal.TryParse(dgv.Rows[index].Cells[column_name].Value.ToString(), out abc))
                {
                    dgv.Rows[index].Cells[column_name].Value = "";
                    return;
                }
                if (dgv.Rows[index].Cells[column_name].Value.ToString() == "" || dgv.Rows[index].Cells[column_name].Value == null || (String)dgv.Rows[index].Cells[column_name].Value == String.Empty)
                {
                    dgv.Rows[index].Cells[column_name].Value = "";
                }
            }
            catch (Exception)
            { }
        }
        public static void Set_Zero_If_Null_DtCell(System.Data.DataTable dgv, int index, string column_name)
        {
            try
            {
                if (dgv.Rows[index][column_name] == null || dgv.Rows[index][column_name].ToString() == "0")
                {
                    dgv.Rows[index][column_name] = "0";
                    return;
                }
                int i = 0;
                decimal abc = 0;
                if (int.TryParse(dgv.Rows[index][column_name].ToString(), out i))
                {
                    return;
                }
                if (decimal.TryParse(dgv.Rows[index][column_name].ToString(), out abc))
                {
                    return;
                }
                if (dgv.Rows[index][column_name].ToString() == "" || dgv.Rows[index][column_name] == null || (String)dgv.Rows[index][column_name] == String.Empty)
                {
                    dgv.Rows[index][column_name] = "0";
                }
            }
            catch (Exception)
            { }
        }

        public static void Set_NUll_If_Null_DtCell(System.Data.DataTable dgv, int index, string column_name)
        {
            try
            {
                if (dgv.Rows[index][column_name] == null || dgv.Rows[index][column_name].ToString() == "0")
                {
                    dgv.Rows[index][column_name] = "";
                    return;
                }
                int i = 0;
                decimal abc = 0;
                if (int.TryParse(dgv.Rows[index][column_name].ToString(), out i))
                {
                    return;
                }
                if (decimal.TryParse(dgv.Rows[index][column_name].ToString(), out abc))
                {
                    return;
                }
                if (dgv.Rows[index][column_name].ToString() == "" || dgv.Rows[index][column_name] == null || (String)dgv.Rows[index][column_name] == String.Empty)
                {
                    dgv.Rows[index][column_name] = "";
                }
            }
            catch (Exception)
            { }
        }
        public static void Set_null_If_Null_GridCell(DataGridView dgv, int index, string column_name)
        {
            try
            {
                if (dgv.Rows[index].Cells[column_name].Value == null)
                {
                    dgv.Rows[index].Cells[column_name].Value = "";
                    return;
                }
                //if (dgv.Rows[index].Cells[column_name].Value.ToString()=="")
                //{
                //    dgv.Rows[index].Cells[column_name].Value = "";
                //    return;
                //}
            }
            catch (Exception)
            { }
        }
        public static void Set_value_If_Null_GridCell(DataGridView dgv, int index, string column_name, string val)
        {
            try
            {
                if (dgv.Rows[index].Cells[column_name].Value == null || dgv.Rows[index].Cells[column_name].Value.ToString() == "")
                {
                    dgv.Rows[index].Cells[column_name].Value = val;
                    return;
                }
            }
            catch (Exception)
            { }
        }

        public static void Set_Date_Format(DateTimePicker dtp)
        {
            try
            {
                dtp.CustomFormat = "dd/MM/yyyy";
                dtp.Format = DateTimePickerFormat.Custom;
            }
            catch (Exception)
            { }
        }

       public static void Set_drag_drop_effect_in_dgv(DataGridView dgv)
        {
            try
            {
                if (dgv.SelectedCells.Count > 0)
                {
                    string set_val = dgv.SelectedCells[dgv.SelectedCells.Count - 1].Value.ToString();
                    int first_pos = dgv.SelectedCells[dgv.SelectedCells.Count - 1].RowIndex;
                    string first_col = dgv.Columns[dgv.SelectedCells[dgv.SelectedCells.Count - 1].ColumnIndex].Name;

                    int last_pos = dgv.CurrentCell.RowIndex;
                    string last_col = dgv.Columns[dgv.CurrentCell.ColumnIndex].Name;

                    if (first_col == last_col)
                    {
                        for (int i = first_pos; i <= last_pos; i++)
                        {
                            dgv.Rows[i].Cells[first_col].Value = set_val;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
       
       public static Form FormProperty(Form frm)
       {
           frm.MaximizeBox = false;
           frm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
           frm.StartPosition = FormStartPosition.CenterScreen;
           //frm.Icon = new Icon(Application.StartupPath + "\\SmartDiam Logo.ico");
           return frm;
       }

       
    }
}
