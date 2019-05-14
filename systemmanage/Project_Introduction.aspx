<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_Introduction.aspx.cs" Inherits="RSSMWeb.systemmanage.Project_Introduction1" %>

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
          .x-grid3-row-body .expander
        {
            padding: 5px;
        }
        .x-grid3-row-body .expander p
        {
            padding: 5px;
        }
        .x-grid3-row-body .expander strong
        {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="Panel2" Title="问题列表" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        Width="1100px" ShowBorder="True" ShowHeader="True" EnableCollapse="true">
        <Items>
            <ext:Form ID="Form7" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:TextBox ID="TextBox5" Label="项目名称" runat="server">
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
                            <ext:Button ID="Button4" Icon="Add" Text="添加" ToolTip="从ERP添加新的项目" EnablePostBack="false"
                                runat="server">
                            </ext:Button>
                            <ext:Button ID="Button5" Icon="Delete" Text="删除" ToolTip="删除项目" runat="server" OnClick="btnDelete_Click" ConfirmText='"确定要执行删除操作?"' ConfirmTitle="删除确认">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="部门表格" PageSize="10" ShowBorder="true" ShowHeader="False"
                        OnRowDoubleClick="ShowDetails" EnableRowDoubleClick="false" runat="server" EnableCheckBoxSelect="true"
                        DataKeyNames="pj_id,pj_name" EnableRowNumber="false" AutoWidth="true" AllowPaging="True"  OnPageIndexChange="Grid1_PageIndexChange">
                        <Columns>
                            <ext:TemplateField RenderAsRowExpander="true">
                                <ItemTemplate>
                                    <div class="expander">
                                        <p>
                                          &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  
                                          <strong>联系人：</strong><%# Eval("cus_contact")%></p>
                                        <p>
                                           &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                           <strong>联系电话：</strong><%# Eval("contact_phone")%></p>
                                        <p>
                                           &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
                                           <strong>送货地址：</strong><%# Eval("cus_address")%></p>
                                    </div>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:BoundField Width="60px" DataField="pj_id" DataFormatString="{0}" HeaderText="项目编号" />
                            <ext:BoundField Width="330px" DataField="pj_name" DataFormatString="{0}" HeaderText="项目名称" />
                           <%-- <ext:TemplateField Width="160px" HeaderText="结束标识">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# GetOIName(Eval("finish_flag")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>--%>
                            
                            <ext:BoundField Width="160px"  DataField="agent_name" DataFormatString="{0}" HeaderText="代理商" />
                            <ext:BoundField Width="160px"  DataField="cus_name" HeaderText="客户" />
                            <ext:BoundField Width="60px"  DataField="user_name_full" HeaderText="业务员" />
                            <ext:BoundField Width="60px"  DataField="code_desp" HeaderText="所属地区" />
                            <ext:CheckBoxField Width="60px" RenderAsStaticField="true" DataField="finish_flag" HeaderText="结束标识" />
                            <ext:TemplateField HeaderText="操作" Width="60px">
                                <ItemTemplate>
                                    <a href="javascript:<%# GetEditUrl(Eval("pj_id"), Eval("pj_name")) %>">编辑</a>
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
        IsModal="True" Width="400px" Height="500px">
    </ext:Window>
    </form>
</body>
</html>
