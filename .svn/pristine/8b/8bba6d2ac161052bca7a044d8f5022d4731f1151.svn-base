using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ExtAspNet;
using RSSMWeb.Code;
using System.Text;
using System.Data.SqlClient;
namespace RSSMWeb.projectsmanage
{
    public partial class customer_new : PageBase
    {
        protected string cus_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            try
            {
                // 关闭按钮的客户端脚本：
                // 1. 首先确认窗体中表单是否被修改（如果已经被修改，则弹出是否关闭的确认对话框）
                // 2. 然后关闭本窗体，回发父窗体
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                string vals = Request.Url.Query;
                if (vals == "")
                {
                    return;
                }
                cus_id = Request.QueryString.GetValues(0)[0];

                string sql = "select * from sys_customer ";
                sql += " where cus_id = " + cus_id + "";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                while (reader.Read())
                {
                    txt_cusname.Text = reader["cus_name"].ToString();
                    txt_cuscontact.Text = reader["cus_contact"].ToString();
                    txt_cusaddress.Text = reader["cus_address"].ToString();
                    txt_contactphone.Text = reader["contact_phone"].ToString();


                }
            }
            catch (Exception e)
            {
                Alert.ShowInTop(e.Message);
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑

            string sql = "";
            string vals = Request.Url.Query;

            if (vals == "")
            {


                sql = "INSERT INTO sys_customer ";
                sql += "(cus_name, cus_contact, cus_address, contact_phone) ";
                sql += "VALUES   ('" + txt_cusname.Text + "', '" + txt_cuscontact.Text + "', '" +txt_cusaddress.Text + "', '" + txt_contactphone.Text+"') ";

                //Alert.ShowInTop(sql);

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error！");
                }
            }
            else
            {
                    cus_id = Request.QueryString.GetValues(0)[0];

                    sql = "update sys_customer set cus_name='" + txt_cusname.Text + "',cus_contact='" + txt_cuscontact.Text + "',cus_address='" + txt_cusaddress.Text + "',contact_phone='" + txt_contactphone.Text + "'";
                    sql += " where cus_id = " + cus_id;


                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error !");
                }
            }
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        protected void btnSaveContinue_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}