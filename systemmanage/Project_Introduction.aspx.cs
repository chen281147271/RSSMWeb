using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Data;
using RSSMWeb.Code;
using System.Text;


namespace RSSMWeb.systemmanage
{
    public partial class Project_Introduction1 :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateAuth("s006");
            Button4.OnClientClick = Window1.GetShowReference("~/systemmanage/Project_Introduction_new.aspx", "新增");
            Button5.OnClientClick = Grid1.GetNoSelectionAlertReference("至少选择一项！");
            BindGrid();
        }

        protected string GetEditUrl(object id, object name)
        {
            return Window1.GetShowReference("~/systemmanage/Project_Introduction_new.aspx?id=" + id, "编辑 - " + name);
        }
       

        #region BindGrid
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

            string sql = "select pj_id,pj_name,pj_id_erp,agent_name,cus_name,finish_flag,user_name_full,code_desp,cus_contact,b.contact_phone,cus_address from pjm_project_info a  left join  sys_customer b  on a.customer_id=b.cus_id left join sys_user c on a.sales_user_id=c.user_id left join sys_agent d on a.agent_id=d. agent_id left join sys_code e on a.area_code=e.code  ";
            sql += " where pj_name like '%" + TextBox5.Text + "%' order by pj_id desc";
            table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

            return table;
        }
        #endregion

        #region Events

        protected void ShowDetails(object sender, ExtAspNet.GridRowClickEventArgs e)
        {

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

                sql = "delete from pjm_project_info where pj_id in (" + sb.ToString().TrimEnd(',') + ");";
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

        protected void Window1_Close(object sender, EventArgs e)
        {
            //Alert.ShowInTop("弹出窗口关闭了！");
            Grid1.RefreshIFrame();
        }

        protected void OnSearchDept(object sender, EventArgs e)
        {
            BindGrid();
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }
        #endregion
    }
}