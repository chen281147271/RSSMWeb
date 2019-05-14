using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using RSSMWeb.Code;
using System.Configuration;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;

namespace RSSMWeb.bugTracer
{
    public partial class bug_classify1 : System.Web.UI.Page
    {
        //protected System.Web.UI.WebControls.Label Label1;
        //protected System.Web.UI.WebControls.Label Label2;
        //protected System.Web.UI.WebControls.Label Label5;
        //protected System.Web.UI.WebControls.Label Label6;
        //protected System.Web.UI.WebControls.DropDownList LabelStyleList;
        //protected System.Web.UI.WebControls.Label Label3;
        //protected System.Web.UI.WebControls.Label Label4;
        //protected System.Web.UI.WebControls.DropDownList ChartTypeList;
        //protected System.Web.UI.WebControls.CheckBox Collect;
        //protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
        //protected System.Web.UI.WebControls.TextBox TextBox1;
        //protected System.Web.UI.WebControls.CheckBox checkBoxCollectPieSlices;
        //protected System.Web.UI.WebControls.TextBox text_Legend;

        DateTime ctemp;
        DateTime c1;
        DateTime c2;
        string strChartType;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = System.DateTime.Today.Year.ToString() + "/01/01";
                TextBox2.Text = System.DateTime.Today.ToShortDateString();
            }
          //  string Months = DateFiledMonths(TextBox1.Text, TextBox2.Text);

            strChartType = Request.QueryString.GetValues(0)[0];

             c1 = Convert.ToDateTime(Convert.ToDateTime(TextBox1.Text).ToString("yyyy-MM"));
             c2 = Convert.ToDateTime(Convert.ToDateTime(TextBox2.Text).ToString("yyyy-MM"));
            
