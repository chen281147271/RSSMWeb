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
using System.Data.SqlClient;
namespace RSSMWeb.systemmanage
{
    public partial class Func_Authority : PageBase
    {
        DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateAuth("s005");
            if (!IsPostBack)
            {
                BindGrid();
                change();
            }
           
        }
        #region BindGrid
        private void BindGrid()
        {
            table = IniGrid();

            Grid1.DataSource = table;
            Grid1.DataBind();

            List<RSSMWeb.Code.Utils.CustomClassForDropdownlist> mylist_username_dpt = Utils.GetUserListForDropdownlist_dpt();
            DropDownList3.EnableSimulateTree = true;
            DropDownList3.DataTextField = "Name";
            DropDownList3.DataValueField = "ID";
            DropDownList3.DataSimulateTreeLevelField = "Group";
            DropDownList3.DataEnableSelectField = "Enableselect";


            DropDownList3.DataSource = mylist_username_dpt;
            DropDownList3.DataBind();
            DropDownList3.SelectedValue = "0";

        }

        private static DataTable IniGrid()
        {
            DataTable table = new DataTable();
            DataColumn column1 = new DataColumn("Id", typeof(String));
            DataColumn column2 = new DataColumn("Name", typeof(String));
            DataColumn column3 = new DataColumn("Group", typeof(String));
            DataColumn column4 = new DataColumn("TreeLevel", typeof(int));
            DataColumn column5 = new DataColumn("EnableSelect", typeof(int));
            DataColumn column6 = new DataColumn("Depth", typeof(int));
            table.Columns.Add(column1);
            table.Columns.Add(column2);
            table.Columns.Add(column3);
            table.Columns.Add(column4);
            table.Columns.Add(column5);
            table.Columns.Add(column6);

            DataRow row = table.NewRow();
            row[0] = "ALL";
            row[1] = "网站功能表";
            row[2] = "1";
            row[3] = 0;
            row[4] = 0;
            row[5] = 27;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "p";
            row[1] = "项目管理";
            row[2] = "2";
            row[3] = 1;
            row[4] = 0;
            row[5] = 6;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "p001";
            row[1] = "项目计划";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "p002";
            row[1] = "项目管理";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "p003";
            row[1] = "项目报表";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "p004";
            row[1] = "代理商管理";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "p005";
            row[1] = "客户管理";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "p006";
            row[1] = "产品管理";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = "b";
            row[1] = "问题追踪";
            row[2] = "2";
            row[3] = 1;
            row[4] = 0;
            row[5] = 4;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "b001";
            row[1] = "问题管理";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "b002";
            row[1] = "问题报表";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "b003";
            row[1] = "问题EXCEL导入";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "b004";
            row[1] = "待定";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "d";
            row[1] = "研发管理";
            row[2] = "2";
            row[3] = 1;
            row[4] = 0;
            row[5] = 1;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = "d001";
            row[1] = "需求管理";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = "s";
            row[1] = "系统管理";
            row[2] = "2";
            row[3] = 1;
            row[4] = 0;
            row[5] = 7;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = "s001";
            row[1] = "系统设置";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "s002";
            row[1] = "文件管理";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "s003";
            row[1] = "用户管理";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "s004";
            row[1] = "角色管理";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "s005";
            row[1] = "权限管理";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "s006";
            row[1] = "项目导入";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "s007";
            row[1] = "组织架构";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = "m";
            row[1] = "我的任务";
            row[2] = "2";
            row[3] = 1;
            row[4] = 0;
            row[5] = 4;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = "m001";
            row[1] = "我的项目";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "m002";
            row[1] = "我的问题";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "m003";
            row[1] = "我的计划";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "m004";
            row[1] = "我的信息";
            row[2] = "3";
            row[3] = 2;
            row[4] = 0;
            table.Rows.Add(row);




            return table;
        }

