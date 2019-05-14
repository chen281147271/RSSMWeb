<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMessage_New.aspx.cs" Inherits="RSSMWeb.myjob.MyMessage_New" validateRequest="false" %>

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
        BodyPadding="5px" EnableBackgroundColor="true"  >
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                  <ext:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                               <ext:ListItem Text="按用户"  Value="按文件名" Selected="true"/>
                               <ext:ListItem Text="按部门" Value="按问题ID"/>
                               <%--<ext:ListItem Text="按角色"  Value="按提出人"/>--%>
                            </ext:DropDownList>
                            
                            <ext:DropDownList ID="DropDownList2" runat="server"  AutoPostBack="false" 
                            OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                            </ext:DropDownList>

                              <ext:DropDownList ID="DropDownList3" runat="server"  AutoPostBack="false"
                              OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                            </ext:DropDownList>
                          <ext:Button ID="btnSaveRefresh" Text="发送" runat="server" Icon="SystemSaveNew" ValidateTarget="Parent"
                          ValidateForms="SimpleForm1" ConfirmText='"确定保存信息?"' ConfirmTitle="保存确认" OnClick="btnSaveRefresh_Click" >
                          </ext:Button>
                    <ext:ToolbarFill ID="ToolbarFill1" runat="server">
                    </ext:ToolbarFill>
              
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" >
                    </ext:Button>
                    <ext:Button ID="btnSaveContinue" Text="保存回发" runat="server" Icon="SystemSaveNew"
                         Visible="false" OnClick="btnSaveContinue_Click" ValidateForms="SimpleForm1">
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
                        <ext:TextBox ID="txt_title" Label="信息标题" runat="server" Required="true"  ShowRedStar="true" /> 
                            <ext:HtmlEditor  runat="server" Label="文本编辑器" ID="HtmlEditor1" Height="250px" >
                            </ext:HtmlEditor>
                           <%-- <ext:TextArea  ID="TextArea1"   Label="多行文本框" runat="server"  Height="150px">
                           
                            </ext:TextArea>--%>
                            <%-- <ext:Label EncodeText="false" runat="server" ID="Label1" ></ext:Label>--%>
                            
                            
                            
                                
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
