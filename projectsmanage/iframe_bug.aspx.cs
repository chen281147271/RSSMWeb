using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Data;

namespace RSSMWeb.projectsmanage
{
    public partial class iframe_bug : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Button4.OnClientClick = Window1.GetShowReference("~/bugTracer/create_bug.aspx", "新增");
            BindGrid();
        }

        protected string GetEditUrl(object id, object name)
        {
            return Window1.GetShowReference("~/bugTracer/bug_details.aspx?id=" + id, "编辑 - " + name);
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
            table.Columns.Add(new DataColumn("bug_id", typeof(String)));
            table.Columns.Add(new DataColumn("bug_title", typeof(String)));
            table.Columns.Add(new DataColumn("bug_create_time", typeof(DateTime)));
            table.Columns.Add(new DataColumn("create_person_name", typeof(String)));
            table.Columns.Add(new DataColumn("bug_state", typeof(String)));
            table.Columns.Add(new DataColumn("deal_person_name", typeof(String)));
            table.Columns.Add(new DataColumn("bug_PDBelong", typeof(String)));
            table.Columns.Add(new DataColumn("bug_PJBelong", typeof(String)));


            DataRow row = table.NewRow();

            row[0] = "11";
            row[1] = "电磁铁问题";
            row[2] = DateTime.Now.AddDays(-100);
            row[3] = "詹锦云";
            row[4] = "开启";
            row[5] = "刘克勇";
            row[6] = "标准盒剂机";
            row[7] = "深圳市第二人民医院";
            table.Rows.Add(row);

            return table;
        }
        #endregion

        #region Events

        protected void ShowDetails(object sender, ExtAspNet.GridRowClickEventArgs e)
        {
           Alert.ShowInTop(String.Format("你点击了第 {0} 行（双击）", e.RowIndex));
            Window1.GetShowReference("~/bugTracer/create_bug.aspx", "查看");
        }

        protected void Window1_Close(object sender, EventArgs e)
        {
            Alert.ShowInTop("弹出窗口关闭了！");
        }
        #endregion
    }
}