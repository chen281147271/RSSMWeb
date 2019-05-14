using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Data.SqlClient;
using RSSMWeb.Code;
using System.Configuration;
using System.IO;
using System.Data;
using System.Text;


namespace RSSMWeb.bugTracer
{
    public partial class bug_details : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

              //  btnSaveRefresh.OnClientClick = Confirm.GetShowReference("确认执行操作三？", String.Empty, MessageBoxIcon.Question, btnSaveRefresh.GetPostBackEventReference(), btnSaveRefresh.GetPostBackEventReference("Cancel"));

                Button3.OnClientClick = Grid1.GetNoSelectionAlertReference("至少选择一项！");
                BindAreaDP();
                LoadData();
                LoadFileData();
            }   
        }

      

        private void BindAreaDP()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetUserList();
            RSSMWeb.Code.Utils.CustomClass tmp = new RSSMWeb.Code.Utils.CustomClass("0", "无", "0");
            List<RSSMWeb.Code.Utils.CustomClassForDropdownlist> mylist_username_dpt = Utils.GetUserListForDropdownlist_dpt();
            mylist.Insert(0, tmp);


            DropDownList7.DataTextField = "Name";
            DropDownList7.DataValueField = "ID";
            DropDownList7.DataSource = mylist;
            DropDownList7.DataBind();

            //DropDownList6.DataTextField = "Name";
            //DropDownList6.DataValueField = "ID";
            //DropDownList6.DataSource = mylist;
            //DropDownList6.DataBind();

            DropDownList6.EnableSimulateTree = true;
            DropDownList6.DataTextField = "Name";
            DropDownList6.DataValueField = "ID";
            DropDownList6.DataSimulateTreeLevelField = "Group";
            DropDownList6.DataEnableSelectField = "Enableselect";

            DropDownList6.DataSource = mylist_username_dpt;
            DropDownList6.DataBind();
            DropDownList6.SelectedValue = "0";

  

            //DropDownList9.DataTextField = "Name";
            //DropDownList9.DataValueField = "ID";
            //DropDownList9.DataSource = mylist;
            //DropDownList9.DataBind();

            DropDownList9.EnableSimulateTree = true;
            DropDownList9.DataTextField = "Name";
            DropDownList9.DataValueField = "ID";
            DropDownList9.DataSimulateTreeLevelField = "Group";
            DropDownList9.DataEnableSelectField = "Enableselect";

            DropDownList9.DataSource = mylist_username_dpt;
            DropDownList9.DataBind();
            DropDownList9.SelectedValue = "0";

            DropDownList10.EnableSimulateTree = true;
            DropDownList10.DataTextField = "Name";
            DropDownList10.DataValueField = "ID";
            DropDownList10.DataSimulateTreeLevelField = "Group";
            DropDownList10.DataEnableSelectField = "Enableselect";

            DropDownList10.DataSource = mylist_username_dpt;
            DropDownList10.DataBind();
            DropDownList10.SelectedValue = "0";

            DropDownList12.EnableSimulateTree = true;
            DropDownList12.DataTextField = "Name";
            DropDownList12.DataValueField = "ID";
            DropDownList12.DataSimulateTreeLevelField = "Group";
            DropDownList12.DataEnableSelectField = "Enableselect";

            DropDownList12.DataSource = mylist_username_dpt;
            DropDownList12.DataBind();
            DropDownList12.SelectedValue = "0";

            mylist.Clear();
            mylist = Utils.GetPJList();
            tmp.ID = "0";
            tmp.Name = "无";
            mylist.Insert(0, tmp);

            DropDownList4.DataTextField = "Name";
            DropDownList4.DataValueField = "ID";
            DropDownList4.DataSource = mylist;
            DropDownList4.DataBind();

            mylist.Clear();
            mylist = Utils.GetPDList();
            tmp.ID = "0";
            tmp.Name = "无";
            mylist.Insert(0, tmp);

            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "ID";
            DropDownList2.DataSource = mylist;
            DropDownList2.DataBind();
        }
        private void LoadData()
        {
            try
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                string vals = Request.Url.Query;
                if (vals == "")
                {
                    return;
                }
                string detail_id = Request.QueryString.GetValues(0)[0];
                string checkType = Request.QueryString.GetValues(1)[0];
                if (checkType == "1")
                {
                    btnSaveRefresh.Visible = false;
                    //Form2.Enabled = false;
                    Button3.Visible = false;
                    FileUpload1.Visible = false;
                    Button1.Visible = false;
                    TextBox1.Visible = false;
                }

                string sql = "SELECT t2.bug_id AS bug_id,t2.bug_title AS bug_title, t2.bug_type AS bug_type ,t1.create_time AS create_time,t1.occur_time as occur_time, ";
                sql += " t1.create_user_id AS create_user_id,t1.bug_state AS bug_state ,t1.process_type AS process_type,t1.rsolve_time as rsolve_time,t1.tester_id as tester_id,  ";
                sql += " t1.PRI AS PRI , t1.next_user_id AS next_user_id ,t3.pj_name AS pj_name ,t4.pd_name AS pd_name,t3.pj_id AS pj_id,t4.pd_id AS pd_id,";
                sql += " t5.user_name_full as create_user_name,t6.user_name_full as next_user_name,t1.detail_id as detail_id ,t1.cur_user_id as cur_user_id, ";
                sql += "t1.is_resolved as is_resolved,t1.phenomenon as phenomenon,t1.analysis as analysis,t1.solution as solution ,t1.resolve_user_id as resolve_user_id, ";
                sql += " t1.req_flag as req_flag, t1.PAP as PAP, t1.charger_id as charger_id, t1.Severity as severity,t1.expect_time as expect_time,t1.rPAP as rPAP ";
                //开启 解决时间
                sql += ",t1.Star_Time,t1.Finish_Time";

                sql += " FROM bug_detail_info t1 LEFT JOIN bug_main_info t2  ON t1.bug_id = t2.bug_id LEFT JOIN pjm_project_info t3 ON t1.pj_id = t3.pj_id ";
                sql += " LEFT JOIN pjm_product_info t4 ON t1.pd_id = t4.pd_id ";
                sql += " LEFT JOIN sys_user t5 ON t1.create_user_id = t5.user_id LEFT JOIN sys_user t6 ON t1.next_user_id = t6.user_id ";
                sql += " where t1.detail_id = " + detail_id;
              

                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                while (reader.Read())
                {
                    TextBox5.Text = reader["bug_title"].ToString();
                    Label3.Text = reader["create_user_name"].ToString();
                    Label1.Text = reader["create_time"].ToString();
                    DropDownList8.SelectedValue = reader["bug_state"].ToString();
                    PreState.Text = reader["bug_state"].ToString();
                    DropDownList3.SelectedValue = reader["bug_type"].ToString();
                    DropDownList1.SelectedValue = reader["process_type"].ToString();
                    DropDownList2.SelectedValue = reader["pd_id"].ToString();
                    DropDownList4.SelectedValue = reader["pj_id"].ToString();
                    DropDownList5.SelectedValue = reader["PRI"].ToString();
                    DropDownList11.SelectedValue = reader["severity"].ToString();

                    Star_Time.Text = reader["Star_Time"].ToString();
                    Finish_Time.Text = reader["Finish_Time"].ToString();
                    if (checkType == "1")
                    {
                        DropDownList7.SelectedValue = reader["cur_user_id"].ToString();
                        DropDownList6.SelectedValue = reader["next_user_id"].ToString();
                    }
                    else
                    {
                        DropDownList7.SelectedValue = reader["next_user_id"].ToString();
                    }
            //        if (reader["resolve_user_id"].ToString() != "0")
            //        {
                        DropDownList9.SelectedValue = reader["resolve_user_id"].ToString();
             //       }       
                     if (reader["charger_id"].ToString() != "0")
                     {
                         DropDownList10.SelectedValue = reader["charger_id"].ToString();
                     }
                     if (reader["tester_id"].ToString() != "0")
                     {
                         DropDownList12.SelectedValue = reader["tester_id"].ToString();
                     } 
                    if (reader["is_resolved"].ToString() == "True")
                    {
                        CheckBox1.Checked = true;
                    }
                    string rsolveTime = reader["rsolve_time"].ToString();
                    if (rsolveTime != "")
                    {
                        DatePicker2.SelectedDate = Convert.ToDateTime(rsolveTime);
                    }
                    string occur_time = reader["occur_time"].ToString();
                    if (occur_time != "")
                    {
                        DatePicker1.SelectedDate = Convert.ToDateTime(reader["occur_time"].ToString());
                    }
                    Phenomenon.Text = reader["phenomenon"].ToString();
                    Phenomenon.Text = Phenomenon.Text.Replace("&ltl", "<");
                    Phenomenon.Text = Phenomenon.Text.Replace("&ltr", ">");
                    Phenomenon.Text = Phenomenon.Text.Replace("&ltd", "'");
                    Phenomenon.Text = Phenomenon.Text.Replace("&lts", "\"");

                    Solution.Text = reader["solution"].ToString();
                   Solution.Text= Solution.Text.Replace("&ltl", "<");
                   Solution.Text= Solution.Text.Replace("&ltr", ">");
                   Solution.Text = Solution.Text.Replace("&ltd", "'");
                   Solution.Text = Solution.Text.Replace("&lts", "\"");

                    RunningRecord.Text = getRRDContent(detail_id);
                 RunningRecord.Text =   RunningRecord.Text.Replace("&ltl", "<");
                  RunningRecord.Text =  RunningRecord.Text.Replace("&ltr", ">");
                  RunningRecord.Text = RunningRecord.Text.Replace("&ltd", "'");
                  RunningRecord.Text = RunningRecord.Text.Replace("&lts", "\"");

                    TextArea1.Text = reader["analysis"].ToString();
                   TextArea1.Text= TextArea1.Text.Replace("&ltl", "<");
                   TextArea1.Text=TextArea1.Text.Replace("&ltr", ">");
                   TextArea1.Text = TextArea1.Text.Replace("&ltd", "'");
                   TextArea1.Text = TextArea1.Text.Replace("&lts", "\"");

                    string PAP = reader["PAP"].ToString();
                    if (PAP != "" && PAP != "0" )
                    {
                        NumBox2.Text = PAP;
                        NumBox2.Enabled = false;
                    }
                    string rPAP = reader["rPAP"].ToString();
                    if (rPAP != "" && rPAP != "0" )
                    {
                        NumBox3.Text = rPAP;
                        NumBox3.Enabled = false;
                    }
                    string expectTime = reader["expect_time"].ToString();
                    if (expectTime != "")
                    {
                        DatePicker3.SelectedDate = Convert.ToDateTime(expectTime);
                    }
                    
                    
                    string reqFlag = reader["req_flag"].ToString();
                    if (reqFlag =="1")
                    {
                        rbtnSecond.Checked = true;
                    }
                    else if (reqFlag == "0")
                    {
                        rbtnThird.Checked = true;
                    }
                    //初始化 转发人等于当前人
                    DropDownList6.SelectedValue = DropDownList7.SelectedValue;
                }
            }
            catch (System.Exception ex)
            {
                Alert.ShowInTop("异常:"+ex.Message);
            }
            // 关闭按钮的客户端脚本：
            // 1. 首先确认窗体中表单是否被修改（如果已经被修改，则弹出是否关闭的确认对话框）
            // 2. 然后关闭本窗体，回发父窗体
            
        }

        private string getRRDContent(string detail_id)
        {
            string rsl = "";
            string sql = "SELECT t.deal_time,t.deal_content,t2.user_name_full as userName FROM bug_running_record t LEFT JOIN sys_user t2 ON t.deal_user_id = t2.user_id ";
            sql += " WHERE t.detail_id = " + detail_id;
            sql += "ORDER BY t.deal_time desc; ";

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

            while (reader.Read())
            {
                string userName = reader["userName"].ToString();
                string dealTime = reader["deal_time"].ToString();
                string dealContent = reader["deal_content"].ToString();
                int i = dealContent.IndexOf("*预期解决日期:");
                string str;
                rsl += "----------------------------------------------\r\n";
                rsl += userName + "  " + dealTime + "\r\n";
                if (i > 0)
                {
                    str = dealContent.Substring(0, i);
                    string time = dealContent.Substring(i+1);
                    rsl += "    " + str + "\r\n";
                    rsl += "    " + time + "\r\n";
                }else
                rsl += "    " + dealContent + "\r\n";
            }
            return rsl;
        }
        private void LoadFileData()
        {
            try
            {
                string vals = Request.Url.Query;
                if (vals == "")
                {
                    return;
                }
                string detail_id = Request.QueryString.GetValues(0)[0];
                string checkType = Request.QueryString.GetValues(1)[0];


                string sql = "select t.file_id,t.file_name,t.file_hint,t.file_url,t.file_upload_time ,t2.user_name_full  ";
                sql += " from sys_upload_file t LEFT JOIN sys_user t2 ON t.file_uploader_id = t2.user_id ";
                sql += " where t.detail_id = " + detail_id;
                DataTable table = new DataTable();
                table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                Grid1.DataSource = table;
                Grid1.DataBind();
            }
            catch (System.Exception ex)
            {
                Alert.ShowInTop("异常:" + ex.Message);
            }
            // 关闭按钮的客户端脚本：
            // 1. 首先确认窗体中表单是否被修改（如果已经被修改，则弹出是否关闭的确认对话框）
            // 2. 然后关闭本窗体，回发父窗体

        }

        protected string GetEditUrl(object furl)
        {
            string rsl = Request.Url.Authority;
            rsl = "http://" + rsl;
            rsl += "/BugAttachment"+furl;
            //Alert.ShowInTop(rsl);
            return rsl;
        }

        protected void btnSaveContinue_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑


            // 2. 关闭本窗体，然后回发父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btnAddCommit(object sender, EventArgs e)
        {
            string detail_id = Request.QueryString.GetValues(0)[0];
             string content = Analysis.Text;
            if (content != "")
            {
                AddBugRecord(detail_id, "留言: " + content);
            }
            DateTime now = DateTime.Now;
            string rrd = " ----------------------------------------------\r\n" + Page.Session["user_name_full"].ToString();
            rrd += now.ToString();
            rrd +="\r\n    留言:" + content + "\r\n" + RunningRecord.Text;
            RunningRecord.Text = rrd;


            RunningRecord.Text = RunningRecord.Text.Replace("&ltl", "<");
            RunningRecord.Text = RunningRecord.Text.Replace("&ltr", ">");
            RunningRecord.Text = RunningRecord.Text.Replace("&ltd", "'");
            RunningRecord.Text = RunningRecord.Text.Replace("&lts", "\"");


            Phenomenon.Text = Phenomenon.Text.Replace("&ltl", "<");
            Phenomenon.Text = Phenomenon.Text.Replace("&ltr", ">");
            Phenomenon.Text = Phenomenon.Text.Replace("&ltd", "'");
            Phenomenon.Text = Phenomenon.Text.Replace("&lts", "\"");


            Solution.Text = Solution.Text.Replace("&ltl", "<");
            Solution.Text = Solution.Text.Replace("&ltr", ">");
            Solution.Text = Solution.Text.Replace("&ltd", "'");
            Solution.Text = Solution.Text.Replace("&lts", "\"");


            TextArea1.Text = TextArea1.Text.Replace("&ltl", "<");
            TextArea1.Text = TextArea1.Text.Replace("&ltr", ">");
            TextArea1.Text = TextArea1.Text.Replace("&ltd", "'");
            TextArea1.Text = TextArea1.Text.Replace("&lts", "\"");

            Analysis.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    sb.Append(Grid1.DataKeys[row][0].ToString());
                    sb.Append(",");
                }

                sql = "delete from sys_upload_file where file_id in (" + sb.ToString().TrimEnd(',') + ");";
                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst < 0)
                {
                    Alert.ShowInTop("save error！" + sql);
                    return;
                }
                Alert.ShowInTop("已删除：" + sb.ToString().TrimEnd(','), "删除成功", MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                Alert.ShowInTop(ex.Message + " : sql = " + sql);
            }
            LoadFileData();
        }

        protected void btnUploadFile(object sender, EventArgs e)
        {
            string vals = Request.Url.Query;
            if (vals == "")
            {
                return;
            }
            string detail_id = Request.QueryString.GetValues(0)[0];
            //判断用户是否选择了文件
            if (FileUpload1.HasFile && FileUpload1.FileName != "")
            {
                //调用自定义方法判断文件类型是否符合要求
                if (IsAllowableFileType(GetFileExtends(FileUpload1.FileName)))
                {
                    //调用自定义方法判断文件大小是否符合要求
                    if (IsAllowableFileSize(FileUpload1.PostedFile.ContentLength))
                    {
                        //从config中读取文件上传路径
                        string strFileUploadPath = ConfigurationManager.AppSettings["FileUploadPathBug"].ToString();
                        strFileUploadPath += "/" + detail_id + "/";
                        //从UploadFile中读取文件名
                        string strFileName = FileUpload1.FileName;
                        //组合成物理路径
                        string strFilePhysicalPath = Server.MapPath(strFileUploadPath);
                        //保存文件
                        if (!Directory.Exists(strFilePhysicalPath))
                        {
                            Directory.CreateDirectory(strFilePhysicalPath);
                         }
                        //strFilePhysicalPath += strFileName;
                        while(File.Exists(strFilePhysicalPath + strFileName))
                        {
                            strFileName = "1" + strFileName;
                        }

                        FileUpload1.SaveAs(strFilePhysicalPath + strFileName);
                        saveFileInDB(detail_id, strFileName);
                        Response.Redirect(Request.Url.ToString()); 
                        //更新文件夹信息
                        Alert.ShowInTop("文件成功上传");
                    }
                    else
                    {
                        //调用自定义方法显示提示
                        Alert.ShowInTop("文件大小不符合要求，请参看上传限制");
                    }
                }
                else
                {
                    //调用自定义方法显示提示
                    Alert.ShowInTop("文件类型不符合要求，请参看上传限制");
                }
            }
            else
            {
                //调用自定义方法显示提示
                Alert.ShowInTop("请选择一个文件");
            }
        }
        protected void saveFileInDB(string detailId, string fileName)
        {
            string fileUrl = "/" + detailId + "/" + fileName;
            string sql = "INSERT INTO sys_upload_file ";
            sql += "(file_name,file_hint,file_url,file_uploader_id,file_upload_time,ref_count,detail_id)";
            sql += " VALUES ('" + fileName + "','" + TextBox1.Text + "','" + fileUrl + "'," + Page.Session["user_id"].ToString() + ",getdate(),1," + detailId + ");";

            int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            if (rst != 1)
            {
                Alert.ShowInTop("save error !");
            }
        }
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            try
            {

                //if (Request.Form["__EVENTARGUMENT"].ToString() == "Cancel")
                //{
                //    Alert.ShowInTop("取消执行操作三！");
                //}
                //else
                //{
                //    Alert.ShowInTop("执行了操作三！");
                //}
                // 1. 这里放置保存窗体中数据的逻辑
                string resolvedFlag = "0";
                if (CheckBox1.Checked)
                {
                    resolvedFlag = "1";
                }
                string reqFlag = "0";
                if (rbtnSecond.Checked)
                {
                    reqFlag = "1";
                }
                else if (rbtnFirst.Checked)
                {
                    reqFlag = "2";
                }

                //记录开启时间 已完成时间 Star_Time Finish_Time 
                if (DropDownList8.SelectedText == "开启" && Star_Time.Text == "")
                {
                    Star_Time.Text = DateTime.Now.ToString();
                }
                if (DropDownList8.SelectedText == "已解决" && Finish_Time.Text == "")
                {
                    Finish_Time.Text = DateTime.Now.ToString();
                }

                string sql = "";
                string detail_id = Request.QueryString.GetValues(0)[0];

                sql = "update bug_detail_info SET process_type = " + DropDownList1.SelectedItem.Value + ",";
                sql += "is_resolved = " + resolvedFlag + ",";
                sql += "phenomenon = '" + Phenomenon.Text + "',";
                if (DatePicker1.Text == "")
                {
                    sql += "occur_time =NULL,";
                }
                else
                {
                    sql += "occur_time=";
                    sql += "cast('";
                    sql += DatePicker1.SelectedDate;
                    sql += "' as datetime),";
                }
              //  sql += "occur_time= '" + DatePicker1.Text + "',";
                sql += "bug_state=" + DropDownList8.SelectedItem.Value + ",";
                sql += "pj_id = " + DropDownList4.SelectedItem.Value + ",";
                sql += "PRI =" + DropDownList5.SelectedItem.Value + ",";
                if (DatePicker2.Text == "")
                {
                    sql += "rsolve_time =NULL,";
                }
                else
                {
                    sql += "rsolve_time=";
                    sql += "cast('";
                    sql += DatePicker2.SelectedDate;
                    sql += "' as datetime),";
                }
               // sql += "rsolve_time= '" + DatePicker2.Text + "',";
                sql += "resolve_user_id=" + DropDownList5.SelectedItem.Value + ",";
                sql += "analysis = '" + TextArea1.Text + "',";
                sql += "solution =  '" + Solution.Text + "',";
                sql += "cur_user_id =" + DropDownList7.SelectedItem.Value + ",";
                sql += "next_user_id =" + DropDownList6.SelectedItem.Value + ",";

                sql += "charger_id =" + DropDownList10.SelectedItem.Value + ",";
                if (DatePicker3.Text == "")
                {
                    sql += "expect_time =NULL,";
                }
                else
                {
                    sql += "expect_time=";
                    sql += "cast('";
                    sql += DatePicker3.SelectedDate;
                    sql += "' as datetime),";
                }
            //    sql += "expect_time ='" + DatePicker3.Text + "',";

                sql += "Star_Time='"+Star_Time.Text+"',";
                sql += "Finish_Time='" + Finish_Time.Text + "',";
                if (NumBox2.Text != "")
                {
                    sql += "PAP =" + NumBox2.Text + ",";
                }
                if (NumBox3.Text != "")
                {
                    sql += "rPAP =" + NumBox3.Text + ",";
                }
               
                sql += "severity =" + DropDownList11.SelectedValue + ",";
                sql += "req_flag =" + reqFlag + ",";
                sql += "pd_id =" + DropDownList2.SelectedItem.Value;
                sql += " where detail_id = " + detail_id;
                //Alert.ShowInTop(sql);
                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error !");
                }
                string content ="状态: " + GetSysCode2(PreState.Text) + " --> " + GetSysCode2(DropDownList8.SelectedItem.Value) + " ||转发->" ;
                content += GetUserName(DropDownList6.SelectedItem.Value);
                content += "*预期解决日期:";
                content += string.Format("{0:d}", DatePicker3.SelectedDate);
                AddBugRecord(detail_id, content);
               // PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
             //   PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                Page.Session["iniGrid"] = 1;


               

                //发送邮件
                //string RunningRecord1 = RunningRecord.Text.Replace("\n", "<BR>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp");
                //string TextArea1_1 = TextArea1.Text.Replace("\n", "<BR>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp");
                //string Solution_1 = Solution.Text.Replace("\n", "<BR>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp");
                //string Phenomenon_1 = Phenomenon.Text.Replace("\n", "<BR>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp");
                //string Theme = "问题主题：" + TextBox5.Text + ", 提出人：" + Label3.Text + ", 问题状态：" + content;
                //string concent = "<BR>问题标题: &nbsp;" + TextBox5.Text + "<BR>提出人: &nbsp;" + Label3.Text + "<BR>所属项目: &nbsp;" + DropDownList4.SelectedText + "<BR>所属产品 &nbsp;" + DropDownList2.SelectedText + "<BR>当前状态 &nbsp;" + DropDownList8.SelectedText + "<BR>现象描述: &nbsp;" + Phenomenon_1 + "<BR>现场处理过程: &nbsp;" + Solution_1 + "<BR>解决方案: &nbsp;" + TextArea1_1 + "<BR>处理过程: &nbsp;" + RunningRecord1 + "<BR><BR><BR><BR><BR><BR>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp-----此邮件来自瑞驰管理系统";
                //if (DropDownList7.SelectedValue != DropDownList6.SelectedValue)
                //{
                //    int res=Utils.SendEmail(Utils.GetEmail(DropDownList6.SelectedValue), Utils.GetEmail(Page.Session["user_id"].ToString()), Theme, concent);
                //    if (res != 0)
                //    {
                //        Alert.ShowInTop("邮件发送失败 请联系检查邮件地址是否为公司邮箱!");
                //    }
                //}
            }
            catch (System.Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }      
        }
    }
}