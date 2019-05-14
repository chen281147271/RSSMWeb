<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agent.aspx.cs" Inherits="RSSMWeb.projectsmanage.agent" %>

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
     <ext:Panel ID="Pane_usermanage" Title="代理商管理" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        Width="900px" ShowBorder="True" ShowHeader="True" EnableCollapse="true">
         <Items>
            <ext:Form ID="Form_user" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                           <ext:TextBox ID="txt_username" Label="代理商名称" runat="server" AutoPostBack="false"  >
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
                            <ext:Button ID="btn_add" Icon="Add" Text="添加" ToolTip="添加新代理商" EnablePostBack="false"
                                runat="server">
                            </ext:Button>
                            <ext:Button ID="btn_delete" Icon="Delete" Text="删除" ToolTip="删除代理商" runat="server"  ConfirmText='"确定要执行删除操作?"' ConfirmTitle="删除确认" OnClick="btnDelete_Click">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="代理商表格" PageSize="20" ShowBorder="true" ShowHeader="False"
                          runat="server" EnableCheckBoxSelect="true" AllowPaging="true"
                        DataKeyNames="agent_id" EnableRowNumber="false" 
                        OnPageIndexChange="Grid1_PageIndexChange">
                        <Columns>
                        <ext:BoundField Width="60px" DataField="agent_id" DataFormatString="{0}" HeaderText="代理商ID" />
                            <ext:BoundField Width="160px" DataField="agent_name" DataFormatString="{0}" HeaderText="代理商名称" />
                            <ext:BoundField Width="200px" DataField="contact_name" DataFormatString="{0}" HeaderText="联系人名称" />
                            <ext:BoundField Width="160px" DataField="contact_phone" DataFormatString="{0}" HeaderText="联系人电话" />
                            <ext:BoundField Width="100px" DataField="contact_desc" DataFormatString="{0}"  HeaderText="备注" />
                            <ext:BoundField Width="100px" DataField="contact_address" DataFormatString="{0}"  HeaderText="代理商所在地" />

                            <ext:TemplateField HeaderText="操作" Width="60px">
                                <ItemTemplate>
                                    <a href="javascript:<%# GetEditUrl(Eval("agent_id"), Eval("agent_name")) %>">编辑</a>
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
