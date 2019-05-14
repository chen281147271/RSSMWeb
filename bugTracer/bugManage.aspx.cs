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


namespace RSSMWeb.bugTracer
{
    public partial class bugManage : PageBase
    {
        public List<RSSMWeb.Code.Utils.CustomClass> userList;
        protected void Page_Load(object sender, EventArgs e)
        {



            ValidateAuth("b001");
            Button4.OnClientClick = Window1.GetShowReference("~/bugTracer/create_bug.aspx", "新增");

            if (!IsPostBack)
            {
                PageIndex.Text = "0";
               // Page.Session.Add("Sort", "0");
               // Page.Session.Add("SortDirection", "desc");

                BindAreaDP();
                //我的问题
                try
                {
                    string detail_id = Request.QueryString.GetValues(0)[0];
                    if (detail_id == "1")
                    {
                        string name = Page.Session["user_id"].ToString();
                        DropDownList5.SelectedValue = name;
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
                Row_Colour_Screen();
                
                Page.Session["iniGrid"] = 0;
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
            //highlightRows.Text = "";
            //highlightRows1.Text = "";
            //highlightRows2.Text = "";
           
            //string[] split = highlightRows_bak.Text.Split(new Char[] { ',' });
            //highlightRows.Text = "";
            //for (int i = 0; i < split.Length-1; i++)
            //{
            //    if (Convert.ToInt32(split[i]) >= 15 * (e.NewPageIndex) && Convert.ToInt32(split[i]) < 15 * (e.NewPageIndex + 1))
            //    {
            //        highlightRows.Text += split[i]+",";
            //    }
            //}
            PageIndex.Text = e.NewPageIndex.ToString();
            Row_Colour_Screen();
            Grid1.PageIndex = e.NewPageIndex;
                
        //    BindGrid();
        }

        #region BindGrid
        private void BindGrid()
        {
            DataTable table = GetDataTable(0, "desc");

            highlightRows.Text = "";
            highlightRows1.Text = "";
            highlightRows2.Text = "";

            // 1.设置总项数
           //Grid1.RecordCount = GetTotalCount();
            
            // 2.获取当前分页数据
          //  DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);


            Grid1.DataSource = table;
            Grid1.DataBind();
            Row_Colour_Screen();

        }
        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            return GetDataTable(Convert.ToInt32(Page.Session["Sort"].ToString()), Page.Session["SortDirection"].ToString()).Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {
            DataTable source = GetDataTable(Convert.ToInt32(Page.Session["Sort"].ToString()), Page.Session["SortDirection"].ToString());

            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
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
        /// 获取项目列表 Sort 0 按创建时间 1按主题 2所属项目
        /// </summary>
        /// <returns></returns>
        protected DataTable GetDataTable(int Sort, string SortDirection)
        {
            DataTable table = new DataTable();
            string sql = "";
            if (CombineFlag.Checked)
            {
                sql = "";
            }
            else
            {
                sql = "SELECT DISTINCT a.* FROM(";

                sql += "SELECT  t2.bug_id AS bug_id,t2.bug_title AS bug_title, t2.bug_type AS bug_type ,t1.create_time AS create_time,";
                sql += " t1.create_user_id AS create_user_id,t1.bug_state AS bug_state ,t1.occur_time AS occur_time,t1.process_type AS process_type,";
                sql += " t1.PRI AS PRI , t1.next_user_id AS next_user_id ,t3.pj_name AS pj_name ,t4.pd_name AS pd_name,";
                sql += " t5.user_name_full as create_user_name,t6.user_name_full as next_user_name,t1.detail_id as detail_id,";
                //颜色
                sql += " t1.expect_time,t1.Star_Time,t1.Finish_Time,";
                //附件标识
                sql += "t7.ref_count";

                sql += " FROM bug_detail_info t1 LEFT JOIN bug_main_info t2  ON t1.bug_id = t2.bug_id LEFT JOIN pjm_project_info t3 ON t1.pj_id = t3.pj_id ";
                sql += " LEFT JOIN pjm_product_info t4 ON t1.pd_id = t4.pd_id ";
                sql += " LEFT JOIN sys_user t5 ON t1.create_user_id = t5.user_id LEFT JOIN sys_user t6 ON t1.next_user_id = t6.user_id ";
                sql += " LEFT JOIN sys_upload_file t7 ON  t7.detail_id=t1.detail_id";
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

                sql += ") AS a ";
                if (Sort == 0)
                {
                    sql += " order by a.detail_id  "+SortDirection;
                }
                else if (Sort == 1)
                {
                    sql += " order by a.bug_title "+SortDirection;
                }
                else if (Sort == 2)
                {
                    sql += " order by a.pj_name "+SortDirection;
                }
                else if (Sort == 3)
                {
                    sql += " order by a.create_user_name " + SortDirection;
                }
            }
            table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
           // Alert.ShowInTop(sql);
            Page.Session["Sort"] = Sort;
            Page.Session["SortDirection"] = SortDirection;
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
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            highlightRows.Text = "";
            highlightRows1.Text = "";
            highlightRows2.Text = "";

            if (sortField == "create_time")
            {
                DataTable table = GetDataTable(0, sortDirection);

            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);


            Grid1.DataSource = view1;
            Grid1.DataBind();
           
            }
            else if (sortField == "bug_title")
            {
                DataTable table = GetDataTable(1, sortDirection);

                Grid1.DataSource = table.DefaultView;
                Grid1.DataBind();
            }
            else if (sortField == "pj_name")
            {
                DataTable table = GetDataTable(2, sortDirection);
                Grid1.DataSource = table.DefaultView;

                Grid1.DataBind();
            }
            else if (sortField == "create_user_name")
            {
                DataTable table = GetDataTable(3, sortDirection);
                Grid1.DataSource = table.DefaultView;

                Grid1.DataBind();
            }
            Row_Colour_Screen();
        }
        protected void Grid1_Sort(object sender, ExtAspNet.GridSortEventArgs e)
        {
            BindGridWithSort(e.SortField, e.SortDirection);
        }
        #endregion

        protected void Button2_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    //    private void BindGrid()
    //  {
    // // 1.设置总项数
    //  Grid1.RecordCount = GetTotalCount();
    
    // // 2.获取当前分页数据
    //  DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);
    
    // // 3.绑定到Grid
    //    Grid1.DataSource = table;
    //    Grid1.DataBind();
    //}

        private void Row_Colour(GridPreRowEventArgs e)
        {
            // e.DataItem  -> System.Data.DataRowView or custom class.
            // e.RowIndex -> Current row index.
            // e.Values -> Rendered html for each column of this row.

            string state = "";
            string expect = "";
            string Star_Time = "";
            string Finish_Time = "";
            string Create_Time = "";
            string date = DateTime.Now.ToString();

            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                //e.Values[1] = String.Format("Bound - {0}", row["MyValue"]);
                // int entranceYear = Convert.ToInt32(row["EntranceYear"]);


                state = GetSysCode(Convert.ToInt32(row["bug_state"].ToString()));
                expect = row["expect_time"].ToString();
                Star_Time = row["Star_Time"].ToString();
                Finish_Time = row["Finish_Time"].ToString();
                Create_Time = row["create_time"].ToString();
                if (state != "废弃")
                {
                    if (expect.Length != 0 && Finish_Time.Length != 0)
                    {
                        if (DateTime.Parse(Finish_Time) > DateTime.Parse(expect))
                        {
                            highlightRows.Text += e.RowIndex.ToString() + ",";
                            highlightRows_bak.Text = highlightRows.Text;
                            highlightRows1_bak.Text = highlightRows1.Text;
                            highlightRows2_bak.Text = highlightRows2.Text;
                            return;
                        }
                    }
                    else if (expect.Length != 0 && Finish_Time.Length == 0)
                    {
                        if (DateTime.Parse(date) >= DateTime.Parse(expect) )
                        {
                            highlightRows.Text += e.RowIndex.ToString() + ",";
                            highlightRows_bak.Text = highlightRows.Text;
                            highlightRows1_bak.Text = highlightRows1.Text;
                            highlightRows2_bak.Text = highlightRows2.Text;
                            return;
                        }
                    }
                }

               if (state == "新增")
                {
                    
                        if ((int)(DateTime.Parse(date) - DateTime.Parse(Create_Time)).TotalDays > 2)
                        {
                            highlightRows2.Text += e.RowIndex.ToString() + ",";
                            highlightRows_bak.Text = highlightRows.Text;
                            highlightRows1_bak.Text = highlightRows1.Text;
                            highlightRows2_bak.Text = highlightRows2.Text;
                            return;
                        }
                    
                }else if (Star_Time.Length != 0)
                    {
                        if ((int)(DateTime.Parse(Star_Time) - DateTime.Parse(Create_Time)).TotalDays > 2)
                        {
                            highlightRows2.Text += e.RowIndex.ToString() + ",";
                            highlightRows_bak.Text = highlightRows.Text;
                            highlightRows1_bak.Text = highlightRows1.Text;
                            highlightRows2_bak.Text = highlightRows2.Text;
                           return;
                        }
                    }
                   

                if (state == "关闭")
                {
                    highlightRows1.Text += e.RowIndex.ToString() + ",";
                }

                highlightRows_bak.Text = highlightRows.Text;
                highlightRows1_bak.Text = highlightRows1.Text;
                highlightRows2_bak.Text = highlightRows2.Text;
                
                //if (entranceYear >= 2006)
                //{
                //    highlightRows.Text += e.RowIndex.ToString() + ",";
                //}
            }
        }

        protected void Grid1_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {


            Row_Colour(e);
            //// e.DataItem  -> System.Data.DataRowView or custom class.
            //// e.RowIndex -> Current row index.
            //// e.Values -> Rendered html for each column of this row.

            //string state = "";
            //string expect = "";
            //string Star_Time = "";
            //string Finish_Time = "";
            //string Create_Time = "";
            //string date = DateTime.Now.ToString();

            //DataRowView row = e.DataItem as DataRowView;
            //if (row != null)
            //{
            //    //e.Values[1] = String.Format("Bound - {0}", row["MyValue"]);
            //   // int entranceYear = Convert.ToInt32(row["EntranceYear"]);

                
            //    state = GetSysCode(Convert.ToInt32(row["bug_state"].ToString()));
            //    expect = row["expect_time"].ToString();
            //    Star_Time = row["Star_Time"].ToString();
            //    Finish_Time = row["Finish_Time"].ToString();
            //    Create_Time = row["create_time"].ToString();
            //    if (state != "关闭" && state != "已解决" && state != "废弃")
            //    {
            //        if (expect.Length != 0 && Finish_Time.Length!=0)
            //        {
            //            if (DateTime.Parse(date) > DateTime.Parse(expect) || DateTime.Parse(Finish_Time) > DateTime.Parse(expect))
            //            {
            //                highlightRows.Text += e.RowIndex.ToString() + ",";
            //                return;
            //            }
            //        }
            //    }
                
            //    if (state == "新增")
            //    {
            //        if (Star_Time.Length != 0)
            //        {
            //            if ((int)(DateTime.Parse(Star_Time) - DateTime.Parse(Create_Time)).TotalDays > 2)
            //            {
            //                highlightRows2.Text += e.RowIndex.ToString() + ",";
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            if ((int)(DateTime.Parse(date) - DateTime.Parse(Create_Time)).TotalDays > 2)
            //            {
            //                highlightRows2.Text += e.RowIndex.ToString() + ",";
            //                return;
            //            }
            //        }
            //    }

            //    if (state == "关闭")
            //    {
            //        highlightRows1.Text += e.RowIndex.ToString() + ",";
            //    }
            //    //if (entranceYear >= 2006)
            //    //{
            //    //    highlightRows.Text += e.RowIndex.ToString() + ",";
            //    //}
            //}
        }
        private void Row_Colour_Screen()
        {
            string[] split = highlightRows_bak.Text.Split(new Char[] { ',' });
            string[] split1 = highlightRows1_bak.Text.Split(new Char[] { ',' });
            string[] split2 = highlightRows2_bak.Text.Split(new Char[] { ',' });
            highlightRows.Text = "";
            highlightRows1.Text = "";
            highlightRows2.Text = "";
            for (int i = 0; i < split.Length - 1; i++)
            {
                if (Convert.ToInt32(split[i]) >= 15 * (Convert.ToInt32(PageIndex.Text)) && Convert.ToInt32(split[i]) < 15 * (Convert.ToInt32(PageIndex.Text) + 1))
                {
                    highlightRows.Text += (Convert.ToInt32(split[i]) - 15 * (Convert.ToInt32(PageIndex.Text))).ToString() + ",";
                }
            }
            for (int i = 0; i < split1.Length - 1; i++)
            {
                if (Convert.ToInt32(split1[i]) >= 15 * (Convert.ToInt32(PageIndex.Text)) && Convert.ToInt32(split1[i]) < 15 * (Convert.ToInt32(PageIndex.Text) + 1))
                {
                    highlightRows1.Text += (Convert.ToInt32(split1[i]) - 15 * (Convert.ToInt32(PageIndex.Text))).ToString() + ",";
                }
            }
            for (int i = 0; i < split2.Length - 1; i++)
            {
                if (Convert.ToInt32(split2[i]) >= 15 * (Convert.ToInt32(PageIndex.Text)) && Convert.ToInt32(split2[i]) < 15 * (Convert.ToInt32(PageIndex.Text) + 1))
                {
                    highlightRows2.Text += (Convert.ToInt32(split2[i]) - 15 * (Convert.ToInt32(PageIndex.Text))).ToString() + ",";
                }
            }
        }

    }
}