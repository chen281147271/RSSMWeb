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


namespace RSSMWeb.developmanage
{
    public partial class bugCombine : PageBase
    {
        public List<RSSMWeb.Code.Utils.CustomClass> userList;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateAuth("b002");
            Button4.OnClientClick = Window1.GetShowReference("~/bugTracer/create_bug.aspx", "新增");
            
            BindGrid();
            if (!IsPostBack)
            {
                BindAreaDP();
            }
        }

        protected string GetEditUrl(object id, object name,object checkType)
        {
            if (Convert.ToInt32(checkType)==1)
            {
                return Window1.GetShowReference("~/bugTracer/bug_details.aspx?id=" + id+"&checkType=1", "查看 - " + name);
            }
            return Window1.GetShowReference("~/bugTracer/bug_details.aspx?id=" + id + "&checkType=2", "编辑 - " + name);
        }

        protected void Grid1_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        #region BindGrid
        private void BindGrid()
        {
            DataTable table = GetDataTable();

            Grid1.DataSource = table;
            Grid1.DataBind();

        }
        private void BindAreaDP()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetUserList();
            RSSMWeb.Code.Utils.CustomClass tmp = new RSSMWeb.Code.Utils.CustomClass("0","不限","0");
            mylist.Insert(0, tmp);
            List<RSSMWeb.Code.Utils.CustomClassForDropdownlist> mylist_username_dpt = Utils.GetUserListForDropdownlist_dpt();

            DropDownList1.EnableSimulateTree = true;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataSimulateTreeLevelField = "Group";
            DropDownList1.DataEnableSelectField = "Enableselect";

            DropDownList1.DataSource = mylist_username_dpt;
            DropDownList1.DataBind();
            DropDownList1.SelectedValue = "0";

            DropDownList5.EnableSimulateTree = true;
            DropDownList5.DataTextField = "Name";
            DropDownList5.DataValueField = "ID";
            DropDownList5.DataSimulateTreeLevelField = "Group";
            DropDownList5.DataEnableSelectField = "Enableselect";

            DropDownList5.DataSource = mylist_username_dpt;
            DropDownList5.DataBind();
            DropDownList5.SelectedValue = "0";

            mylist.Clear();
            mylist = Utils.GetPJList();
            tmp.ID = "0";
            tmp.Name = "不限";
            mylist.Insert(0, tmp);

            DropDownList6.DataTextField = "Name";
            DropDownList6.DataValueField = "ID";
            DropDownList6.DataSource = mylist;
            DropDownList6.DataBind();
            DropDownList6.SelectedValue = "0";

            mylist.Clear();
            mylist = Utils.GetPDList();
            tmp.ID = "0";
            tmp.Name = "不限";
            mylist.Insert(0, tmp);

            DropDownList7.DataTextField = "Name";
            DropDownList7.DataValueField = "ID";
            DropDownList7.DataSource = mylist;
            DropDownList7.DataBind();
            DropDownList7.SelectedValue = "0";
        }
        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <returns></returns>
        protected DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            string sql = "";
            if (CombineFlag.Checked)
            {
                sql = "";
            }
            else
            {
                sql = "SELECT t2.bug_id AS bug_id,t2.bug_title AS bug_title, t2.bug_type AS bug_type ,t1.create_time AS create_time,";
                sql += " t1.create_user_id AS create_user_id,t1.bug_state AS bug_state ,t1.occur_time AS occur_time,t1.process_type AS process_type,";
                sql += " t1.PRI AS PRI , t1.next_user_id AS next_user_id ,t3.pj_name AS pj_name ,t4.pd_name AS pd_name,";
                sql += " t5.user_name_full as create_user_name,t6.user_name_full as next_user_name,t1.detail_id as detail_id";

                sql += " FROM bug_detail_info t1 LEFT JOIN bug_main_info t2  ON t1.bug_id = t2.bug_id LEFT JOIN pjm_project_info t3 ON t1.pj_id = t3.pj_id ";
                sql += " LEFT JOIN pjm_product_info t4 ON t1.pd_id = t4.pd_id ";
                sql += " LEFT JOIN sys_user t5 ON t1.create_user_id = t5.user_id LEFT JOIN sys_user t6 ON t1.next_user_id = t6.user_id ";
                sql += " where t2.bug_title like '%" + TextBox8.Text + "%'";

                if (nbBugId.Text != "" && nbBugId.Text != "0")
                {
                    sql += " and t1.bug_id = " + nbBugId.Text;
                }
                if (DropDownList3.SelectedItem.Value != "0")
                {
                    sql += " and t2.bug_type = " + DropDownList3.SelectedItem.Value;
                }
                if (DropDownList1.SelectedItem != null)
                {
                    if (DropDownList1.SelectedItem.Value != "0")
                    {
                        sql += " and t1.create_user_id = " + DropDownList1.SelectedItem.Value;
                    }
                }
                if (DropDownList2.SelectedItem.Value != "0")
                {
                    sql += " and t1.bug_state = " + DropDownList2.SelectedItem.Value;
                }
                if (DropDownList4.SelectedItem.Value != "0")
                {
                    sql += " and t1.process_type = " + DropDownList4.SelectedItem.Value;
                }
                if (DropDownList5.SelectedItem != null)
                {
                    if (DropDownList5.SelectedItem.Value != "0")
                    {
                        sql += " and t1.next_user_id = " + DropDownList5.SelectedItem.Value;
                    }
                }
                if (DropDownList6.SelectedItem != null)
                {
                    if (DropDownList6.SelectedItem.Value != "0")
                    {
                        sql += " and t1.pj_id = " + DropDownList6.SelectedItem.Value;
                    }
                }
                if (DropDownList6.SelectedItem != null)
                {
                    if (DropDownList7.SelectedItem.Value != "0")
                    {
                        sql += " and t1.pd_id = " + DropDownList7.SelectedItem.Value;
                    }
                }
                sql += " order by detail_id desc; ";
            }
            table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
           // Alert.ShowInTop(sql);
            return table;
        }
        #endregion

        #region Events

        protected void ShowDetails(object sender, ExtAspNet.GridRowClickEventArgs e)
        {
           // Alert.ShowInTop(String.Format("你点击了第 {0} 行（双击）", e.RowIndex));
           // Window1.GetShowReference("~/bugTracer/create_bug.aspx", "查看");
        }

        protected void Window1_Close(object sender, EventArgs e)
        {
            //Alert.ShowInTop("弹出窗口关闭了！");
        }

        protected void CombineBugs(object sender, EventArgs e)
        {
            //Alert.ShowInTop("弹出窗口关闭了！");
            StringBuilder sb = new StringBuilder();
            string srcId="0";
            int tnum = 0;
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                srcId = Grid1.DataKeys[row][1].ToString();
                sb.Append(srcId);
                sb.Append(",");
                tnum++;
            }
            if (tnum < 2)
            {
                Alert.ShowInTop("合并数台少.");
            }
            string sql = "UPDATE bug_detail_info SET bug_id = (SELECT t2.bug_id FROM bug_detail_info t2 WHERE t2.detail_id = " + srcId + ")  ";
            sql += "WHERE detail_id in (" + sb.ToString().TrimEnd(',') + ")";
            //Alert.ShowInTop(sql);
            int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            if (rst < 0)
            {
                Alert.ShowInTop("save error !");
            }
            
            sql = "UPDATE bug_main_info SET sub_bug_count = sub_bug_count + 1 WHERE bug_id = 1;";
            Alert.ShowInTop("合并成功:" + sb.ToString().TrimEnd(','));
            BindGrid();
        }
        #endregion
    }
}