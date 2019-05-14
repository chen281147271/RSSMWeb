<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bug_classify1.aspx.cs" Inherits="RSSMWeb.bugTracer.bug_classify1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization=true  EnableScriptLocalization=true>
    </asp:ScriptManager>
			<p class="dscr">
				<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox1"  Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox2"  Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
        开始日期
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        
        结束日期
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Button ID="btn_createtable" runat="server" onclick="btn_createtable_Click" 
                    Text="生成图表" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TextBox1" ControlToValidate="TextBox2" Display="Dynamic" 
                    ErrorMessage="结束日期必须大于起始日期" Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="开始日期不能为空"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="结束日期不能为空"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="起始日期必须为日期格式" 
                    MaximumValue="2999-01-01" MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                <asp:RangeValidator ID="RangeValidator2" runat="server" 
                    ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="结束日期必须为日期格式" 
                    MaximumValue="2999-01-01" MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
        </p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Palette="BrightPastel" 
                            BackColor="#F3DFC1" Width="700px" Height="296px" BorderlineDashStyle="Solid" 
                            BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="过程类型统计" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
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
					</td>
				</tr>
			</table>
            <table class="sampleTable" runat="server" id="char2tabel">
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
					<td valign="top">
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
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
</body>
</html>
