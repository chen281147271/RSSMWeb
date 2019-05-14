<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agent_new.aspx.cs" Inherits="RSSMWeb.projectsmanage.agent_new" %>

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
                         Visible="false" OnClick="btnSaveContinue_Click">
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
                            <ext:TextBox ID="txt_agentname" Label="代理商名称" runat="server" Required="true" ShowRedStar="true"  />
                            <ext:TextBox ID="txt_contactname" Label="联系人" runat="server" Required="false" ShowRedStar="false" />   
                            <ext:TextBox ID="txt_contactphone" Label="联系人电话" runat="server" Required="false" ShowRedStar="false"  /> 
                            <ext:TextBox ID="txt_contactdesc" Label="备注" runat="server" Required="false"  ShowRedStar="false" /> 
                            <ext:TextBox ID="txt_contactaddress" Label="代理商所在地" runat="server" Required="false"  ShowRedStar="false" /> 
                                
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
