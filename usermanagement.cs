using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace shree_agro
{
    class usermanagement
    {

        public static string sql_insertuser(userinfo userdetail)
        {
            string status;
            try
            {
                status = sp_sqlconnection.dml_sp_id("userdetail", "qtype=insert|user_name=" + userdetail.user_name + "|user_password=" + userdetail.user_password + "|user_type=" + userdetail.user_type + "|user_sec_question=" + userdetail.user_sec_question + "|user_sec_answer=" + userdetail.user_sec_answer + "|user_status=" + userdetail.user_status + "|country_id=" + userdetail.company_id + "");//insert user detail

            }
            catch (Exception)
            {
                status = "";
            }
            return status;
        }

        public static int sql_updateuser(userinfo userdetail)
        {
            int status;
            try
            {
                sp_sqlconnection.dml_sp("userdetail", "qtype=update|user_name=" + userdetail.user_name + "|user_password=" + userdetail.user_password + "|user_type=" + userdetail.user_type + "|user_sec_question=" + userdetail.user_sec_question + "|user_sec_answer=" + userdetail.user_sec_answer + "|user_status=" + userdetail.user_status + "|country_id=" + userdetail.company_id + "|user_id=" + userdetail.user_id + "");//Update user detail
                status = 1;
            }
            catch (Exception)
            {
                status = 0;
            }
            return status;
        }

        public static int sql_insertuserwithpermission(userinfo userdetail)
        {
            int status;
            try
            {
                sp_sqlconnection.dml_sp("userdetail", "qtype=insert|user_name=" + userdetail.user_name + "|user_password=" + userdetail.user_password + "|user_type=" + userdetail.user_type + "|user_sec_question=" + userdetail.user_sec_question + "|user_sec_answer=" + userdetail.user_sec_answer + "|user_status=" + userdetail.user_status + "|ins=" + userdetail.ins + "|del=" + userdetail.del + "|edt==" + userdetail.edt + "|company_id=" + userdetail.company_id + "");//insert user detail
                status = 1;
            }
            catch (Exception)
            {
                status = 0;
            }
            return status;
        }

        public static int sql_updateuserwithpermission(userinfo userdetail)
        {
            int status;
            try
            {
                sp_sqlconnection.dml_sp("userdetail", "qtype=update|user_name=" + userdetail.user_name + "|user_password=" + userdetail.user_password + "|user_type=" + userdetail.user_type + "|user_sec_question=" + userdetail.user_sec_question + "|user_sec_answer=" + userdetail.user_sec_answer + "|user_status=" + userdetail.user_status + "|ins=" + userdetail.ins + "|del=" + userdetail.del + "|edt==" + userdetail.edt + "|company_id=" + userdetail.company_id + "|user_id=" + userdetail.user_id + "");//Update user detail
                status = 1;
            }
            catch (Exception)
            {
                status = 0;
            }
            return status;
        }

        public static int sql_deleteuser(userinfo userdetail)
        {
            int status;
            try
            {
                sp_sqlconnection.dml_sp("userdetail", "qtype=delete|user_id=" + userdetail.user_id + "");//Delete user detail
                status = 1;
            }
            catch (Exception)
            {
                status = 0;
            }
            return status;
        }

        public static string sql_changepassword(string username, string current_password, string new_password)
        {
            string status;
            try
            {
                DataTable check_pwd = sqlconnection.fetchdatatable("select user_password from user_tbl where user_name='" + username + "'");
                if (check_pwd.Rows.Count != 0)
                {
                    string pwd = check_pwd.Rows[0]["user_Password"].ToString();
                    if (current_password == pwd)
                    {
                        sqlconnection.insertdata("update user_tbl set user_password='" + new_password + "' where user_name='" + username + "'");
                        status = "Password Change Successfully!";
                    }
                    else
                    {
                        status = "Current Password Doesnot Match!";
                    }

                }
                else
                {
                    status = "User Doesnot Found!";
                }

            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            return status;
        }

        public static string sql_forgotpassword(string username, string sec_question, string answer)
        {
            string status;
            try
            {
                DataTable check_answer = sqlconnection.fetchdatatable("select user_password from user_tbl where user_name='" + username + "' and user_sec_question='" + sec_question + "' and user_sec_answer='" + answer + "'");
                if (check_answer.Rows.Count != 0)
                {
                    status = check_answer.Rows[0][0].ToString();
                }
                else
                {
                    status = "Incorrect Data Inserted!";
                }

            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            return status;
        }

        public static DataTable alluser_detail()
        {
            DataTable dt_userdetail = new DataTable();
            dt_userdetail = sqlconnection.fetchdatatable("select * from user_tbl");
            return dt_userdetail;
        }

        public static DataTable userdetail_id(int userid)
        {
            DataTable userdetailbyid = new DataTable();
            userdetailbyid = sqlconnection.fetchdatatable("select * from user_tbl where user_id=" + userid + "");
            return userdetailbyid;
        }

        public static DataTable userdetail_name(string username)
        {
            DataTable userdetailbyname = new DataTable();
            userdetailbyname = sqlconnection.fetchdatatable("select * from user_tbl where user_name=" + username + "");
            return userdetailbyname;
        }



        //for login check
        public static int login(String uname, String pass, string c_id)
        {
            int rt;
            DataTable dt_login = new DataTable();
            dt_login = sp_sqlconnection.get_sp("userdetail", "qtype=logincheck|u_name=" + uname + "|u_password=" + pass + "");
            if (dt_login.Rows.Count != 0)
            {
                rt = 1;
                //if (uname.ToUpper() == "ADMIN")
                if (Convert.ToInt32(dt_login.Rows[0]["status"].ToString()) == 2)
                {
                    UserDetail.c_id = Convert.ToInt32(c_id);
                }
                else
                {
                    UserDetail.c_id = Convert.ToInt32(dt_login.Rows[0]["c_id"].ToString());
                }
                UserDetail.mail_from = "";// "vijayshah2080@gmail.com";
                UserDetail.mail_pass = "";// "vbvj20071402";
                //UserDetail.mail_from = "vishalgajera99@gmail.com";
                //UserDetail.mail_pass = "v1i2s3#4@5l";
                UserDetail.con_id = UserDetail.c_id.ToString();
                UserDetail.user_id = Convert.ToInt32(dt_login.Rows[0]["u_id"].ToString());
                UserDetail.status = Convert.ToInt32(dt_login.Rows[0]["status"].ToString());
                UserDetail.name = uname.Trim().ToUpper();
                UserDetail.type = "";// dt_login.Rows[0]["u_type"].ToString();
                jump:
                DataTable dt_comp = sp_sqlconnection.get_sp("company_detail", "qtype=selectcompany|c_id=" + UserDetail.c_id + "");
                //sqlconnection.fetchdatatable("select * from company_tbl where c_id=" + UserDetail.c_id + "");
                if (dt_comp.Columns.Count == 0)
                {
                    goto jump;
                }
                if (dt_comp.Rows.Count > 0)
                {
                    //UserDetail.con_id = UserDetail.c_id.ToString();
                    UserDetail.curr = "INR"; //dt_curr.Rows[0]["currency"].ToString();
                    UserDetail.curr_rate = 1.00M;// Convert.ToDecimal(dt_curr.Rows[0]["rate"].ToString());
                    UserDetail.cname = dt_comp.Rows[0]["c_name"].ToString();
                    UserDetail.country = dt_comp.Rows[0]["country"].ToString();
                    UserDetail.email = dt_comp.Rows[0]["email"].ToString();
                    UserDetail.w_id = 1;
                }
                jump1:
                DataTable dt_year = sp_sqlconnection.get_sp("year_detail","qtype=selectyear|c_id="+UserDetail.c_id+"|status=1");
                if (dt_year.Columns.Count == 0)
                {
                    goto jump1;
                }
                if (dt_year.Rows.Count > 0)
                {
                    UserDetail.y_id = Convert.ToInt32(dt_year.Rows[0]["y_id"].ToString());
                    UserDetail.year_name = dt_year.Rows[0]["y_name"].ToString();
                    UserDetail.f_date = Convert.ToDateTime(dt_year.Rows[0]["f_date"].ToString());
                    UserDetail.t_date = Convert.ToDateTime(dt_year.Rows[0]["t_date"].ToString());
                   
                    //    UserDetail.curr_rate = Convert.ToDecimal(dt_curr.Rows[0]["rate"].ToString());
                    //    UserDetail.cname = dt_curr.Rows[0]["cname"].ToString();
                    //    UserDetail.country = dt_curr.Rows[0]["country"].ToString();
                }
            }
            else
            {
                rt = 0;
            }
            return rt;
        }

        //for avoid duplication of user
        public static bool userckeck(string username)
        {
            DataTable dt_user = new DataTable();
            dt_user = sp_sqlconnection.get_sp("userdetail", "qtype=checkuser|user_name=" + username + "");
            if (dt_user.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string empcode(string id, string designation)
        {
            string e_code = "";
            string id_code = designation.Substring(0, 3);
            try
            {
                if (id == "")
                {
                    e_code = id_code + "1";
                }
                else
                {
                    int length = id.Length;
                    length = length - 3;
                    string id2 = id.Substring(3, length);
                    e_code = id_code + (int.Parse(id2) + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                int linenumber = sqlconnection.LineNumber(ex);
                //sqlconnection.error(ex.Message, "usermanagement.cs", System.Reflection.MethodInfo.GetCurrentMethod().ToString(), linenumber);
            }
            return e_code;
        }

        //public static string user_permission(string u_name)
        //{
        //    string per = "";
        //    try
        //    {
        //        DataTable dt_login = new DataTable();
        //        dt_login = sp_sqlconnection.get_sp("userdetail", "qtype=userpermission|user_name=" + u_name + "");
        //        if (dt_login.Rows.Count != 0)
        //        {
        //            per = dt_login.Rows[0]["ins"].ToString() + "," + dt_login.Rows[0]["del"].ToString() + "," + dt_login.Rows[0]["edt"].ToString();
        //        }
        //        else
        //        {
        //            per = "0,0,0";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        int linenumber = sqlconnection.LineNumber(ex);
        //        sqlconnection.error(ex.Message, "usermanagement.cs", System.Reflection.MethodInfo.GetCurrentMethod().ToString(), linenumber);    
        //    }
        //    return per;
        //}
        public static string next_id(string id)
        {
            string next_number = "";
            try
            {
                if (id != "")
                {

                    string last = id.Substring(2, id.Length - 2);
                    next_number = id.Substring(0, 2) + (int.Parse(last) + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                int linenumber = sqlconnection.LineNumber(ex);
                //sqlconnection.error(ex.Message, "usermanagement.cs", System.Reflection.MethodInfo.GetCurrentMethod().ToString(), linenumber);
            }
            return next_number;
        }

        public static Boolean check_attendance(string finger_id)
        {
            bool ret_val = false;
            try
            {
                string date = Convert.ToDateTime(DateTime.Now).ToString("MM-dd-yyyy");
                DataTable dt_checkentry = new DataTable();
                dt_checkentry = sqlconnection.fetchdatatable("select * from log_tbl where date='" + date + "' and fingure_id='" + finger_id + "'");
                if (dt_checkentry.Rows.Count % 2 != 0)
                {
                    ret_val = true;
                }
                else
                {
                    ret_val = false;
                }
            }
            catch (Exception ex)
            {
            }
            return ret_val;
        }
    }

    //public class userinfo
    //{
    //    public int user_id { get; set; }
    //    public string user_name { get; set; }
    //    public string user_password { get; set; }
    //    public string user_type { get; set; }
    //    public string user_sec_question { get; set; }
    //    public string user_sec_answer { get; set; }
    //    public int user_status { get; set; }
    //    public int ins { get; set; }
    //    public int del { get; set; }
    //    public int edt { get; set; }
    //    public string company_id { get; set; }

    //}
}
