using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using RSSMWeb.Code;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.IO;
namespace RSSMWeb.myjob
{
    public partial class MyMessage_New : System.Web.UI.Page
    {
        protected string oid;
        protected string dpt_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                LoadData();
                change();
              
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

                string sql = "select * from sys_message ";
                sql += " where message_id = " + oid + "";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                while (reader.Read())
                {
                    //TextArea1.Text = reader["message_content"].ToString(); 
                    //Label1.Text = reader["message_content"].ToString();

                    HtmlEditor1.Text = Md5Helper.DESDecrypt(reader["message_content"].ToString());
                    txt_title.Text = reader["message_title"].ToString();
                    HtmlEditor1.EnableColors = false;
                    HtmlEditor1.EnableFont = false;
                    HtmlEditor1.EnableFontSize = false;
                    HtmlEditor1.EnableFormat = false;
                    HtmlEditor1.EnableLinks = false;
                    HtmlEditor1.EnableLists = false;
                    HtmlEditor1.EnableSourceEdit = false;
                    DropDownList1.Visible = false;
                    DropDownList2.Visible = false;
                    DropDownList3.Visible = false;
                    btnSaveRefresh.Visible = false;


                    if (reader["msg_tgt_id"].ToString() == Page.Session["user_id"].ToString())
                    {
                        sql = "update sys_message  set msg_read_flag=1 where message_id='";
                        sql += oid;
                        sql += "'";
                        int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                        if (rst != 1)
                        {
                            Alert.ShowInTop("修改查看Flag失败 !");
                        }
                    }
                }
                //ExtAspNet.PageContext.RegisterStartupScript("parent.window.location.href=parent.window.location.href;");
                //ExtAspNet.PageContext.RegisterStartupScript( "ActiveWindow.GetClosePostBackReference()");
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
        private void BindGrid()
        {


            List<RSSMWeb.Code.Utils.CustomClassForDropdownlist> mylist_username_dpt = Utils.GetUserListForDropdownlist_dpt();
            DropDownList3.EnableSimulateTree = true;
            DropDownList3.DataTextField = "Name";
            DropDownList3.DataValueField = "ID";
            DropDownList3.DataSimulateTreeLevelField = "Group";
            DropDownList3.DataEnableSelectField = "Enableselect";


            DropDownList3.DataSource = mylist_username_dpt;
            DropDownList3.DataBind();
            DropDownList3.SelectedValue = "0";

        }
        protected void Getmanage_type()
        {


            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetRIList();

            mylist.Insert(0, new RSSMWeb.Code.Utils.CustomClass("-1", "-------------请选择-------------", "0"));

            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "ID";



            DropDownList2.DataSource = mylist;
            DropDownList2.DataBind();
            DropDownList2.SelectedIndex = 0;

        }
        protected void GetOrg()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetOIList();
            mylist.Insert(0, new RSSMWeb.Code.Utils.CustomClass("-1", "-------------请选择-------------", "0"));



            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "ID";



            DropDownList2.DataSource = mylist;
            DropDownList2.DataBind();
            DropDownList2.SelectedIndex = 0;

        }
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            //SendEmail();
          //  return;
            // 1. 这里放置保存窗体中数据的逻辑
            if (HtmlEditor1.Text.Length > 500)
            {
                Alert.Show("长度不能超过500!");
                return;
            }
            
            string sql = "";
            string vals = Request.Url.Query;

            if (vals == "")
            {
                if (DropDownList1.SelectedItem.Text == "按用户")
                {

                    if (DropDownList3.SelectedValue == "0")
                    {
                        Alert.Show("请选择一个有效的值");
                        return;
                    }
                    sql = "insert into sys_message (message_content,message_create_time,msg_creator_id,msg_tgt_id,msg_tgt_type,msg_read_flag,message_title)";
                    sql+="values('";
                    sql += Md5Helper.DESEncrypt(HtmlEditor1.Text);
                    sql+="',GETDATE(),'";
                    sql += Page.Session["user_id"].ToString();
                    sql+="','";
                    sql += DropDownList3.SelectedValue;
                    sql += "',0,0,'";
                    sql += txt_title.Text;
                    sql += "' )";

                    int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                    if (rst != 1)
                    {
                        Alert.ShowInTop("save error !");
                    }
                }
                else if (DropDownList1.SelectedItem.Text == "按部门")
                {
                    if (DropDownList2.SelectedValue == "-1")
                    {
                        Alert.Show("请选择一个有效的值");
                        return;
                    }
                    sql = "select user_id from sys_user where org_id ='";
                    sql += DropDownList2.SelectedValue.ToString();
                    sql += "'";
                   // Alert.ShowInTop(sql);
                    SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                    while (dr.Read())
                    {
                        if (dr[0].ToString() == Page.Session["user_id"].ToString())
                        {
                            continue;
                        }
                        sql = "insert into sys_message (message_content,message_create_time,msg_creator_id,msg_tgt_id,msg_tgt_type,msg_read_flag,message_title)";
                        sql += "values('";
                        sql += Md5Helper.DESEncrypt(HtmlEditor1.Text);
                        sql += "',GETDATE(),'";
                        sql += Page.Session["user_id"].ToString();
                        sql += "','";
                        sql += dr[0].ToString();
                        sql += "',0,0,'";
                        sql += txt_title.Text;
                        sql += "' )";

                        int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                        if (rst != 1)
                        {
                            Alert.ShowInTop("save error !");
                        }
                    }
                }
            }
            else
            {
                oid = Request.QueryString.GetValues(0)[0];
             //   sql = "update sys_organize_info set org_name='" + TextBox5.Text + "',org_normal_name='" + TextBox1.Text + "',org_manager_name='" + TextBox2.Text;
              //  sql += "',org_assist_name='" + TextBox3.Text + "',is_top=" + top_flag + ",father_org_id= " + dr_dpt.SelectedItem.Value;
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
        private void change()
        {
            DropDownList2.Items.Clear();
            if (DropDownList1.SelectedItem.Text == "按部门")
            {
                DropDownList3.Enabled = false;
                DropDownList2.Enabled = true;
                //btn_Search.Enabled = false;

                GetOrg();
            }
            else if (DropDownList1.SelectedItem.Text == "按角色")
            {
                DropDownList3.Enabled = false;
                DropDownList2.Enabled = true;
                //btn_Search.Enabled = false;
                Getmanage_type();
            }
            else
            {
                DropDownList3.Enabled = true;
                DropDownList2.Enabled = false;
                //btn_Search.Enabled = true;
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            change();
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
       
    }
}