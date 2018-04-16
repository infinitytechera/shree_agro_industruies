using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace shree_agro
{
    class UserDetail
    {
        public static int check_load { get; set; }
        public static int user_id { get; set; }
        public static string name { get; set; }
        public static string type { get; set; }
        public static int c_id { get; set; }
        public static int w_id { get; set; }
        //public static int ins { get; set; }
        //public static int upd { get; set; }
        //public static int del { get; set; }
        public static string con_id { get; set; }
        //public static string company_id { get; set; }
        public static int y_id { get; set; }
        public static string year_name { get; set; }
        //public static int repair_status { get; set; }
        public static int status { get; set; }
        public static string curr { get; set; }
        public static string cname { get; set; }
        public static decimal curr_rate { get; set; }
        //public static decimal rate_calc { get; set; }
        //public static decimal rate_disc { get; set; }
        public static string country { get; set; }
        //public static string color_group { get; set; }
        //public static string color { get; set; }
        //public static string shade { get; set; }
        //public static string overtone { get; set; }
        //public static string clarity { get; set; }
        //public static string shape { get; set; }
        //public static string size { get; set; }
        //public static string lab { get; set; }
        //public static string fluo { get; set; }
        public static string mail_from { get; set; }
        public static string mail_pass { get; set; }
        //public static string lut_no { get; set; }
        public static string email { get; set; }
        public static DateTime f_date { get; set; }
        public static DateTime t_date { get; set; }

        public static DataTable dt_comapany = new DataTable();
        public static DataTable dt_year = new DataTable();
        public static DataTable dt_item = new DataTable();
        public static DataTable dt_party = new DataTable();
        public static DataTable dt_broker = new DataTable();
        public static DataTable dt_warehouse = new DataTable();




        //public static string[] l_color_grade = new string[10000];
        //public static string[] l_clarity_grade = new string[10000];
        //public static string[] l_tins_grade = new string[10000];
        //public static string[] quick_result = new string[10000];
        //public static string[] priority = new string[10000];
        //public static string[] responsibility = new string[10000];
        //public static string[] g_status = new string[10000];
        //public static string[] exporter_refno = new string[10000];
        //public static string[] pre_carriage_by = new string[10000];
        //public static string[] consignee = new string[10000];
        //public static string[] por_by_pre_carrier = new string[10000];
        //public static string[] vessel_flight = new string[10000];

    }
}
