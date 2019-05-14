<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_bug.aspx.cs" Inherits="RSSMWeb.projectsmanage.iframe_bug" %>

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
    <ext:TabStrip ID="TabStrip1" Width="800px" ShowBorder="true" ActiveTabIndex="0"
        runat="server">
        <Tabs>
            <ext:Tab ID="Tab1" Title="生产装配" EnableBackgroundColor="true" BodyPadding="5px" Layout="Fit"
                runat="server">
                <Items>
                    <ext:Panel ID="Panel2" Title="问题列表" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
                        Width="800px" ShowBorder="True" ShowHeader="True" EnableCollapse="true" >
                        <Items>
                            <ext:Form ID="Form7" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                                ShowHeader="False" runat="server">
                                <Rows>
                                    <ext:FormRow>
                                        <Items>
                                            <ext:TextBox ID="TextBox5" Label="问题编号" runat="server">
                                            </ext:TextBox>
                                            <ext:TextBox ID="TextBox8" Label="问题主题" runat="server">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow>
                                        <Items>
                                            <ext:DropDownList ID="DropDownList3" runat="server" Label="问题子类">
                                                <ext:ListItem Text="机械结构" Value="100" />
                                                <ext:ListItem Text="电气控制" Value="101" />
                                                <ext:ListItem Text="软件" Value="102" />
                                                <ext:ListItem Text="电子" Value="103"  />
                                                <ext:ListItem Text="流程及操作" Value="104" />
                                                <ext:ListItem Text="其他" Value="105" />
                                                <ext:ListItem Text="全部" Value="106" Selected="true"/>
                                            </ext:DropDownList>
                                            <ext:DropDownList ID="DropDownList1" runat="server" Label="提出人">
                                                <ext:ListItem Text="詹锦云" Value="100"  />
                                                <ext:ListItem Text="李建文" Value="101" />
                                                <ext:ListItem Text="马光磊" Value="102" />
                                                <ext:ListItem Text="全部" Value="103" Selected="true"/>
                                            </ext:DropDownList>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow>
                                        <Items>
                                            <ext:DropDownList ID="DropDownList2" runat="server" Label="当前状态">
                                                <ext:ListItem Text="新增" Value="100"  />
                                                <ext:ListItem Text="关闭" Value="101" />
                                                <ext:ListItem Text="处理中" Value="102" />
                                                <ext:ListItem Text="验证中" Value="103"  />
                                                <ext:ListItem Text="分析中" Value="104" />
                                                <ext:ListItem Text="废弃" Value="105" />
                                                <ext:ListItem Text="暂不处理" Value="106" />
                                                <ext:ListItem Text="全部" Value="107" Selected="true" />
                                            </ext:DropDownList>                                            
                                            <ext:Button ID="Button2" Text="搜索" runat="server">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                            <ext:Panel ID="Panel6" ShowBorder="True" ShowHeader="false" runat="server">
                                <Toolbars>
                                    <ext:Toolbar ID="Toolbar1" runat="server">
                                        <Items>
                                            <ext:Button ID="Button4" Icon="Add" Text="添加" ToolTip="添加新问题" EnablePostBack="false" runat="server">
                                            </ext:Button>
                                            <ext:Button ID="Button5" Icon="ChartOrganisationAdd" Text="合并" ToolTip="合并问题列表" runat="server">
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </Toolbars>
                                <Items>
                                    <ext:Grid ID="Grid1" Title="项目表格" PageSize="3" ShowBorder="true" ShowHeader="False" OnRowDoubleClick="ShowDetails"
                                    EnableRowDoubleClick="true"
                                        runat="server" EnableCheckBoxSelect="true" DataKeyNames="bug_id,bug_title" EnableRowNumber="false">
                                        <Columns>
                                            <ext:BoundField Width="60px" DataField="bug_id"  DataFormatString="{0}" HeaderText="问题编号" />
                                            <ext:BoundField Width="160px" DataField="bug_title" DataFormatString="{0}" HeaderText="问题主题" />
                                            <ext:BoundField Width="80px" DataField="bug_create_time" HeaderText="创建时间" />
                                            <ext:BoundField Width="60px" DataField="create_person_name" DataFormatString="{0}"
                                                HeaderText="创建人" />
                                            <ext:BoundField Width="60px" DataField="bug_state" HeaderText="状态"  />
                                             <ext:BoundField Width="60px" DataField="deal_person_name" DataFormatString="{0}"
                                                HeaderText="处理人" />
                                            <ext:BoundField Width="60px" DataField="bug_PDBelong" DataFormatString="{0}"
                                                HeaderText="所属产品" />                                 
                                            <ext:BoundField Width="80px" DataField="bug_PJBelong" DataFormatString="{0}" HeaderText="所属项目" />
                                            <ext:TemplateField HeaderText="操作" Width="60px">
                                                <ItemTemplate>
                                                    <a href="javascript:<%# GetEditUrl(Eval("bug_id"), Eval("bug_title")) %>">查看</a>&nbsp;
                                                    <a href="javascript:<%# GetEditUrl(Eval("bug_id"), Eval("bug_title")) %>">编辑</a>
                                                </ItemTemplate>
                                            </ext:TemplateField>
                                        </Columns>
                                    </ext:Grid>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Tab>
            <ext:Tab ID="Tab2" Title="<span class='highlight'>品质测试(5)</span> " BodyPadding="5px"
                EnableBackgroundColor="true" runat="server">
                <Items>
                    <ext:Label ID="Label1" CssClass="highlight" Text="第三个标签的内容" runat="server" />
                </Items>
            </ext:Tab>
            <ext:Tab ID="Tab3" Title="项目实施" BodyPadding="5px" EnableBackgroundColor="true" runat="server">
                <Items>
                    <ext:Label ID="Label3" CssClass="highlight" Text="第三个标签的内容" runat="server" />
                </Items>
            </ext:Tab>
            <ext:Tab ID="Tab4" Title="售后服务" BodyPadding="5px" EnableBackgroundColor="true" runat="server">
                <Items>
                    <ext:Label ID="Label2" CssClass="highlight" Text="第三个标签的内容）" runat="server" />
                </Items>
            </ext:Tab>
        </Tabs>
    </ext:TabStrip>
    <ext:Window ID="Window1" Title="编辑" Popup="false" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" EnableConfirmOnClose="true" IFrameUrl="about:blank"
        EnableMaximize="true" EnableResize="true" OnClose="Window1_Close" Target="Top"
        IsModal="True" Width="800px" Height="650px">
    </ext:Window>
    </form>
</body>
</html>
