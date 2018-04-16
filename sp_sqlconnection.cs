using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace shree_agro
{
    internal class sp_sqlconnection
    {
        public static string con_str = System.IO.File.ReadAllText(Application.StartupPath + "\\constring.txt");
        //public static string con_str = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=SmartDiam_Test;Persist Security Info=True;User ID=sa;Password=admin@123";
        //public static string con_str = ConfigurationManager.ConnectionStrings["connectionstring1"].ConnectionString;
        public static string id;

        public static string status;

        //==============  For Simple Store Procedure ===============//
        public static string dml_sp(string sp_name, string all_parameters)
        {
            try
            {
                status = "";
                SqlConnection cn = new SqlConnection(con_str);
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                   // MessageBox.Show("Could Not Connect To Server. Please Try Again !");
                    return "";
                }
                SqlCommand cmd = new SqlCommand(sp_name, cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // for removing "|" data string
                string[] parameters = all_parameters.Split('|');

                // for removing "=" data string
                for (int i = 0; i < parameters.Length; i++)
                {
                    // for removing "=" data string
                    string[] this_param = parameters[i].Split('=');

                    //now addding @status ans select
                    cmd.Parameters.Add(new SqlParameter("@" + this_param[0], this_param[1]));
                }

                status = Convert.ToString(cmd.ExecuteNonQuery());
                cn.Close();
            }
            catch (Exception)
            {
                //  MessageBox.Show(e.Message);
            }
            return status;
        }

        //============== Get connection ================//
        public static System.Data.SqlClient.SqlConnection getconnection()
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(con_str);
            con.Open();
            return con;
        }

        //================= For Get Datatable ====================//
        public static DataTable get_sp(string sp_name, string all_parameters)
        {
            DataTable tmp = new DataTable();
            try
            {
                SqlConnection cn = new SqlConnection(con_str);
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                   // MessageBox.Show("Could Not Connect To Server. Please Try Again !");
                    return tmp;
                }
                SqlCommand cmd = new SqlCommand(sp_name, cn);
                cmd.CommandTimeout = 1000000;
                // for removing "|" data string
                string[] parameters = all_parameters.Split('|');

                // for removing "=" data string
                for (int i = 0; i < parameters.Length; i++)
                {
                    // for removing "=" data string
                    string[] this_param = parameters[i].Split('=');

                    //now addding @status ans select
                    cmd.Parameters.Add(new SqlParameter("@" + this_param[0], this_param[1]));
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(tmp);
                cn.Close();
            }
            catch (Exception)
            {
            }

            return (tmp);
        }

        //======================= For Get Max ID =======================//
        public static string dml_sp_id(string sp_name, string all_parameters)
        {
            try
            {
                SqlConnection cn = new SqlConnection(con_str);
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                   // MessageBox.Show("Could Not Connect To Server. Please Try Again !");
                    return "";
                }
                id = "";
                SqlCommand cmd = new SqlCommand(sp_name, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                string[] parameters = all_parameters.Split('|');
                for (int i = 0; i < parameters.Length; i++)
                {
                    string[] this_param = parameters[i].Split('=');
                    cmd.Parameters.Add(new SqlParameter("@" + this_param[0], this_param[1]));
                }
                id = Convert.ToString(cmd.ExecuteScalar());
                cn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return id;
        }
    }
}