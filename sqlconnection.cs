using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace shree_agro
{
    internal class sqlconnection
    {
        public static string con_str = System.IO.File.ReadAllText(Application.StartupPath + "\\constring.txt");
        //public static string con_str = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=SmartDiam_Test;Persist Security Info=True;User ID=sa;Password=admin@123";
        // public static String con_str = ConfigurationManager.ConnectionStrings["connectionstring1"].ConnectionString;

        //================= Get Line Number In Error =================//
        public static int LineNumber(Exception ex)
        {
            int linenum = 0;
            try
            {
                linenum = Convert.ToInt32(ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(":line") + 5));
            }
            catch
            {
                //Stack trace is not available!
            }
            return linenum;
        }

        //================ Get A Datatable ==============//
        public static DataTable fetchdatatable(String query)
        {
            DataTable dt1 = new DataTable();
            try
            {
                SqlConnection cn = new SqlConnection(con_str);
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                    //MessageBox.Show("Could Not Connect To Server. Please Try Again !");
                    return dt1;
                }
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 1000000000;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                da.Fill(dt1);
                cn.Close();
            }

            catch
            {
            }
            return (dt1);
            
        }

        //======== For Simple Procedure ====//
        public static string insertdata(String query)
        {
            string id = "";
            try
            {
                SqlConnection cn = new SqlConnection(con_str);
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                    //MessageBox.Show("Could Not Connect To Server. Please Try Again !");
                    return id;
                }
                SqlCommand cmd = new SqlCommand(query, cn);
                id = Convert.ToString(cmd.ExecuteNonQuery());
                cn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return id;
        }

        //============== Get Employee Code ===============//
        public static string get_managername(string emp_code)
        {
            string name = "";
            try
            {
                DataTable dt_empnname = sp_sqlconnection.get_sp("cis_employeedetail", "qtype=selectbyempcode|emp_code=" + emp_code + "");
                if (dt_empnname.Rows.Count != 0)
                {
                    name = dt_empnname.Rows[0]["emp_name"].ToString();
                }
            }
            catch (Exception)
            {
            }
            return name;
        }

        //=====================insert Data And Id Return =============//
        public static string insertdata_id(String query)
        {
            string id = "";
            try
            {
                SqlConnection cn = new SqlConnection(con_str);
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Could Not Connect To Server. Please Try Again !");
                    return id;
                }
                SqlCommand cmd = new SqlCommand(query, cn);
                id = Convert.ToString(cmd.ExecuteScalar());
                cn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return id;
        }

        //========== For Get Maximum ID ===================//
        public static int getlastid(string tbl, string id)
        {
            try
            {
            }
            catch (Exception)
            {
                throw;
            }
            DataTable dt_id = new DataTable();
            new System.Data.SqlClient.SqlDataAdapter("select * from " + tbl + " ORDER BY " + id + "", con_str).Fill(dt_id);

            if (dt_id.Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                int id1 = int.Parse(dt_id.Rows[dt_id.Rows.Count - 1][0].ToString());
                id1 += 1;
                return id1;
            }
        }

        //================ Get Unique Key =================//
        public static string GetUniqueKey(int maxSize)//for genarate autonumber
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        //==============Insert Error in Table ========================//
        public static void error(string error_name, string form_name, string module_name, int linenumber)
        {
            sqlconnection.insertdata("insert into cis_error_tbl(error_name,form_name,date,time,module_name,linenumber) values('" + error_name + "','" + form_name + "','" + DateTime.Today.ToString("MM-dd-yyyy") + "','" + string.Format("{0:hh:mm:ss tt}", DateTime.Now) + "','" + module_name + "','" + linenumber + "')");
        }
    }
}