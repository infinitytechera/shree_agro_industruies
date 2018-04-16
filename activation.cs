using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Security.Cryptography;


namespace shree_agro
{
    class activation
    {
        public static string con_str = System.IO.File.ReadAllText(Application.StartupPath + "\\constring.txt");
        public static string debitday = "";
        public static string expiredate = "";
        public static PhysicalAddress GetMacAddress()//for get mac address
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces

                if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }
       
        public static String verify()//check cis details exist or not
        {
            string ret_tf = "";
            try
            {
                string mac_address = activation.GetMacAddress().ToString();
                DataTable dt_selectdetails = new DataTable();
                dt_selectdetails = sqlconnection.fetchdatatable("select top 1 * from cis_tbl where serial_key = '" + mac_address + "'  order by id DESC");
                if (dt_selectdetails.Rows.Count != 0)
                {
                    DateTime start_date = DateTime.Today.Date;
                    DateTime end_date = Convert.ToDateTime(dt_selectdetails.Rows[0]["ed"].ToString().Substring(0, 10));
                    string diff = (end_date - start_date).ToString();
                    int index = diff.IndexOf(".");
                    int diffrence;
                    if (index < 0)
                    {
                        diffrence = 0;
                    }
                    else
                    {
                        diffrence = int.Parse(diff.Substring(0, index));
                    }
                    if (dt_selectdetails.Rows[0]["enc_key"].ToString() == "")
                    {
                        if (diffrence > 0)
                        {
                            //MessageBox.Show("Demo Version Has Expired! To Buy Full Version Contact To Coruscate IT Solution", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ret_tf = diffrence.ToString();
                        }
                        else
                        {
                            ret_tf = "Demo Expired";
                        }
                    }
                    else if (dt_selectdetails.Rows[0]["enc_key"].ToString() != "")
                    {
                        if (diffrence > 0)
                        {
                            if (diffrence <= 30)
                            {
                                ret_tf = "Remain Month";
                            }
                            else
                            {
                                ret_tf = "Ok";
                               
                            }
                        }
                        else
                        {
                            ret_tf = "Validity Over";
                        }
                    }
                }
                else
                {
                     ret_tf = "Not Exist";
                }
            }
            catch (Exception ex)
            {
                ret_tf="Error";
                int linenumber = sqlconnection.LineNumber(ex);
                //sqlconnection.error(ex.Message, "activation.cs", System.Reflection.MethodInfo.GetCurrentMethod().ToString(), linenumber);
            }
            return ret_tf;
        }

        public static string verifyt = "";

        public static string verification(Form currentform)//for verify software validity
        {
            //try
            //{
            //     verifyt = verify();
            //    if (verifyt == "Error")
            //    {
            //        MessageBox.Show("Contact To Coruscate IT Solution", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        currentform.WindowState = FormWindowState.Minimized;
            //        currentform.ShowInTaskbar = false;
            //        Application.Exit();
            //    }
            //    else if (verifyt == "Not Exist")
            //    {
            //        if (GetMacAddress().ToString() != "")
            //        {
            //            string start_date = Convert.ToDateTime(DateTime.Today.Date).ToString("MM-dd-yyyy");
            //            string end_date = Convert.ToDateTime(DateTime.Today.Date.AddDays(15)).ToString("MM-dd-yyyy");
            //            string insert_id = sp_sqlconnection.dml_sp_id("actdetail", "qtype=insert|sd=" + start_date + "|ed=" + end_date + "|serial_key=" + GetMacAddress().ToString() + "");
            //            //if (insert_id != "")
            //            //{
            //            //    MessageBox.Show("You Have Activated Demo Version! It Will Expire After 15 Days ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            //    debitday = "15";
            //            //    return debitday;
            //            //}
            //            //else
            //            //{
            //            //    MessageBox.Show("Demo Version Activation Faild", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            //    currentform.WindowState = FormWindowState.Minimized;
            //            //    currentform.ShowInTaskbar = false;
            //            //    //activationf.Show();
            //            //    Application.Exit();
            //            //}
            //        }
            //    }
            //    else if (verifyt == "Validity Over")
            //    {
            //        MessageBox.Show("Validity Over! Contact To Admin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        currentform.WindowState = FormWindowState.Minimized;
            //        currentform.ShowInTaskbar = false;
            //        //frm_activation activationf = new frm_activation("exit");
            //        //activationf.ShowDialog();
            //       // return "";
            //        //Application.Exit();
            //    }
            //    //else if (verifyt == "Demo Expired")
            //    //{
            //    //    MessageBox.Show("Demo Version Has Expired! To Buy Full Version Contact To Coruscate IT Solution", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //    currentform.WindowState = FormWindowState.Minimized;
            //    //    currentform.ShowInTaskbar = false;     
            //    //    //frm_activation activationf = new frm_activation("exit");
            //    //    //activationf.ShowDialog();
            //    //    //Application.Exit();
            //    //}
            //    else if (verifyt == "Remain Month")
            //    {
            //        DataTable enddate = new DataTable();
            //        enddate = sqlconnection.fetchdatatable("select top 1 * from act_tbl where serial_key = '" + GetMacAddress().ToString() + "'  order by id DESC");
            //        expiredate = Convert.ToDateTime((enddate.Rows[0]["ed"].ToString().Substring(0, 10))).ToString("dd-MM-yyyy");
            //        verifyt = expiredate;
            //        return verifyt;
            //    }
            //    else if (verifyt == "Ok")
            //    {
            //        return verifyt;
            //    }
            //    else
            //    {
            //        debitday = verifyt;
            //        return debitday;
            //    }
            //}
            //catch (Exception ex)
            //{
               
            //}

            return "";
        }

        public static string remainingdays(Form currentformname)//for return message remaining days or expiredate 
        {
            string message = "";

            //verification(currentformname);

            //if (debitday != "")
            //{
            //    message = "" + debitday + " Days Remianing In Your Demo Version!";
            //   // disableactivation(mdi);
            //}
            //else if (expiredate != "")
            //{
            //    message = "Your Activation Will Be Expire on " + expiredate + "";
            //    // disableactivation(mdi);
            //}
            //else if(verifyt=="Ok")
            //{
            //    message = "OK";
            //}

            //else
            //{
            //    message = "";
            //}


            return message;
        }

        public static void enableactivation(Form mdi,string controlname,string stripitem)//for Enable Activation menustrip
        {
            //try
            //{
            //    Control[] controls = mdi.Controls.Find(controlname, true);
            //    foreach (Control ctrl in controls)
            //    {
            //        if (ctrl.Name == controlname)
            //        {
            //            MenuStrip strip = ctrl as MenuStrip;
            //            strip.Items[stripitem].Visible = true;
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }

    }
}
