using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace shree_agro
{
    class Read_xlsx
    {private static Workbook newWorkbook = null;
        private static _Worksheet objsheet = null;
        private static Microsoft.Office.Interop.Excel.Range rng = null;

        public static System.Data.DataTable GetDataFromExcel(string path)
        {
            try
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";

                System.Data.DataTable dt_sheet = new System.Data.DataTable();
                dt_sheet = GetSheetsNameFromExcel(path);
                string query = "SELECT * from [" + dt_sheet.Rows[0][1].ToString() + "]";
                System.Data.DataTable dt = new System.Data.DataTable();

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds);
                        dt = ds.Tables[0];
                    }
                    conn.Close();
                }
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static System.Data.DataTable GetSheetsNameFromExcel(string path)
        {
            try
            {
                System.Data.DataTable dt_sheet = new System.Data.DataTable();
                //DataSet ds = new DataSet();
                //OleDbCommand excelCommand = new OleDbCommand(); OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();
                //string excelConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                //OleDbConnection excelConn = new OleDbConnection(excelConnStr);
                //excelConn.Open();
                //System.Data.DataTable dtPatterns = new System.Data.DataTable();
                //dt_sheet = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);



                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Open(path, ReadOnly: true);
                // Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Open(path);
                //var workbook = app.Workbooks.Open(filename, ReadOnly: true);
                String[] excelSheets = new String[excelBook.Worksheets.Count];
                int i = 0;
                foreach (Microsoft.Office.Interop.Excel.Worksheet wSheet in excelBook.Worksheets)
                {
                    excelSheets[i] = wSheet.Name;
                    i++;
                }
                System.Data.DataTable dt_sheet_order = new System.Data.DataTable();
                dt_sheet_order.Columns.Add("id");
                dt_sheet_order.Columns.Add("TABLE_NAME");
                for (int k = 0; k < excelSheets.Length; k++)
                {
                    DataRow dr = dt_sheet_order.NewRow();
                    dr["id"] = (k + 1).ToString();
                    dr["TABLE_NAME"] = excelSheets[k] + "$";
                    dt_sheet_order.Rows.Add(dr);
                }
                return dt_sheet_order;

                Marshal.ReleaseComObject(excelSheets);
                Marshal.ReleaseComObject(excelBook);
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static System.Data.DataTable GetDataFromExcell(string path,string name)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            string query = "SELECT * from ["+name+"]";
            System.Data.DataTable dt = new System.Data.DataTable();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                conn.Close();
            }
            return dt;
        }
        public static string get_last_file(string path)
        {
            int cnt = 0;
            string[] files = System.IO.Directory.GetFiles(path);
            string[,] file_detail = new string[10000, 2];

            string lastFileName = string.Empty;
            foreach (string filename in files)
            {
                DateTime lastModified = System.IO.File.GetLastWriteTime(filename);
                cnt++;
                for (int i = 0; i < 1000; i++)
                {
                    if (file_detail[i, 0] == null)
                    {
                        file_detail[i, 0] = lastModified.ToString();
                        file_detail[i, 1] = filename;
                        break;
                    }
                }
            }
            string file_name = "";
            DateTime file_date;
            if (cnt > 0)
            {
                file_date = Convert.ToDateTime(file_detail[0, 0]);
                file_name = file_detail[0, 1];
                for (int i = 0; i < cnt-1; i++)
                {
                    if (file_date < Convert.ToDateTime(file_detail[i + 1, 0]))
                    {
                        file_date = Convert.ToDateTime(file_detail[i + 1, 0]);
                        file_name = file_detail[i + 1, 1];
                    }
                }
                if (cnt==1)
                {
                    file_name = file_detail[0, 1];
                }
            }
            return file_name;
        }

        public static string validate_range(string param1, string param2)
        {
            string a = "";
            try
            {
                a = (param1 + ':' + param2).Replace(" ", string.Empty);
                int index = a.IndexOf(':');
                char[] final = a.ToCharArray();

                int first_1 = a.Split(':')[0].IndexOfAny("0123456789".ToCharArray());
                int first_2 = a.Split(':')[1].IndexOfAny("0123456789".ToCharArray());

                first_2 = first_2 + a.Split(':')[0].Length + 1;

                if (final[first_1].ToString() == "0")
                {
                    a = "";
                }
                else if (final[first_2].ToString() == "0")
                {
                    a = "";
                }
                else if (!(char.IsLetter(final[0]) && char.IsLetter(final[index + 1]) && char.IsDigit(final[index - 1]) && char.IsDigit(final[final.Length - 1])))
                {
                    a = "";
                }
            }
            catch (Exception)
            {
            }
            return a;
        }
        public static System.Data.DataTable GetDataFromExcel_range(string path, string range)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";

            System.Data.DataTable dt_sheet = new System.Data.DataTable();
            dt_sheet = GetSheetsNameFromExcel(path);
            string query = "SELECT * from [" + dt_sheet.Rows[0][1].ToString() + "" + range + "]";

            System.Data.DataTable dt = new System.Data.DataTable();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                conn.Close();
            }
            return dt;
        }
    }
}
