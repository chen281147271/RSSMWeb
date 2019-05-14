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
    public partial class Att : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //部门和员工没有维护！
            //List<RSSMWeb.Code.Utils.CustomClassForDropdownlist> mylist_username_dpt = Utils.GetUserListForDropdownlist_dpt();
            //DropDownList1.EnableSimulateTree = true;
            //DropDownList1.DataTextField = "Name";
            //DropDownList1.DataValueField = "ID";
            //DropDownList1.DataSimulateTreeLevelField = "Group";
            //DropDownList1.DataEnableSelectField = "Enableselect";

            //DropDownList1.DataSource = mylist_username_dpt;
            //DropDownList1.DataBind();
            //DropDownList1.SelectedValue = "0";
            if (!IsPostBack)
            {
                BTime.SelectedDate = System.DateTime.Now;
                ETime.SelectedDate = System.DateTime.Now;
                GetDataTable();
                BindGrid();
            }
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

            Grid1.DataSource = null;
            Grid1.PageIndex = 0;
            Grid1.DataBind();
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

            //string sql = "select a.org_id,a.org_name ,a.org_normal_name,a.org_manager_name,a.org_assist_name,a.is_top,b.org_name as father_org_id from sys_organize_info a  left join sys_organize_info b  on b.org_id=a.father_org_id ";
            //sql += " where a.org_name like '%" + TextBox5.Text + "%'";
            //table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            string sql = "select Badgenumber,name,CHECKTIME from USERINFO a left join CHECKINOUT b on a.userid=b.userid ";
            sql += " where CHECKTIME between # ";
            sql += BTime.Text;
            sql += " 00:00:00# and #";
            sql += ETime.Text;
            sql += " 23:59:59#";
            if (TextBox5.Text.Length > 0)
            {
                sql += " and (name like '%";
                sql += TextBox5.Text;
                sql += "%'or Badgenumber= '";
                sql += TextBox5.Text;
                sql += "')";
            }
            sql+=" order by a.userid,CHECKTIME desc";
           // table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransactionAtt, System.Data.CommandType.Text, sql);
            table = AccessHelper.dataTable(sql);

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
        #endregion

        protected void Grid1_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            PageIndex.Text = e.NewPageIndex.ToString();
            Grid1.PageIndex = e.NewPageIndex;
        }
    }
}