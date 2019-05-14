<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SDCMissionDetails.aspx.cs" Inherits="RSSMWeb.developmanage.SDCMissionDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <ext:Panel ID="Panel1" runat="server" Layout="Form" ShowBorder="true" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true" AutoScroll="True">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </ext:Button>
                    <ext:Button ID="btnSaveRefresh2" Text="保存新增" runat="server" Icon="SystemSaveNew"  ValidateForms="Form2" ValidateTarget="Self"
                        OnClick="btnSaveRefresh_Click2"  ConfirmText="确认新增该任务?" ConfirmTitle="确认"  >
                    </ext:Button>
                    <ext:Button ID="btnSaveRefresh" Text="保存变更" runat="server" Icon="SystemSaveNew" OnClick="btnSaveRefresh_Click"
                    ConfirmText="确认保存该任务?" ConfirmTitle="确认" ValidateForms="Form2" ValidateTarget="Self" >
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="Panel2" Layout="Form" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <ext:Form ID="Form2" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="TextBox5" Label="任务标题" runat="server"  ShowRedStar="True" Required="True" />
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:CheckBox ID="CheckBox1" runat="server" Text="" Label="是否完成">
                                    </ext:CheckBox>
                                </Items>
                            </ext:FormRow> 
                            
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="DropDownList7" runat="server" Label="开发负责人" ShowRedStar="True" Required="True" >
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="DropDownList6" runat="server" Label="测试负责人" ShowRedStar="True" Required="True">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            
                            <ext:FormRow>
                                <Items>
                                    <ext:DatePicker ID="DatePicker2" runat="server" Label="开始日期" ShowRedStar="True" Required="True">
                                    </ext:DatePicker>
                                    <ext:DatePicker ID="DatePicker4" runat="server" Label="预期完成时间" ShowRedStar="True" Required="True">
                                    </ext:DatePicker>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DatePicker ID="DatePicker3" runat="server" Label="实际完成日期">
                                    </ext:DatePicker>
                                    <ext:NumberBox  ID="NumBox2" Label="绩效分值" runat="server"  MinValue="0" NoDecimal="true" NoNegative="True" />
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea ID="content" Label="任务说明" Height="60px" runat="server"  ShowRedStar="True" Required="True"
                                        Enabled="True" >
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:Panel>
            <ext:Panel ID="Panel3" Layout="Form" runat="server" ShowBorder="true" ShowHeader="false">
            <Toolbars>
                    <ext:Toolbar ID="Toolbar2" runat="server">
                        <Items>
                            <ext:Button ID="Button3" Icon="Add"  Text="新增" ToolTip="新增明细" 
                                 runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="任务明细" PageSize="3" ShowBorder="true" ShowHeader="True"
                        runat="server"  DataKeyNames="sdd_detail_id" EnableRowNumber="true" >
                        <Columns>
                            <ext:CheckBoxField Width="40px" RenderAsStaticField="true" DataField="finish_flag" HeaderText="完结" />
                            <ext:BoundField Width="40px" DataField="sdd_detail_id" DataFormatString="{0}" HeaderText="编号" />
                            <ext:BoundField Width="80px" DataField="charger_name" DataFormatString="{0}" HeaderText="任务负责人" />
                            <ext:TemplateField Width="160px" HeaderText="任务内容" >
                                    <ItemTemplate>
                                        <a href="javascript:<%# GetEditUrl(Eval("sdd_detail_id"),Eval("sdd_pjm_id"), 2) %>">
                                        <asp:Label ID="Label2"  EncodeText="fasle" runat="server" Text='<%#Eval("mission_content")%>'></asp:Label>
                                        </a>
                                    </ItemTemplate>
                                </ext:TemplateField>
                            <ext:BoundField Width="80px" DataField="begin_date" DataFormatString="{0}" HeaderText="开始时间" />
                            <ext:BoundField Width="80px" DataField="expect_date" DataFormatString="{0}" HeaderText="期望时间" />
                            <ext:BoundField Width="80px" DataField="finish_date" DataFormatString="{0}" HeaderText="完结时间" />
                            <ext:BoundField Width="60px" DataField="PAP" HeaderText="基础分值" />
                            <ext:BoundField Width="60px" DataField="rPAP" HeaderText="实际分值" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
        <ext:Window ID="Window1" Title="任务细节" Popup="false" EnableIFrame="true" runat="server"
            CloseAction="HidePostBack" EnableConfirmOnClose="true" IFrameUrl="about:blank"
            EnableMaximize="true" EnableResize="true" Target="Top"
            IsModal="True" Width="600px"  Layout="Form" Height="250px" AutoHeight="True" AutoScroll="True">
        </ext:Window>
    </form>
</body>
</html>
