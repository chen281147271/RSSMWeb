<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectplan.aspx.cs" Inherits="RSSMWeb.projectsmanage.projectplan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .rowpanel
        {
            margin-bottom: 5px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="Panel2" Title="项目列表" runat="server" 
        EnableBackgroundColor="true" BodyPadding="5px" Width="1024px" ShowBorder="True"
        ShowHeader="True" EnableCollapse="true" >
        <Items>
            <ext:Form ID="Form7" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:TextBox ID="TextBox5" Label="项目编号" runat="server">
                            </ext:TextBox>
                            <ext:TextBox ID="TextBox8" Label="项目名称" runat="server">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:TextBox ID="TextBox1" Label="ERP编号" runat="server">
                            </ext:TextBox>
                            <ext:TextBox ID="TextBox2" Label="状态" runat="server">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DropDownList ID="DropDownList3" runat="server" Label="所属地区" >
                            </ext:DropDownList>
                            <ext:Button ID="Button11" Text="搜索" runat="server"  Icon="BulletMagnify"  OnClick="QueryPJ" >
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
             <ext:Panel ID="Panel6" ShowBorder="True" ShowHeader="false" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:CheckBox ID="CheckBox1" runat="server" Text="未计划" Label="未计划" >
                            </ext:CheckBox>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="项目表格" PageSize="4" ShowBorder="true" ShowHeader="False" 
                        runat="server" EnableCheckBoxSelect="false" DataKeyNames="pj_id" EnableRowNumber="True" AllowSorting="true">
                        <Columns>
                            <ext:CheckBoxField Width="60px" RenderAsStaticField="true" DataField="plan_id" HeaderText="是否计划" />
                            <ext:BoundField Width="60px" DataField="sub_pj_id" SortField="sub_pj_id" DataFormatString="{0}" HeaderText="子项目编号" />
                            <ext:BoundField Width="60px" DataField="pj_id" SortField="pj_id" DataFormatString="{0}" HeaderText="编号" />
                            <ext:BoundField Width="200px" DataField="pj_name" DataFormatString="{0}" HeaderText="项目名称" />
                            <ext:BoundField Width="200px" DataField="sub_pj_desc" DataFormatString="{0}" HeaderText="子项目描述" />
                            <ext:BoundField Width="100px" DataField="user_name_full" DataFormatString="{0}" HeaderText="销售" />
                            <ext:CheckBoxField Width="60px" RenderAsStaticField="true" DataField="finish_flag" HeaderText="是否完结" />
                            <ext:BoundField Width="120px" DataField="agent_name" HeaderText="代理商"  />
                            <ext:BoundField Width="100px" DataField="cus_name" DataFormatString="{0}" HeaderText="客户" />
                            <ext:TemplateField Width="60px" HeaderText="地区">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# GetSysCode(Eval("area_code")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                             
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
     <br />
    <ext:Panel ID="Panel3" Title="深圳市第二人民医院----订单项目计划" runat="server"  
        BodyPadding="5px" Width="1024px" ShowBorder="True" EnableBackgroundColor="false"
        ShowHeader="True" EnableCollapse="true" CssClass="rowpanel" >
        <Items>
        <ext:Form ID="Form6" runat="server" EnableBackgroundColor="true" ShowBorder="True"
                BodyPadding="5px" ShowHeader="true" Title="人员计划"  EnableCollapse="true" CssClass="rowpanel">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:DropDownList ID="DropDownList1" runat="server" Label="销售责任人" Width="150px" >
                                <ext:ListItem Text="王庆磊" Value="wql" Selected="true" />
                                <ext:ListItem Text="刘海滨" Value="lhb" />
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DropDownList ID="DropDownList2" runat="server" Label="实施责任人" Width="150px">
                                <ext:ListItem Text="陈灿良" Value="ccl" Selected="true" />
                                <ext:ListItem Text="崔高峰" Value="cgf" />
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:Button ID="Button7" Text="提交" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="Form3" runat="server" EnableBackgroundColor="true" ShowBorder="True"
                BodyPadding="5px" ShowHeader="true" Title="启动阶段" EnableCollapse="true"  LabelWidth="150px" CssClass="rowpanel" >
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:Label ID="Label2" Label="项目启动时间" Text="2013/7/15" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="DatePicker1" runat="server" Label="方案确认日期"  Required="true"
                                ShowRedStar="true" EmptyText="请输入计划日期" ShowEmptyLabel="True" Width="150px" >
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="DatePicker2" runat="server" Label="项目计划书提交日期"  Required="true"
                                ShowRedStar="true" EmptyText="请输入计划日期" ShowEmptyLabel="True" Width="150px" >
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="DatePicker3" runat="server" Label="ERP标准产品下单日期"  Required="true"
                                ShowRedStar="true" EmptyText="请输入计划日期" ShowEmptyLabel="True" Width="150px" >
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:Button ID="Button2" Text="提交" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
     
            <ext:Form ID="Form2" runat="server" EnableBackgroundColor="true" ShowBorder="True" CssClass="rowpanel"
                BodyPadding="5px" ShowHeader="true" Title="数据采集阶段" LabelWidth="150px"  EnableCollapse="true">
                <Rows>
                   <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="DatePicker4" runat="server" Label="数据采集日期"  Required="true"
                                ShowRedStar="true" EmptyText="请输入计划日期" ShowEmptyLabel="True" Width="150px" >
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="DatePicker6" runat="server" Label="ERP定制产品下单日期"  Required="true"
                                ShowRedStar="true" EmptyText="请输入计划日期" ShowEmptyLabel="True" Width="150px" >
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:Button ID="Button1" Text="提交" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>

            <ext:Form ID="Form4" runat="server" EnableBackgroundColor="true" ShowBorder="True" CssClass="rowpanel"
                BodyPadding="5px" ShowHeader="true" Title="生产阶段"  LabelWidth="150px"  EnableCollapse="true">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="DatePicker7" runat="server" Label="生产完成日期"  Required="true"
                                ShowRedStar="true" EmptyText="请输入计划日期" ShowEmptyLabel="True" Width="150px" >
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="DatePicker8" runat="server" Label="品检完成日期"  Required="true"
                                ShowRedStar="true" EmptyText="请输入计划日期" ShowEmptyLabel="True" Width="150px" >
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="DatePicker9" runat="server" Label="产品发货日期"  Required="true"
                                ShowRedStar="true" EmptyText="请输入计划日期" ShowEmptyLabel="True" Width="150px" >
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:Button ID="Button8" Text="提交" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>

            <ext:Form ID="Form5" runat="server" EnableBackgroundColor="true" ShowBorder="True"
                BodyPadding="5px" ShowHeader="true" Title="实施阶段"  LabelWidth="150px"  EnableCollapse="true">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="DatePicker5" runat="server" Label="产品到货日期"  Required="true"
                                ShowRedStar="true" EmptyText="请输入计划日期" ShowEmptyLabel="True" Width="150px" >
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="DatePicker10" runat="server" Label="产品上线日期"  Required="true"
                                ShowRedStar="true" EmptyText="请输入计划日期" ShowEmptyLabel="True" Width="150px" >
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="DatePicker11" runat="server" Label="实施验收日期"  Required="true"
                                ShowRedStar="true" EmptyText="请输入计划日期" ShowEmptyLabel="True" Width="150px" >
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:Button ID="Button3" Text="提交" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:Panel>
   
    </form>
</body>
</html>
