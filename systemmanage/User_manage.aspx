<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_manage.aspx.cs" Inherits="RSSMWeb.systemmanage.WebForm1" %>

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
     <ext:Panel ID="Pane_usermanage" Title="用户管理" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        Width="1200px" ShowBorder="True" ShowHeader="True" EnableCollapse="true">
         <Items>
            <ext:Form ID="Form_user" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                           <ext:TextBox ID="txt_username" Label="用户姓名" runat="server" AutoPostBack="false" 
                                >
                            </ext:TextBox>   
                            
                            <ext:Button ID="btn_Search" Text="搜索" runat="server" >
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
             <ext:Panel ID="Panel6" ShowBorder="True" ShowHeader="false" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="btn_add" Icon="Add" Text="添加" ToolTip="添加新用户" EnablePostBack="false"
                                runat="server">
                            </ext:Button>
                            <ext:Button ID="btn_delete" Icon="Delete" Text="删除" ToolTip="删除用户" runat="server"  ConfirmText='"确定要执行删除操作?"' ConfirmTitle="删除确认" OnClick="btnDelete_Click">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="用户表格" PageSize="20" ShowBorder="true" ShowHeader="False"
                         runat="server" EnableCheckBoxSelect="true"
                        DataKeyNames="user_id" EnableRowNumber="false" AllowPaging="True" 
                        OnPageIndexChange="Grid1_PageIndexChange">
                        <Columns>
                            <ext:BoundField Width="60px" DataField="user_id" DataFormatString="{0}" HeaderText="用户ID" />
                            <ext:BoundField Width="160px" DataField="user_name" DataFormatString="{0}" HeaderText="登入名" />
                            <ext:BoundField Width="160px" DataField="user_name_full" DataFormatString="{0}" HeaderText="用户名称" />
                            <%--<ext:BoundField Width="100px" DataField="user_password" DataFormatString="{0}"  HeaderText="用户密码" />--%>
                            <ext:TemplateField Width="60px" HeaderText="用户状态">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# GetSysCode(Eval("user_state")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <%--<ext:BoundField Width="100px" DataField="pwd_validate_time" DataFormatString="{0}"  HeaderText="密码验证时间" />--%>
                            <%--<ext:BoundField Width="100px" DataField="update_time" DataFormatString="{0}"  HeaderText="更新时间" />--%>
                            <ext:BoundField Width="150px" DataField="email_address" DataFormatString="{0}"  HeaderText="电子邮件" />
                            <ext:BoundField Width="100px" DataField="phone_number" DataFormatString="{0}"  HeaderText="电话号码" />
                            <ext:BoundField Width="100px" DataField="cellphone_numer" DataFormatString="{0}"  HeaderText="手机号码" />
                            <ext:BoundField Width="100px" DataField="home_address" DataFormatString="{0}"  HeaderText="家庭住址" />
                            <%--<ext:BoundField Width="100px" DataField="create_time" DataFormatString="{0}"  HeaderText="创建时间" />--%>
                            <ext:TemplateField Width="60px" HeaderText="用户角色">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# GetSysCode(Eval("manage_type")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                         <%--   <ext:TemplateField Width="160px" HeaderText="用户所属部门">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# GetOIName(Eval("org_id")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>--%>
                            <ext:BoundField Width="160px" DataField="org_name" DataFormatString="{0}"  HeaderText="用户所属部门" />
                            <ext:TemplateField HeaderText="操作" Width="60px">
                                <ItemTemplate>
                                    <a href="javascript:<%# GetEditUrl(Eval("user_id"), Eval("user_name_full")) %>">编辑</a>
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
        EnableMaximize="true" EnableResize="true"  Target="Top"
        IsModal="True" Width="400px" Height="450px">
    </ext:Window>

    </form>
</body>
</html>
