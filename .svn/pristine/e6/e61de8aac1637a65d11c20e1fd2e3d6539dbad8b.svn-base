using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using RSSMWeb.Code;
using System.Data.SqlClient;

namespace RSSMWeb.systemmanage
{
    public partial class Role_Management_new : PageBase
    {
        protected string oid;
        protected string dpt_id;
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
                oid = Request.QueryString.GetValues(0)[0];

                string sql = "select * from sys_role_info ";
                sql += " where role_id = " + oid + "";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                while (reader.Read())
                {
                    txt_logname.Text = reader["role_name"].ToString();
                  
                }
            }
            catch (Exception e)
            {
                Alert.ShowInTop(e.Message);
            }
        }

        protected void btnSaveContinue_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑


            // 2. 关闭本窗体，然后回发父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑

            string sql = "";
            string vals = Request.Url.Query;

            if (vals == "")
            {
                sql = "INSERT INTO sys_role_info ";
                sql += "(role_name) ";
                sql += "VALUES   ('" + txt_logname.Text + "') ";

                //Alert.ShowInTop(sql);

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error！");
                    return;
                }

                sql = "select IDENT_CURRENT('sys_role_info') ";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                string newId = "0";
                while (reader.Read())
                {
                    newId = reader.GetValue(0).ToString();
                }

                sql = "  insert into sys_func_authority (og_id,og_type)values ('";
                sql += newId;
                sql += "',3004)";

                //Alert.ShowInTop(sql);

                rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst < 0)
                {
                    Alert.ShowInTop("save error！");
                }
            }
            else
            {
                oid = Request.QueryString.GetValues(0)[0];
                sql = "update sys_role_info set role_name='" + txt_logname.Text + "'";
                sql += " where role_id = " + oid;

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error !");
                }
            }
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

    }
}