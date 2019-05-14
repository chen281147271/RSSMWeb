<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bug_pj.aspx.cs" Inherits="RSSMWeb.bugTracer.bug_pj" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
<%--      <input id="x" runat="server" value="1" name="x"  type="text">
       <script type="text/javascript">
    <!--
           //  Response.Write("<script>alert("OK");</scriptlanguage="javascript">");
           var winWidth = 0;
           var winHeight = 0;
           function findDimensions() //函数：获取尺寸
           {
               //获取窗口宽度
               if (window.innerWidth)
                   winWidth = window.innerWidth;
               else if ((document.body) && (document.body.clientWidth))
                   winWidth = document.body.clientWidth; //获取窗口高度
               if (window.innerHeight)
                   winHeight = window.innerHeight;
               else if ((document.body) && (document.body.clientHeight))
                   winHeight = document.body.clientHeight; /* nasty hack to deal with doctype switch in IE */
               if (document.documentElement && document.documentElement.clientHeight && document.documentElement.clientWidth) {
                   winHeight = document.documentElement.clientHeight;
                   winWidth = document.documentElement.clientWidth;
               } //结果输出至两个文本框
               //document.form1.availHeight.value = winHeight;
               //document.form1.availWidth.value = winWidth;
               //document.for
               // alert(winWidth);
               // document.all.xx.value = winWidth;
               //  document.write(winWidth);
               // return  alert(winWidth);
               document.getElementById("x").value = winWidth;


           }
           findDimensions();
           window.onresize = findDimensions;
    //-->

    </script>--%>

        <script>
          function gridClick(projectId,pj_name)
    {

        //        document.getElementById("Label1").value = projectId;
      
      //  label1.innerHTML = projectId;
       
//        var label2 = document.getElementById("<%=Label2.ClientID %>");
//        
//          //获取GridView控件
  //      var gdview = document.getElementById("<%=GridView1.ClientID %>");
//           //分别获取选定行标注点的X、Y坐标
     //   var value = gdview.rows[1].cells[1].innerText;
    //    label2.innerHTML = value;
        //  window.location.reload(true);

        
        document.getElementById("Text1").value = pj_name;
         document.getElementById("<%=LinkButton1.ClientID %>").click();
         // window.location.reload(true);


      
    }
        </script>

        <script src="../js/2.0.2.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".flip").click(function () {
            $(".panel").slideToggle("slow");
        });
    });
</script>
 
