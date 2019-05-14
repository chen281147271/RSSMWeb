<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_new.aspx.cs" Inherits="RSSMWeb.systemmanage.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <ext:Panel ID="Panel1" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true"  >
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose"  >
                    </ext:Button>
                    <ext:Button ID="btnSaveContinue" Text="保存回发" runat="server" Icon="SystemSaveNew"
                         Visible="false">
                    </ext:Button>
                    <ext:Button ID="btnSaveRefresh" Text="保存" runat="server" Icon="SystemSaveNew" ValidateTarget="Parent"
                          ValidateForms="SimpleForm1" ConfirmText='"确定保存信息?"' ConfirmTitle="保存确认" OnClick="btnSaveRefresh_Click" >
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="Panel2" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false" >
                <Items>
                    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <ext:TextBox ID="txt_logname" Label="登入名" runat="server" Required="true" ShowRedStar="true"  />
                            <ext:TextBox ID="txt_username" Label="用户姓名" runat="server" Required="true" ShowRedStar="true" />   
                            <ext:TextBox ID="txt_password" Label="登入密码" runat="server" Required="false" 
                                ShowRedStar="false" TextMode="Password"   /> 
                            <ext:DropDownList ID="dr_userstate" runat="server" Label="用户状态" Required="true" ShowRedStar="true">
                                        <ext:ListItem Text="正常" Value="2001" Selected="true" />
                                        <ext:ListItem Text="停用" Value="2002" />
                            </ext:DropDownList>
                            <ext:TextBox ID="txt_email" Label="电子邮件" runat="server" Required="false"  ShowRedStar="false" /> 
                            <ext:TextBox ID="txt_phone" Label="电话号码" runat="server" Required="false"  ShowRedStar="false" /> 
                            <ext:TextBox ID="txt_cellphone" Label="手机号码" runat="server" Required="false"  ShowRedStar="false" /> 
                            <ext:TextBox ID="txt_homeadr" Label="家庭住址" runat="server" Required="false"  ShowRedStar="false" /> 
                            <ext:TextBox ID="txt_psw_validate" Label="密码过期时间" runat="server" Required="false"  ShowRedStar="false"  Enabled="false" /> 
                            <ext:DropDownList ID="dr_managetype" runat="server" Label="职位" Required="true" ShowRedStar="true"/>
                           <ext:DropDownList ID="dr_dpt" runat="server" Label="所属部门" Required="true" ShowRedStar="true" />
                                                  
                            
                                                  
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
