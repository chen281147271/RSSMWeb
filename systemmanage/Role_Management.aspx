<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Role_Management.aspx.cs" Inherits="RSSMWeb.systemmanage.Role_Management" %>

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
     <ext:Panel ID="Pane_usermanage" Title="角色管理" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        Width="1200px" ShowBorder="True" ShowHeader="True" EnableCollapse="true">
         <Items>
            <ext:Form ID="Form_user" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                           <ext:TextBox ID="txt_username" Label="角色姓名" runat="server" AutoPostBack="false" 
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
                            <ext:Button ID="btn_add" Icon="Add" Text="添加" ToolTip="添加新角色" EnablePostBack="false"
                                runat="server">
                            </ext:Button>
                            <ext:Button ID="btn_delete" Icon="Delete" Text="删除" ToolTip="删除角色" runat="server"  ConfirmText='"确定要执行删除操作?"' ConfirmTitle="删除确认" OnClick="btnDelete_Click">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="角色表格" PageSize="4" ShowBorder="true" ShowHeader="False"
                         runat="server" EnableCheckBoxSelect="true"
                        DataKeyNames="role_id,role_name" EnableRowNumber="false">
                        <Columns>
                            <ext:BoundField Width="60px" DataField="role_id" DataFormatString="{0}" HeaderText="用户ID" />
                            <ext:BoundField Width="160px" DataField="role_name" DataFormatString="{0}" HeaderText="角色名" />

                            <ext:TemplateField HeaderText="操作" Width="60px">
                                <ItemTemplate>
                                    <a href="javascript:<%# GetEditUrl(Eval("role_id"), Eval("role_name")) %>">编辑</a>
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
        IsModal="True" Width="400px" Height="250px">
    </ext:Window>

    </form>
</body>
</html>
