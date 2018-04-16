using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace shree_agro
{
    class stock
    {
        static DataTable dt_stock = new DataTable();
        static string refno = "";
        static decimal weight = 0.00M;
        static string measurement = "";



        public static string get_measurement(string item)
        {
            DataRow[] dr_check_measure = UserDetail.dt_item.Select("i_name='" + item + "'");
            if (dr_check_measure.Count() != 0)
            {
                measurement = dr_check_measure[0][3].ToString();
            }
            else { measurement = ""; }

            return measurement;
        }
        public static decimal get_bag_weight(string item)
        {
            DataRow[] dr_check_weight = UserDetail.dt_item.Select("i_name='" + item + "'");
            if (dr_check_weight.Count() != 0)
            {
                weight = Convert.ToDecimal(dr_check_weight[0][4].ToString());
            }
            else { weight = 0.00M; }

            return weight;
        }





        //public static DataTable get_stock_rate(string refno)
        //{
        //    dt_stock = sp_sqlconnection.get_sp("get_stock_detail", "qtype=stock|refno=" + refno + "|c_id=" + UserDetail.con_id + "");
        //    if (dt_stock.Rows.Count > 0)
        //    {
        //        if (Convert.ToDecimal(dt_stock.Rows[0]["carat"].ToString()) > 0.00M)
        //            dt_stock.Rows[0]["rate"] = Convert.ToDecimal(dt_stock.Rows[0]["amount"].ToString()) / Convert.ToDecimal(dt_stock.Rows[0]["carat"].ToString());
        //        else
        //            dt_stock.Rows[0]["rate"] = "0.00";
        //    }
        //    return dt_stock;
        //}



        //public static decimal get_stock_refno(string refno, string type)
        //{
        //    decimal stock_carat = 0.00M;
        //    dt_stock.Rows.Clear();

        //    dt_stock = sp_sqlconnection.get_sp("get_stock_detail", "qtype=stock|refno=" + refno + "|c_id=" + UserDetail.con_id + "|y_id=" + UserDetail.y_id + "");

        //    if (dt_stock.Rows.Count > 0)
        //    {
        //        if (dt_stock.Rows[0]["CARAT"].ToString() != "")
        //        {
        //            stock_carat = Convert.ToDecimal(dt_stock.Rows[0]["CARAT"].ToString());
        //        }
        //    }
        //    return stock_carat;
        //}
        //public static decimal get_stock_rate_refno(string refno, string type)
        //{
        //    decimal stock_rate = 0.00M;
        //    dt_stock.Rows.Clear();
        //    dt_stock = sp_sqlconnection.get_sp("get_stock_detail", "qtype=stock|refno=" + refno + "|c_id=" + UserDetail.con_id + "");
        //    if (dt_stock.Rows.Count > 0)
        //    {
        //        if (dt_stock.Rows[0]["CARAT"].ToString() != "" && dt_stock.Rows[0]["amount"].ToString() != "")
        //        {
        //            stock_rate = Convert.ToDecimal(dt_stock.Rows[0]["amount"].ToString()) / Convert.ToDecimal(dt_stock.Rows[0]["CARAT"].ToString());
        //        }
        //    }
        //    return stock_rate;
        //}
        //public static int get_stock_pcs_refno(string refno, string type)
        //{
        //    int stock_pcs = 0;
        //    dt_stock.Rows.Clear();

        //    dt_stock = sp_sqlconnection.get_sp("get_stock_detail", "qtype=stock_pcs|refno=" + refno + "|c_id=" + UserDetail.con_id + "");

        //    if (dt_stock.Rows.Count > 0)
        //    {
        //        if (dt_stock.Rows[0]["pcs"] != null && dt_stock.Rows[0]["pcs"].ToString() != "")
        //        {
        //            stock_pcs = Convert.ToInt32(dt_stock.Rows[0]["pcs"].ToString());
        //        }
        //    }
        //    return stock_pcs;
        //}

        //public static string get_refno(string lot)
        //{
        //    DataRow[] dr_check_ref = UserDetail.dt_item.Select("LotNoNew='" + lot + "'");
        //    if (dr_check_ref.Count() != 0)
        //    {
        //        refno = dr_check_ref[0][0].ToString();
        //    }
        //    else { refno = ""; }

        //    return refno;
        //}
        //public static string get_kapan(string refno)
        //{
        //    DataRow[] dr_check_kapan = UserDetail.dt_item.Select("refno='" + refno + "'");
        //    if (dr_check_kapan.Count() != 0)
        //    {
        //        kapan = dr_check_kapan[0][5].ToString();
        //    }
        //    else { kapan = ""; }

        //    return kapan;
        //}

        //public static string get_lotno(string ref_no)
        //{
        //    DataRow[] dr_check_lot = UserDetail.dt_item.Select("refno='" + ref_no + "'");
        //    if (dr_check_lot.Count() != 0)
        //    {
        //        lotno = dr_check_lot[0][1].ToString();
        //    }
        //    else { lotno = ""; }
        //    return lotno;
        //}


    }
}