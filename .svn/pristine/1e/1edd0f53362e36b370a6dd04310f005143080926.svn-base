<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customer.aspx.cs" Inherits="RSSMWeb.projectsmanage.customer" %>

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
     <ext:Panel ID="Pane_usermanage" Title="客户管理" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        Width="800px" ShowBorder="True" ShowHeader="True" EnableCollapse="true">
         <Items>
            <ext:Form ID="Form_user" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                           <ext:TextBox ID="txt_username" Label="客户名称" runat="server" AutoPostBack="false" 
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
                            <ext:Button ID="btn_add" Icon="Add" Text="添加" ToolTip="添加新客户" EnablePostBack="false"
                                runat="server">
                            </ext:Button>
                            <ext:Button ID="btn_delete" Icon="Delete" Text="删除" ToolTip="删除客户" runat="server"  ConfirmText='"确定要执行删除操作?"' ConfirmTitle="删除确认" OnClick="btnDelete_Click">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="客户表格" PageSize="20" ShowBorder="true" ShowHeader="False"
                          runat="server" EnableCheckBoxSelect="true" AllowPaging="True" 
                        DataKeyNames="cus_id" EnableRowNumber="false" OnPageIndexChange="Grid1_PageIndexChange">
                        <Columns>
                            <ext:BoundField Width="60px" DataField="cus_id" DataFormatString="{0}" HeaderText="客户ID" />
                            <ext:BoundField Width="200px" DataField="cus_name" DataFormatString="{0}" HeaderText="客户名称" />
                            <ext:BoundField Width="160px" DataField="cus_contact" DataFormatString="{0}" HeaderText="联系人" />
                            <ext:BoundField Width="100px" DataField="cus_address" DataFormatString="{0}"  HeaderText="医院所在地" />
                            <ext:BoundField Width="100px" DataField="contact_phone" DataFormatString="{0}"  HeaderText="联系人电话" />

                            <ext:TemplateField HeaderText="操作" Width="60px">
                                <ItemTemplate>
                                    <a href="javascript:<%# GetEditUrl(Eval("cus_id"), Eval("cus_name")) %>">编辑</a>
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
