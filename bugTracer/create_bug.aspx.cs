﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using RSSMWeb.Code;
using System.Data.SqlClient;


namespace RSSMWeb.bugTracer
{
    public partial class create_bug : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                BindAreaDP();
            }
        }

        private void LoadData()
        {

            // 关闭按钮的客户端脚本：
            // 1. 首先确认窗体中表单是否被修改（如果已经被修改，则弹出是否关闭的确认对话框）
            // 2. 然后关闭本窗体，回发父窗体
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();

        }
        private void BindAreaDP()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetUserList();
            RSSMWeb.Code.Utils.CustomClass tmp = new RSSMWeb.Code.Utils.CustomClass("0", "无", "0");
            List<RSSMWeb.Code.Utils.CustomClassForDropdownlist> mylist_username_dpt = Utils.GetUserListForDropdownlist_dpt();
            mylist.Insert(0, tmp);

            //NextUser.DataTextField = "Name";
            //NextUser.DataValueField = "ID";
            //NextUser.DataSource = mylist;
            //NextUser.DataBind();

            NextUser.EnableSimulateTree = true;
            NextUser.DataTextField = "Name";
            NextUser.DataValueField = "ID";
            NextUser.DataSimulateTreeLevelField = "Group";
            NextUser.DataEnableSelectField = "Enableselect";

            NextUser.DataSource = mylist_username_dpt;
            NextUser.DataBind();
            NextUser.SelectedValue = "0";

            //DropDownList1.DataTextField = "Name";
            //DropDownList1.DataValueField = "ID";
            //DropDownList1.DataSource = mylist;
            //DropDownList1.DataBind();

            DropDownList1.EnableSimulateTree = true;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataSimulateTreeLevelField = "Group";
            DropDownList1.DataEnableSelectField = "Enableselect";

            DropDownList1.DataSource = mylist_username_dpt;
            DropDownList1.DataBind();
            DropDownList1.SelectedValue = "0";

            mylist.Clear();
            mylist = Utils.GetPJList();
            tmp.ID = "0";
            tmp.Name = "无";
            mylist.Insert(0, tmp);

            BugBelongPJ.DataTextField = "Name";
            BugBelongPJ.DataValueField = "ID";
            BugBelongPJ.DataSource = mylist;
            BugBelongPJ.DataBind();

            mylist.Clear();
            mylist = Utils.GetPDList();
            tmp.ID = "0";
            tmp.Name = "无";
            mylist.Insert(0, tmp);

            BugBelongPD.DataTextField = "Name";
            BugBelongPD.DataValueField = "ID";
            BugBelongPD.DataSource = mylist;
            BugBelongPD.DataBind();

            OccurTime.SelectedDate = DateTime.Now;
        }
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 这里放置保存窗体中数据的逻辑
                string sql;
                string reqFlag = "0";
                string strExpect_Time="";
                if (rbtnSecond.Checked)
                {
                    reqFlag = "1";
                }
                else if (rbtnFirst.Checked)
                {
                    reqFlag = "2";
                }
                
                sql = "INSERT INTO bug_main_info (bug_title,bug_type,sub_bug_count)  ";
                sql += "VALUES   ('" + BugTitle.Text + "', " + BugType.SelectedItem.Value + ", 1 ) ";

                //Alert.ShowInTop(sql);

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error！");
                }
                string sIsResolved = "0";
                if (IsResolved.Checked)
                {
                    sIsResolved = "1";
                }
                sql = "select IDENT_CURRENT('bug_main_info') ";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                string newId="0";
                while (reader.Read())
                {
                    newId = reader.GetValue(0).ToString();
                }
                string resolveUser = "0";
                if (DropDownList1.SelectedItem != null)
                {
                    resolveUser = DropDownList1.SelectedItem.Value;
                }
                sql = "INSERT INTO bug_detail_info (bug_id,process_type,is_resolved,phenomenon,create_time,occur_time,create_user_id,bug_state, ";
                sql += "pj_id,PRI,rsolve_time,resolve_user_id,solution,cur_user_id,next_user_id,pd_id,req_flag,expect_time) ";
                sql += "VALUES (" + newId+"," + BugProcType.SelectedItem.Value + "," + sIsResolved + ",'" + Phenomenon.Text + "',GETDATE(), ";
                if (OccurTime.Text == "")
                {
                    sql += "NULL, ";
                }
                else
                {
                    sql += "cast('";
                    sql += OccurTime.SelectedDate;
                    sql += "' as datetime),";
                }
             //   sql+="cast('" + OccurTime.SelectedDate + "' as datetime),";
                sql += Page.Session["user_id"].ToString() + ",6001," + BugBelongPJ.SelectedItem.Value + "," + BugAuth.SelectedItem.Value + ", ";
                if (FixTime.Text == "")
                {
                    sql += "NULL, ";
                }
                else
                {
                    sql += "cast('";
                    sql += FixTime.SelectedDate;
                    sql += "' as datetime),";
                }
               // sql += "cast('" + FixTime.SelectedDate + "' as datetime),";
                sql +=resolveUser + ",'" + Solution.Text + "'," + Page.Session["user_id"].ToString() + "," + NextUser.SelectedItem.Value;
                sql += ", " + BugBelongPD.SelectedItem.Value + ", " + reqFlag + ", ";
                if (Expect_Time.Text == "")
                {
                    sql+="NULL";
                }
                else
                {
                    sql += "cast('";
                    sql += Expect_Time.SelectedDate;
                    sql += "' as datetime)";
                }
                sql+= ");";
                // 2. 关闭本窗体，然后刷新父窗体
                rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error !");
                }
                sql = "select IDENT_CURRENT('bug_detail_info') ";
               reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                string newDetailId = "0";
                while (reader.Read())
                {
                    newDetailId = reader.GetValue(0).ToString();
                }
                AddBugRecord(newDetailId, "新增*预期解决日期:" + string.Format("{0:d}", Expect_Time.SelectedDate));
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());

                //发送邮件
             //  int res= Utils.SendEmail(Utils.GetEmail(NextUser.SelectedValue), Utils.GetEmail(Page.Session["user_id"].ToString()), BugTitle.Text, Phenomenon.Text);
                //if (NextUser.SelectedValue !="0")
                //{
                //    string Solution_1 = Solution.Text.Replace("\n", "<BR>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp");
                //    string Phenomenon_1 = Phenomenon.Text.Replace("\n", "<BR>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp");

                //    string Theme = "问题主题：" + BugTitle.Text + ", 提出人：" + Utils.GetUserName(Convert.ToInt32(Page.Session["user_id"].ToString())) + ", 问题状态：新增";
                //    string concent = "<BR>问题标题: &nbsp;" + BugTitle.Text + "<BR>提出人: &nbsp;" + Utils.GetUserName(Convert.ToInt32(Page.Session["user_id"].ToString())) + "<BR>所属项目: &nbsp;" + BugBelongPJ.SelectedText + "<BR>所属产品 &nbsp;" + BugBelongPD.SelectedText + "<BR>当前状态 &nbsp;" + "新增" + "<BR>现象描述: &nbsp;" + Phenomenon_1 + "<BR>现场处理过程: &nbsp;" + Solution_1 + "<BR><BR><BR><BR><BR><BR>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp-----此邮件来自瑞驰管理系统";

                //    int res = Utils.SendEmail(Utils.GetEmail(NextUser.SelectedValue), Utils.GetEmail(Page.Session["user_id"].ToString()), Theme, concent);

                //    if (res != 0)
                //    {
                //        Alert.ShowInTop("邮件发送失败 请联系检查邮件地址是否为公司邮箱!");
                //    }
                //}
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }
        }
    }
}