<style type="text/css"> 
div.panel,p.flip
{
margin:0px;
padding:5px;
text-align:center;
background:#e5eecc;
border:solid 1px #c3c3c3;
cursor:pointer
}
div.panel
{
height:300px;
display:none;
width: 1000px;
}
</style>
	</head>
	<body> 

    
    <form id="Form1" method="post" runat="server">
        <div id="Div1" class="panel" >

						<table class="controls" cellpadding="4" width="100%">
                        <tr width="100%">
                        <td  width="50%" align="center" colspan="2">
                        柱状图
                        </td>

                         <td  width="50%" align="center" colspan="2">
                        饼状图
                        </td>


                        </tr>
							<tr width="100%">
								<td  width="25%" align="left">图表类型:</td>
								<td width="25%" align="left">
									<asp:dropdownlist id="ChartType" runat="server" Width="120px"  AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Column">Column</asp:ListItem>
										<asp:ListItem Value="Bar">Bar</asp:ListItem>
									</asp:dropdownlist></td>

								<td  width="25%" align="left">
									<p>是否合并较少的项:</p>
								</td>
								<td width="25%" align="left">
									<asp:checkbox id="chk_Pie" runat="server" AutoPostBack="True" Text="" Checked="True" ></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label" width="25%" align="left">柱宽度:</td>
								<td width="25%" align="left"><asp:dropdownlist id="BarWidthList" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="1.0">1.0</asp:ListItem>
										<asp:ListItem Value="0.8" Selected="True">0.8</asp:ListItem>
										<asp:ListItem Value="0.6">0.6</asp:ListItem>
										<asp:ListItem Value="0.4">0.4</asp:ListItem>
									</asp:dropdownlist>
								</td>

                                <td class="label" width="25%" align="left">合并标准(%):</td>
								<td width="25%" align="left">
									<asp:dropdownlist id="comboBoxCollectedThreshold" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
									</asp:dropdownlist>
								</td>

							</tr>
							<tr>
								<td class="label" width="25%" align="left"> 显示风格:</td>
								<td width="25%" align="left">
									<asp:dropdownlist id="DrawingStyle" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Default">Default</asp:ListItem>
										<asp:ListItem Value="Emboss">Emboss</asp:ListItem>
										<asp:ListItem Value="Cylinder">Cylinder</asp:ListItem>
										<asp:ListItem Value="Wedge">Wedge</asp:ListItem>
										<asp:ListItem Value="LightToDark">LightToDark</asp:ListItem>
									</asp:dropdownlist></td>

                                    <td class="label" width="25%" align="left">合并区颜色:</td>
								<td width="25%" align="left"><asp:dropdownlist id="comboBoxCollectedColor" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="Green">Green</asp:ListItem>
										<asp:ListItem Value="Gray">Gray</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Gold">Gold</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" width="25%" align="left">Show as 3D:</td>
								<td width="25%" align="left">
									<asp:CheckBox id="Show3D" tabIndex="6" runat="server" Text="" AutoPostBack="True"></asp:CheckBox></td>

                                    <td class="label" width="25%" align="left">合并区域文本:</td>
								<td width="25%" align="left">
									<asp:TextBox id="textBoxCollectedLabel" runat="server" Width="120px" CssClass="spaceright" AutoPostBack="True" MaxLength="10"></asp:TextBox>
								</td>
							</tr>
                            <tr>
                        <td  width="50%" align="center" colspan="2">
                        通用设置
                        </td>
								<td class="label"  width="25%" align="left">合并区域图例:</td>
								<td width="25%" align="left">
									<asp:TextBox id="textBoxCollectedLegend" runat="server" CssClass="spaceright" Width="120px" AutoPostBack="True" MaxLength="10"></asp:TextBox>
								</td>
							</tr>
							<tr>
                             <td width="25%" align="left">图表宽度:</td>
                            <td width="25%"  align="left"><asp:dropdownlist id="Dropdownlist1" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="700">700PX</asp:ListItem>
										<asp:ListItem Value="800">800PX</asp:ListItem>
										<asp:ListItem Value="900">900PX</asp:ListItem>
										<asp:ListItem Value="1000">1000PX</asp:ListItem>
                                        <asp:ListItem Value="1100">1100PX</asp:ListItem>
                                        <asp:ListItem Value="1200">1200PX</asp:ListItem>
									</asp:dropdownlist></td>
								<td class="label"  width="25%" align="left">是否突出显示合并区:</td>
								<td width="25%" align="left"><asp:checkbox id="ShowExplode" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
                             <td width="25%" align="left">图表高度:</td>
                            <td width="25%"  align="left"><asp:dropdownlist id="Dropdownlist2" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="292">292PX</asp:ListItem>
										<asp:ListItem Value="310">310PX</asp:ListItem>
										<asp:ListItem Value="320">320PX</asp:ListItem>
										<asp:ListItem Value="330">330PX</asp:ListItem>
                                        <asp:ListItem Value="340">340PX</asp:ListItem>
                                        <asp:ListItem Value="350">350PX</asp:ListItem>
									</asp:dropdownlist></td>
								<TD class="label" width="25%" align="left">图表类型:</td>
								<td width="25%" align="left">
									<asp:dropdownlist id="comboBoxChartType" runat="server" CssClass="spaceright" AutoPostBack="True" Width="120px">
										<asp:ListItem Value="Pie" Selected="True">Pie</asp:ListItem>
										<asp:ListItem Value="Doughnut">Doughnut</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					
						
					

