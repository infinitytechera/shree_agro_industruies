using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shree_agro
{
    class gen_inv_voucher
    {

        public static int gen_invoice_no_pur_sale(string type)
        {
            int i_no = 0;
            if (UserDetail.c_id != 0)
            {
                jump:
                DataTable dt_invoice = sp_sqlconnection.get_sp("pur_sale_detail", "qtype=geninv|y_id=" + UserDetail.y_id + "|c_id=" + UserDetail.c_id + "|inv_type=" + type + "");//
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

        public static int gen_voucher_payment()
        {
            int i_no = 0;
            if (UserDetail.c_id != 0)
            {
                jump:
                DataTable dt_invoice = sp_sqlconnection.get_sp("payment_detail", "qtype=gentranno|y_id=" + UserDetail.y_id + "|c_id=" + UserDetail.c_id + "");//
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
    }
}
