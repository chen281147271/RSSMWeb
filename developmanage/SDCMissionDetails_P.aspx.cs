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
    public partial class SDCMissionDetails_P : PageBase
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
                string pjm_id = Request.QueryString.GetValues(1)[0];
                string checkType = Request.QueryString.GetValues(2)[0];
                string detail_id = Request.QueryString.GetValues(0)[0]; ;
                BindAreaDP();
                Label1.Text = pjm_id;
                if (checkType == "0")
                {
                    btnSaveRefresh.Visible = false;
                    
                }
                else if (checkType == "1")
                {
                    btnSaveRefresh2.Visible = false;
                    LoadData(detail_id);
 
                }
                else if (checkType == "2")
                {
                    btnSaveRefresh2.Visible = false;
                    LoadData(detail_id);

                }
            }
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
        }

        private void LoadData(string detail_id)
        {
            try
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                string sql = "";
                sql = "SELECT t.*,t2.user_name_full  FROM dev_sdd_mission_detail t LEFT JOIN sys_user t2 ON t.user_id = t2.user_id ";
                sql += " where t.sdd_detail_id = " + detail_id;

                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                while (reader.Read())
                {
                    
                    DropDownList7.SelectedValue = reader["user_id"].ToString();
                    if (reader["finish_flag"].ToString().ToUpper() == "TRUE")
                    {
                        CheckBox1.Checked = true;
                        CheckBox1.Enabled = false;
                    }
                    string begin_date = reader["begin_date"].ToString();
                    if (begin_date != "")
                    {
                        DatePicker2.SelectedDate = Convert.ToDateTime(begin_date);
                    }
                    string respect_date = reader["expect_date"].ToString();
                    if (respect_date != "")
                    {
                        DatePicker4.SelectedDate = Convert.ToDateTime(respect_date);
                    }
                    string finish_date = reader["finish_date"].ToString();
                    if (finish_date != "")
                    {
                        DatePicker3.SelectedDate = Convert.ToDateTime(finish_date);
                        DatePicker3.Enabled = false;
                    }
                    string PAP = reader["PAP"].ToString();
                    if (PAP != "" && PAP != "0")
                    {
                        NumBox2.Text = PAP;
                        NumBox2.Enabled = false;
                    }
                    string rPAP = reader["rPAP"].ToString();
                    if (rPAP != "" && rPAP != "0")
                    {
                        NumberBox1.Text = rPAP;
                        NumberBox1.Enabled = false;
                    }
                    content.Text = reader["mission_content"].ToString();
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

        //修改
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 这里放置保存窗体中数据的逻辑
                string detail_id = Request.QueryString.GetValues(0)[0];
                string sql = "";

                sql += "  UPDATE dev_sdd_mission_detail SET user_id = " + DropDownList7.SelectedItem.Value + ", ";
                sql +="  mission_content = '"+content.Text+"',";
                if (DatePicker4.Text != "")
                {
                    sql += "expect_date = '"+DatePicker4.Text+"',";
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
                if (NumberBox1.Text != "")
                {
                    sql += "rPAP = " + NumberBox1.Text + ",";
                }
               
                string finishFlag = "0";
                if (CheckBox1.Checked)
                {
                    finishFlag = "1";
                }
                sql += "finish_flag = "+finishFlag+" ";

                sql += " WHERE sdd_detail_id = " + detail_id + ";";
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
                string pjm_id = Request.QueryString.GetValues(1)[0];
                sql += " INSERT INTO dev_sdd_mission_detail ";
                sql += " (sdd_pjm_id,user_id,";
                if (NumBox2.Text != "")
                {
                    sql +="PAP,";
                }
                if (NumberBox1.Text != "")
                {
                    sql +="rPAP,";
                }
                sql += "mission_content,expect_date,begin_date,finish_flag";
                if (DatePicker3.Text != "")
                {
                    sql += ",finish_date";
                }
                sql += ") ";

                sql += " VALUES (" + pjm_id + "," + DropDownList7.SelectedItem.Value+",";
                if (NumBox2.Text != "")
                {
                    sql += NumBox2.Text + ",";
                }
                if (NumberBox1.Text != "")
                {
                    sql +=  NumberBox1.Text + ",";
                }
                sql += "'" + content.Text + "','" + DatePicker4.Text + "','" + DatePicker2.Text+"',";

                string finishFlag = "0";
                if (CheckBox1.Checked)
                {
                    finishFlag = "1";
                }

                sql += finishFlag;

                if (DatePicker3.Text != "")
                {
                    sql +=",'" + DatePicker3.Text + "'";
                }
                sql += ");";


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