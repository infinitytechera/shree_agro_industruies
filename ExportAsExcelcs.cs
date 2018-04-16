using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace shree_agro
{
    class ExportAsExcelcs
    {
        public static void Export(DataGridView dgv, string form_name)
        {
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    CheckExcellProcesses();
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    app.Visible = true;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    if (form_name.Length > 31)
                    {
                        form_name = "Sheet1";
                    }
                    if (form_name.Contains('/'))
                    {
                        form_name = form_name.Replace('/', '_');
                    }
                    worksheet.Name = form_name;
                    Cursor.Current = Cursors.WaitCursor;
                    int k = 1;
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (dgv.Columns[i].Visible == true)
                        {
                            worksheet.Cells[1, k] = dgv.Columns[i].HeaderText;
                            worksheet.Cells[1, k].Entirerow.Font.Bold = true;
                            worksheet.Cells[1, k].Entirerow.Font.Size = 12;
                            worksheet.Cells[1, k].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
                            worksheet.Cells[1, k].Interior.Color = XlRgbColor.rgbPink;
                            k++;
                        }
                    }
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        k = 1;
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            if (dgv.Columns[j].Visible == true)
                            {
                                if (dgv.Rows[i].Cells[j].Value != null)
                                {
                                    if (dgv.Rows[i].Cells[j].Style.BackColor.IsEmpty == false)
                                    {
                                        worksheet.Cells[i + 2, k].Interior.Color = dgv.Rows[i].Cells[j].Style.BackColor;
                                    }
                                    worksheet.Cells[i + 2, k] = dgv.Rows[i].Cells[j].Value.ToString();
                                }
                                k++;
                            }
                        }
                    }
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[1, j + 1].EntireColumn.AutoFit();
                    }
                    Cursor.Current = Cursors.Default;

                    Marshal.ReleaseComObject(worksheet);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(app);
                    MessageBox.Show("Export Compeleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //KillExcel();
                }
                else
                {
                    MessageBox.Show("There Is No Data To Export", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void Export_devgrid(GridView dgv, string form_name)
        {
            try
            {
                //if (dgv.RowCount > 0)
                //{
                //    CheckExcellProcesses();
                //    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                //    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                //    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                //    app.Visible = true;
                //    worksheet = workbook.Sheets["Sheet1"];
                //    worksheet = workbook.ActiveSheet;
                //    if (form_name.Length > 31)
                //    {
                //        form_name = "Sheet1";
                //    }
                //    if (form_name.Contains('/'))
                //    {
                //        form_name = form_name.Replace('/', '_');
                //    }
                //    worksheet.Name = form_name;
                //    Cursor.Current = Cursors.WaitCursor;
                //    int k = 1;
                //    for (int i = 0; i < dgv.Columns.Count; i++)
                //    {
                //        if (dgv.Columns[i].Visible == true)
                //        {
                //            worksheet.Cells[1, k] = dgv.Columns[i].HeaderText;
                //            worksheet.Cells[1, k].Entirerow.Font.Bold = true;
                //            worksheet.Cells[1, k].Entirerow.Font.Size = 12;
                //            worksheet.Cells[1, k].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
                //            worksheet.Cells[1, k].Interior.Color = XlRgbColor.rgbPink;
                //            k++;
                //        }
                //    }
                //    for (int i = 0; i < dgv.Rows.Count; i++)
                //    {
                //        k = 1;
                //        for (int j = 0; j < dgv.Columns.Count; j++)
                //        {
                //            if (dgv.Columns[j].Visible == true)
                //            {
                //                if (dgv.Rows[i].Cells[j].Value != null)
                //                {
                //                    if (dgv.Rows[i].Cells[j].Style.BackColor.IsEmpty == false)
                //                    {
                //                        worksheet.Cells[i + 2, k].Interior.Color = dgv.Rows[i].Cells[j].Style.BackColor;
                //                    }
                //                    worksheet.Cells[i + 2, k] = dgv.Rows[i].Cells[j].Value.ToString();
                //                }
                //                k++;
                //            }
                //        }
                //    }
                //    for (int j = 0; j < dgv.Columns.Count; j++)
                //    {
                //        worksheet.Cells[1, j + 1].EntireColumn.AutoFit();
                //    }
                //    Cursor.Current = Cursors.Default;

                //    Marshal.ReleaseComObject(worksheet);
                //    Marshal.ReleaseComObject(workbook);
                //    Marshal.ReleaseComObject(app);
                //    MessageBox.Show("Export Compeleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //KillExcel();
                //}
                //else
                //{
                //    MessageBox.Show("There Is No Data To Export", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void export_datatable(System.Data.DataTable dt_out, string form)
        {
            try
            {
                if (dt_out.Rows.Count != 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    app.Visible = true;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;

                    if (form.Length > 31)
                        form = "Sheet1";
                    worksheet.Name = form;
                    for (int j = 1; j < dt_out.Columns.Count + 1; j++)
                    {
                        worksheet.Cells[1, j] = dt_out.Columns[j - 1].ColumnName;
                        worksheet.Cells[1, j].Entirerow.Font.Bold = true;
                        worksheet.Cells[1, j].Entirerow.Font.Size = 12;
                        worksheet.Cells[1, j].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
                        //worksheet.Cells[1, j].Interior.Color = XlRgbColor.rgbBlue;
                    }
                    for (int j = 0; j < dt_out.Rows.Count; j++)
                    {
                        for (int k = 0; k < dt_out.Columns.Count; k++)
                        {
                            worksheet.Cells[j + 2, k + 1] = dt_out.Rows[j][k].ToString();
                        }
                    }
                    for (int j = 0; j < dt_out.Columns.Count; j++)
                    {
                        worksheet.Cells[1, j + 1].EntireColumn.AutoFit();
                    }

                    Cursor.Current = Cursors.Default;

                    Marshal.ReleaseComObject(worksheet);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(app);
                }
            }
            catch (Exception)
            {
            }
        }
        public static void export_ledger_datatable(System.Data.DataTable dt_out, string form)
        {
            try
            {
                if (dt_out.Rows.Count != 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    app.Visible = true;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;

                    if (form.Length > 31)
                        form = "Sheet1";
                    worksheet.Name = form;
              
                    for (int j = 0; j < dt_out.Rows.Count; j++)
                    {
                        for (int k = 0; k < dt_out.Columns.Count; k++)
                        {
                            worksheet.Cells[j + 2, k + 1] = dt_out.Rows[j][k].ToString();
                        }
                    }
                    for (int j = 0; j < dt_out.Columns.Count; j++)
                    {
                        worksheet.Cells[1, j + 1].EntireColumn.AutoFit();
                    }
                    for (int i = 1; i < dt_out.Rows.Count+1; i++)
                    {
                        if (dt_out.Rows[i-1]["Date"].ToString().ToUpper() == "" || dt_out.Rows[i-1]["Date"].ToString().ToUpper() == "DATE")
                        {
                            for (int j = 1; j < dt_out.Columns.Count + 1; j++)
                            {
                                //worksheet.Cells[i, j] = dt_out.Columns[j - 1].ColumnName;
                                worksheet.Cells[i+1, j].Entirerow.Font.Bold = true;
                                //worksheet.Cells[i, j].Entirerow.Font.Size = 12;
                               // worksheet.Cells[i, j].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
                                //worksheet.Cells[1, j].Interior.Color = XlRgbColor.rgbBlue;
                            }
                        }
                    }
                    string[] fr_to = new string[2];
                    fr_to[0] = "A1";
                    fr_to[1] = "L" + (dt_out.Rows.Count + 2);
              

                    Microsoft.Office.Interop.Excel.Range mergenum1 = worksheet.get_Range(fr_to[0], fr_to[1]);
                    worksheet.Cells.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Cells.Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    mergenum1.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = true;
                    mergenum1.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = true;
                    mergenum1.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
                    mergenum1.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = true;
                    mergenum1.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
                    mergenum1.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = true;
                    Cursor.Current = Cursors.Default;

                    Marshal.ReleaseComObject(worksheet);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(app);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void MixExport(DataGridView dgv, string form_name)
        {
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    CheckExcellProcesses();
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    app.Visible = true;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    if (form_name.Length > 31)
                    {
                        form_name = "Sheet1";
                    }
                    if (form_name.Contains('/'))
                    {
                        form_name = form_name.Replace('/', '_');
                    }
                    worksheet.Name = form_name;
                    Cursor.Current = Cursors.WaitCursor;
                    int k = 1;
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (dgv.Columns[i].Visible == true)
                        {
                            worksheet.Cells[1, k] = dgv.Columns[i].HeaderText;
                            worksheet.Cells[1, k].Entirerow.Font.Bold = true;
                            worksheet.Cells[1, k].Entirerow.Font.Size = 12;
                            worksheet.Cells[1, k].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
                            worksheet.Cells[1, k].Interior.Color = XlRgbColor.rgbPink;
                            k++;
                        }
                    }
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        k = 1;
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            if (dgv.Columns[j].Visible == true)
                            {
                                if (dgv.Rows[i].Cells[j].Value != null)
                                {
                                    if (dgv.Rows[i].Cells[j].Style.BackColor.IsEmpty == false)
                                    {
                                        worksheet.Cells[i + 2, k].Interior.Color = dgv.Rows[i].Cells[j].Style.BackColor;
                                    }
                                    worksheet.Cells[i + 2, k] = "'" + dgv.Rows[i].Cells[j].Value.ToString();
                                }
                                k++;
                            }
                        }
                    }
                    Cursor.Current = Cursors.Default;

                    Marshal.ReleaseComObject(worksheet);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(app);
                    MessageBox.Show("Export Compeleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //KillExcel();
                }
                else
                {
                    MessageBox.Show("There Is No Data To Export", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Mixexport_datatable(System.Data.DataTable dt_out, string form)
        {
            try
            {
                if (dt_out.Rows.Count != 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    app.Visible = true;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;

                    if (form.Length > 31)
                        form = "Sheet1";
                    worksheet.Name = form;
                    for (int j = 1; j < dt_out.Columns.Count + 1; j++)
                    {
                        worksheet.Cells[1, j] = dt_out.Columns[j - 1].ColumnName;
                        worksheet.Cells[1, j].Entirerow.Font.Bold = true;
                        worksheet.Cells[1, j].Entirerow.Font.Size = 12;
                        worksheet.Cells[1, j].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
                        worksheet.Cells[1, j].Interior.Color = XlRgbColor.rgbPink;
                    }
                    for (int j = 0; j < dt_out.Rows.Count; j++)
                    {
                        for (int k = 0; k < dt_out.Columns.Count; k++)
                        {
                            worksheet.Cells[j + 2, k + 1] = "'" + dt_out.Rows[j][k].ToString();
                        }
                    }
                    Cursor.Current = Cursors.Default;

                    Marshal.ReleaseComObject(worksheet);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(app);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void demofile(string[] a, string name)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                if (name.Length > 31)
                    name = "Sheet1";
                worksheet.Name = name;

                for (int i = 0; i < a.Length; i++)
                {
                    worksheet.Cells[1, i + 1] = a[i];
                }
            }
            catch (Exception)
            { }
        }

        public static Hashtable myHashtable;
        public static void CheckExcellProcesses()
        {
            Process[] AllProcesses = Process.GetProcessesByName("excel");
            myHashtable = new Hashtable();
            int iCount = 0;

            foreach (Process ExcelProcess in AllProcesses)
            {
                myHashtable.Add(ExcelProcess.Id, iCount);
                iCount = iCount + 1;
            }

        }
        public static void KillExcel()
        {
            Process[] AllProcesses = Process.GetProcessesByName("excel");

            // check to kill the right process
            foreach (Process ExcelProcess in AllProcesses)
            {
                if (myHashtable.ContainsKey(ExcelProcess.Id) == false)
                    ExcelProcess.Kill();
            }

            AllProcesses = null;
        }

    }
}
