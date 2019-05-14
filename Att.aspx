<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Att.aspx.cs" Inherits="RSSMWeb.systemmanage.Att" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .highlight
        {
            font-weight: bold;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="Panel2" Title="考勤明细" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        Width="1000px" ShowBorder="True" ShowHeader="True" EnableCollapse="true">
        <Items>
            <ext:Form ID="Form7" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                         <Items>
                             <ext:Label ID="Label1" runat="server" Label="查询说明" EncodeText="false" Text="<span style='color:red;font-weight:bold;'>请在10点后查询当天早上的考勤记录！</span>" >
                             </ext:Label>
                         </Items>
                    </ext:FormRow>
                     <ext:FormRow>
                         <Items>
                             <ext:DatePicker ID="BTime" runat="server" Label="起始日期">
                             </ext:DatePicker>
                             <ext:DatePicker ID="ETime" runat="server" Label="结束日期" >
                             </ext:DatePicker>
                         </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:TextBox ID="TextBox5" Label="员工姓名" runat="server">
                            </ext:TextBox>     
                            <ext:Button ID="Button2" Text="搜索" runat="server" OnClick="OnSearchDept" >
                            </ext:Button>
<%--                            <ext:DropDownList ID="DropDownList1" runat="server" Label="员工姓名">
                            </ext:DropDownList>--%>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="Panel6" ShowBorder="True" ShowHeader="false" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="部门表格" PageSize="25" ShowBorder="true" ShowHeader="False"
                        OnRowDoubleClick="ShowDetails" EnableRowDoubleClick="false" runat="server" EnableCheckBoxSelect="False" 
                        DataKeyNames="org_id,org_name" EnableRowNumber="false" AllowPaging="true" OnPageIndexChange="Grid1_PageIndexChange" AutoHeight="True"  >
                        <Columns>
                            <ext:BoundField Width="60px" DataField="Badgenumber" DataFormatString="{0}" HeaderText="工号" />
                            <ext:BoundField Width="160px" DataField="name" DataFormatString="{0}" HeaderText="姓名" />
                            <ext:BoundField Width="160px" DataField="CHECKTIME" DataFormatString="{0}" HeaderText="打卡时间" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="Window1" Title="编辑" Popup="false" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" EnableConfirmOnClose="true" IFrameUrl="about:blank"
        EnableMaximize="true" EnableResize="true" OnClose="Window1_Close" Target="Top"
        IsModal="True" Width="400px" Height="250px">
    </ext:Window>
        <ext:HiddenField ID="PageIndex" runat="server">    </ext:HiddenField>
    </form>
</body>
</html>
