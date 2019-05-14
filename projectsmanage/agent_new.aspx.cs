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
    public partial class agent_new : PageBase
    {
        protected string agent_id;
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
                agent_id = Request.QueryString.GetValues(0)[0];

                string sql = "select * from sys_agent ";
                sql += " where agent_id = " + agent_id + "";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                while (reader.Read())
                {
                    txt_agentname.Text = reader["agent_name"].ToString();
                    txt_contactname.Text = reader["contact_name"].ToString();
                    txt_contactphone.Text = reader["contact_phone"].ToString();
                    txt_contactdesc.Text = reader["contact_desc"].ToString();
                    txt_contactaddress.Text = reader["contact_address"].ToString();



                }
            }
            catch (Exception e)
            {
                Alert.ShowInTop(e.Message);
            }
        }



        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑

            string sql = "";
            string vals = Request.Url.Query;

            if (vals == "")
            {


                sql = "INSERT INTO sys_agent ";
                sql += "(agent_name, contact_name, contact_phone, contact_desc,contact_address) ";
                sql += "VALUES   ('" + txt_agentname.Text + "', '" + txt_contactname.Text + "', '" + txt_contactphone.Text + "', '" + txt_contactphone.Text+"','"+txt_contactaddress.Text + "') ";

                //Alert.ShowInTop(sql);

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error！");
                }
            }
            else
            {
                agent_id = Request.QueryString.GetValues(0)[0];

                sql = "update sys_agent set agent_name='" + txt_agentname.Text + "',contact_name='" + txt_contactname.Text + "',contact_phone='" + txt_contactphone.Text + "',contact_desc='" + txt_contactdesc.Text + "',contact_address='" + txt_contactaddress.Text + "'";
                sql += " where agent_id = " + agent_id;


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