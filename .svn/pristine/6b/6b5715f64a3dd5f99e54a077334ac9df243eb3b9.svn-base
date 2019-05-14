using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Data;
using System.Web.UI.HtmlControls;
using RSSMWeb.Code;
using System.Data.SqlClient;

namespace RSSMWeb.projectsmanage
{
    public partial class projectplan : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateAuth("p001");
            if (!IsPostBack)
            {
                BindGrid();
                BindAreaDP();
            }
        }

        protected void QueryPJ(object sender, EventArgs e)
        {
            BindGrid();
        }

        #region BindGrid
        private void BindGrid()
        {
            DataTable table = QuerySubPJList();

            Grid1.DataSource = table;
            Grid1.DataBind();

        }

        private void BindAreaDP()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetCodeSource(8);

            DropDownList3.DataTextField = "Name";
            DropDownList3.DataValueField = "ID";

            DropDownList3.DataSource = mylist;
            DropDownList3.DataBind();
            DropDownList3.SelectedValue = "8035"; 
        }
        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <returns></returns>
        protected DataTable QuerySubPJList()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("plan_id", typeof(bool)));
            table.Columns.Add(new DataColumn("sub_pj_id", typeof(String)));
            table.Columns.Add(new DataColumn("pj_id", typeof(String)));
            table.Columns.Add(new DataColumn("pj_name", typeof(String)));
            table.Columns.Add(new DataColumn("sub_pj_desc", typeof(String)));
            table.Columns.Add(new DataColumn("user_name_full", typeof(String)));
            table.Columns.Add(new DataColumn("finish_flag", typeof(bool)));
            table.Columns.Add(new DataColumn("agent_name", typeof(String)));
            table.Columns.Add(new DataColumn("cus_name", typeof(String)));
            table.Columns.Add(new DataColumn("area_code", typeof(String)));
            //table.Columns.Add(new DataColumn("hint", typeof(String)));
            
            string sql = "select a.sub_pj_id as sub_pj_id ,a.pj_id as pj_id ,a.sub_pj_desc as sub_pj_desc ,a.finish_flag as finish_flag,a.plan_id as plan_id ,";
            sql += "b.pj_name as pj_name ,b.area_code as area_code ,d.user_name_full as user_name_full ,e.agent_name as agent_name ,f.cus_name as cus_name  ";
            sql +="FROM (((pjm_sub_project a LEFT JOIN pjm_project_info b ON a.pj_id = b.pj_id) LEFT JOIN sys_user d ON ";
            sql += "b.sales_user_id = d.user_id ) LEFT JOIN sys_agent e ON b.agent_id = e.agent_id)LEFT JOIN sys_customer f ON b.customer_id = f.cus_id ";
            sql += " where b.pj_name like '%" + TextBox8.Text + "%'";
            if (TextBox5.Text != "")
            {
                sql += " and a.pj_id = " + TextBox5.Text;
            }
            if (TextBox1.Text != "")
            {
                sql += " and pj_id_erp = " + TextBox1.Text;
            }
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sub_pj_id,pj_id,sub_pj_desc,plan_id,pj_name,area_code,user_name_full,agent_name,cus_name;
                bool finish_flag, plan_flag;
                if ( reader[0] != DBNull.Value)
                {
                    sub_pj_id = reader.GetSqlValue(0).ToString();
                }else
                {
                    sub_pj_id = "";
                }
                if ( reader[1] != DBNull.Value)
                {
                    pj_id = reader.GetSqlValue(1).ToString();
                }else
                {
                    pj_id = "";
                }
                if ( reader[2] != DBNull.Value)
                {
                    sub_pj_desc = reader.GetSqlValue(2).ToString();
                }else
                {
                    sub_pj_desc = "";
                }
                if (reader[3] != DBNull.Value)
                {
                    if (reader.GetSqlValue(2).ToString() == "true")
                    {
                        finish_flag = true;
                    }
                    else
                    {
                        finish_flag = false;
                    }
                }
                else
                {
                    finish_flag = false;
                }
                if (reader[4] != DBNull.Value)
                {
                    plan_id = reader.GetSqlValue(4).ToString();
                    plan_flag = true;
                }
                else
                {
                    plan_id = "";
                    plan_flag = false;
                }
                if ( reader[5] != DBNull.Value)
                {
                    pj_name = reader.GetSqlValue(5).ToString();
                }else
                {
                    pj_name = "";
                }
                if (reader[6] != DBNull.Value)
                {
                    area_code = reader.GetSqlValue(6).ToString();
                }else
                {
                    area_code = "0";
                }
                if (reader[7] != DBNull.Value)
                {
                    user_name_full = reader.GetSqlValue(7).ToString();
                }
                else
                {
                    user_name_full = "";
                }
                if (reader[8] != DBNull.Value)
                {
                    agent_name = reader.GetSqlValue(8).ToString();
                }
                else
                {
                    agent_name = "";
                }
                if (reader[9] != DBNull.Value)
                {
                    cus_name = reader.GetSqlValue(9).ToString();
                }
                else
                {
                    cus_name = "";
                }
                DataRow row = table.NewRow();

                row[0] = plan_flag;
                row[1] = sub_pj_id;
                row[2] = pj_id;
                row[3] = pj_name;
                row[4] = sub_pj_desc;
                row[5] = user_name_full;
                row[6] = finish_flag;
                row[7] = agent_name;
                row[8] = cus_name;
                row[9] = area_code;
    
                table.Rows.Add(row);
            }
            return table;
        }
        #endregion
    }
}