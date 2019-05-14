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
namespace RSSMWeb.myjob
{
    public partial class MyMessage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_add.OnClientClick = Window1.GetShowReference("~/myjob/MyMessage_New.aspx", "新增");
            btn_delete.OnClientClick = Grid1.GetNoSelectionAlertReference("至少选择一项！");
            BindGrid();
        }
        private void BindGrid()
        {
            DataTable table = GetDataTable(0);

            Grid1.DataSource = table;
            Grid1.DataBind();

            table = GetDataTable(1);

            Grid2.DataSource = table;
            Grid2.DataBind();

        }
        /// <summary>
        /// 获取项目列表 1 已发送 0已收到的
        /// </summary>
        /// <returns></returns>
        protected DataTable GetDataTable( int flag)
        {
            DataTable table = new DataTable();

            string sql = "select message_title,message_id, message_content,message_create_time,msg_creator_id,msg_tgt_id,msg_tgt_type,msg_read_flag from sys_message ";
            if (flag == 0)
            {
                sql += " where message_content like '%" + txt_username.Text + "%' and msg_tgt_id=";
                sql += Page.Session["user_id"].ToString();
                sql += " order by message_create_time desc";
            }
            else
            {
                sql += " where message_content like '%" + TextBox1.Text + "%' and msg_creator_id=";
                sql += Page.Session["user_id"].ToString();
                sql += " order by message_create_time desc";
            }
            table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return table;
        }
        protected string GetEditUrl(object id, object name)
        {
            return Window1.GetShowReference("~/myjob/MyMessage_New.aspx?id=" + id, "编辑 - " + name);
            
            
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

                sql = "delete from sys_message where message_id in (" + sb.ToString().TrimEnd(',') + ");";
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

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        protected void Grid2_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
        }

        //protected void btnPressed_Click(object sender, EventArgs e)
        //{
        //    btnPressed.Pressed = true;
        //    btnPressed1.Pressed = false;
        //   // GetDataTable(0);
        //    BindGrid();
        //}
        //protected void btnPressed_Click1(object sender, EventArgs e)
        //{
        //    btnPressed1.Pressed = true;
        //    btnPressed.Pressed = false;
        // //   GetDataTable(1);
        //    BindGrid();
        //}

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "全部")
            {
                BindGrid();
            }
            else if (DropDownList1.SelectedItem.Text == "未读")
            {
                DataTable table = new DataTable();

                string sql = "select message_id,SubString(message_content,0,10) as message_content,message_create_time,msg_creator_id,msg_tgt_id,msg_tgt_type,msg_read_flag from sys_message ";
                sql += " where message_content like '%" + txt_username.Text + "%' and msg_tgt_id=";
                sql += Page.Session["user_id"].ToString();
                sql += " and msg_read_flag=0";
                sql += " order by message_create_time desc";
                table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                Grid1.DataSource = table;
                Grid1.DataBind();

            }
            else
            {
                DataTable table = new DataTable();

                string sql = "select message_id,SubString(message_content,0,10) as message_content,message_create_time,msg_creator_id,msg_tgt_id,msg_tgt_type,msg_read_flag from sys_message ";
                sql += " where message_content like '%" + txt_username.Text + "%' and msg_tgt_id=";
                sql += Page.Session["user_id"].ToString();
                sql += " and msg_read_flag=1";
                sql += " order by message_create_time desc";
                table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                Grid1.DataSource = table;
                Grid1.DataBind();
            }
        }

        protected void Grid1_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
           // Window1.GetShowReference("../grid/grid_iframe_window.aspx", "弹出窗口一");
            Window1.GetShowReference("~/myjob/MyMessage_New.aspx");
        }
      
    }
}