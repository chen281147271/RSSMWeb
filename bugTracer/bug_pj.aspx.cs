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
using ExtAspNet;

namespace RSSMWeb.bugTracer
{
    public partial class bug_pj : PageBase
    {
        
        public void inichart()
        {
            Chart1.Width = Unit.Pixel(Convert.ToInt32(Dropdownlist1.SelectedValue.ToString()));
            Chart2.Width = Unit.Pixel(Convert.ToInt32(Dropdownlist1.SelectedValue.ToString()));
            Chart3.Width = Unit.Pixel(Convert.ToInt32(Dropdownlist1.SelectedValue.ToString()));
            Chart4.Width = Unit.Pixel(Convert.ToInt32(Dropdownlist1.SelectedValue.ToString()));
            Chart5.Width = Unit.Pixel(Convert.ToInt32(Dropdownlist1.SelectedValue.ToString()));
            Chart6.Width = Unit.Pixel(Convert.ToInt32(Dropdownlist1.SelectedValue.ToString()));


            Chart1.Height = Unit.Pixel(Convert.ToInt32(Dropdownlist2.SelectedValue.ToString()));
            Chart2.Height = Unit.Pixel(Convert.ToInt32(Dropdownlist2.SelectedValue.ToString()));
            Chart3.Height = Unit.Pixel(Convert.ToInt32(Dropdownlist2.SelectedValue.ToString()));
            Chart4.Height = Unit.Pixel(Convert.ToInt32(Dropdownlist2.SelectedValue.ToString()));
            Chart5.Height = Unit.Pixel(Convert.ToInt32(Dropdownlist2.SelectedValue.ToString()));
            Chart6.Height = Unit.Pixel(Convert.ToInt32(Dropdownlist2.SelectedValue.ToString()));

        }
        protected void Page_Load(object sender, System.EventArgs e)
        {
           // inichart();
            inichart();
            if (!IsPostBack)
            {
                iniGridView();
                //  Label1.Text = GridView1.Rows[0].Cells[0].Text;
                Label2.Text = GridView1.Rows[0].Cells[1].Text;

            }
            string Rowsindex = Text1.Value;
            //  Alert.Show(aaaa);
            //   Response.Write(aaaa);
            if (Rowsindex == "")
            {
                Rowsindex = GridView1.Rows[0].Cells[0].Text;
                Label2.Text = GridView1.Rows[0].Cells[1].Text;
                inichar_part1(Rowsindex);
                inichar_part2(Rowsindex);
                inichar_part3(Rowsindex);

            }
            else
            {

                Label2.Text = GridView1.Rows[Convert.ToInt32(Rowsindex)].Cells[1].Text;
                inichar_part1(GridView1.Rows[Convert.ToInt32(Rowsindex)].Cells[0].Text);
                inichar_part2(GridView1.Rows[Convert.ToInt32(Rowsindex)].Cells[0].Text);
                inichar_part3(GridView1.Rows[Convert.ToInt32(Rowsindex)].Cells[0].Text);

            }

        }
        protected void iniGridView()
        {
            string sql = "select b.pj_name ,COUNT(a.pj_id) as 问题总数,b.pj_id from bug_detail_info a right join pjm_project_info b  on a.pj_id=b.pj_id group by b.pj_id,b.pj_name order by COUNT(a.pj_id) desc";
            GridView1.DataSource  = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            GridView1.DataBind();
          //  Grid1.DataSource = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
          //  Grid1.DataBind();
        }
        #region 按过程分类
        protected void inichar_part1( string pj_id)
        {


            //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>findDimensions()</script>", true);

                 //Chart1.Width = Convert.ToInt32(x.Value.ToString());
                 //Response.Write(x.Value.ToString());
                 string pj_name = Label2.Text;

                 Chart1.DataSource = Utils.Getchart_bug_pj1(pj_id);

                 Chart1.Series.Add(new Series(""));
                 Chart1.Series[0].BorderColor = Color.FromName("180, 26, 59, 105");

                 Chart1.Series[0].XValueMember = "code_desp";
                 Chart1.Series[0].YValueMembers = "合计";

                 Chart1.Titles[0].Text = pj_name + "按过程分类统计";
                 Chart1.Series[0].IsVisibleInLegend = false;


                 Chart1.ChartAreas[0].AxisX.Interval = 1;//设置轴的间隔
                 // Chart1.Series[0].LegendText = "#PERCENT";
                 if (ChartType.SelectedItem.ToString() == "Bar")
                 {
                     Chart1.Series[0].ChartType = SeriesChartType.Bar;

                     Chart1.Titles[0].Text = pj_name + "按过程分类统计";
                 }
                 else
                 {
                     Chart1.Series[0].ChartType = SeriesChartType.Column;

                     Chart1.Titles[0].Text = pj_name + "按过程分类统计";
                 }

                 // Set point width of the series
                 Chart1.Series[0]["PointWidth"] = BarWidthList.SelectedItem.Text;


                 // Set drawing style
                 Chart1.Series[0]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;

                 // Show as 2D or 3D
                 if (Show3D.Checked)
                     Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

                 else
                     Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;





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

               //  Chart2.DataSource = Utils.Getchart_bug_pj1(pj_id);

                // Chart2.Series.Add(new Series(""));
                 Chart2.Series[0].BorderColor = Color.FromName("180, 26, 59, 105");

                 SqlDataReader reader = Utils.Getchart_bug_pd_pjdr1(pj_id);
                 int i = 0;
                 while (reader.Read())
                 {
                     if (reader["合计"].ToString()=="")
                     {
                         continue;
                     }
                     Chart2.Series[0].Points.AddY(reader["合计"].ToString());
                     Chart2.Series[0].Points[i++].LegendText = reader["code_desp"].ToString();
                    
                 }

                 Chart2.Titles[0].Text = pj_name + "按过程分类统计";
                 Chart2.Series[0].IsVisibleInLegend = true;

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


        }
        #endregion
        #region 按问题子类
        protected void inichar_part2(string pj_id)
        {


            string pj_name = Label2.Text;

            Chart3.DataSource = Utils.Getchart_bug_pj2(pj_id);

            Chart3.Series.Add(new Series(""));
            Chart3.Series[0].BorderColor = Color.FromName("180, 26, 59, 105");

            Chart3.Series[0].XValueMember = "code_desp";
            Chart3.Series[0].YValueMembers = "合计";

            Chart3.Titles[0].Text = pj_name + "按问题子类统计";
            Chart3.Series[0].IsVisibleInLegend = false;


            Chart3.ChartAreas[0].AxisX.Interval = 1;//设置轴的间隔
            // Chart1.Series[0].LegendText = "#PERCENT";
            if (ChartType.SelectedItem.ToString() == "Bar")
            {
                Chart3.Series[0].ChartType = SeriesChartType.Bar;

                Chart3.Titles[0].Text = pj_name + "按问题子类统计";
            }
            else
            {
                Chart3.Series[0].ChartType = SeriesChartType.Column;

                Chart3.Titles[0].Text = pj_name + "按问题子类统计";
            }

            // Set point width of the series
            Chart3.Series[0]["PointWidth"] = BarWidthList.SelectedItem.Text;


            // Set drawing style
            Chart3.Series[0]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;

            // Show as 2D or 3D
            if (Show3D.Checked)
                Chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            else
                Chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;





            if (!IsPostBack)
            {
                Chart4.Series[0].Font = new Font("Trebuchet MS", 8, FontStyle.Bold);

                // Set current selection
                this.chk_Pie.Checked = false;
                comboBoxChartType.SelectedIndex = 0;
                comboBoxCollectedColor.SelectedIndex = 0;
                comboBoxCollectedThreshold.SelectedIndex = 0;
                textBoxCollectedLabel.Text = "Other";
                textBoxCollectedLegend.Text = "Other";

                Chart4.Series[0]["CollectedToolTip"] = "Other";

                this.chk_Pie.Checked = true;
            }


            // Chart2.Series.Add(new Series(""));
            Chart4.Series[0].BorderColor = Color.FromName("180, 26, 59, 105");

            SqlDataReader reader = Utils.Getchart_bug_pd_pjdr2(pj_id);
            int i = 0;
            while (reader.Read())
            {
                if (reader["合计"].ToString() == "")
                {
                    continue;
                }
                Chart4.Series[0].Points.AddY(reader["合计"].ToString());
                Chart4.Series[0].Points[i++].LegendText = reader["code_desp"].ToString();
               

            }

            Chart4.Titles[0].Text = pj_name + "按过程分类统计";
            Chart4.Series[0].IsVisibleInLegend = true;

            Series series1 = Chart4.Series[0];
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
                Chart4.Series[0]["DoughnutRadius"] = "50";
            }


        }
        #endregion
        #region 按产品
        protected void inichar_part3(string pj_id)
        {


            string pj_name = Label2.Text;

            Chart5.DataSource = Utils.Getchart_bug_pj3(pj_id);

            Chart5.Series.Add(new Series(""));
            Chart5.Series[0].BorderColor = Color.FromName("180, 26, 59, 105");

            Chart5.Series[0].XValueMember = "pd_name";
            Chart5.Series[0].YValueMembers = "合计";

            Chart5.Titles[0].Text = pj_name + "按产品统计";
            Chart5.Series[0].IsVisibleInLegend = false;


            Chart5.ChartAreas[0].AxisX.Interval = 1;//设置轴的间隔
            // Chart1.Series[0].LegendText = "#PERCENT";
            if (ChartType.SelectedItem.ToString() == "Bar")
            {
                Chart5.Series[0].ChartType = SeriesChartType.Bar;

                Chart5.Titles[0].Text = pj_name + "按产品统计";
            }
            else
            {
                Chart5.Series[0].ChartType = SeriesChartType.Column;

                Chart5.Titles[0].Text = pj_name + "按产品子类统计";
            }

            // Set point width of the series
            Chart5.Series[0]["PointWidth"] = BarWidthList.SelectedItem.Text;


            // Set drawing style
            Chart5.Series[0]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;

            // Show as 2D or 3D
            if (Show3D.Checked)
                Chart5.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            else
                Chart5.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;





            if (!IsPostBack)
            {
                Chart6.Series[0].Font = new Font("Trebuchet MS", 8, FontStyle.Bold);

                // Set current selection
                this.chk_Pie.Checked = false;
                comboBoxChartType.SelectedIndex = 0;
                comboBoxCollectedColor.SelectedIndex = 0;
                comboBoxCollectedThreshold.SelectedIndex = 0;
                textBoxCollectedLabel.Text = "Other";
                textBoxCollectedLegend.Text = "Other";

                Chart6.Series[0]["CollectedToolTip"] = "Other";

                this.chk_Pie.Checked = true;
            }


            // Chart2.Series.Add(new Series(""));
            Chart6.Series[0].BorderColor = Color.FromName("180, 26, 59, 105");

            SqlDataReader reader = Utils.Getchart_bug_pd_pjdr3(pj_id);
            int i = 0;
            while (reader.Read())
            {
                if (reader["合计"].ToString() == "")
                {
                    continue;
                }
                Chart6.Series[0].Points.AddY(reader["合计"].ToString());
                Chart6.Series[0].Points[i++].LegendText = reader["pd_name"].ToString();


            }

            Chart6.Titles[0].Text = pj_name + "按过程分类统计";
            Chart6.Series[0].IsVisibleInLegend = true;

            Series series1 = Chart6.Series[0];
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
                Chart6.Series[0]["DoughnutRadius"] = "50";
            }


        }
        #endregion



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

             GridView1.PageIndex = e.NewPageIndex;
             iniGridView();
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            // GridView1.PageIndex = e.;
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //int i;
            ////执行循环，保证每条数据都可以更新
            //for (i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    //首先判断是否是数据行
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        //当鼠标停留时更改背景色
            //        e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
            //        //当鼠标移开时还原背景色
            //        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            //    }
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //鼠标经过时，行背景色变  
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA';this.style.cursor='pointer';");


             //   e.Row.Attributes.Add("onmouseover", "this.style.cursor:hand");
                //鼠标移出时，行背景色变 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

                //e.Row.Attributes.Add("onclick");
              //  e.Row.Attributes.Add("onclick", "alert('"+GridView1.DataKeys[e.Row.RowIndex].Value.ToString()+"');");

                e.Row.Attributes.Add("onclick","gridClick('"+ GridView1.DataKeys[e.Row.RowIndex].Value.ToString()+"','"+e.Row.RowIndex.ToString()+"')");
               //string  aaaa= GridView1.DataKeys[e.Row.RowIndex].Value;
              //  e.Row.Attributes.Add("onclick", "gridClick(this,'" + GridView1.DataKeys[e.Row.RowIndex].Value.ToString() + "','" + e.Row.RowIndex.ToString() + "')");

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
         //   inichart();
           // Chart1.Width = Unit.Pixel(1000);
        }



    }
}