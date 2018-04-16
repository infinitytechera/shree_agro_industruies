using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace shree_agro
{
    class bind_master
    {
        public static void bind_mst()
        {
            bind_warehouse_mst();
            bind_item();
            bind_party();
            bind_general();
        }


        public static void bind_warehouse_mst()
        {
            jump:
            UserDetail.dt_warehouse = sp_sqlconnection.get_sp("warehouse_detail", "qtype=select|c_id=" + UserDetail.c_id + "");
            if (UserDetail.dt_warehouse.Columns.Count == 0)
            {
                goto jump;
            }
        }
        public static void bind_item()
        {
            jump:
            UserDetail.dt_item = sp_sqlconnection.get_sp("item_detail", "qtype=select|c_id=" + UserDetail.c_id + "");//sqlconnection.fetchdatatable("select * from item_tbl where c_id=" + UserDetail.c_id + "");
            if (UserDetail.dt_item.Columns.Count == 0)
            {
                goto jump;
            }
        }
        public static void bind_party()
        {
            jump:
            UserDetail.dt_party = sp_sqlconnection.get_sp("party_detail", "qtype=select|c_id=" + UserDetail.c_id + "");//sqlconnection.fetchdatatable("select * from party_mst_tbl where c_id=" + UserDetail.c_id + " order by name");
            if (UserDetail.dt_party.Columns.Count == 0)
            {
                goto jump;
            }
            jump1:
            UserDetail.dt_broker = sp_sqlconnection.get_sp("party_detail", "qtype=selectcategory|c_id=" + UserDetail.c_id + "|category=BROKER");//sqlconnection.fetchdatatable("select * from party_mst_tbl where c_id=" + UserDetail.c_id + " order by name");
            if (UserDetail.dt_broker.Columns.Count == 0)
            {
                goto jump1;
            }
        }
        public static void bind_general()
        {
            #region General Master Bind
            //jump:
            //UserDetail.dt_general = sqlconnection.fetchdatatable("select * from general_tbl");
            //if (UserDetail.dt_general.Columns.Count == 0)
            //{
            //    goto jump;
            //}
            //else
            //{
            //    if (UserDetail.dt_general.Rows.Count > 0)
            //    {
            //        //Array.Resize(ref UserDetail.l_color_grade, 0);
            //        //Array.Resize(ref UserDetail.l_clarity_grade, 0);
            //        //Array.Resize(ref UserDetail.l_tins_grade, 0);
            //        //Array.Resize(ref UserDetail.quick_result, 0);
            //        //Array.Resize(ref UserDetail.priority, 0);
            //        //Array.Resize(ref UserDetail.responsibility, 0);
            //        //Array.Resize(ref UserDetail.g_status, 0);
            //        Array.Resize(ref UserDetail.exporter_refno, 0);
            //        Array.Resize(ref UserDetail.pre_carriage_by, 0);
            //        Array.Resize(ref UserDetail.consignee, 0);
            //        Array.Resize(ref UserDetail.por_by_pre_carrier, 0);
            //        Array.Resize(ref UserDetail.vessel_flight, 0);

            //        //Array.Resize(ref UserDetail.l_color_grade, UserDetail.dt_general.Rows.Count);
            //        //Array.Resize(ref UserDetail.l_clarity_grade, UserDetail.dt_general.Rows.Count);
            //        //Array.Resize(ref UserDetail.l_tins_grade, UserDetail.dt_general.Rows.Count);
            //        //Array.Resize(ref UserDetail.quick_result, UserDetail.dt_general.Rows.Count);
            //        //Array.Resize(ref UserDetail.priority, UserDetail.dt_general.Rows.Count);
            //        //Array.Resize(ref UserDetail.responsibility, UserDetail.dt_general.Rows.Count);
            //        //Array.Resize(ref UserDetail.g_status, UserDetail.dt_general.Rows.Count);
            //        Array.Resize(ref UserDetail.exporter_refno, UserDetail.dt_general.Rows.Count);
            //        Array.Resize(ref UserDetail.pre_carriage_by, UserDetail.dt_general.Rows.Count);
            //        Array.Resize(ref UserDetail.consignee, UserDetail.dt_general.Rows.Count);
            //        Array.Resize(ref UserDetail.por_by_pre_carrier, UserDetail.dt_general.Rows.Count);
            //        Array.Resize(ref UserDetail.vessel_flight, UserDetail.dt_general.Rows.Count);

            //        for (int i = 0; i < UserDetail.dt_general.Rows.Count; i++)
            //        {
            //            //Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "l_color_grade");
            //            //Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "l_clarity_grade");
            //            //Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "l_tins_grade");
            //            //Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "quick_result");
            //            //Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "priority");
            //            //Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "responsibility");
            //            //Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "g_status");
            //            Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "exporter_refno");
            //            Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "pre_carriage_by");
            //            Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "consignee");
            //            Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "por_by_pre_carrier");
            //            Set_Comboas_Null.Set_NUll_If_Null_DtCell(UserDetail.dt_general, i, "vessel_flight");

            //            //if (UserDetail.dt_general.Rows[i]["l_color_grade"] != null && UserDetail.dt_general.Rows[i]["l_color_grade"].ToString() != "")
            //            //    UserDetail.l_color_grade[i] = UserDetail.dt_general.Rows[i]["l_color_grade"].ToString();
            //            //if (UserDetail.dt_general.Rows[i]["l_clarity_grade"] != null && UserDetail.dt_general.Rows[i]["l_clarity_grade"].ToString() != "")
            //            //    UserDetail.l_clarity_grade[i] = UserDetail.dt_general.Rows[i]["l_clarity_grade"].ToString();
            //            //if (UserDetail.dt_general.Rows[i]["l_tins_grade"] != null && UserDetail.dt_general.Rows[i]["l_tins_grade"].ToString() != "")
            //            //    UserDetail.l_tins_grade[i] = UserDetail.dt_general.Rows[i]["l_tins_grade"].ToString();
            //            //if (UserDetail.dt_general.Rows[i]["quick_result"] != null && UserDetail.dt_general.Rows[i]["quick_result"].ToString() != "")
            //            //    UserDetail.quick_result[i] = UserDetail.dt_general.Rows[i]["quick_result"].ToString();
            //            //if (UserDetail.dt_general.Rows[i]["priority"] != null && UserDetail.dt_general.Rows[i]["priority"].ToString() != "")
            //            //    UserDetail.priority[i] = UserDetail.dt_general.Rows[i]["priority"].ToString();
            //            //if (UserDetail.dt_general.Rows[i]["responsibility"] != null && UserDetail.dt_general.Rows[i]["responsibility"].ToString() != "")
            //            //    UserDetail.responsibility[i] = UserDetail.dt_general.Rows[i]["responsibility"].ToString();
            //            //if (UserDetail.dt_general.Rows[i]["g_status"] != null && UserDetail.dt_general.Rows[i]["g_status"].ToString() != "")
            //            //    UserDetail.g_status[i] = UserDetail.dt_general.Rows[i]["g_status"].ToString();
            //            if (UserDetail.dt_general.Rows[i]["exporter_refno"] != null && UserDetail.dt_general.Rows[i]["exporter_refno"].ToString() != "")
            //                UserDetail.exporter_refno[i] = UserDetail.dt_general.Rows[i]["exporter_refno"].ToString();
            //            if (UserDetail.dt_general.Rows[i]["pre_carriage_by"] != null && UserDetail.dt_general.Rows[i]["pre_carriage_by"].ToString() != "")
            //                UserDetail.pre_carriage_by[i] = UserDetail.dt_general.Rows[i]["pre_carriage_by"].ToString();
            //            if (UserDetail.dt_general.Rows[i]["consignee"] != null && UserDetail.dt_general.Rows[i]["consignee"].ToString() != "")
            //                UserDetail.consignee[i] = UserDetail.dt_general.Rows[i]["consignee"].ToString();
            //            if (UserDetail.dt_general.Rows[i]["por_by_pre_carrier"] != null && UserDetail.dt_general.Rows[i]["por_by_pre_carrier"].ToString() != "")
            //                UserDetail.por_by_pre_carrier[i] = UserDetail.dt_general.Rows[i]["por_by_pre_carrier"].ToString();
            //            if (UserDetail.dt_general.Rows[i]["vessel_flight"] != null && UserDetail.dt_general.Rows[i]["vessel_flight"].ToString() != "")
            //                UserDetail.vessel_flight[i] = UserDetail.dt_general.Rows[i]["vessel_flight"].ToString();
            //            if (i == 0)
            //            {
            //                if (Convert.ToDecimal(UserDetail.dt_general.Rows[0]["rate"].ToString()) >= 0.00M)
            //                {
            //                    UserDetail.rate_calc = Convert.ToDecimal(UserDetail.dt_general.Rows[0]["rate"].ToString());
            //                }
            //            }
            //        }
            //        //UserDetail.l_color_grade = UserDetail.l_color_grade.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //        //UserDetail.l_clarity_grade = UserDetail.l_clarity_grade.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //        //UserDetail.l_tins_grade = UserDetail.l_tins_grade.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //        //UserDetail.quick_result = UserDetail.quick_result.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //        //UserDetail.priority = UserDetail.priority.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //        //UserDetail.responsibility = UserDetail.responsibility.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //        //UserDetail.g_status = UserDetail.g_status.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //        UserDetail.exporter_refno = UserDetail.exporter_refno.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //        UserDetail.pre_carriage_by = UserDetail.pre_carriage_by.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //        UserDetail.consignee = UserDetail.consignee.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //        UserDetail.por_by_pre_carrier = UserDetail.por_by_pre_carrier.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //        UserDetail.vessel_flight = UserDetail.vessel_flight.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            //    }
            //} 
            #endregion
        }
    }
}