        #endregion
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    sb.Append(Grid1.DataKeys[row][0].ToString());
                    sb.Append(",");
                }

                sql = "delete from sys_user where user_id in (" + sb.ToString().TrimEnd(',') + ");";
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
        protected void Getmanage_type()
        {

            
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetRIList();

            mylist.Insert(0, new RSSMWeb.Code.Utils.CustomClass("-1", "-------------请选择-------------", "0"));

            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "ID";



            DropDownList2.DataSource = mylist;
            DropDownList2.DataBind();
            DropDownList2.SelectedIndex = 0;

        }
        protected void GetOrg()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetOIList();
            mylist.Insert(0, new RSSMWeb.Code.Utils.CustomClass("-1", "-------------请选择-------------", "0"));

           

            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "ID";



            DropDownList2.DataSource = mylist;
            DropDownList2.DataBind();
            DropDownList2.SelectedIndex=0;

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            change();
            try
            {
                if (DropDownList1.SelectedItem.Text == "按部门"&& DropDownList2.SelectedValue!="-1")
                {
                    string sql = "select * from sys_func_authority ";
                    sql += " where og_id = " + DropDownList2.SelectedItem.Value + " and og_type=3002";
                    Search(sql);
                }
                else if (DropDownList1.SelectedItem.Text == "按角色" && DropDownList2.SelectedValue != "-1")
                {
                    string sql = "select * from sys_func_authority ";
                    sql += " where og_id = " + DropDownList2.SelectedItem.Value + " and og_type=3004";
                    Search(sql);
                }
            }
            catch
            {
                ;
            }
        }

        private void change()
        {
            DropDownList2.Items.Clear();
            if (DropDownList1.SelectedItem.Text == "按部门")
            {
                DropDownList3.Enabled = false;
                DropDownList2.Enabled = true;
                //btn_Search.Enabled = false;
                
                GetOrg();
            }
            else if (DropDownList1.SelectedItem.Text == "按角色")
            {
                DropDownList3.Enabled = false;
                DropDownList2.Enabled = true;
                //btn_Search.Enabled = false;
                Getmanage_type();
            }
            else
            {
                DropDownList3.Enabled = true;
                DropDownList2.Enabled = false;
                //btn_Search.Enabled = true;
            }
        }

        //protected void Grid1_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        //{
        //    if (e.CommandName == "AuthoritySelect")
        //    {

        //        //int i = Convert.ToInt32(e.CommandArgument.ToString());

        //        //int i = ((ExtAspNet.GridRow)((ExtAspNet.CheckBoxList)e.).NamingContainer).RowIndex;//(该方法不需要html中的绑定,取id.刚刚看到的,加上来,好方法.......)

        //        int i = e.RowIndex;
        //      //  ExtAspNet.TextBox tb = (ExtAspNet.TextBox)Grid1.Rows[i].FindControl("textbox3");

        //        //string str = tb.Text.Trim();
        //        //Response.Write(str);

        //    }


        //}

        protected void Grid1_RowClick(object sender, ExtAspNet.GridRowClickEventArgs e)
        {
           // ((ExtAspNet.CheckBoxField)Grid1.Rows[e.RowIndex].FindControl("cbxAuthority")).Checked = true;
          //  ExtAspNet.CheckBoxField myCheckBoxField = Grid1.FindColumn("cbxAuthority") as ExtAspNet.CheckBoxField;
          //  ExtAspNet.BoundField bf = (ExtAspNet.BoundField)Grid1.FindColumn("cbxAuthority");
           // if (bf.HeaderText)
         //   string aa = ;
          //  cbxAuthority.SetCheckedState(e.RowIndex, true);
            //int i = e.RowIndex;
            //bool EnableSelect = false;
            //string menuId = Convert.ToString(Grid1.DataKeys[i][0]);
            //string mname = Convert.ToString(Grid1.DataKeys[i][1]);
            //int Depth = Convert.ToInt32(Grid1.DataKeys[i][2]);
            //if (menuId == "s")
            //{
            //    foreach (int row in Grid1.SelectedRowIndexArray)
            //    {
            //        if (row == i)
            //        {
            //            EnableSelect = true;

            //        }
            //    }

            //    int AlreadyNum = 0;
            //    foreach (int row in Grid1.SelectedRowIndexArray)
            //    {
            //        for (int k = 0; k < Depth; k++)
            //        {
            //            if (row == k + i + 1)
            //            {
            //                AlreadyNum++;
            //            }
            //        }

            //    }
            //    int num = 0;
            //    if (EnableSelect)
            //    {
            //        int[] TaxRates = new int[Depth - AlreadyNum + Grid1.SelectedRowIndexArray.Length];
            //        foreach (int row in Grid1.SelectedRowIndexArray)
            //        {
            //            TaxRates[num++] = row;
            //        }
            //        for (int k = 0; k < Depth; k++)
            //        {
            //            TaxRates[num++] = k + e.RowIndex;
            //        }
            //        Grid1.SelectedRowIndexArray = TaxRates;
            //    }
            //    else
            //    {
            //        int[] TaxRates = new int[Grid1.SelectedRowIndexArray.Length - AlreadyNum];
            //        foreach (int row in Grid1.SelectedRowIndexArray)
            //        {
            //            bool b = false;
            //            for (int k = 0; k < Depth; k++)
            //            {

            //                if (row == k + i + 1)
            //                {
            //                    b = true;
            //                }
            //            }
            //            if (!b)
            //            {
            //                TaxRates[num++] = row;

            //            }
            //        }

            //        Grid1.SelectedRowIndexArray = TaxRates;
            //    }

            //}
            //else
            //{
            //    int num = 0;
            //    int[] TaxRates = new int[Grid1.SelectedRowIndexArray.Length + 1];
            //    foreach (int row in Grid1.SelectedRowIndexArray)
            //    {
            //        TaxRates[num++] = row;
            //    } TaxRates[num] = e.RowIndex;
            //}


        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Show")
            {
              //  ExtAspNet.LinkButtonField Authority = (ExtAspNet.LinkButtonField)Grid1.FindColumn("btn_cbxAuthority");

               // Authority._icon = Icon.BulletCross;
              //  Authority.Grid.Rows[e.RowIndex].
               


                ExtAspNet.CheckBoxField Authority = (ExtAspNet.CheckBoxField)Grid1.FindColumn("cbx_Authority");
                
                int i = e.RowIndex;
                bool EnableSelect = false;
                string menuId = Convert.ToString(Grid1.DataKeys[i][0]);
                string mname = Convert.ToString(Grid1.DataKeys[i][1]);
               // int Depth = Convert.ToInt32(Grid1.DataKeys[i][2]);
                string FirstWord = menuId.Substring(0, 1);
                int Depth = Convert.ToInt32(GetAuthorityTreeDepth(FirstWord));
                int FirstWordLoc = Convert.ToInt32(GetAuthorityTreeLoc(FirstWord));
                EnableSelect = Authority.GetCheckedState(e.RowIndex);
                int EndDepth = Convert.ToInt32(GetAuthorityTreeDepth("A"));
                bool AllSelect = true;
                if (menuId == "s" || menuId == "m" || menuId == "b" || menuId == "p" || menuId == "d"||menuId == "ALL")
                {
                    
                    for (int k = 1; k < Depth + 1; k++)
                    {
                        if (EnableSelect)
                            Authority.SetCheckedState(e.RowIndex + k, true);
                     
                        else
                            Authority.SetCheckedState(e.RowIndex + k, false);
                            Authority.SetCheckedState(0, false);
                    }
                    if (EnableSelect)
                    {
                           for (int k1 = 1; k1 < EndDepth + 1; k1++)
                        {
                            if (!Authority.GetCheckedState(k1))
                            {
                                AllSelect = false;
                                break;
                            }
                        }
                        if (AllSelect)
                        {
                            Authority.SetCheckedState(0, true);
                        }
                    }

                }
                else
                {
                    if (EnableSelect)
                    {

                        for (int k = FirstWordLoc + 1; k < Depth + 1 + 1; k++)
                        {
                            if (!Authority.GetCheckedState(k))
                            {
                                AllSelect = false;
                                break;
                            }
                        }
                        if (AllSelect)
                        {
                            Authority.SetCheckedState(FirstWordLoc, true);
                        }
                        for (int k = 1; k < EndDepth + 1; k++)
                        {
                            if (!Authority.GetCheckedState(k))
                            {
                                AllSelect = false;
                                break;
                            }
                        }
                        if (AllSelect)
                        {
                            Authority.SetCheckedState(0, true);
                        }
                    }
                    else
                    {
                        Authority.SetCheckedState(0, false);
                        Authority.SetCheckedState(FirstWordLoc, false);
                    }
                }


               

                
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList1.SelectedItem.Text == "按部门")
                {
                    string sql = "select * from sys_func_authority ";
                    sql += " where og_id = " + DropDownList2.SelectedItem.Value + " and og_type=3002";
                    Search(sql);
                }
                else if (DropDownList1.SelectedItem.Text == "按角色")
                {

                    string sql = "select * from sys_func_authority ";
                    sql += " where og_id = " + DropDownList2.SelectedItem.Value + " and og_type=3004";
                    Search(sql);
                }
            }
            catch
            {
                ;
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from sys_func_authority ";
            sql += " where og_id = " + DropDownList3.SelectedItem.Value + " and og_type=3001";
            Search(sql);

        }

        protected void Search(string strsql)
        {
            ExtAspNet.CheckBoxField Authority = (ExtAspNet.CheckBoxField)Grid1.FindColumn("cbx_Authority");


           // string sql = "select * from sys_func_authority ";
          //  sql += " where og_id = " + DropDownList3.SelectedItem.Value + "";
            string sql = strsql;
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            if (!reader.HasRows)
            {
                for(int i=0;i<=Convert.ToInt32(GetAuthorityTreeDepth("A"));i++)
                {
                    Authority.SetCheckedState(i,false);
                }
                
                if (DropDownList1.SelectedItem.Text == "按用户")
                {
                    sql = "  insert into sys_func_authority (og_id,og_type)values ('";
                    sql += DropDownList3.SelectedItem.Value;
                    sql += "',3001)";
                }
                else if (DropDownList1.SelectedItem.Text == "按部门")
                {
                    sql = "  insert into sys_func_authority (og_id,og_type)values ('";
                    sql += DropDownList2.SelectedItem.Value;
                    sql += "',3002)";
                }
                else if (DropDownList1.SelectedItem.Text == "按角色")
                {
                    sql = "  insert into sys_func_authority (og_id,og_type)values ('";
                    sql += DropDownList2.SelectedItem.Value;
                    sql += "',3004)";
                }

                //Alert.ShowInTop(sql);

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst < 0)
                {
                    Alert.ShowInTop("save error！");
                    return;
                }
                else
                {
                    Alert.Show("权限表中不存在该用户记录 系统已自动新增该用户！");
                }
                
            }
            while (reader.Read())
            {
                //p
                bool p001 = Convert.ToBoolean(reader["p001"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 1, p001);
                bool p002 = Convert.ToBoolean(reader["p002"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 2, p002);
                bool p003 = Convert.ToBoolean(reader["p003"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 3, p003);
                bool p004 = Convert.ToBoolean(reader["p004"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 4, p004);
                bool p005 = Convert.ToBoolean(reader["p005"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 5, p005);
                bool p006 = Convert.ToBoolean(reader["p006"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 6, p006);
                if (p001 && p002 && p003 && p004 && p005 && p006)
                {
                    Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")), true);
                }
                else
                {
                    Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")), false);
                }

                //b
                bool b001 = Convert.ToBoolean(reader["b001"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b")) + 1, b001);
                bool b002 = Convert.ToBoolean(reader["b002"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b")) + 2, b002);
                bool b003 = Convert.ToBoolean(reader["b003"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b")) + 3, b003);
                bool b004 = Convert.ToBoolean(reader["b004"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b")) + 4, b004);
                if (b001 && b002 && b003 && b004)
                {
                    Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b")), true);
                }
                else
                {
                    Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b")), false);
                }

                //d
                bool d001 = Convert.ToBoolean(reader["d001"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("d")) + 1, d001);
                if (d001)
                {
                    Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("d")), true);
                }
                else
                {
                    Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("d")), false);
                }

                //s
                bool s001 = Convert.ToBoolean(reader["s001"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 1, s001);
                bool s002 = Convert.ToBoolean(reader["s002"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 2, s002);
                bool s003 = Convert.ToBoolean(reader["s003"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 3, s003);
                bool s004 = Convert.ToBoolean(reader["s004"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 4, s004);
                bool s005 = Convert.ToBoolean(reader["s005"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 5, s005);
                bool s006 = Convert.ToBoolean(reader["s006"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 6, s006);
                bool s007 = Convert.ToBoolean(reader["s007"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 7, s007);
                if (s001 && s002 && s003 && s004 && s005 && s006 && s007)
                {
                    Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")), true);
                }
                else
                {
                    Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")), false);
                }


                //m
                bool m001 = Convert.ToBoolean(reader["m001"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("m")) + 1, m001);
                bool m002 = Convert.ToBoolean(reader["m002"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("m")) + 2, m002);
                bool m003 = Convert.ToBoolean(reader["m003"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("m")) + 3, m003);
                bool m004 = Convert.ToBoolean(reader["m004"]);
                Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("m")) + 4, m004);
                if (m001 && m002 && m003 && m004)
                {
                    Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("m")), true);
                }
                else
                {
                    Authority.SetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("m")), false);
                }

                if (Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p"))) && Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b"))) && Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b"))) && Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("d"))) && Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s"))) && Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("m"))))
                {
                    Authority.SetCheckedState(0, true);
                }
                else
                {
                    Authority.SetCheckedState(0, false);
                }

            }
        }
        

        protected void btn_Search_Click(object sender, EventArgs e)
        {
           
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            ExtAspNet.CheckBoxField Authority = (ExtAspNet.CheckBoxField)Grid1.FindColumn("cbx_Authority");

            if (DropDownList3.SelectedItem.Value != "")
            {
                string sql = "update sys_func_authority set p001='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 1);
                       sql += "',p002='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 2);
                       sql += "',p003='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 3);
                       sql += "',p004='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 4);
                       sql += "',p005='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 5);
                       sql += "',p006='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("p")) + 6);
                       sql += "',b001='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b")) + 1);
                       sql += "',b002='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b")) + 2);
                       sql += "',b003='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b")) + 3);
                       sql += "',b004='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("b")) + 4);
                       sql += "',d001='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("d")) + 1);
                       sql += "',s001='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 1);
                       sql += "',s002='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 2);
                       sql += "',s003='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 3);
                       sql += "',s004='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 4);
                       sql += "',s005='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 5);
                       sql += "',s006='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 6);
                       sql += "',s007='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("s")) + 7);
                       sql += "',m001='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("m")) + 1);
                       sql += "',m002='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("m")) + 2);
                       sql += "',m003='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("m")) + 3);
                       sql += "',m004='";
                       sql += Authority.GetCheckedState(Convert.ToInt32(GetAuthorityTreeLoc("m")) + 4);
                       sql +="' where og_id = '";
                       if (DropDownList1.SelectedItem.Text == "按用户")
                       {
                           sql += DropDownList3.SelectedItem.Value;
                           sql += "' and og_type=3001";
                       }
                       else if (DropDownList1.SelectedItem.Text == "按部门")
                       {
                           sql += DropDownList2.SelectedItem.Value;
                           sql += "' and og_type=3002";
                       }
                       else if (DropDownList1.SelectedItem.Text == "按角色")
                       {
                           sql += DropDownList2.SelectedItem.Value;
                           sql += "' and og_type=3004";
                       }

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst < 0)
                {
                    Alert.ShowInTop("save error！");
                    return;
                }
                else
                {
                    Alert.Show("修改成功！");
                }
            }
        }

        

    }
}