            inichart_column();
            inichart_pie();        
        }
        
        
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        protected void inichart_column()
        {
            if (strChartType == "1")
            {
                #region 按过程分类
                Chart1.Series.Clear();
                Chart1.Series.Add(new Series("研发设计"));
                Chart1.Series["研发设计"].BorderColor = Color.FromName("180, 26, 59, 105");
                SqlDataReader reader = Utils.Getchart("5001", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["研发设计"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["研发设计"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["研发设计"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                }// Chart1.Series["研发设计"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");


                Chart1.Series.Add(new Series("生产装配问题"));
                Chart1.Series["生产装配问题"].BorderColor = Color.FromName("180, 26, 59, 105");
                reader = Utils.Getchart("5002", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["生产装配问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["生产装配问题"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["生产装配问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                } //Chart1.Series["生产装配问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");


                Chart1.Series.Add(new Series("品质测试问题"));
                Chart1.Series["品质测试问题"].BorderColor = Color.FromName("180, 26, 59, 105");
                reader = Utils.Getchart("5003", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["品质测试问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["品质测试问题"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["品质测试问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                } //Chart1.Series["品质测试问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");



                Chart1.Series.Add(new Series("项目实施问题"));
                Chart1.Series["项目实施问题"].BorderColor = Color.FromName("180, 26, 59, 105");
                reader = Utils.Getchart("5004", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["项目实施问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["项目实施问题"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["项目实施问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                }// Chart1.Series["项目实施问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");



                Chart1.Series.Add(new Series("售后服务问题"));
                Chart1.Series["售后服务问题"].BorderColor = Color.FromName("180, 26, 59, 105");
                reader = Utils.Getchart("5005", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["售后服务问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["售后服务问题"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["售后服务问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                } //Chart1.Series["售后服务问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");


                Chart1.Series.Add(new Series("流程运行问题"));
                Chart1.Series["流程运行问题"].BorderColor = Color.FromName("180, 26, 59, 105");
                reader = Utils.Getchart("5006", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["流程运行问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["流程运行问题"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["流程运行问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                } //Chart1.Series["流程运行问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");



                Chart1.Series.Add(new Series("其他"));
                Chart1.Series["其他"].BorderColor = Color.FromName("180, 26, 59, 105");
                reader = Utils.Getchart("5007", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["其他"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["其他"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["其他"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                } //Chart1.Series["其他"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");




                // Set series chart type

                Chart1.ChartAreas[0].AxisX.Interval = 1;//设置轴的间隔
                // Chart1.Series[0].LegendText = "#PERCENT";
                if (ChartType.SelectedItem.ToString() == "Bar")
                {
                    Chart1.Series["研发设计"].ChartType = SeriesChartType.Bar;
                    Chart1.Series["生产装配问题"].ChartType = SeriesChartType.Bar;
                    Chart1.Series["品质测试问题"].ChartType = SeriesChartType.Bar;
                    Chart1.Series["项目实施问题"].ChartType = SeriesChartType.Bar;
                    Chart1.Series["售后服务问题"].ChartType = SeriesChartType.Bar;
                    Chart1.Series["流程运行问题"].ChartType = SeriesChartType.Bar;
                    Chart1.Series["其他"].ChartType = SeriesChartType.Bar;
                    Chart1.Titles[0].Text = "按过程类型统计";
                }
                else
                {
                    Chart1.Series["研发设计"].ChartType = SeriesChartType.Column;
                    Chart1.Series["生产装配问题"].ChartType = SeriesChartType.Column;
                    Chart1.Series["品质测试问题"].ChartType = SeriesChartType.Column;
                    Chart1.Series["项目实施问题"].ChartType = SeriesChartType.Column;
                    Chart1.Series["售后服务问题"].ChartType = SeriesChartType.Column;
                    Chart1.Series["流程运行问题"].ChartType = SeriesChartType.Column;
                    Chart1.Series["其他"].ChartType = SeriesChartType.Column;
                    Chart1.Titles[0].Text = "按过程类型统计";
                }

                // Set point width of the series
                Chart1.Series["研发设计"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                Chart1.Series["生产装配问题"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                Chart1.Series["品质测试问题"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                Chart1.Series["项目实施问题"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                Chart1.Series["售后服务问题"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                Chart1.Series["流程运行问题"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                Chart1.Series["其他"]["PointWidth"] = BarWidthList.SelectedItem.Text;

                // Set drawing style
                Chart1.Series["研发设计"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                Chart1.Series["生产装配问题"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                Chart1.Series["品质测试问题"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                Chart1.Series["项目实施问题"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                Chart1.Series["售后服务问题"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                Chart1.Series["流程运行问题"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                Chart1.Series["其他"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;

                // Show as 2D or 3D
                if (Show3D.Checked)
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

                else
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                #endregion
            }
            else if (strChartType == "2")
            {
                #region 按问题分类
                Chart1.Series.Clear();
                Chart1.Series.Add(new Series("机械结构"));
                Chart1.Series["机械结构"].BorderColor = Color.FromName("180, 26, 59, 105");
                SqlDataReader reader = Utils.Getchart_bug_type("9001", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["机械结构"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["机械结构"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["机械结构"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                }// Chart1.Series["研发设计"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");



                Chart1.Series.Add(new Series("电气控制"));
                Chart1.Series["电气控制"].BorderColor = Color.FromName("180, 26, 59, 105");
                reader = Utils.Getchart_bug_type("9002", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["电气控制"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["电气控制"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["电气控制"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                } //Chart1.Series["生产装配问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");



                Chart1.Series.Add(new Series("软件"));
                Chart1.Series["软件"].BorderColor = Color.FromName("180, 26, 59, 105");
                reader = Utils.Getchart_bug_type("9003", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["软件"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["软件"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["软件"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                } //Chart1.Series["品质测试问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");


                Chart1.Series.Add(new Series("电子"));
                Chart1.Series["电子"].BorderColor = Color.FromName("180, 26, 59, 105");
                reader = Utils.Getchart_bug_type("9004", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["电子"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["电子"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["电子"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                }// Chart1.Series["项目实施问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");


                Chart1.Series.Add(new Series("流程及操作"));
                Chart1.Series["流程及操作"].BorderColor = Color.FromName("180, 26, 59, 105");
                reader = Utils.Getchart_bug_type("9005", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["流程及操作"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["流程及操作"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["流程及操作"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                } //Chart1.Series["售后服务问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");


                Chart1.Series.Add(new Series("其他"));
                Chart1.Series["其他"].BorderColor = Color.FromName("180, 26, 59, 105");
                reader = Utils.Getchart_bug_type("9006", TextBox1.Text, TextBox2.Text);
                ctemp = c1;
                while (reader.Read())
                {

                    string month = reader["m"].ToString();
                    string count = reader["合计"].ToString();
                    while (ctemp.ToString("yyyy-MM") != month)
                    {
                        Chart1.Series["其他"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }
                    Chart1.Series["其他"].Points.AddXY(month, count);
                    ctemp = ctemp.AddMonths(1);
                }
                while (ctemp <= c2)
                {
                    Chart1.Series["其他"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                    ctemp = ctemp.AddMonths(1);
                } //Chart1.Series["流程运行问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");


                // Set series chart type

                Chart1.ChartAreas[0].AxisX.Interval = 1;//设置轴的间隔
                // Chart1.Series[0].LegendText = "#PERCENT";
                if (ChartType.SelectedItem.ToString() == "Bar")
                {
                    Chart1.Series["机械结构"].ChartType = SeriesChartType.Bar;
                    Chart1.Series["电气控制"].ChartType = SeriesChartType.Bar;
                    Chart1.Series["软件"].ChartType = SeriesChartType.Bar;
                    Chart1.Series["电子"].ChartType = SeriesChartType.Bar;
                    Chart1.Series["流程及操作"].ChartType = SeriesChartType.Bar;
                    Chart1.Series["其他"].ChartType = SeriesChartType.Bar;
                    Chart1.Titles[0].Text = "按问题分类统计";
                }
                else
                {
                    Chart1.Series["机械结构"].ChartType = SeriesChartType.Column;
                    Chart1.Series["电气控制"].ChartType = SeriesChartType.Column;
                    Chart1.Series["软件"].ChartType = SeriesChartType.Column;
                    Chart1.Series["电子"].ChartType = SeriesChartType.Column;
                    Chart1.Series["流程及操作"].ChartType = SeriesChartType.Column;
                    Chart1.Series["其他"].ChartType = SeriesChartType.Column;
                    Chart1.Titles[0].Text = "按问题分类统计";
                }

                // Set point width of the series
                Chart1.Series["机械结构"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                Chart1.Series["电气控制"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                Chart1.Series["软件"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                Chart1.Series["电子"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                Chart1.Series["流程及操作"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                Chart1.Series["其他"]["PointWidth"] = BarWidthList.SelectedItem.Text;

                // Set drawing style
                Chart1.Series["机械结构"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                Chart1.Series["电气控制"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                Chart1.Series["软件"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                Chart1.Series["电子"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                Chart1.Series["流程及操作"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                Chart1.Series["其他"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;

                // Show as 2D or 3D
                if (Show3D.Checked)
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

                else
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                #endregion
            }
            else if (strChartType == "3")
            {
                #region 按产品分类
                Chart1.Series.Clear();
                string sql = "select * from  pjm_product_info";
                SqlDataReader reader1=SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                while (reader1.Read())
                {
                    string id= reader1["pd_id"].ToString();
                    string pd_name = reader1["pd_name"].ToString();
                    Chart1.Series.Add(new Series(pd_name));
                    Chart1.Series[pd_name].BorderColor = Color.FromName("180, 26, 59, 105");
                    SqlDataReader reader = Utils.Getchart_bug_pd(id, TextBox1.Text, TextBox2.Text);
                    ctemp = c1;
                    while (reader.Read())
                    {

                        string month = reader["m"].ToString();
                        string count = reader["合计"].ToString();
                        while (ctemp.ToString("yyyy-MM") != month)
                        {
                            Chart1.Series[pd_name].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                            ctemp = ctemp.AddMonths(1);
                        }
                        Chart1.Series[pd_name].Points.AddXY(month, count);
                        ctemp = ctemp.AddMonths(1);
                    }
                    while (ctemp <= c2)
                    {
                        Chart1.Series[pd_name].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                        ctemp = ctemp.AddMonths(1);
                    }// Chart1.Series["研发设计"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");

                }

                //Chart1.Series.Add(new Series("标准片剂机"));
                //Chart1.Series["标准片剂机"].BorderColor = Color.FromName("180, 26, 59, 105");
                //reader = Utils.Getchart_bug_pd("2", TextBox1.Text, TextBox2.Text);
                //ctemp = c1;
                //while (reader.Read())
                //{

                //    string month = reader["m"].ToString();
                //    string count = reader["合计"].ToString();
                //    while (ctemp.ToString("yyyy-MM") != month)
                //    {
                //        Chart1.Series["标准片剂机"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                //        ctemp = ctemp.AddMonths(1);
                //    }
                //    Chart1.Series["标准片剂机"].Points.AddXY(month, count);
                //    ctemp = ctemp.AddMonths(1);
                //}
                //while (ctemp <= c2)
                //{
                //    Chart1.Series["标准片剂机"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                //    ctemp = ctemp.AddMonths(1);
                //} //Chart1.Series["生产装配问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");



                //Chart1.Series.Add(new Series("拆零分包机"));
                //Chart1.Series["拆零分包机"].BorderColor = Color.FromName("180, 26, 59, 105");
                //reader = Utils.Getchart_bug_pd("3", TextBox1.Text, TextBox2.Text);
                //ctemp = c1;
                //while (reader.Read())
                //{

                //    string month = reader["m"].ToString();
                //    string count = reader["合计"].ToString();
                //    while (ctemp.ToString("yyyy-MM") != month)
                //    {
                //        Chart1.Series["拆零分包机"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                //        ctemp = ctemp.AddMonths(1);
                //    }
                //    Chart1.Series["拆零分包机"].Points.AddXY(month, count);
                //    ctemp = ctemp.AddMonths(1);
                //}
                //while (ctemp <= c2)
                //{
                //    Chart1.Series["拆零分包机"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                //    ctemp = ctemp.AddMonths(1);
                //} //Chart1.Series["品质测试问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");


                //Chart1.Series.Add(new Series("智能药柜"));
                //Chart1.Series["智能药柜"].BorderColor = Color.FromName("180, 26, 59, 105");
                //reader = Utils.Getchart_bug_pd("4", TextBox1.Text, TextBox2.Text);
                //ctemp = c1;
                //while (reader.Read())
                //{

                //    string month = reader["m"].ToString();
                //    string count = reader["合计"].ToString();
                //    while (ctemp.ToString("yyyy-MM") != month)
                //    {
                //        Chart1.Series["智能药柜"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                //        ctemp = ctemp.AddMonths(1);
                //    }
                //    Chart1.Series["智能药柜"].Points.AddXY(month, count);
                //    ctemp = ctemp.AddMonths(1);
                //}
                //while (ctemp <= c2)
                //{
                //    Chart1.Series["智能药柜"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                //    ctemp = ctemp.AddMonths(1);
                //}// Chart1.Series["项目实施问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");


                //Chart1.Series.Add(new Series("智能药架"));
                //Chart1.Series["智能药架"].BorderColor = Color.FromName("180, 26, 59, 105");
                //reader = Utils.Getchart_bug_pd("5", TextBox1.Text, TextBox2.Text);
                //ctemp = c1;
                //while (reader.Read())
                //{

                //    string month = reader["m"].ToString();
                //    string count = reader["合计"].ToString();
                //    while (ctemp.ToString("yyyy-MM") != month)
                //    {
                //        Chart1.Series["智能药架"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                //        ctemp = ctemp.AddMonths(1);
                //    }
                //    Chart1.Series["智能药架"].Points.AddXY(month, count);
                //    ctemp = ctemp.AddMonths(1);
                //}
                //while (ctemp <= c2)
                //{
                //    Chart1.Series["智能药架"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                //    ctemp = ctemp.AddMonths(1);
                //} //Chart1.Series["售后服务问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");


                //Chart1.Series.Add(new Series("机械手自动上药机"));
                //Chart1.Series["机械手自动上药机"].BorderColor = Color.FromName("180, 26, 59, 105");
                //reader = Utils.Getchart_bug_pd("6", TextBox1.Text, TextBox2.Text);
                //ctemp = c1;
                //while (reader.Read())
                //{

                //    string month = reader["m"].ToString();
                //    string count = reader["合计"].ToString();
                //    while (ctemp.ToString("yyyy-MM") != month)
                //    {
                //        Chart1.Series["机械手自动上药机"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                //        ctemp = ctemp.AddMonths(1);
                //    }
                //    Chart1.Series["机械手自动上药机"].Points.AddXY(month, count);
                //    ctemp = ctemp.AddMonths(1);
                //}
                //while (ctemp <= c2)
                //{
                //    Chart1.Series["机械手自动上药机"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");
                //    ctemp = ctemp.AddMonths(1);
                //} //Chart1.Series["流程运行问题"].Points.AddXY(ctemp.ToString("yyyy-MM"), "");


                // Set series chart type

                Chart1.ChartAreas[0].AxisX.Interval = 1;//设置轴的间隔
                // Chart1.Series[0].LegendText = "#PERCENT";
                if (ChartType.SelectedItem.ToString() == "Bar")
                {
                    while (reader1.Read())
                    {
                        Chart1.Series[reader1["pd_name"].ToString()].ChartType = SeriesChartType.Bar;
                    }
                    //Chart1.Series["标准片剂机"].ChartType = SeriesChartType.Bar;
                    //Chart1.Series["拆零分包机"].ChartType = SeriesChartType.Bar;
                    //Chart1.Series["智能药柜"].ChartType = SeriesChartType.Bar;
                    //Chart1.Series["智能药架"].ChartType = SeriesChartType.Bar;
                    //Chart1.Series["机械手自动上药机"].ChartType = SeriesChartType.Bar;
                    Chart1.Titles[0].Text = "按产品分类统计";
                }
                else
                {
                    while (reader1.Read())
                    {
                        Chart1.Series[reader1["pd_name"].ToString()].ChartType = SeriesChartType.Column;
                    }
                    //Chart1.Series["标准盒剂机"].ChartType = SeriesChartType.Column;
                    //Chart1.Series["标准片剂机"].ChartType = SeriesChartType.Column;
                    //Chart1.Series["拆零分包机"].ChartType = SeriesChartType.Column;
                    //Chart1.Series["智能药柜"].ChartType = SeriesChartType.Column;
                    //Chart1.Series["智能药架"].ChartType = SeriesChartType.Column;
                    //Chart1.Series["机械手自动上药机"].ChartType = SeriesChartType.Column;
                    Chart1.Titles[0].Text = "按产品分类统计";
                }

                // Set point width of the series

                while (reader1.Read())
                {
                    Chart1.Series[reader1["pd_name"].ToString()]["PointWidth"] = BarWidthList.SelectedItem.Text;
                }
                //Chart1.Series["标准盒剂机"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                //Chart1.Series["标准片剂机"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                //Chart1.Series["拆零分包机"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                //Chart1.Series["智能药柜"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                //Chart1.Series["智能药架"]["PointWidth"] = BarWidthList.SelectedItem.Text;
                //Chart1.Series["机械手自动上药机"]["PointWidth"] = BarWidthList.SelectedItem.Text;

                // Set drawing style
                while (reader1.Read())
                {
                    Chart1.Series[reader1["pd_name"].ToString()]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                }
                //Chart1.Series["标准盒剂机"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                //Chart1.Series["标准片剂机"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                //Chart1.Series["拆零分包机"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                //Chart1.Series["智能药柜"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                //Chart1.Series["智能药架"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
                //Chart1.Series["机械手自动上药机"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;

                // Show as 2D or 3D
                if (Show3D.Checked)
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

                else
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                #endregion
            }
            else if (strChartType == "4")
            {

                char2tabel.Visible = false;

                Chart1.Series.Clear();
                Chart1.Series.Add(new Series("项目问题总数统计"));
                Chart1.DataSource = Utils.Getchart_pj("2013", "2013");
                Chart1.Series[0].XValueMember = "pj_name";
                Chart1.Series[0].YValueMembers = "问题总数";
                

            }
        }

        protected void inichart_pie()
        {

            //char2

                //   Chart2.Series[0].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), ChartTypeList.SelectedItem.Text, true);

                // Set series font
            if (!IsPostBack)
            {
                Chart2.Series[0].Font = new Font("Trebuchet MS", 8, FontStyle.Bold);

                // Set current selection
                this.chk_Pie.Checked = false;
                comboBoxChartType.SelectedIndex = 0;
                comboBoxCollectedColor.SelectedIndex = 0;
                comboBoxCollectedThreshold.SelectedIndex = 0;
                textBoxCollectedLabel.Text = "Other";
                textBoxCollectedLegend.Text = "Other";

                Chart2.Series[0]["CollectedToolTip"] = "Other";

                this.chk_Pie.Checked = true;
            }
                if (strChartType == "1")
                {
                    string sql = "select COUNT(*) as 总数,b.code_desp from bug_detail_info a,sys_code b where a.process_type=b.code ";
                    sql += " and a.create_time between '";
                    sql += TextBox1.Text;
                    sql += "' and '";
                    sql += TextBox2.Text;
                    sql += "'group by process_type,b.code_desp";
                    SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                    int i = 0;
                    while (reader.Read())
                    {
                        if (reader["总数"].ToString() == "")
                        {
                            continue;
                        }
                        Chart2.Series[0].Points.AddY(reader["总数"].ToString());
                        Chart2.Series[0].Points[i++].LegendText = reader["code_desp"].ToString();
                        //  Chart2.Series[0].Points[0]
                    }
                }
                else if (strChartType == "2")
                {
                    string sql = "select COUNT(*) as 总数,b.code_desp from bug_detail_info a,sys_code b,bug_main_info c where c.bug_type=b.code and a.bug_id=c.bug_id ";
                    sql += " and a.create_time between '";
                    sql += TextBox1.Text;
                    sql += "' and '";
                    sql += TextBox2.Text;
                    sql += "'group by bug_type,b.code_desp";
                    SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                    int i = 0;
                    while (reader.Read())
                    {
                        if (reader["总数"].ToString() == "")
                        {
                            continue;
                        }
                        Chart2.Series[0].Points.AddY(reader["总数"].ToString());
                        Chart2.Series[0].Points[i++].LegendText = reader["code_desp"].ToString();
                        //  Chart2.Series[0].Points[0]
                    }
                }
                else if (strChartType == "3")
                {
                    string sql = "select COUNT(*) as 总数,b.pd_name from bug_detail_info a,pjm_product_info b where a.pd_id=b.pd_id  ";
                    sql += " and a.create_time between '";
                    sql += TextBox1.Text;
                    sql += "' and '";
                    sql += TextBox2.Text;
                    sql += "'group by a.pd_id,b.pd_name";
                    SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                    int i = 0;
                    while (reader.Read())
                    {
                        if (reader["总数"].ToString() == "")
                        {
                            continue;
                        }
                        Chart2.Series[0].Points.AddY(reader["总数"].ToString());
                        Chart2.Series[0].Points[i++].LegendText = reader["pd_name"].ToString();
                        //  Chart2.Series[0].Points[0]
                    }
                }

            Series series1 = Chart2.Series[0];

            if (this.chk_Pie.Checked)
            {
                comboBoxChartType.Enabled = true;
                comboBoxCollectedColor.Enabled = true;
                comboBoxCollectedThreshold.Enabled = true;
                textBoxCollectedLabel.Enabled = true;
                textBoxCollectedLegend.Enabled = true;
                this.ShowExplode.Enabled = true;

                // Set the threshold under which all points will be collected
                series1["CollectedThreshold"] = comboBoxCollectedThreshold.SelectedItem.ToString();

                // Set the label of the collected pie slice
                series1["CollectedLabel"] = textBoxCollectedLabel.Text;

                // Set the legend text of the collected pie slice
                series1["CollectedLegendText"] = textBoxCollectedLegend.Text;

                // Set the collected pie slice to be exploded
                series1["CollectedSliceExploded"] = this.ShowExplode.Checked.ToString();

                // Set collected color
                series1["CollectedColor"] = comboBoxCollectedColor.SelectedItem.ToString();

                // Set chart type
                series1.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboBoxChartType.SelectedItem.ToString(), true);

                //  Chart2.Titles[0].Text = "1";
            }

            else
            {
                series1["CollectedThreshold"] = "0";
                comboBoxChartType.Enabled = false;
                comboBoxCollectedColor.Enabled = false;
                comboBoxCollectedThreshold.Enabled = false;
                textBoxCollectedLabel.Enabled = false;
                textBoxCollectedLegend.Enabled = false;
                this.ShowExplode.Enabled = false;
            }

            if (this.comboBoxChartType.SelectedItem.ToString() == "Doughnut")
            {
                Chart2.Series[0]["DoughnutRadius"] = "50";
            }
            // Chart2.Titles[0].Text = "11";
        }

        public static string DateFiledMonths(string startTime, string endTime)
        {
            try
            {
                int index = 0;
                string filed = string.Empty;
                DateTime c1 = Convert.ToDateTime(Convert.ToDateTime(startTime).ToString("yyyy-MM"));
                DateTime c2 = Convert.ToDateTime(Convert.ToDateTime(endTime).ToString("yyyy-MM"));
                if (c1 > c2)
                {
                    DateTime tmp = c1;
                    c1 = c2;
                    c2 = tmp;
                }
                while (c2 >= c1)
                {
                    index++;
                    if (index > 12)  // 判断是否大于12个月，如果大于，跳出 www.2cto.com
                        break;
                    filed += c1.ToString("yyyy-MM") + "|";
                    c1 = c1.AddMonths(1);
                }
                return filed.TrimEnd('|');
            }
            catch { return null; }
        } 

        protected void btn_createtable_Click(object sender, EventArgs e)
        {

        }
    }
}