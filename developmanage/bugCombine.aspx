<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bugCombine.aspx.cs" Inherits="RSSMWeb.developmanage.bugCombine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="Panel2" Title="问题列表" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        Width="1000px" ShowBorder="True" ShowHeader="True" EnableCollapse="true">
        <Items>
            <ext:Form ID="Form7" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:NumberBox  ID="nbBugId" Label="问题编号" runat="server"  EmptyText="输入问题数字编号">
                            </ext:NumberBox >
                            <ext:TextBox ID="TextBox8" Label="问题标题" runat="server">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DropDownList ID="DropDownList3" runat="server" Label="问题子类">
                                <ext:ListItem Text="机械结构" Value="9001" />
                                <ext:ListItem Text="电气控制" Value="9002" />
                                <ext:ListItem Text="软件" Value="9003" />
                                <ext:ListItem Text="电子" Value="9004" />
                                <ext:ListItem Text="流程及操作" Value="9005" />
                                <ext:ListItem Text="其他" Value="9006" />
                                <ext:ListItem Text="全部" Value="0" Selected="true" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="DropDownList1" runat="server" Label="提出人">
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DropDownList ID="DropDownList4" runat="server" Label="过程类型">
                                <ext:ListItem Text="研发设计发现问题" Value="5001" />
                                <ext:ListItem Text="生产装配发现问题" Value="5002" />
                                <ext:ListItem Text="品质测试发现问题" Value="5003" />
                                <ext:ListItem Text="项目实施发现问题" Value="5004" />
                                <ext:ListItem Text="售后服务发现问题" Value="5005" />
                                <ext:ListItem Text="流程运行发现问题" Value="5006" />
                                <ext:ListItem Text="其他" Value="5007" />
                                <ext:ListItem Text="全部" Value="0" Selected="true" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="DropDownList5" runat="server" Label="待处理人">
                            <ext:ListItem Text="全部" Value="0" Selected="true" />
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DropDownList ID="DropDownList2" runat="server" Label="当前状态">
                                <ext:ListItem Text="新增" Value="6001" />
                                <ext:ListItem Text="开启" Value="6002" />
                                <ext:ListItem Text="修复" Value="6003" />
                                <ext:ListItem Text="关闭" Value="6004" />
                                <ext:ListItem Text="忽略" Value="6005" />
                                <ext:ListItem Text="废弃" Value="6006" />
                                <ext:ListItem Text="全部" Value="0" Selected="true" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="DropDownList7" runat="server" Label="所属产品">
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DropDownList ID="DropDownList6" runat="server" Label="所属项目">
                            </ext:DropDownList>
                            <ext:Button ID="Button2" Text="搜索" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:CheckBox ID="CombineFlag" runat="server" Text="" Label="合并后显示" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="Panel6" ShowBorder="True" ShowHeader="false" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="Button4" Icon="Add" Text="添加" ToolTip="添加新问题" EnablePostBack="false"
                                runat="server">
                            </ext:Button>
                            <ext:Button ID="Button5" Icon="ChartOrganisationAdd" Text="合并" ToolTip="合并问题列表" runat="server" 
                            ConfirmIcon="Information" ConfirmText="确定对所选定的问题进行主题合并" OnClick="CombineBugs" >
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="项目表格" PageSize="15" ShowBorder="true" ShowHeader="False"
                        OnRowDoubleClick="ShowDetails" EnableRowDoubleClick="false" runat="server" EnableCheckBoxSelect="true"
                        DataKeyNames="bug_id,detail_id" EnableRowNumber="false"  OnPageIndexChange="Grid1_PageIndexChange"
                         AllowPaging="true"   >
                        <Columns>
                            <ext:BoundField Width="40px" DataField="bug_id" DataFormatString="{0}" HeaderText="编号" />
                            <ext:BoundField Width="40px" DataField="detail_id" DataFormatString="{0}" HeaderText="子编号" />
                            <ext:BoundField Width="160px" DataField="bug_title" DataFormatString="{0}" HeaderText="问题主题" />
                            <ext:BoundField Width="100px" DataField="create_time" HeaderText="创建时间" />
                            <ext:TemplateField Width="60px" HeaderText="类型">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# GetSysCode(Eval("bug_type")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="过程类型">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# GetSysCode(Eval("process_type")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:BoundField Width="60px" DataField="create_user_name" DataFormatString="{0}" HeaderText="创建人" />
                            <ext:TemplateField Width="40px" HeaderText="状态">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# GetSysCode(Eval("bug_state")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:BoundField Width="60px" DataField="next_user_name" DataFormatString="{0}" HeaderText="待处理人" />
                            <ext:TemplateField Width="60px" HeaderText="优先级">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# GetSysCode(Eval("PRI")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:BoundField Width="80px" DataField="pd_name" DataFormatString="{0}" HeaderText="所属产品" />
                            <ext:BoundField Width="100px" DataField="pj_name" DataFormatString="{0}" HeaderText="所属项目" />
                            <ext:TemplateField HeaderText="操作" Width="60px">
                                <ItemTemplate>
                                    <a href="javascript:<%# GetEditUrl(Eval("detail_id"), Eval("bug_title"),1) %>">查看</a>&nbsp;
                                    <a href="javascript:<%# GetEditUrl(Eval("detail_id"), Eval("bug_title"),2) %>">编辑</a>
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
        IsModal="True" Width="800px"  Layout="Form" Height="650px" AutoHeight="True" AutoScroll="True">
    </ext:Window>
    </form>
</body>
</html>
