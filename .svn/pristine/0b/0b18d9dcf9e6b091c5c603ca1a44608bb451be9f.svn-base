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
namespace RSSMWeb.systemmanage
{
    public partial class WebForm2 : PageBase
    {
        protected string user_id;
        protected string tpye;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                Getmanage_type();
                GetOrg();
                LoadData();
            }
        }

        protected void Getmanage_type()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetCodeSource(4);

            dr_managetype.DataTextField = "Name";
            dr_managetype.DataValueField = "ID";

            dr_managetype.DataSource = mylist;
            dr_managetype.DataBind();
            dr_managetype.SelectedValue = "4001"; 
        }
        protected void GetOrg()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetOIList();

            dr_dpt.DataTextField = "Name";
            dr_dpt.DataValueField = "ID";

            dr_dpt.DataSource = mylist;
            dr_dpt.DataBind();
            dr_dpt.SelectedValue = "15";
        }
        private void LoadData()
        {
            try
            {
                // 关闭按钮的客户端脚本：
                // 1. 首先确认窗体中表单是否被修改（如果已经被修改，则弹出是否关闭的确认对话框）
                // 2. 然后关闭本窗体，回发父窗体
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                string vals = Request.Url.Query.ToString();
                if (vals == "")
                {
                    return;
                }
                user_id = Request.QueryString["id"].ToString();
                tpye = Page.Session["type"].ToString();
                if (tpye == "0")
                {
                    dr_dpt.Enabled = false;
                    dr_managetype.Enabled = false;
                    dr_userstate.Enabled = false;
                    txt_logname.Enabled = false;

                }
                string sql = "select * from sys_user ";
                sql += " where user_id = " + user_id + "";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                while (reader.Read())
                {
                    txt_logname.Text = reader["user_name"].ToString();
                    txt_username.Text = reader["user_name_full"].ToString();
                    txt_password.Text = "";
                    dr_userstate.SelectedValue = reader["user_state"].ToString();
                    txt_email.Text = reader["email_address"].ToString();
                    txt_phone.Text = reader["phone_number"].ToString();
                    txt_cellphone.Text = reader["cellphone_numer"].ToString();
                    txt_homeadr.Text = reader["home_address"].ToString();
                    dr_managetype.SelectedValue = reader["manage_type"].ToString();
                    dr_dpt.SelectedValue = reader["org_id"].ToString();
                    txt_psw_validate.Text = reader["pwd_validate_time"].ToString();
                    
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
                if (txt_password.Text.Trim() == "")
                {
                    Alert.ShowInTop("密码不能为空");
                    return;
                }
                
                sql = "INSERT INTO sys_user ";
                sql += "(user_name, user_name_full, user_password, user_state, pwd_validate_time,email_address,phone_number,cellphone_numer,home_address,create_time,manage_type,org_id) ";
                sql += "VALUES   ('" + txt_logname.Text + "', '" + txt_username.Text + "', '" + Md5Helper.Encrypt(txt_password.Text.ToString()) + "', '" + dr_userstate.SelectedItem.Value + "','" + "-1" + "',' " + txt_email.Text + "','" + txt_phone.Text + "','" + txt_cellphone.Text + "','" + txt_homeadr.Text+"','" + System.DateTime.Today.ToString() + "','" + dr_managetype.SelectedItem.Value +"','" + dr_dpt.SelectedItem.Value + "') ";

                //Alert.ShowInTop(sql);

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst <0)
                {
                    Alert.ShowInTop("save error！");
                    return;
                }

                sql = "select IDENT_CURRENT('sys_user') ";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                string newId = "0";
                while (reader.Read())
                {
                    newId = reader.GetValue(0).ToString();
                }

                sql = "  insert into sys_func_authority (og_id,og_type)values ('";
                sql+=newId;
                sql+="',3001)";

                //Alert.ShowInTop(sql);

                 rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst < 0)
                {
                    Alert.ShowInTop("save error！");
                }


            }
            else
            {
                user_id = Request.QueryString.GetValues(0)[0];
                if (txt_password.Text != "")
                {
                    sql = "update sys_user set user_name='" + txt_logname.Text + "',user_name_full='" + txt_username.Text + "',user_password='" + Md5Helper.Encrypt(txt_password.Text.ToString());
                    sql += "',user_state='" + dr_userstate.SelectedItem.Value + "',pwd_validate_time=" + txt_psw_validate.Text + ",email_address= '" + txt_email.Text;
                    sql += "',phone_number='" + txt_phone.Text + "',cellphone_numer='" + txt_cellphone.Text + "',home_address='" + txt_homeadr.Text + "',manage_type= " + dr_managetype.SelectedItem.Value + ",org_id= " + dr_dpt.SelectedItem.Value;
                    sql += " where user_id = " + user_id;

                }
                else
                {
                    sql = "update sys_user set user_name='" + txt_logname.Text + "',user_name_full='" + txt_username.Text;
                    sql += "',user_state='" + dr_userstate.SelectedItem.Value + "',pwd_validate_time=" + txt_psw_validate.Text + ",email_address= '" + txt_email.Text;
                    sql += "',phone_number='" + txt_phone.Text + "',cellphone_numer='"+txt_cellphone.Text+"',home_address='" + txt_homeadr.Text + "',manage_type= " + dr_managetype.SelectedItem.Value + ",org_id= " + dr_dpt.SelectedItem.Value;
                    sql += " where user_id = " + user_id;
                }

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst < 0)
                {
                    Alert.ShowInTop("save error !");
                }
            }
            Page.Session["user_name_full"] = txt_username.Text;
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
           // PageContext.Redirect("~/Default.aspx");
        }

        protected void btnSaveContinue_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}