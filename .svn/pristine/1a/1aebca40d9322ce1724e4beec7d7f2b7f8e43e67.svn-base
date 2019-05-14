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
    public partial class iframe_info : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();

            }

        }

        #region BindGrid
        private void BindGrid()
        {
            DataTable table = GetDataTable();
            DataTable table2 = GetDataTable2();

            Grid1.DataSource = table;
            Grid1.DataBind();

            Grid2.DataSource = table2;
            Grid2.DataBind();

        }

        protected DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("subpj_state", typeof(bool)));
            table.Columns.Add(new DataColumn("subpj_id", typeof(String)));
            table.Columns.Add(new DataColumn("pd_name", typeof(String)));
            table.Columns.Add(new DataColumn("subpj_unit", typeof(String)));
            table.Columns.Add(new DataColumn("subpj_create_time", typeof(DateTime)));
            table.Columns.Add(new DataColumn("business_person_name", typeof(String)));
            table.Columns.Add(new DataColumn("order_num", typeof(Decimal)));
            table.Columns.Add(new DataColumn("finish_num", typeof(Decimal)));
            table.Columns.Add(new DataColumn("unfinish_num", typeof(Decimal)));
            table.Columns.Add(new DataColumn("gift_num", typeof(Decimal)));
            table.Columns.Add(new DataColumn("finish_gift_num", typeof(Decimal)));


            DataRow row = table.NewRow();

            row[0] = true;
            row[1] = "20131021001";
            row[2] = "深圳市二院外传输线";
            row[3] = "WH025-s00-000a";
            row[4] = DateTime.Now.AddDays(-80);
            row[5] = "王庆磊";
            row[6] = 1;
            row[7] = 0;
            row[8] = 1; /*new Guid();*/
            row[9] = 0;
            row[10] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = false;
            row[1] = "20131021001";
            row[2] = "智能药价包装木箱";
            row[3] = "WH025-s01-000a";
            row[4] = DateTime.Now.AddDays(-80);
            row[5] = "王庆磊";
            row[6] = 2;
            row[7] = 1;
            row[8] = 1; /*new Guid();*/
            row[9] = 3;
            row[10] = 0;
            table.Rows.Add(row);

            return table;
        }

        protected DataTable GetDataTable2()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("oper_info", typeof(String)));
            table.Columns.Add(new DataColumn("oper_time", typeof(DateTime)));
            table.Columns.Add(new DataColumn("oper_person", typeof(String)));
            table.Columns.Add(new DataColumn("next_person", typeof(String)));

            DataRow row = table.NewRow();

            row[0] = "提交项目启动通知书";
            row[1] = DateTime.Now.AddDays(-80);
            row[2] = "单宝莉";
            row[3] = "单宝莉";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "erp标准产品下单成功";
            row[1] = DateTime.Now.AddDays(-78);
            row[2] = "单宝莉";
            row[3] = "项目实施部";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "提交项目实施计划书";
            row[1] = DateTime.Now.AddDays(-75);
            row[2] = "陈灿良";
            row[3] = "魏金海";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "提交数据采集资料";
            row[1] = DateTime.Now.AddDays(-65);
            row[2] = "魏金海";
            row[3] = "魏金海";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "erp定制产品下单成功";
            row[1] = DateTime.Now.AddDays(-64);
            row[2] = "魏金海";
            row[3] = "生产制造部";
            table.Rows.Add(row);

            return table;
        }


        #endregion
    }
}