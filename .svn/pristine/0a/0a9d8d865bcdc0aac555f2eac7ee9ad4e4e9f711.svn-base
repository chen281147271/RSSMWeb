<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dpt_new.aspx.cs" Inherits="RSSMWeb.systemmanage.dpt_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <ext:Panel ID="Panel1" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose"  >
                    </ext:Button>
                    <ext:Button ID="btnSaveContinue" Text="保存回发" runat="server" Icon="SystemSaveNew"
                        OnClick="btnSaveContinue_Click" Visible="false">
                    </ext:Button>
                    <ext:Button ID="btnSaveRefresh" Text="保存" runat="server" Icon="SystemSaveNew" ValidateTarget="Parent"
                        OnClick="btnSaveRefresh_Click"  ValidateForms="SimpleForm1" ConfirmText='"确定保存信息?"' ConfirmTitle="保存确认" >
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="Panel2" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <ext:TextBox ID="TextBox5" Label="部门名称" runat="server" Required="true" ShowRedStar="true"  />
                            <ext:TextBox ID="TextBox1" Label="成员职位" runat="server" Required="false"  />   
                            <ext:TextBox ID="TextBox2" Label="管理职位" runat="server" Required="false"   /> 
                            <ext:TextBox ID="TextBox3" Label="助理职位" runat="server" Required="false"   /> 
                            <ext:DropDownList ID="dr_dpt" runat="server" Label="上级部门" Required="true" ShowRedStar="true" />                           
                            <ext:CheckBox ID="CheckBox1" runat="server" Text="" Label="顶层">
                            </ext:CheckBox>                      
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
