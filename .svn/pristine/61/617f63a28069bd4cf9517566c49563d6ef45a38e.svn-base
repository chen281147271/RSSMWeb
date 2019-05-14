<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SDCMissionDetails_P.aspx.cs" Inherits="RSSMWeb.developmanage.SDCMissionDetails_P" %>

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
                                    <ext:Label ID="Label1" Label="任务编号" runat="server"  />
                                    <ext:CheckBox ID="CheckBox1" runat="server" Text="" Label="是否完成">
                                    </ext:CheckBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="DropDownList7" runat="server" Label="负责人" ShowRedStar="True" Required="True" >
                                    </ext:DropDownList>
                                    <ext:DatePicker ID="DatePicker3" runat="server" Label="实际完成日期">
                                    </ext:DatePicker>
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
                                    <ext:NumberBox  ID="NumBox2" Label="绩效分值" runat="server"  MinValue="0" NoDecimal="true" NoNegative="True" />
                                    <ext:NumberBox  ID="NumberBox1" Label="获取分值" runat="server"  MinValue="0" NoDecimal="true" NoNegative="True" />
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
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
