using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DevExpress.WinRTPresenter;
using System.Diagnostics;
using System.Collections;
using System.Runtime.InteropServices;

namespace shree_agro
{
    class Bind_Data
    {
        static DataTable dt_item = new DataTable();
        static DataTable dt_master = new DataTable();
        static DataTable dt_bank = new DataTable();
        static DataTable dt_invoice = new DataTable();
        static Process[] s_process = new Process[1];
        static Process[] e_process = new Process[1];
        static Process[] dup_process = new Process[0];
        public static Hashtable myHashtable;
        static string[] _path = new string[1];
        static string[] amt_word = new string[6];

        public static DataTable bind_item(string type)
        {
            dt_master = sqlconnection.fetchdatatable("select *,0 as 'edit' from master_tbl where type='" + type + "'");
            return dt_master;
        }
        public static DataTable bind_master(string type)
        {
            dt_master = sqlconnection.fetchdatatable("select *,0 as 'edit' from master_tbl where type='" + type + "'");
            return dt_master;
        }
        public static DataTable bind_gen()
        {
            dt_master = sqlconnection.fetchdatatable("select *,0 as 'edit' from general_tbl");
            return dt_master;
        }
        public static DataTable bind_mail()
        {
            dt_master = sqlconnection.fetchdatatable("select *,0 as 'edit' from mail_tbl");
            return dt_master;
        }
        public static DataTable bind_bank()
        {
            dt_master = sqlconnection.fetchdatatable("select *,0 as 'edit' from bank_tbl");
            return dt_master;
        }
        public static DataTable bind_invoice()
        {
            dt_master = sqlconnection.fetchdatatable("select *,0 as 'edit' from invoice_tbl");
            return dt_master;
        }
        public static DataTable bind_name_mst(string type)
        {
            dt_master = sqlconnection.fetchdatatable("select name from master_tbl where type='" + type + "'");
            return dt_master;
        }

        //public static string generate_shape(string shape)
        //{
        //    string shape_code = "";
        //    string[] _shape = shape.Trim().ToUpper().Replace("-", " ").Split('~');
        //    //bind_master.bind_shape_code("GIA");
        //    if (UserDetail.dt_shape_code.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < UserDetail.dt_shape_code.Rows.Count; i++)
        //        {
        //            if (UserDetail.dt_shape_code.Rows[i]["code"].ToString() == _shape[0])
        //            {
        //                shape_code = UserDetail.dt_shape_code.Rows[i]["shape"].ToString();
        //                break;
        //            }
        //        }
        //        if (shape_code == "")
        //        {
        //            shape_code = _shape[0];
        //        }
        //    }

        //    return shape_code;
        //}
        //public static string generate_fluorosense(string fluo)
        //{
        //    string fluo_code = "";
        //    string[] _fluo = fluo.Trim().ToUpper().Replace("-", " ").Split(' ');
        //    //bind_master.bind_shape_code("GIA");
        //    if (fluo.Trim() != "")
        //    {
        //        if (_fluo[0] == "NONE")
        //        {
        //            fluo_code = "NON";
        //        }
        //        else if (_fluo[0] == "FAINT")
        //        {
        //            fluo_code = "FNT";
        //        }
        //        else if (_fluo[0] == "MEDIUM")
        //        {
        //            fluo_code = "MED";
        //        }
        //        else if (_fluo[0] == "STRONG")
        //        {
        //            fluo_code = "STR";
        //        }
        //        else if (_fluo[0] == "VERY")
        //        {
        //            fluo_code = "VST";
        //        }
        //        else
        //        {
        //            fluo_code = fluo;
        //        }
        //    }
        //    else
        //    {
        //        fluo_code = "";
        //    }

        //    return fluo_code;
        //}
        //public static string generate_size(string size)
        //{
        //    string size_code = "";
        //    string[] _size = size.Trim().ToUpper().Replace("-", " ").Split('~');
        //    decimal from = 0.00M;
        //    decimal to = 0.00M;
        //    //bind_master.bind_shape_code("GIA");
        //    if (UserDetail.dt_size.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < UserDetail.dt_size.Rows.Count; i++)
        //        {
        //            from = Convert.ToDecimal(UserDetail.dt_size.Rows[i]["p_from"].ToString());
        //            to = Convert.ToDecimal(UserDetail.dt_size.Rows[i]["p_to"].ToString());
        //            if (from <= Convert.ToDecimal(_size[0]) && to >= Convert.ToDecimal(_size[0]))
        //            {
        //                size_code = UserDetail.dt_size.Rows[i]["name"].ToString();
        //                break;
        //            }
        //        }
        //        if (size_code == "")
        //        {
        //            size_code = _size[0];
        //        }
        //    }

