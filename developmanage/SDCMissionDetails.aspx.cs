using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RSSMWeb.Code;
using ExtAspNet;
using System.Data;
using System.Data.SqlClient;

namespace RSSMWeb.developmanage
{
    public partial class SDCMissionDetails : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string vals = Request.Url.Query;
            if (vals == "")
            {
                return;
            }

            if (!IsPostBack)
            {
                string pjm_id = Request.QueryString.GetValues(0)[0];
                string checkType = Request.QueryString.GetValues(1)[0];
                Button3.OnClientClick = Window1.GetShowReference("~/developmanage/SDCMissionDetails_P.aspx?id=0&pjmId=" + pjm_id + "&checkType=0", "新增");
                BindAreaDP();

                if (checkType == "0")
                {
                    btnSaveRefresh.Visible = false;
                    Panel3.Visible = false;
                }
                else if (checkType == "1")
                {
                    btnSaveRefresh2.Visible = false;
                    LoadData(pjm_id);
                    BindGrid(pjm_id);
                }
                else if (checkType == "2")
                {
                    btnSaveRefresh2.Visible = false;
                    LoadData(pjm_id);
                    BindGrid(pjm_id);
                }
            }
        }

        private void BindGrid(string pjm_id)
        {
            DataTable table = GetDataTable(pjm_id);

            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        protected DataTable GetDataTable(string pjm_id)
        {
            DataTable table = new DataTable();
            string sql = "";
            sql = "SELECT t1.*,t2.user_name_full AS charger_name ";
           
            sql += "  FROM dev_sdd_mission_detail t1 LEFT JOIN sys_user t2 ON t1.user_id = t2.user_id ";
            sql += "  WHERE sdd_pjm_id = " + pjm_id + " order by t1.sdd_detail_id ;";
            
            table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            // Alert.ShowInTop(sql);
            return table;
        }
        private void BindAreaDP()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetUserList();
            RSSMWeb.Code.Utils.CustomClass tmp = new RSSMWeb.Code.Utils.CustomClass("0", "无", "0");
            List<RSSMWeb.Code.Utils.CustomClassForDropdownlist> mylist_username_dpt = Utils.GetUserListForDropdownlist_dpt();
            mylist.Insert(0, tmp);

            DropDownList7.EnableSimulateTree = true;
            DropDownList7.DataTextField = "Name";
            DropDownList7.DataValueField = "ID";
            DropDownList7.DataSource = mylist;
            DropDownList7.DataSimulateTreeLevelField = "Group";
            DropDownList7.DataEnableSelectField = "Enableselect";
            DropDownList7.DataSource = mylist_username_dpt;
            DropDownList7.DataBind();
            DropDownList7.SelectedValue = "0";

            DropDownList6.EnableSimulateTree = true;
            DropDownList6.DataTextField = "Name";
            DropDownList6.DataValueField = "ID";
            DropDownList6.DataSimulateTreeLevelField = "Group";
            DropDownList6.DataEnableSelectField = "Enableselect";

            DropDownList6.DataSource = mylist_username_dpt;
            DropDownList6.DataBind();
            DropDownList6.SelectedValue = "0";


        }

        private void LoadData(string pjm_id)
        {
            try
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                string sql = "";
                sql = "SELECT t1.sdd_pjm_id,t1.pjm_title,t1.respect_date,t1.finish_date,t1.finish_flag,t1.PAP,t1.begin_date, ";
                sql += " t2.user_name_full AS charger_name, t3.user_name_full AS tester_name,t1.charger_id,t1.tester_id ,t1.pjm_content  ";
                sql += "  FROM dev_sdd_mission t1 LEFT JOIN sys_user t2 ON t1.charger_id = t2.user_id ";
                sql += "  LEFT JOIN sys_user t3 ON t1.tester_id = t3.user_id ";
                sql += " where t1.sdd_pjm_id = " + pjm_id;
                sql += " order by sdd_pjm_id desc ;";


                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                while (reader.Read())
                {
                    TextBox5.Text = reader["pjm_title"].ToString();
                    DropDownList7.SelectedValue = reader["charger_id"].ToString();
                    DropDownList6.SelectedValue = reader["tester_id"].ToString();
                    if (reader["finish_flag"].ToString() == "1")
                    {
                        CheckBox1.Checked = true;
                    }
                    string begin_date = reader["begin_date"].ToString();
                    if (begin_date != "")
                    {
                        DatePicker2.SelectedDate = Convert.ToDateTime(begin_date);
                    }
                    string respect_date = reader["respect_date"].ToString();
                    if (respect_date != "")
                    {
                        DatePicker4.SelectedDate = Convert.ToDateTime(respect_date);
                    }
                    string finish_date = reader["finish_date"].ToString();
                    if (finish_date != "")
                    {
                        DatePicker3.SelectedDate = Convert.ToDateTime(finish_date);
                    }
                    string PAP = reader["PAP"].ToString();
                    if (PAP != "" && PAP != "0")
                    {
                        NumBox2.Text = PAP;
                        NumBox2.Enabled = false;
                    }
                    content.Text = reader["pjm_content"].ToString();
                }
            }
            catch (System.Exception ex)
            {
                Alert.ShowInTop("异常:" + ex.Message);
            }
            // 关闭按钮的客户端脚本：
            // 1. 首先确认窗体中表单是否被修改（如果已经被修改，则弹出是否关闭的确认对话框）
            // 2. 然后关闭本窗体，回发父窗体

        }

        protected string GetEditUrl(object id, object pjm_id,object checkType)
        {
            if (Convert.ToInt32(checkType) == 1)
            {
                return Window1.GetShowReference("~/developmanage/SDCMissionDetails_P.aspx?id=" + id + "&pjmId=" + pjm_id + "&checkType=1", "查看 ");
            }
            return Window1.GetShowReference("~/developmanage/SDCMissionDetails_P.aspx?id=" + id + "&pjmId=" + pjm_id + "&checkType=2", "编辑 ");
        }

        protected void Grid1_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        //修改
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 这里放置保存窗体中数据的逻辑
                
                string sql = "";
                string pjm_id = Request.QueryString.GetValues(0)[0];
                sql +="  UPDATE dev_sdd_mission SET pjm_title = '"+TextBox5.Text+"', ";
                sql +="  pjm_content = '"+content.Text+"',";
                sql +="  charger_id = "+DropDownList7.SelectedItem.Value+",";
                sql +="  tester_id = "+DropDownList6.SelectedItem.Value+",";

                if (DatePicker4.Text != "")
                {
                    sql += "respect_date = '"+DatePicker4.Text+"',";
                }
                if (DatePicker2.Text != "")
                {
                    sql += "begin_date = '"+DatePicker2.Text+"',";
                }
                if (DatePicker3.Text != "")
                {
                    sql += "finish_date = '"+DatePicker3.Text+"',";
                }
                if (NumBox2.Text !="")
                {
                    sql += "PAP = " + NumBox2.Text + ",";
                }
                
                string finishFlag = "0";
                if (CheckBox1.Checked)
                {
                    finishFlag = "1";
                }
                sql += "finish_flag = "+finishFlag+" ";

                sql += " WHERE sdd_pjm_id = " + pjm_id + ";";
                //Alert.ShowInTop(sql);
                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error !");
                }
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            catch (System.Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }
        }

        //新增
        protected void btnSaveRefresh_Click2(object sender, EventArgs e)
        {
            try
            {
                // 1. 这里放置保存窗体中数据的逻辑

                string sql = "";
                string pjm_id = Request.QueryString.GetValues(0)[0];
                sql += " INSERT INTO dev_sdd_mission ";
                sql +=" (pjm_title,pjm_content,charger_id,tester_id,respect_date,";
                if (DatePicker3.Text != "")
                {
                    sql += "finish_date,";
                }

                sql += " finish_flag,";
                if (NumBox2.Text != "")
                {
                    sql += "PAP,";
                }
                sql += "begin_date,create_time) ";
                sql += " VALUES ('" + TextBox5.Text + "','" + content.Text + "'," + DropDownList7.SelectedItem.Value;
                sql += "," + DropDownList6.SelectedItem.Value + ",";
                sql += "'" + DatePicker4.Text+"',";
                if (DatePicker3.Text != "")
                {
                    sql += "'"+DatePicker3.Text+"',";
                }

                string finishFlag = "0";
                if (CheckBox1.Checked)
                {
                    finishFlag = "1";
                }

                sql += finishFlag + ","; 
                if (NumBox2.Text != "")
                {
                    sql += NumBox2.Text+",";
                }
                sql += "'" + DatePicker2.Text + "',getdate()); ";


                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error !");
                }

                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            catch (System.Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }
        }
    }
}