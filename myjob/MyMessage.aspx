<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMessage.aspx.cs" Inherits="RSSMWeb.myjob.MyMessage" validateRequest="false"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
     <ext:Panel ID="Pane_usermanage" Title="我的站内信息(已接收)" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        Width="1200px" ShowBorder="True" ShowHeader="True" EnableCollapse="true">
         <Items>
            <ext:Form ID="Form_user" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                           <ext:TextBox ID="txt_username" Label="" runat="server" AutoPostBack="false">
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
<%--                           <ext:Button ID="btnPressed" Text="收到的信息" runat="server" EnablePress="true" Pressed="true" OnClick="btnPressed_Click" />
                           <ext:Button ID="btnPressed1" Text="发送的信息" runat="server" EnablePress="true" Pressed="false"  OnClick="btnPressed_Click1" />--%>
                            <ext:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                               <ext:ListItem Text="全部" Value="全部" Selected="true"/>
                               <ext:ListItem Text="已读" Value="已读" />
                               <ext:ListItem Text="未读" Value="未读" />
                            </ext:DropDownList>
                            <ext:Button ID="btn_add" Icon="Add" Text="发送新的站内信" ToolTip="发送新站内信" EnablePostBack="false"
                                runat="server">
                            </ext:Button>
                            <ext:Button ID="btn_delete" Icon="Delete" Text="删除" ToolTip="删除记录" runat="server"  ConfirmText='"确定要执行删除操作?"' ConfirmTitle="删除确认" OnClick="btnDelete_Click" Enabled="false">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="消息表格" PageSize="15" ShowBorder="true" ShowHeader="False"
                         runat="server" EnableCheckBoxSelect="true"
                        DataKeyNames="message_id" EnableRowNumber="false" AllowPaging="True" 
                        OnPageIndexChange="Grid1_PageIndexChange" 
                        OnRowDoubleClick="Grid1_RowDoubleClick">
                        <Columns>
                            <ext:BoundField Width="60px" DataField="message_id" DataFormatString="{0}" HeaderText="消息ID" />
                            <%--<ext:BoundField Width="160px" DataField="message_content" DataFormatString="{0}" HeaderText="消息内容" />--%>
                            <ext:TemplateField Width="160px" HeaderText="消息标题">
                                <ItemTemplate>
                                   <a href="javascript:<%# GetEditUrl(Eval("message_id"), Eval("message_create_time")) %>">
                                    <asp:Label ID="Label2"  EncodeText="fasle" runat="server" Text='<%#Eval("message_title")%>'></asp:Label>
                                    </a>
                                </ItemTemplate>
                                </ext:TemplateField>
                            <ext:BoundField Width="160px" DataField="message_create_time" DataFormatString="{0}" HeaderText="创建时间" />

                            <ext:TemplateField Width="60px" HeaderText="发送者">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#GetUserName(Eval("msg_creator_id")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="160px" HeaderText="是否已读">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#isread(Eval("msg_read_flag")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="操作" Width="60px">
                                <ItemTemplate>
                                    <a href="javascript:<%# GetEditUrl(Eval("message_id"), Eval("message_create_time")) %>">查看</a>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
            </Items>
        </ext:Panel>
         <ext:Panel ID="Panel1" Title="我的站内信息(已发送)" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        Width="1200px" ShowBorder="true" ShowHeader="true" EnableCollapse="true" Collapsed="false" >
         <Items>
            <ext:Form ID="Form2" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                           <ext:TextBox ID="TextBox1" Label="" runat="server" AutoPostBack="false">
                            </ext:TextBox>   
                            
                            <ext:Button ID="Button1" Text="搜索" runat="server" >
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
             <ext:Panel ID="Panel2" ShowBorder="True" ShowHeader="false" runat="server">
              <%--  <Toolbars>
                    <ext:Toolbar ID="Toolbar2" runat="server">
                        <Items>
                           <ext:Button ID="Button2" Text="收到的信息" runat="server" EnablePress="true" Pressed="true" OnClick="btnPressed_Click" />
                           <ext:Button ID="Button3" Text="发送的信息" runat="server" EnablePress="true" Pressed="false"  OnClick="btnPressed_Click1" />
                            <ext:Button ID="Button4" Icon="Add" Text="添加" ToolTip="发送新站内信" EnablePostBack="false"
                                runat="server">
                            </ext:Button>
                            <ext:Button ID="Button5" Icon="Delete" Text="删除" ToolTip="删除记录" runat="server"  ConfirmText='"确定要执行删除操作?"' ConfirmTitle="删除确认" OnClick="btnDelete_Click">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>--%>
                <Items>
                    <ext:Grid ID="Grid2" Title="消息表格" PageSize="15" ShowBorder="true" ShowHeader="False"
                         runat="server" EnableCheckBoxSelect="true"
                        DataKeyNames="message_id" EnableRowNumber="false" AllowPaging="True" 
                        OnPageIndexChange="Grid2_PageIndexChange">
                        <Columns>
                            <ext:BoundField Width="60px" DataField="message_id" DataFormatString="{0}" HeaderText="消息ID" />
                            <%--<ext:BoundField Width="160px" DataField="message_content" DataFormatString="{0}" HeaderText="消息内容" />--%>
                            <ext:TemplateField Width="160px" HeaderText="消息标题">
                               <ItemTemplate>
                                   <a href="javascript:<%# GetEditUrl(Eval("message_id"), Eval("message_create_time")) %>">
                                    <asp:Label ID="Label4"  EncodeText="fasle" runat="server" Text='<%#Eval("message_title") %>'></asp:Label>
                                    </a>
                                </ItemTemplate>
                                </ext:TemplateField>
                            <ext:BoundField Width="160px" DataField="message_create_time" DataFormatString="{0}" HeaderText="创建时间" />

                            <ext:TemplateField Width="60px" HeaderText="发送给">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#GetUserName(Eval("msg_tgt_id")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="160px" HeaderText="是否已读">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#isread(Eval("msg_read_flag")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="操作" Width="60px">
                                <ItemTemplate>
                                    <a href="javascript:<%# GetEditUrl(Eval("message_id"), Eval("message_create_time")) %>">查看</a>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
            </Items>
        </ext:Panel>
         <ext:Window ID="Window1" Title="编辑" Popup="false" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" EnableConfirmOnClose="true" IFrameUrl="about:blank" EnableClose="false"
        EnableMaximize="true" EnableResize="true"  Target="Top"
        IsModal="True" Width="800px" Height="350px">
    </ext:Window>

    </form>
</body>
</html>