        //    return size_code;
        //}
        public static DataTable bind_item_master()
        {
            dt_master = sqlconnection.fetchdatatable("select *,0 as 'edit' from TabItemMaster");
            return dt_master;
        }
        public static DataTable bind_pur_sale_party()
        {
            UserDetail.dt_party = sqlconnection.fetchdatatable("select * from party_mst_tbl where c_id=" + UserDetail.c_id + "");
            return UserDetail.dt_party;
        }
        //private void autosuggestion(textedit text)
        //{
        //    try
        //    {
        //        AutoCompleteStringCollection party_name = new AutoCompleteStringCollection();
        //        if (dt_party.Rows.Count > 0)
        //        {
        //            bind_party();
        //        }
        //        for (int i = 0; i < dt_party.Rows.Count; i++)
        //        {
        //            party_name.Add(dt_party.Rows[i]["name"].ToString());
        //        }
        //        txt_name.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        txt_name.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //        txt_name.MaskBox.AutoCompleteCustomSource = party_name;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
        public static int gen_jv_v_no(string type)
        {
            int i_no = 0;
            if (UserDetail.con_id != "0")
            {
            jump:
                DataTable dt_invoice = sqlconnection.fetchdatatable("select top 1 isnull(max(isnull(v_no,0)),0) from jv_tbl where y_id=" + UserDetail.y_id + " and c_id=" + UserDetail.con_id + " and type='" + type + "'");
                if (dt_invoice.Rows.Count > 0)
                {
                    i_no = Convert.ToInt32(dt_invoice.Rows[0][0].ToString());
                }
                if (dt_invoice.Columns.Count == 0)
                {
                    goto jump;
                }
                i_no = i_no + 1;
            }
            return i_no;
        }
        public static int gen_invoice_no(string type)
        {
            int i_no = 0;
            if (UserDetail.con_id != "0")
            {
            jump:
                DataTable dt_invoice = sqlconnection.fetchdatatable("select top 1 isnull(max(isnull(inv_no,0)),0) from pur_sale_tbl where y_id=" + UserDetail.y_id + " and c_id=" + UserDetail.con_id + " and inv_type='" + type + "'");
                if (dt_invoice.Rows.Count > 0)
                {
                    i_no = Convert.ToInt32(dt_invoice.Rows[0][0].ToString());
                }
                if (dt_invoice.Columns.Count == 0)
                {
                    goto jump;
                }
                i_no = i_no + 1;
            }
            return i_no;
        }
        public static int gen_labour_invoice_no(string p_id)
        {
            int i_no = 0;
        jump:
            DataTable dt_invoice = sqlconnection.fetchdatatable("select top 1 isnull(max(isnull(inv_no,0)),0) from labour_tbl where y_id=" + UserDetail.y_id + " and c_id=" + p_id + "");
            if (dt_invoice.Rows.Count > 0)
            {
                i_no = Convert.ToInt32(dt_invoice.Rows[0][0].ToString());
            }
            if (dt_invoice.Columns.Count == 0)
            {
                goto jump;
            }
            i_no = i_no + 1;
            return i_no;
        }
        public static int gen_invoice_no_for_c_id(string type, string c_id)
        {
            int i_no = 0;
        jump:
            DataTable dt_invoice = sqlconnection.fetchdatatable("select top 1 isnull(max(isnull(inv_no,0)),0) from pur_sale_tbl where c_id=" + c_id + " and inv_type='" + type + "'");
            if (dt_invoice.Rows.Count > 0)
            {
                i_no = Convert.ToInt32(dt_invoice.Rows[0][0].ToString());
            }
            if (dt_invoice.Columns.Count == 0)
            {
                goto jump;
            }
            i_no = i_no + 1;
            return i_no;
        }
        public static string gen_str(TextBox txt)
        {
            string g_str = "";
            string[] sep = new string[] { "\r\n" };
            string[] lines = txt.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (txt.Text != "")
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (g_str == "")
                        g_str = g_str + "'" + lines[i].Trim() + "'";
                    else
                        g_str = g_str + ",'" + lines[i].Trim() + "'";
                }
            }
            return g_str;
        }
        public static string gen_str_list(ListBox txt)
        {
            string g_str = "";
            string[] sep = new string[] { "\r\n" };
            string[] lines = txt.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (txt.Text != "")
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (g_str == "")
                        g_str = g_str + "'" + lines[i].Trim() + "'";
                    else
                        g_str = g_str + ",'" + lines[i].Trim() + "'";
                }
            }
            return g_str;
        }
        public static void KillExcel(int j)
        {
            try
            {
                //if (j == 1 || j == 2)
                //{
                Process[] AllProcesses = Process.GetProcessesByName("excel");
                //}
                if (j == 1)
                {
                    Array.Resize(ref s_process, AllProcesses.Length);
                    for (int i = 0; i < AllProcesses.Length; i++)
                    {
                        s_process[i] = AllProcesses[i];
                    }
                }
                else if (j == 2)
                {
                    Array.Resize(ref e_process, AllProcesses.Length);
                    for (int i = 0; i < AllProcesses.Length; i++)
                    {
                        e_process[i] = AllProcesses[i];
                    }
                }

                AllProcesses = null;
            }
            catch (Exception)
            { }
        }
        public static void KillProcess()
        {
            try
            {

                int l = 0;
                int m = 0;

                Array.Resize(ref dup_process, 0);
                if (s_process.Length > 0)
                {
                    int i = 0;
                    //for (int i = 0; i < e_process.Length; i++)
                    foreach (Process EndProcess in e_process)
                    {
                        m = 0;
                        //for (int k = 0; k < s_process.Length; k++)
                        foreach (Process StartProcess in s_process)
                        {
                            if (StartProcess.Id == EndProcess.Id)
                            {
                                m = 0;
                                break;
                            }
                            else
                            {
                                m++;
                            }
                        }
                        if (m > 0)
                        {
                            Array.Resize(ref dup_process, dup_process.Length + 1);
                            dup_process[l] = e_process[i];
                            l++;

                        }
                        i++;
                    }
                }
                else
                {
                    for (int i = 0; i < e_process.Length; i++)
                    {
                        Array.Resize(ref dup_process, dup_process.Length + 1);
                        dup_process[l] = e_process[i];
                        l++;
                    }
                }
                myHashtable = new Hashtable();
                int iCount = 0;

                foreach (Process ExcelProcess in dup_process)
                {
                    myHashtable.Add(ExcelProcess.Id, iCount);
                    iCount = iCount + 1;
                }
                foreach (Process ExcelProcess in dup_process)
                {
                    try
                    {
                        if (myHashtable.ContainsKey(ExcelProcess.Id) == true)
                            ExcelProcess.Kill();
                    }
                    catch (Exception)
                    { }
                }
                dup_process = null;
                s_process = null;
                e_process = null;
            }
            catch (Exception)
            { }
        }
        public static void open_excel()
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;
            for (int i = 0; i < _path.Length; i++)
            {
                excelApp.Workbooks.Open(_path[i]);
            }

        }
        public static void NumberToWord(int num)
        {
            try
            {
                if (num > 0)
                {
                    if ((num / 10000000) >= 1)
                    {
                        amt_word[0] = ((int)(num / 10000000)).ToString();
                        num = num - (((int)(num / 10000000)) * 10000000);
                    }
                    if ((num / 100000) >= 1)
                    {
                        amt_word[1] = ((int)(num / 100000)).ToString();
                        num = num - (((int)(num / 100000)) * 100000);
                    }
                    if ((num / 1000) >= 1)
                    {
                        amt_word[2] = ((int)(num / 1000)).ToString();
                        num = num - (((int)(num / 1000)) * 1000);
                    }
                    if ((num / 100) >= 1)
                    {
                        amt_word[3] = ((int)(num / 100)).ToString();
                        num = num - (((int)(num / 100)) * 100);
                    }
                    if ((num / 10) >= 1)
                    {
                        amt_word[4] = ((int)(num / 10)).ToString();
                        num = num - (((int)(num / 10)) * 10);
                    }
                    if ((num / 1) >= 1)
                    {
                        amt_word[5] = ((int)(num / 1)).ToString();
                        num = num - (((int)(num / 1)) * 1);
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (amt_word[i] == null)
                        amt_word[i] = "0";
                }
            }
            catch (Exception)
            { }
        }
    }

}
