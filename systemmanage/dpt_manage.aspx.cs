using System;
using ExtAspNet;
using System.Data;
using RSSMWeb.Code;
using System.Text;


namespace RSSMWeb.systemmanage
{
    public partial class dpt_manage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateAuth("s007");
            Button4.OnClientClick = Window1.GetShowReference("~/systemmanage/dpt_new.aspx", "新增");
            Button5.OnClientClick = Grid1.GetNoSelectionAlertReference("至少选择一项！");
            BindGrid();
        }

        protected string GetEditUrl(object id, object name)
        {
            return Window1.GetShowReference("~/systemmanage/dpt_new.aspx?id=" + id, "编辑 - " + name);
        }
        protected string GetOIName(object id)
        {


            return Utils.GetOIName(Convert.ToInt32(id));
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

            string sql = "select a.org_id,a.org_name ,a.org_normal_name,a.org_manager_name,a.org_assist_name,a.is_top,b.org_name as father_org_id from sys_organize_info a  left join sys_organize_info b  on b.org_id=a.father_org_id ";
            sql += " where a.org_name like '%" + TextBox5.Text + "%'";
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
            string sql="";
            try
            {
                StringBuilder sb = new StringBuilder();
                int startIndex = Grid1.PageIndex * Grid1.PageSize;
                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    sb.Append(Grid1.DataKeys[row + startIndex][0].ToString());
                    sb.Append(",");
                }

                sql = "delete from sys_organize_info where org_id in (" + sb.ToString().TrimEnd(',') + ");";
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
                Alert.ShowInTop(ex.Message+" : sql = "+sql);
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
        #endregion


    }
}