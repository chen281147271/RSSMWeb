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

namespace RSSMWeb.systemmanage
{
    public partial class Role_Management : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateAuth("s004");
            btn_add.OnClientClick = Window1.GetShowReference("~/systemmanage/Role_Management_new.aspx", "新增");
            btn_delete.OnClientClick = Grid1.GetNoSelectionAlertReference("至少选择一项！");
            BindGrid();

        }
        protected string GetEditUrl(object id, object name)
        {
            return Window1.GetShowReference("~/systemmanage/Role_Management_new.aspx?id=" + id + "&编辑 - " + name);
        }

        protected string GetOIName(object id)
        {
            return Utils.GetOIName(Convert.ToInt32(id));
        }

        private void BindGrid()
        {
            DataTable table = GetDataTable();

            Grid1.DataSource = table;
            Grid1.DataBind();

        }
        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <returns></returns>
        protected DataTable GetDataTable()
        {
            DataTable table = new DataTable();

            string sql = "select * from sys_role_info";
            sql += " where role_name like '%" + txt_username.Text + "%'";
            table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return table;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                int startIndex = Grid1.PageIndex * Grid1.PageSize;
                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    sb.Append(Grid1.DataKeys[row + startIndex][0].ToString());
                    sb.Append(",");
                }

                sql = "delete from sys_role_info where role_id in (" + sb.ToString().TrimEnd(',') + ");";
                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst < 0)
                {
                    Alert.ShowInTop("save error！");
                    return;
                }
                Alert.ShowInTop("已删除：" + sb.ToString().TrimEnd(','), "删除成功", MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                Alert.ShowInTop(ex.Message + " : sql = " + sql);
            }
            BindGrid();
        }
    }
}