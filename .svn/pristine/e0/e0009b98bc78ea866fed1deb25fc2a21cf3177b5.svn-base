<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SDCManage.aspx.cs" Inherits="RSSMWeb.developmanage.SDCManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:PageManager ID="PageManager1" runat="server" />
        <ext:Panel ID="Panel2" Title="任务列表" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
            Width="1000px" ShowBorder="True" ShowHeader="True" EnableCollapse="true">
            <Items>
                <ext:Panel ID="Panel6" ShowBorder="True" ShowHeader="false" runat="server">
                    <Toolbars>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:Button ID="Button4" Icon="Add" Text="添加" ToolTip="添加新软件项目" EnablePostBack="false"
                                    runat="server">
                                </ext:Button>
                                <ext:Button ID="Button5" Icon="ChartOrganisationAdd" Text="刷新" ToolTip="刷新列表" runat="server" >
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </Toolbars>
                    <Items>
                        <ext:Grid ID="Grid1" Title="任务表格" PageSize="15" ShowBorder="true" ShowHeader="False" runat="server" 
                            DataKeyNames="sdd_pjm_id" EnableRowNumber="false"  OnPageIndexChange="Grid1_PageIndexChange"
                             AllowPaging="true"   >
                            <Columns>
                                <ext:CheckBoxField Width="60px" RenderAsStaticField="true" DataField="finish_flag" HeaderText="完结" />
                                <ext:BoundField Width="40px" DataField="sdd_pjm_id" DataFormatString="{0}" HeaderText="编号" />
                                <ext:TemplateField Width="160px" HeaderText="任务标题" >
                                    <ItemTemplate>
                                        <a href="javascript:<%# GetEditUrl(Eval("sdd_pjm_id"), Eval("pjm_title"),2) %>">
                                        <asp:Label ID="Label2"  EncodeText="fasle" runat="server" Text='<%#Eval("pjm_title")%>'></asp:Label>
                                        </a>
                                    </ItemTemplate>
                                </ext:TemplateField>
                                <ext:BoundField Width="100px" DataField="create_time" HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd}" />
                                <ext:BoundField Width="80px" DataField="charger_name" DataFormatString="{0}" HeaderText="开发负责人" />
                                <ext:BoundField Width="80px" DataField="tester_name" DataFormatString="{0}" HeaderText="测试负责人" />
                                <ext:BoundField Width="100px" DataField="begin_date" HeaderText="任务开始时间" DataFormatString="{0:yyyy-MM-dd}" />
                                <ext:BoundField Width="100px" DataField="respect_date" HeaderText="预期完成时间" DataFormatString="{0:yyyy-MM-dd}" />
                                <ext:BoundField Width="100px" DataField="finish_date" HeaderText="实际完成时间" DataFormatString="{0:yyyy-MM-dd}" />
                                <ext:BoundField Width="80px" DataField="PAP" HeaderText="基础PAP" />
                            </Columns>
                        </ext:Grid>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Panel>
        <ext:Window ID="Window1" Title="明细" Popup="false" EnableIFrame="true" runat="server"
            CloseAction="HidePostBack" EnableConfirmOnClose="true" IFrameUrl="about:blank"
            EnableMaximize="true" EnableResize="true" Target="Top"
            IsModal="True" Width="800px"  Layout="Form" Height="650px" AutoHeight="True" AutoScroll="True">
        </ext:Window>

        <ext:HiddenField ID="User_Id" runat="server">    </ext:HiddenField>
    </form>
</body>
</html>
