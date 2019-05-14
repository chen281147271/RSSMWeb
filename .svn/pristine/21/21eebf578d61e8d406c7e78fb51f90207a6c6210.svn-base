using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using RSSMWeb.Code;
using System.Text;
using System.Data.SqlClient;
namespace RSSMWeb.projectsmanage
{
    public partial class product_info_new : PageBase
    {
        protected string pd_id;
        protected string chargeruser_id;
        protected string pdstate_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                GetUserName();
                GetPDState();
            }
        }
        protected void GetUserName()
        {
            List<RSSMWeb.Code.Utils.CustomClassForDropdownlist> mylist = Utils.GetUserListForDropdownlist();

            dr_chargeruserid.DataTextField = "Name";
            dr_chargeruserid.DataValueField = "ID";
            dr_chargeruserid.DataSimulateTreeLevelField = "Group";
            dr_chargeruserid.DataEnableSelectField = "Enableselect";

            dr_chargeruserid.DataSource = mylist;
            dr_chargeruserid.DataBind();
            dr_chargeruserid.SelectedValue = chargeruser_id;
        }
        protected void GetPDState()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetCodeSourcebygroup(2);

            dr_pdstate.DataTextField = "Name";
            dr_pdstate.DataValueField = "ID";

            dr_pdstate.DataSource = mylist;
            dr_pdstate.DataBind();
            dr_pdstate.SelectedValue = pdstate_id;
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
                pd_id = Request.QueryString.GetValues(0)[0];

                string sql = "select * from pjm_product_info ";
                sql += " where pd_id = " + pd_id + "";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                while (reader.Read())
                {
                    txt_pdname.Text = reader["pd_name"].ToString();
                    txt_pddescription.Text = reader["pd_description"].ToString();
                    dr_chargeruserid.Text = reader["charger_user_id"].ToString();
                    dr_pdstate.Text = reader["pd_state"].ToString();

                    chargeruser_id = dr_chargeruserid.Text;
                    pdstate_id = dr_pdstate.Text;


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


                sql = "INSERT INTO pjm_product_info ";
                sql += "( pd_name, pd_description, charger_user_id,pd_state) ";
                sql += "VALUES   ('" + txt_pdname.Text + "', '" + txt_pddescription.Text + "', '" + dr_chargeruserid.SelectedItem.Value + "', '" + dr_pdstate.SelectedItem.Value + "') ";

                //Alert.ShowInTop(sql);

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error！");
                }
            }
            else
            {
                pd_id = Request.QueryString.GetValues(0)[0];

                sql = "update pjm_product_info set pd_name='" + txt_pdname.Text + "',pd_description='" + txt_pddescription.Text + "',charger_user_id='" + dr_chargeruserid.SelectedItem.Value + "',pd_state='" + dr_pdstate.SelectedItem.Value + "'";
                sql += " where pd_id = " + pd_id;


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