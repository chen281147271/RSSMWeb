<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_Introduction_new.aspx.cs" Inherits="RSSMWeb.systemmanage.Project_Introduction" %>

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
        BodyPadding="5px" EnableBackgroundColor="true" >
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                   <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose"  >
                    </ext:Button>
                    <ext:Button ID="btnSearch"  Text="ERP查询项目编号" runat="server" Icon="SystemSearch" 
                     OnClick="btnSearch_Click">
                    </ext:Button>
                    <%--<ext:Button ID="btnSaveContinue" Text="保存回发" runat="server" Icon="SystemSaveNew"
                        OnClick="btnSaveContinue_Click" Visible="false">
                    </ext:Button>--%>
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
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True" >
                        <Items>
                            <ext:TextBox ID="txt_Project_No" Label="项目编号" runat="server" Required="true" ShowRedStar="true"  />
                            <ext:TextBox ID="txt_Project_name" Label="项目名称" runat="server" Required="true" ShowRedStar="true" />   
                        <%--<ext:TextBox ID="txt_Odd_type" Label="单别" runat="server" Required="false"   /> 
                            <ext:TextBox ID="txt_Odd_No" Label="单号" runat="server" Required="false"   /> --%>
                            <ext:DropDownList ID="dr_sales" Label="业务员" runat="server" Required="false"   /> 
                            <ext:DropDownList ID="dr_Customer_No" Label="客户" runat="server" 
                                Required="false" AutoPostBack="true"
                                OnSelectedIndexChanged="dr_Customer_No_SelectedIndexChanged"   /> 
                            <ext:TextBox ID="txt_address" Label="客户地址(自动生成)" runat="server" Required="false"  Enabled="false" />  
                            <ext:TextBox ID="txt_Contacts" Label="联系人(自动生成)" runat="server" Required="false"  Enabled="false" /> 
                            <ext:TextBox ID="txt_telephone_number" Label="联系电话(自动生成)" runat="server" Required="false" Enabled="false"  />   
                            <%--<ext:TextBox ID="txt_area" Label="所属地区" runat="server" Required="false"   /> --%>
                            <%--<ext:DropDownList ID="dr_customer" runat="server" Label="所属项目" Required="false" ShowRedStar="false" />--%>
                            <ext:DropDownList ID="dr_area" runat="server" Label="所属地区" Required="false" ShowRedStar="false" />
                            <ext:DropDownList ID="dr_agent" runat="server" Label="代理商" Required="false" ShowRedStar="false" />                        
                            <ext:CheckBox ID="ck_isover" runat="server" Text="" Label="完结状态">
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
