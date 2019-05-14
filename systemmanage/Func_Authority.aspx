<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Func_Authority.aspx.cs" Inherits="RSSMWeb.systemmanage.Func_Authority" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <ext:PageManager ID="PageManager1" runat="server" />
     <ext:Panel ID="Pane_usermanage" Title="用户权限管理" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        Width="1200px" ShowBorder="True" ShowHeader="True" EnableCollapse="true">
         <Items>
           <%-- <ext:Form ID="Form_user" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                           <ext:TextBox ID="txt_username" Label="关键字" runat="server" AutoPostBack="false" 
                                >
                            </ext:TextBox>   
                            
                            <ext:Button ID="btn_Search" Text="搜索" runat="server" >
                            </ext:Button>
                            <ext:DropDownList ID="DropDownList1" runat="server" >
                               <ext:ListItem Text="按文件名"  />
                               <ext:ListItem Text="按问题" />
                               <ext:ListItem Text="按提出人" Selected="true" />
                               <ext:ListItem Text="按项目"  />
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>--%>
             <ext:Panel ID="Panel6" ShowBorder="True" ShowHeader="false" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>

<%--                            <ext:Button ID="btn_delete" Icon="Delete" Text="删除" ToolTip="删除文件" runat="server"  ConfirmText='"确定要执行删除操作?"' ConfirmTitle="删除确认" OnClick="btnDelete_Click">
                            </ext:Button>
--%>
                          
                            

                            <ext:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                               <ext:ListItem Text="按用户"  Value="按文件名" Selected="true"/>
                               <ext:ListItem Text="按部门" Value="按问题ID"/>
                               <ext:ListItem Text="按角色"  Value="按提出人"/>
                            </ext:DropDownList>
                            
                            <ext:DropDownList ID="DropDownList2" runat="server"  AutoPostBack="true" 
                            OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                            </ext:DropDownList>

                            <%--  <ext:TextBox ID="txt_username" Label="关键字" runat="server" AutoPostBack="False" 
                                >
                            </ext:TextBox>   --%>
                              <ext:DropDownList ID="DropDownList3" runat="server"  AutoPostBack="true"
                              OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                            </ext:DropDownList>
                            <%--<ext:Button ID="btn_Search" Text="搜索" runat="server" OnClick="btn_Search_Click">
                            </ext:Button>--%>
                            <ext:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" ConfirmText="确定保存修改吗？" Icon="SystemSave" >
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="权限表" PageSize="4" ShowBorder="true" ShowHeader="False"
                         runat="server"     
                        DataKeyNames="Id,Name,Depth" OnRowCommand="Grid1_RowCommand"  >
                        <Columns>
<%--
                       <ext:CheckBoxField ColumnID="cbxAuthority" TextAlign="Center" Width="60px" 
                         RenderAsStaticField="false" HeaderText="权限" CommandName="AuthoritySelect"  />--%>
                        <%-- <ext:LinkButtonField  Icon="BulletTick" ColumnID="btn_cbxAuthority" HeaderText="权限" CommandName="AuthoritySelect" />--%>
                         <ext:CheckBoxField ColumnId="cbx_Authority" DataField="EnableSelect" HeaderText="权限" RenderAsStaticField="false"
                          AutoPostBack="true" CommandName="Show" Width="50px" />

                         <ext:BoundField DataField="Name" DataSimulateTreeLevelField="TreeLevel" DataFormatString="{0}"
                          HeaderText="网站地图" ExpandUnusedSpace="True"  ColumnID="cbxAuthority"/>

                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
            </Items>
        </ext:Panel>
    </form>
   <%-- <script type="text/javascript">
        // 页面AJAX回发后执行的函数
        function onAjaxReady() {
            var txt_usernameClientID = '<%= txt_username.ClientID %>';
            var txt_username = X(txt_usernameClientID);
             txt_username.Visible = false;
        }
     </script>--%>
</body>
</html>
