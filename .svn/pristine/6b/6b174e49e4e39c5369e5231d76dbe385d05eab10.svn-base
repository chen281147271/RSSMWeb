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
    public partial class SDCManage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateAuth("d003");
            Button4.OnClientClick = Window1.GetShowReference("~/developmanage/SDCMissionDetails.aspx?id=0&checkType=0", "新增");

            if (!IsPostBack)
            {
                try
                {
                    string detail_id = Request.QueryString.GetValues(0)[0];
                    if (detail_id == "1")
                    {
                        string name = Page.Session["user_id"].ToString();
                        User_Id.Text = name;
                    }
                }
                catch
                {

                }
                BindGrid();
            }
            if (Page.Session["iniGrid"].ToString() == "1")
            {
                BindGrid();
                Page.Session["iniGrid"] = 0;
            }
        }

        protected string GetEditUrl(object id, object name, object checkType)
        {
            if (Convert.ToInt32(checkType) == 1)
            {
                return Window1.GetShowReference("~/developmanage/SDCMissionDetails.aspx?id=" + id + "&checkType=1", "查看 - " + name);
            }
            return Window1.GetShowReference("~/developmanage/SDCMissionDetails.aspx?id=" + id + "&checkType=2", "编辑 - " + name);
        }

        protected void Grid1_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        private void BindGrid()
        {
            DataTable table = GetDataTable();

            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        protected DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            string sql = "";
            sql = "SELECT t1.sdd_pjm_id,t1.pjm_title,t1.respect_date,t1.finish_date,t1.finish_flag,t1.PAP,t1.begin_date, ";
            sql += " t2.user_name_full AS charger_name, t3.user_name_full AS tester_name ,t1.create_time ";
            sql += "  FROM dev_sdd_mission t1 LEFT JOIN sys_user t2 ON t1.charger_id = t2.user_id ";
            sql += "  LEFT JOIN sys_user t3 ON t1.tester_id = t3.user_id ";
            if (User_Id.Text != "")
            {
                sql += "where (charger_id=";
                sql+=User_Id.Text;
                sql+=" or tester_id=";
                sql+=User_Id.Text;
                if(sdd_pjm_id()!="")
                {
                sql += " or sdd_pjm_id in( ";
                sql += sdd_pjm_id();
                sql += ")";
                }
                sql+=" )";
            }
            sql +=" order by t1.sdd_pjm_id desc;";
                
            table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            // Alert.ShowInTop(sql);
            return table;
        }

        protected string sdd_pjm_id()
        {
            string str="";
            string sql="";
            sql = "select sdd_pjm_id from dev_sdd_mission_detail where user_id=";
            sql += User_Id.Text;

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                str += reader.GetSqlValue(0).ToString()+",";
            }
            if (str.Length != 0)
            {
                return str.Remove(str.Length - 1);
            }
            return str;
        }
    }
}