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
    public partial class dpt_new : PageBase
    {
        protected string oid;
        protected string dpt_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                GetOrg();
            }
        }
        protected void GetOrg()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetOIList();

            dr_dpt.DataTextField = "Name";
            dr_dpt.DataValueField = "ID";

            dr_dpt.DataSource = mylist;
            
            dr_dpt.DataBind();
            
            dr_dpt.SelectedValue = dpt_id;


            dr_dpt.Items.Remove(dr_dpt.Items.FindByValue(oid));
            
            
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

                string sql = "select * from sys_organize_info ";
                sql += " where org_id = " + oid + "";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                while(reader.Read())
                {
                    TextBox5.Text = reader["org_name"].ToString();
                    TextBox1.Text = reader["org_normal_name"].ToString();
                    TextBox2.Text = reader["org_manager_name"].ToString();
                    TextBox3.Text = reader["father_org_id"].ToString();
                    //dr_dpt.Text = reader["org_name"].ToString();
                    dpt_id = reader["father_org_id"].ToString();
                    if (reader["is_top"].ToString() == "True")
                    {
                        CheckBox1.Checked = true;
                    }                    
                }
            }
            catch(Exception e)
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
            string top_flag = "0";
            if (CheckBox1.Checked)
            {
                top_flag = "1";
            }
            string sql = "";
            string vals = Request.Url.Query;
           
            if (vals == "")
            {
                sql = "INSERT INTO sys_organize_info ";
                sql += "(org_name, org_normal_name, org_manager_name, org_assist_name, is_top, father_org_id) ";
                sql += "VALUES   ('" + TextBox5.Text + "', '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "'," + top_flag + ", " + dr_dpt.SelectedItem.Value + ") ";

                //Alert.ShowInTop(sql);
                
                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error！");
                    return;
                }

                sql = "select IDENT_CURRENT('sys_organize_info') ";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                string newId = "0";
                while (reader.Read())
                {
                    newId = reader.GetValue(0).ToString();
                }

                sql = "  insert into sys_func_authority (og_id,og_type)values ('";
                sql += newId;
                sql += "',3002)";

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
                sql = "update sys_organize_info set org_name='" + TextBox5.Text + "',org_normal_name='" + TextBox1.Text + "',org_manager_name='" + TextBox2.Text;
                sql += "',org_assist_name='" + TextBox3.Text + "',is_top=" + top_flag + ",father_org_id= " + dr_dpt.SelectedItem.Value;
                sql += " where org_id = " + oid;

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