</div>
 
<p class="flip" >更改图表配置</p>
			单击表格显示详细信息 已选择：
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:LinkButton ID="LinkButton1"
                runat="server" onclick="LinkButton1_Click" >刷新</asp:LinkButton><%--<input id="Text1" type="text" runat="server" visible="false"  />--%>
                <input id="Text1" type="hidden"  runat="server" />
                
            <table class="sampleTable" width="100%">
        <tr>
        <td>

            <asp:GridView ID="GridView1" runat="server" Width="100%" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                GridLines="None" AllowPaging="True" AllowSorting="True" 
                DataKeyNames="pj_id" onpageindexchanging="GridView1_PageIndexChanging" 
                onrowdatabound="GridView1_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="pj_id" HeaderText="项目编号" />
                    <asp:BoundField DataField="pj_name" HeaderText="项目名称" />
                    <asp:BoundField DataField="问题总数" HeaderText="问题总数" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

        </td>
        </tr>
        </table>
			<table class="sampleTable" width="100%">
				<tr>
					<td width="100%" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Palette="BrightPastel" 
                            BackColor="#F3DFC1" Height="296px" BorderlineDashStyle="Solid" 
                            BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1" Width="700px">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="过程类型统计" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" 
                                    BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" 
                                    IsTextAutoFit="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"  />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False"  />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<%--<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">图表类型:</td>
								<td>
									<asp:dropdownlist id="ChartType" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Column">Column</asp:ListItem>
										<asp:ListItem Value="Bar">Bar</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">柱宽度:</td>
								<td><asp:dropdownlist id="BarWidthList" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="1.0">1.0</asp:ListItem>
										<asp:ListItem Value="0.8" Selected="True">0.8</asp:ListItem>
										<asp:ListItem Value="0.6">0.6</asp:ListItem>
										<asp:ListItem Value="0.4">0.4</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">显示风格:</td>
								<td>
									<asp:dropdownlist id="DrawingStyle" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Default">Default</asp:ListItem>
										<asp:ListItem Value="Emboss">Emboss</asp:ListItem>
										<asp:ListItem Value="Cylinder">Cylinder</asp:ListItem>
										<asp:ListItem Value="Wedge">Wedge</asp:ListItem>
										<asp:ListItem Value="LightToDark">LightToDark</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td>
									<asp:CheckBox id="Show3D" tabIndex="6" runat="server" Text="" AutoPostBack="True"></asp:CheckBox></td>
							</tr>
						</table>
					</td>--%>
				</tr>
			</table>
            <table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart2" runat="server" Palette="BrightPastel" 
                            BackColor="#D3DFF0" Height="296px" Width="700px" BorderlineDashStyle="Solid" 
                            BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" 
                            IsSoftShadows="False" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                            <titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="合计统计" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="Area1" XValueType="Double" Name="Series1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20" MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double" Label="#PERCENT{P1}">
									<points>
										<%--<asp:DataPoint LegendText="RUS" CustomProperties="OriginalPointIndex=0" YValues="39" />
										<asp:DataPoint LegendText="CAN" CustomProperties="OriginalPointIndex=1" YValues="18" />
										<asp:DataPoint LegendText="USA" CustomProperties="OriginalPointIndex=2" YValues="15" />
										<asp:DataPoint LegendText="PRC" CustomProperties="OriginalPointIndex=3" YValues="12" />
										<asp:DataPoint LegendText="DEN" CustomProperties="OriginalPointIndex=5" YValues="8" />
										<asp:DataPoint LegendText="AUS" YValues="4.5" />
										<asp:DataPoint LegendText="IND" CustomProperties="OriginalPointIndex=4" YValues="3.20000004768372" />
										<asp:DataPoint LegendText="ARG" YValues="2" />
										<asp:DataPoint LegendText="FRA" YValues="1" />--%>
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2>
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisy2>
									<axisx2>
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisx2>
									<area3dstyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<%--<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label" style="WIDTH: 181px">
									<p>是否合并较少的项:</p>
								</td>
								<td>
									<asp:checkbox id="chk_Pie" runat="server" AutoPostBack="True" Text="" Checked="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 29px">合并标准(%):</td>
								<td>
									<asp:dropdownlist id="comboBoxCollectedThreshold" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px">合并区颜色:</td>
								<td><asp:dropdownlist id="comboBoxCollectedColor" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="Green">Green</asp:ListItem>
										<asp:ListItem Value="Gray">Gray</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Gold">Gold</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px">合并区域文本:</td>
								<td>
									<asp:TextBox id="textBoxCollectedLabel" runat="server" Width="120px" CssClass="spaceright" AutoPostBack="True" MaxLength="10"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 16px">合并区域图例:</td>
								<td style="HEIGHT: 16px">
									<asp:TextBox id="textBoxCollectedLegend" runat="server" CssClass="spaceright" Width="120px" AutoPostBack="True" MaxLength="10"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 20px">是否突出显示合并区:</td>
								<td style="HEIGHT: 20px"><asp:checkbox id="ShowExplode" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<TD class="label" style="WIDTH: 181px">图表类型:</td>
								<td>
									<asp:dropdownlist id="comboBoxChartType" runat="server" CssClass="spaceright" AutoPostBack="True" Width="120px">
										<asp:ListItem Value="Pie" Selected="True">Pie</asp:ListItem>
										<asp:ListItem Value="Doughnut">Doughnut</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>--%>
				</tr>
			</table>
            			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart3" runat="server" Palette="BrightPastel" 
                            BackColor="#F3DFC1" Width="700px" Height="296px" BorderlineDashStyle="Solid" 
                            BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="按问题子类统计" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" 
                                    BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" 
                                    IsTextAutoFit="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
							<%--	<asp:Series  Name="研发设计" BorderColor="180, 26, 59, 105">
									<points>
                                        <asp:DataPoint XValue="36890" YValues="32" />
										<asp:DataPoint XValue="36891" YValues="56" />
										<asp:DataPoint XValue="36892" YValues="35" />
										<asp:DataPoint XValue="36893" YValues="12" />
										<asp:DataPoint XValue="36894" YValues="35" />
										<asp:DataPoint XValue="36895" YValues="6" />
										<asp:DataPoint XValue="36896" YValues="23" />
									</points>
								</asp:Series>--%>
							
								
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"  />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False"  />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<%--<table class="controls" cellpadding="4">
							<tr>
								<td class="label">图表类型:</td>
								<td>
									<asp:dropdownlist id="Dropdownlist1" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Column">Column</asp:ListItem>
										<asp:ListItem Value="Bar">Bar</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">柱宽度:</td>
								<td><asp:dropdownlist id="Dropdownlist2" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="1.0">1.0</asp:ListItem>
										<asp:ListItem Value="0.8" Selected="True">0.8</asp:ListItem>
										<asp:ListItem Value="0.6">0.6</asp:ListItem>
										<asp:ListItem Value="0.4">0.4</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">显示风格:</td>
								<td>
									<asp:dropdownlist id="Dropdownlist3" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Default">Default</asp:ListItem>
										<asp:ListItem Value="Emboss">Emboss</asp:ListItem>
										<asp:ListItem Value="Cylinder">Cylinder</asp:ListItem>
										<asp:ListItem Value="Wedge">Wedge</asp:ListItem>
										<asp:ListItem Value="LightToDark">LightToDark</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td>
									<asp:CheckBox id="CheckBox1" tabIndex="6" runat="server" Text="" AutoPostBack="True"></asp:CheckBox></td>
							</tr>
						</table>--%>
					</td>
				</tr>
			</table>
            <table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart4" runat="server" Palette="BrightPastel" 
                            BackColor="#D3DFF0" Height="296px" Width="700px" BorderlineDashStyle="Solid" 
                            BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" 
                            IsSoftShadows="False" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                            <titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="合计统计" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="Area1" XValueType="Double" Name="Series1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20" MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double" Label="#PERCENT{P1}">
									<points>
										<%--<asp:DataPoint LegendText="RUS" CustomProperties="OriginalPointIndex=0" YValues="39" />
										<asp:DataPoint LegendText="CAN" CustomProperties="OriginalPointIndex=1" YValues="18" />
										<asp:DataPoint LegendText="USA" CustomProperties="OriginalPointIndex=2" YValues="15" />
										<asp:DataPoint LegendText="PRC" CustomProperties="OriginalPointIndex=3" YValues="12" />
										<asp:DataPoint LegendText="DEN" CustomProperties="OriginalPointIndex=5" YValues="8" />
										<asp:DataPoint LegendText="AUS" YValues="4.5" />
										<asp:DataPoint LegendText="IND" CustomProperties="OriginalPointIndex=4" YValues="3.20000004768372" />
										<asp:DataPoint LegendText="ARG" YValues="2" />
										<asp:DataPoint LegendText="FRA" YValues="1" />--%>
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2>
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisy2>
									<axisx2>
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisx2>
									<area3dstyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<%--<table class="controls" cellpadding="4">
							<tr>
								<td class="label" style="WIDTH: 181px">
									<p>是否合并较少的项:</p>
								</td>
								<td>
									<asp:checkbox id="Checkbox2" runat="server" AutoPostBack="True" Text="" Checked="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 29px">合并标准(%):</td>
								<td>
									<asp:dropdownlist id="Dropdownlist4" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px">合并区颜色:</td>
								<td><asp:dropdownlist id="Dropdownlist5" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="Green">Green</asp:ListItem>
										<asp:ListItem Value="Gray">Gray</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Gold">Gold</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px">合并区域文本:</td>
								<td>
									<asp:TextBox id="textBox1" runat="server" Width="120px" CssClass="spaceright" AutoPostBack="True" MaxLength="10"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 16px">合并区域图例:</td>
								<td style="HEIGHT: 16px">
									<asp:TextBox id="textBox2" runat="server" CssClass="spaceright" Width="120px" AutoPostBack="True" MaxLength="10"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 20px">是否突出显示合并区:</td>
								<td style="HEIGHT: 20px"><asp:checkbox id="Checkbox3" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<TD class="label" style="WIDTH: 181px">图表类型:</td>
								<td>
									<asp:dropdownlist id="Dropdownlist6" runat="server" CssClass="spaceright" AutoPostBack="True" Width="120px">
										<asp:ListItem Value="Pie" Selected="True">Pie</asp:ListItem>
										<asp:ListItem Value="Doughnut">Doughnut</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>--%>
					</td>
				</tr>
			</table>
            			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart5" runat="server" Palette="BrightPastel" 
                            BackColor="#F3DFC1" Width="700px" Height="296px" BorderlineDashStyle="Solid" 
                            BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="按产品统计" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" 
                                    BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" 
                                    IsTextAutoFit="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
							<%--	<asp:Series  Name="研发设计" BorderColor="180, 26, 59, 105">
									<points>
                                        <asp:DataPoint XValue="36890" YValues="32" />
										<asp:DataPoint XValue="36891" YValues="56" />
										<asp:DataPoint XValue="36892" YValues="35" />
										<asp:DataPoint XValue="36893" YValues="12" />
										<asp:DataPoint XValue="36894" YValues="35" />
										<asp:DataPoint XValue="36895" YValues="6" />
										<asp:DataPoint XValue="36896" YValues="23" />
									</points>
								</asp:Series>--%>
							
								
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"  />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False"  />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<%--<table class="controls" cellpadding="4">
							<tr>
								<td class="label">图表类型:</td>
								<td>
									<asp:dropdownlist id="Dropdownlist7" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Column">Column</asp:ListItem>
										<asp:ListItem Value="Bar">Bar</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">柱宽度:</td>
								<td><asp:dropdownlist id="Dropdownlist8" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="1.0">1.0</asp:ListItem>
										<asp:ListItem Value="0.8" Selected="True">0.8</asp:ListItem>
										<asp:ListItem Value="0.6">0.6</asp:ListItem>
										<asp:ListItem Value="0.4">0.4</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">显示风格:</td>
								<td>
									<asp:dropdownlist id="Dropdownlist9" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Default">Default</asp:ListItem>
										<asp:ListItem Value="Emboss">Emboss</asp:ListItem>
										<asp:ListItem Value="Cylinder">Cylinder</asp:ListItem>
										<asp:ListItem Value="Wedge">Wedge</asp:ListItem>
										<asp:ListItem Value="LightToDark">LightToDark</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td>
									<asp:CheckBox id="CheckBox4" tabIndex="6" runat="server" Text="" AutoPostBack="True"></asp:CheckBox></td>
							</tr>
						</table>--%>
					</td>
				</tr>
			</table>
            <table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart6" runat="server" Palette="BrightPastel" 
                            BackColor="#D3DFF0" Height="296px" Width="700px" BorderlineDashStyle="Solid" 
                            BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" 
                            IsSoftShadows="False" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                            <titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="合计统计" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="Area1" XValueType="Double" Name="Series1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20" MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double" Label="#PERCENT{P1}">
									<points>
										<%--<asp:DataPoint LegendText="RUS" CustomProperties="OriginalPointIndex=0" YValues="39" />
										<asp:DataPoint LegendText="CAN" CustomProperties="OriginalPointIndex=1" YValues="18" />
										<asp:DataPoint LegendText="USA" CustomProperties="OriginalPointIndex=2" YValues="15" />
										<asp:DataPoint LegendText="PRC" CustomProperties="OriginalPointIndex=3" YValues="12" />
										<asp:DataPoint LegendText="DEN" CustomProperties="OriginalPointIndex=5" YValues="8" />
										<asp:DataPoint LegendText="AUS" YValues="4.5" />
										<asp:DataPoint LegendText="IND" CustomProperties="OriginalPointIndex=4" YValues="3.20000004768372" />
										<asp:DataPoint LegendText="ARG" YValues="2" />
										<asp:DataPoint LegendText="FRA" YValues="1" />--%>
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2>
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisy2>
									<axisx2>
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisx2>
									<area3dstyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<%--<table class="controls" cellpadding="4">
							<tr>
								<td class="label" style="WIDTH: 181px">
									<p>是否合并较少的项:</p>
								</td>
								<td>
									<asp:checkbox id="Checkbox5" runat="server" AutoPostBack="True" Text="" Checked="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 29px">合并标准(%):</td>
								<td>
									<asp:dropdownlist id="Dropdownlist10" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px">合并区颜色:</td>
								<td><asp:dropdownlist id="Dropdownlist11" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="Green">Green</asp:ListItem>
										<asp:ListItem Value="Gray">Gray</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Gold">Gold</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px">合并区域文本:</td>
								<td>
									<asp:TextBox id="textBox3" runat="server" Width="120px" CssClass="spaceright" AutoPostBack="True" MaxLength="10"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 16px">合并区域图例:</td>
								<td style="HEIGHT: 16px">
									<asp:TextBox id="textBox4" runat="server" CssClass="spaceright" Width="120px" AutoPostBack="True" MaxLength="10"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 20px">是否突出显示合并区:</td>
								<td style="HEIGHT: 20px"><asp:checkbox id="Checkbox6" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<TD class="label" style="WIDTH: 181px">图表类型:</td>
								<td>
									<asp:dropdownlist id="Dropdownlist12" runat="server" CssClass="spaceright" AutoPostBack="True" Width="120px">
										<asp:ListItem Value="Pie" Selected="True">Pie</asp:ListItem>
										<asp:ListItem Value="Doughnut">Doughnut</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>--%>
					</td>
				</tr>
			</table>
   

			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
</body>
</html>

