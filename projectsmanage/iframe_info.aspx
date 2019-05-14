<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_info.aspx.cs" Inherits="RSSMWeb.projectsmanage.iframe_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <ext:Panel ID="Panel1" BodyPadding="5px" runat="server" EnableBackgroundColor="true"
        EnableCollapse="True" Title="深圳市第二人民医院" Width="1000px">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="Button4" Text="编辑" ToolTip="修改项目信息" runat="server">
                    </ext:Button>
                    <ext:Button ID="Button5" Text="放弃" ToolTip="放弃修改,恢复前状" runat="server">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel runat="server" AutoHeight="true" Title="基本信息" ID="GroupPanel1" EnableCollapse="True">
                <Items>
                    <ext:Form ID="Form2" runat="server" EnableBackgroundColor="true" ShowBorder="False" CssClass=".rowpanel"
                        ShowHeader="False">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="TextBox1" Label="项目编号" runat="server" Enabled="false" Width="200px" Text="2013-01">
                                    </ext:TextBox>
                                    <ext:Label Label="完结状态" runat="server" Text="未完结">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="TextBox2" Label="项目名称" runat="server" Enabled="false" Text="深圳市第二人民医院药房项目">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="TextBox3" Label="单别" runat="server" Enabled="false">
                                    </ext:TextBox>
                                    <ext:TextBox ID="TextBox4" Label="单号" runat="server" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="TextBox5" Label="客户编号" runat="server" Enabled="false">
                                    </ext:TextBox>
                                    <ext:DropDownList ID="DropDownList3" runat="server" Label="所属地区" Enabled="false">
                                        <ext:ListItem Text="广东" Value="100" Selected="true" />
                                        <ext:ListItem Text="河南" Value="101" />
                                        <ext:ListItem Text="浙江" Value="102" />
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="TextBox6" Label="联系人" runat="server" Enabled="false">
                                    </ext:TextBox>
                                    <ext:TextBox ID="TextBox7" Label="联系电话" runat="server" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="TextBox8" Label="客户地址" runat="server" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" EnableBackgroundColor="true" AutoHeight="true" Title="子订单信息"
                runat="server" EnableCollapse="True">
                <Items>
                    <ext:Grid ID="Grid1" Title="子订单表格" PageSize="4" ShowBorder="true" ShowHeader="False" 
                        runat="server" EnableCheckBoxSelect="false" DataKeyNames="subpj_id" EnableRowNumber="True" AllowSorting="true">
                        <Columns>                           
                            <ext:BoundField Width="60px" DataField="subpj_id" SortField="subpj_id" DataFormatString="{0}" HeaderText="单号" />
                            <ext:BoundField Width="190px" DataField="pd_name" DataFormatString="{0}" HeaderText="品名" />
                            <ext:BoundField Width="120px" DataField="subpj_unit" HeaderText="规格" />
                            <ext:BoundField Width="120px" DataField="subpj_create_time" HeaderText="订单时间" SortField="subpj_create_time"/>
                            <ext:BoundField Width="80px" DataField="business_person_name" DataFormatString="{0}" HeaderText="业务员" />
                            <ext:BoundField Width="60px" DataField="order_num" DataFormatString="{0}" HeaderText="订单数量" />
                            <ext:BoundField Width="60px" DataField="finish_num" DataFormatString="{0}" HeaderText="已交数量" />
                            <ext:BoundField Width="60px" DataField="unfinish_num" DataFormatString="{0}" HeaderText="未交数量" />
                            <ext:BoundField Width="60px" DataField="gift_num" DataFormatString="{0}" HeaderText="赠送数量" />
                            <ext:BoundField Width="60px" DataField="finish_gift_num" DataFormatString="{0}" HeaderText="已赠送" />
                            <ext:CheckBoxField Width="60px" RenderAsStaticField="true" DataField="subpj_state" HeaderText="结束状态" />    
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" EnableBackgroundColor="true" AutoHeight="true" Title="项目运行记录"
                runat="server" EnableCollapse="True">
                <Items>
                    <ext:Form ID="Form3" runat="server" EnableBackgroundColor="true" ShowBorder="False" CssClass=".rowpanel"
                            ShowHeader="False">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Grid ID="Grid2" Title="子订单表格" PageSize="4" ShowBorder="true" ShowHeader="False"
                                        runat="server" EnableCheckBoxSelect="false" DataKeyNames="oper_info" EnableRowNumber="True">
                                        <Columns>
                                            <ext:BoundField Width="260px" DataField="oper_info"  DataFormatString="{0}" HeaderText="操作内容" />
                                            <ext:BoundField Width="190px" DataField="oper_time" DataFormatString="{0}" HeaderText="操作时间" />
                                            <ext:BoundField Width="120px" DataField="oper_person" HeaderText="处理人/部门" />
                                            <ext:BoundField Width="120px" DataField="next_person" HeaderText="接受人/部门"  />
                                        </Columns>
                                    </ext:Grid>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea ID="TextArea1" runat="server" Label="备注" Height="60px" ShowLabel="false" 
                                    AutoGrowHeight="true" AutoGrowHeightMin="60" AutoGrowHeightMax="500" Text="单宝莉 2013-01-0
 客户要求暂停发货,等待医院方准备场地.
 --------------------------------------------------------" Enabled="false" >
                                    
                                    </ext:TextArea>
                                </Items>
                                
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="TextBox9" runat="server" Label="Label" Text="" ShowLabel="false" EmptyText="增加留言注释" >
                                    </ext:TextBox>
                                    <ext:Button ID="Button1" Text="留言" ToolTip="增加留言" runat="server">
                                    </ext:Button>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>

    </form>
</body>
</html>
