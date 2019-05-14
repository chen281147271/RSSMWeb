<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dpt_manage.aspx.cs" Inherits="RSSMWeb.systemmanage.dpt_manage" %>

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
    <ext:Panel ID="Panel2" Title="问题列表" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        Width="800px" ShowBorder="True" ShowHeader="True" EnableCollapse="true">
        <Items>
            <ext:Form ID="Form7" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:TextBox ID="TextBox5" Label="部门名称" runat="server">
                            </ext:TextBox>     
                            <ext:Button ID="Button2" Text="搜索" runat="server" OnClick="OnSearchDept" >
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="Panel6" ShowBorder="True" ShowHeader="false" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="Button4" Icon="Add" Text="添加" ToolTip="添加新部门" EnablePostBack="false"
                                runat="server">
                            </ext:Button>
                            <ext:Button ID="Button5" Icon="Delete" Text="删除" ToolTip="删除部门" runat="server" OnClick="btnDelete_Click" ConfirmText='"确定要执行删除操作?"' ConfirmTitle="删除确认">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="部门表格" PageSize="4" ShowBorder="true" ShowHeader="False"
                        OnRowDoubleClick="ShowDetails" EnableRowDoubleClick="false" runat="server" EnableCheckBoxSelect="true"
                        DataKeyNames="org_id,org_name" EnableRowNumber="false">
                        <Columns>
                            <ext:BoundField Width="60px" DataField="org_id" DataFormatString="{0}" HeaderText="部门编号" />
                            <ext:BoundField Width="160px" DataField="org_name" DataFormatString="{0}" HeaderText="部门名称" />
<%--                            <ext:TemplateField Width="160px" HeaderText="上级部门">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# GetOIName(Eval("father_org_id")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>--%>
                            <ext:BoundField Width="60px" DataField="father_org_id" DataFormatString="{0}" HeaderText="上级部门" />
                            <ext:CheckBoxField Width="60px" RenderAsStaticField="true" DataField="is_top" HeaderText="是否顶层" />
                            <ext:TemplateField HeaderText="操作" Width="60px">
                                <ItemTemplate>
                                    <a href="javascript:<%# GetEditUrl(Eval("org_id"), Eval("org_name")) %>">编辑</a>
                                </ItemTemplate>
                            </ext:TemplateField>
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
    </form>
</body>
</html>
