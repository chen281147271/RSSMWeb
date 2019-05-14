<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="File_Management.aspx.cs" Inherits="RSSMWeb.systemmanage.File_Management" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <ext:PageManager ID="PageManager1" runat="server" />
     <ext:Panel ID="Pane_usermanage" Title="文件管理" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
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

                            <ext:Button ID="btn_delete" Icon="Delete" Text="删除" ToolTip="删除文件" runat="server"  ConfirmText='"确定要执行删除操作?"' ConfirmTitle="删除确认" OnClick="btnDelete_Click">
                            </ext:Button>

                          
                            

                            <ext:DropDownList ID="DropDownList2" runat="server"  Label="关键字" >
                               <ext:ListItem Text="按文件名"  Value="按文件名" />
                               <ext:ListItem Text="按问题ID" Value="按问题ID"/>
                               <ext:ListItem Text="按提出人" Selected="true" Value="按提出人"/>
                               <ext:ListItem Text="按项目"  Value="按项目"/>
                            </ext:DropDownList>
                              <ext:TextBox ID="txt_username" Label="关键字" runat="server" AutoPostBack="false" 
                                >
                            </ext:TextBox>   

                            <ext:Button ID="btn_Search" Text="搜索" runat="server" >
                            </ext:Button>

                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="文件列表" PageSize="15" ShowBorder="true" ShowHeader="False"
                         runat="server" EnableCheckBoxSelect="true" AllowPaging="True" 
                        DataKeyNames="file_id" EnableRowNumber="false" 
                        OnPageIndexChange="Grid1_PageIndexChange">
                        <Columns>
                            <ext:BoundField Width="60px" DataField="file_id" DataFormatString="{0}" HeaderText="文件ID" />
                            <ext:BoundField Width="160px" DataField="file_name" DataFormatString="{0}" HeaderText="文件名称" />
                            <ext:BoundField Width="160px" DataField="file_hint" DataFormatString="{0}" HeaderText="文件备注" />
                           <%-- <ext:TemplateField Width="60px" HeaderText="上传的用户">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# GetName(Eval("file_uploader_id"),"1") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>--%>
                            <ext:BoundField Width="100px" DataField="user_name_full" DataFormatString="{0}" HeaderText="上传的用户" />
                            <ext:BoundField Width="160px" DataField="file_upload_time" DataFormatString="{0}"  HeaderText="上传时间" />
                            <ext:BoundField Width="100px" DataField="ref_count" DataFormatString="{0}"  HeaderText="文件引用数" />
                           <%-- <ext:TemplateField Width="60px" HeaderText="所属项目">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# GetName(Eval("pj_id"),"2") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>--%>
                            <ext:BoundField Width="160px" DataField="pj_name" DataFormatString="{0}" HeaderText="所属项目" />
                           <%-- <ext:TemplateField Width="160px" HeaderText="所属问题">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# GetSysCode(Eval("detail_id")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>--%>
                            <ext:BoundField Width="120px" DataField="detail_id" DataFormatString="{0}" HeaderText="所属问题ID" />
                            <ext:TemplateField HeaderText="操作" Width="60px">
                                <ItemTemplate>
                                    <a href="<%# Down_Load(Eval("file_url")) %>" target="_blank">下载</a>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
