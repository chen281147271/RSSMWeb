using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using RSSMWeb.Code;
using System.Data.SqlClient;
namespace RSSMWeb.systemmanage
{
    public partial class Project_Introduction : PageBase
    {
        protected string oid;
        protected string Area_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCustomer();
                GetUserList();
                GetAgent();
                GetArea();
                LoadData();
                
            }
        }
        protected void GetArea()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetCodeSourcebygroup(8);

            dr_area.DataTextField = "Name";
            dr_area.DataValueField = "ID";

            dr_area.DataSource = mylist;

            
            dr_area.DataBind();

            //dr_area.SelectedValue = Area_id;


            //dr_dpt.Items.Remove(dr_dpt.Items.FindByValue(oid));


        }
        protected void GetAgent()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetAgentList();

            dr_agent.DataTextField = "Name";
            dr_agent.DataValueField = "ID";

            dr_agent.DataSource = mylist;

            dr_agent.DataBind();

            //dr_area.SelectedValue = Area_id;


            //dr_dpt.Items.Remove(dr_dpt.Items.FindByValue(oid));


        }
        protected void GetUserList()
        {
            List<RSSMWeb.Code.Utils.CustomClassForDropdownlist> mylist_username_dpt = Utils.GetUserListForDropdownlist_dpt();

            dr_sales.EnableSimulateTree = true;
            dr_sales.DataTextField = "Name";
            dr_sales.DataValueField = "ID";
            dr_sales.DataSimulateTreeLevelField = "Group";
            dr_sales.DataEnableSelectField = "Enableselect";

            dr_sales.DataSource = mylist_username_dpt;
            dr_sales.DataBind();
            dr_sales.SelectedValue = "0";


        }

        protected void GetCustomer()
        {
            List<RSSMWeb.Code.Utils.CustomClass> mylist = Utils.GetCustomerList();

            dr_Customer_No.DataTextField = "Name";
            dr_Customer_No.DataValueField = "ID";

            dr_Customer_No.DataSource = mylist;

            
            dr_Customer_No.DataBind();




        }
        private void LoadData()
        {
            try
            {
                // 关闭按钮的客户端脚本：
                // 1. 首先确认窗体中表单是否被修改（如果已经被修改，则弹出是否关闭的确认对话框）
                // 2. 然后关闭本窗体，回发父窗体
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                string vals = Request.Url.Query;
                if (vals == "")
                {
                    return;
                }
                oid = Request.QueryString.GetValues(0)[0];
                txt_address.Enabled = false;
                txt_telephone_number.Enabled = false;
                txt_Contacts.Enabled = false;

                string sql = "select pj_id,pj_name,pj_id_erp,agent_name,cus_name,finish_flag,user_name_full,code_desp,cus_contact,b.contact_phone,cus_address,a.area_code,a.agent_id,a.sales_user_id,a.customer_id from pjm_project_info a  left join  sys_customer b  on a.customer_id=b.cus_id left join sys_user c on a.sales_user_id=c.user_id left join sys_agent d on a.agent_id=d. agent_id left join sys_code e on a.area_code=e.code   ";
                sql += " where pj_id = '" + oid + "'";
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                if (!reader.HasRows)
                {
                    Alert.Show("ERP系统中没有找到该单号!");
                    return;
                }
                reader.Read();

              //  ,cus_name,cus_address,user_name_full,code_desp,agent_name,cus_contact,contact_phone,finish_flag
                txt_Project_No.Text = reader["pj_id_erp"].ToString();
                txt_Project_name.Text = reader["pj_name"].ToString();
                dr_Customer_No.SelectedValue = reader["customer_id"].ToString();
                txt_address.Text = reader["cus_address"].ToString();
                dr_sales.SelectedValue = reader["sales_user_id"].ToString();
                dr_area.SelectedValue = reader["area_code"].ToString();
                dr_agent.SelectedValue = reader["agent_id"].ToString();
                txt_Contacts.Text = reader["cus_contact"].ToString();
                txt_telephone_number.Text = reader["contact_phone"].ToString();
                ck_isover.Checked = Convert.ToBoolean(reader["finish_flag"]);


                //string sql = "select * from V_order ";
                //sql += " where 项目编号 = '" + txt_Project_No.Text.Trim() + "'";
                //SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransactionERP, System.Data.CommandType.Text, sql);
                //if (!reader.HasRows)
                //{
                //    Alert.Show("ERP系统中没有找到该单号!");
                //    return;
                //}
                //reader.Read();
                
                //    txt_Project_name.Text = reader["项目名称"].ToString();
                //    //txt_Odd_type.Text = reader["单别"].ToString();
                //    //txt_Odd_No.Text = reader["单号"].ToString();
                //    txt_Customer_No.Text = reader["客户编号"].ToString();
                //    txt_address.Text = reader["送货地址"].ToString();


                //    if (reader["状态"].ToString() == "未结束")
                //    {
                //        ck_isover.Checked = false;
                //    }
                //    else
                //    {
                //        ck_isover.Checked = true;
                //    }
                }
            
            catch (Exception e)
            {
                Alert.ShowInTop(e.Message);
            }
        }

        //protected void btnSaveContinue_Click(object sender, EventArgs e)
        //{
        //    // 1. 这里放置保存窗体中数据的逻辑


        //    // 2. 关闭本窗体，然后回发父窗体
        //  //  PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        //}
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {

            // 1. 这里放置保存窗体中数据的逻辑







            string top_flag = "0";
            if (ck_isover.Checked)
            {
                top_flag = "1";
            }
            string vals = Request.Url.Query;
            string sql = "";
            if (vals == "")
            {

                sql = "select * from pjm_project_info where pj_id_erp ='" + txt_Project_No.Text + "'";

                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                if (reader.HasRows)
                {
                    Alert.Show("改项目已存在系统中 请勿重复新增！");
                    return;
                }
                sql = "INSERT INTO pjm_project_info ";
                sql += "(pj_name, customer_id, agent_id, pj_id_erp, finish_flag, sales_user_id,area_code) ";
                sql += "VALUES   ('" + txt_Project_name.Text + "', '" + dr_Customer_No.SelectedValue + "', '" + dr_agent.SelectedValue + "', '" + txt_Project_No.Text + "'," + top_flag + ", " + dr_sales.SelectedValue + "," + dr_area.SelectedValue + ") ";

                //Alert.ShowInTop(sql);

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error！");
                    return;
                }
            }
            else
            {
                oid = Request.QueryString.GetValues(0)[0];
                sql = "update pjm_project_info set pj_name='" + txt_Project_name.Text + "',customer_id='" + dr_Customer_No.SelectedValue + "',agent_id='" + dr_agent.SelectedValue;
                sql += "',pj_id_erp='" + txt_Project_No.Text + "',finish_flag=" + top_flag + ",sales_user_id= " + dr_sales.SelectedValue + ",area_code=" + dr_area.SelectedValue;
                sql += " where pj_id = " + oid;

                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst != 1)
                {
                    Alert.ShowInTop("save error !");
                }
            }
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
         
        }


        protected void SearchErp()
        {

            if (txt_Project_No.Text == "")
            {
                Alert.Show("请填写ERP项目号!");
                return;
            }

            string sql = "select * from pjm_project_info where pj_id_erp ='" + txt_Project_No.Text+"'";

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

            if (reader.HasRows)
            {
                Alert.Show("改项目已存在系统中 请勿重复新增！");
                return;
            }
            

            sql = "select * from V_order ";
            sql += " where 项目编号 = '" + txt_Project_No.Text + "'";
            reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransactionERP, System.Data.CommandType.Text, sql);

            if (!reader.HasRows)
            {
                Alert.Show("ERP系统中没有找到该单号!");
                return;
            }
            reader.Read();

            txt_Project_name.Text = reader["项目名称"].ToString();
            if (Utils.GetUserCode(reader["业务人员"].ToString()) == "-1")
            {
                Alert.Show("该业务人员不存在 请为" + reader["业务人员"].ToString() + "注册后操作！");
                // PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                return;
            }
            else
                dr_sales.SelectedValue = Utils.GetUserCode(reader["业务人员"].ToString());

            string cus_erp_id = reader["客户编号"].ToString();
            sql = "select * from sys_customer";
            sql += " where cus_erp_id='" + cus_erp_id + "'";

            reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            if (!reader.HasRows)
            {
                sql = "  insert into sys_customer (cus_name,cus_erp_id) values('";
                sql += txt_Project_name.Text + "--系统自动生成 请维护','" + cus_erp_id + "')";

                int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

                if (i > 0)
                {
                    Alert.Show("系统已自动生成一条客户记录 请维护！");
                    sql = "select * from sys_customer where cus_erp_id='";
                    sql += cus_erp_id + "'";


                    reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                    reader.Read();
                    GetCustomer();


                }
                else
                {
                    Alert.Show("系统自动生成一条客户记录失败！");
                }



            }
            reader.Read();
            dr_Customer_No.SelectedValue = reader["cus_id"].ToString();

            change_Customer_No();



        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchErp();
        }

        protected void dr_Customer_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_Customer_No();
        }
        protected void change_Customer_No()
        {
            string sql = "select * from sys_customer ";
            sql += " where cus_id = '" + dr_Customer_No.SelectedValue + "'";
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);

            if (!reader.HasRows)
            {
                Alert.Show("客户表中不存在该记录!");
                return;
            }
            reader.Read();
            txt_address.Text = reader["cus_address"].ToString();
            txt_Contacts.Text = reader["cus_contact"].ToString();
            txt_telephone_number.Text = reader["contact_phone"].ToString();
        }
        

      
    }
}