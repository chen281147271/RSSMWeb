<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RSSMWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<%--<script type="text/javascript" language="javascript">
　　function Go()
　　{
　　　<%=GetEditUrl()%>";
　　}
</script>--%>




    <title>瑞驰智能 企业管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="rdi.ico" />
    <meta name="Title" content="深圳市瑞驰智能系统有限公司 企业管理系统" />
    <meta name="Description" content="" />
    <meta name="Keywords" content="extjs,ext,asp.net,control,asp.net 2.0,ajax,web2.0" />
    <link href="css/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server">
    </ext:PageManager>
    <ext:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <ext:Region ID="Region1" Margins="0 0 0 0" Height="62px" ShowBorder="false" ShowHeader="false"
                Position="Top" Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" Position="Bottom" runat="server">
                        <Items>
                      <%-- 
                        <ext:Button ID="btnMenu" Text="项目管理" EnablePostBack="false" runat="server">
                            <Menu>
                                <ext:MenuHyperLink ID="MenuHyperLink1" runat="server" Icon="TagGreen" Target="_blank" NavigateUrl="~/admin/hello.aspx"
                                    Text="项目计划">
                                </ext:MenuHyperLink>
                            </Menu>
                        </ext:Button>
                         
                            <ext:Button ID="btnExpandAll" IconUrl="~/images/expand-all.gif" Text="展开全部" EnablePostBack="false"
                                runat="server" Visible="false">
                            </ext:Button>
                            <ext:Button ID="btnCollapseAll" IconUrl="~/images/collapse-all.gif" Text="折叠全部" EnablePostBack="false"
                                runat="server" Visible="false">
                            </ext:Button>
                           --%>
                            <ext:ToolbarFill ID="ToolbarFill1" runat="server">
                            </ext:ToolbarFill>
                            <ext:ToolbarText ID="ToolbarText1" Text="菜单：" runat="server">
                            </ext:ToolbarText>
                            <ext:DropDownList ID="ddlMenu" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlMenu_SelectedIndexChanged"
                                runat="server">
                                <ext:ListItem Text="树菜单" Value="tree" />
                                <ext:ListItem Text="琴菜单" Value="accordion" />
                            </ext:DropDownList>
                            <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                            </ext:ToolbarSeparator>
                            <ext:ToolbarText ID="ToolbarText4" Text="&nbsp;&nbsp;语言：" runat="server" Visible="false">
                            </ext:ToolbarText>
                            <ext:DropDownList ID="ddlLanguage" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged"
                                runat="server" Visible="false">
                                <ext:ListItem Text="English" Value="en" />
                                <ext:ListItem Text="简体中文" Value="zh_cn" />
                                <ext:ListItem Text="繁體中文" Value="zh_tw" />
                            </ext:DropDownList>
                            <ext:ToolbarText ID="ToolbarText3" Text="&nbsp;&nbsp;主题：" runat="server">
                            </ext:ToolbarText>
                            <ext:DropDownList ID="ddlTheme" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged"
                                runat="server">
                                <ext:ListItem Text="Blue" Selected="true" Value="blue" />
                                <ext:ListItem Text="Gray" Value="gray" />
                                <ext:ListItem Text="Access" Value="access" />
                                <ext:ListItem Text="Blueen" Value="blueen" />
                                <ext:ListItem Text="First" Value="first" />
                                <ext:ListItem Text="Second" Value="second" />
                                <ext:ListItem Text="Fourth" Value="fourth" />
                            </ext:DropDownList>
                            <ext:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                            </ext:ToolbarSeparator>
                                            
                            <ext:Button ID="btnQuit" Text="退出登录" EnablePostBack="false" runat="server"  
                                                            OnClientClick="window.open('login.aspx','_self');">
                            </ext:Button>
                             
                        
                        <ext:HyperLink ID="textlab" runat="server" NavigateUrl="javascript:X('Window2').box_show('/rss/myjob/MyMessage.aspx');" ></ext:HyperLink>
                        
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:ContentPanel ShowBorder="false" CssClass="header" ShowHeader="false" BodyStyle="background-color:#1C3E7E;"
                        ID="ContentPanel1" runat="server">
                        <div class="title">
                            <a href="./default.aspx" style="color:#fff;">瑞驰企业管理系统</a>
                        </div>
                        <div class="version">
                        
                        
                           <a id ="lgTag"  href="javascript:<% =GetEditUrl() %>" style="color:#fff;" onclick=""><% =Page.Session["user_name_full"].ToString() %></a>
                           
                          <ext:Timer ID="Timer1" Interval="60" Enabled="false" OnTick="Timer1_Tick" EnableAjaxLoading="false" runat="server">
                          </ext:Timer>
                          

                        </div>
<%--                        <div class="version">
                        <ext:HyperLink ID="textlab" runat="server"></ext:HyperLink>
                        </div>--%>
                        
                    </ext:ContentPanel>
                </Items>
            </ext:Region>
            <ext:Region ID="Region2" Split="true" EnableSplitTip="true" CollapseMode="Mini" Width="200px"
                Margins="0 0 0 0" ShowHeader="true" Title="功能列表" EnableLargeHeader="false" Icon="Outline"
                EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
            </ext:Region>
            <ext:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Margins="0 0 0 0" Position="Center"
                runat="server">
                <Items>
                    <ext:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                        <Tabs>
                            <ext:Tab Title="首页" Layout="Fit" Icon="House" runat="server">
                                <Toolbars>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:ToolbarFill ID="ToolbarFill2" runat="server">
                                            </ext:ToolbarFill>
                                             
                                            <ext:Button ID="btnSourceCode" Icon="PageWhiteCode" Text="源代码" EnablePostBack="false"
                                                runat="server" Hidden="True">
                                            </ext:Button>
                                            
                                            <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                            </ext:ToolbarSeparator>
                                            <ext:Button ID="Button1" Icon="TabGo" Text="企业网站" OnClientClick="window.open('http://www.szrss.com', '_blank');"
                                                EnablePostBack="false" runat="server">
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </Toolbars>
                                <Items>
                                    <ext:ContentPanel ShowBorder="false" BodyPadding="10px" ShowHeader="false" AutoScroll="true"
                                        CssClass="intro" runat="server">
                                        &nbsp;<h2>关于瑞驰企业管理系统</h2>
                                        基于瑞驰公司业务流程,关联ERP系统所开发的企业级业务流程管理系统。仅限瑞驰内部使用.
                                        <br />                                    
                                        <h2>更新说明</h2>
                                        &nbsp;
                                        <h3>2014-03-31</h3>
                                         <h5>开通软件开发部任务管理系统</h5>
                                         
                                        &nbsp;
                                        <h3>2014-03-21</h3>
                                         <h5>问题追踪--状态名称 [忽略] 修改为 [待优化]</h5>
                                         <h5>站内信连通公司邮件系统</h5>
                                         <h5>问题追踪--状态 增加 [已解决]</h5>
                                        <h5>问题追踪-- 增加 排序功能 支持[问题主题][创建时间][创建人][所属项目]</h5>
                                        <h5>编辑问题后,不再重复刷新界面</h5>
                                        <h5>增加功能菜单 -- [问题处理流程图]</h5>
                                        <h5>增加 [我的问题] 界面</h5>
                                       
                                         &nbsp;
                                        <h3>2014-03-07</h3>
                                         <h5>增加问题管理中 需求/问题 分类属性</h5>
                                         <h5>增加站内信功能</h5>
                                         <h5>增加绩效考核相关属性</h5>
                                        <h5>增加预期解决时间</h5>
                                        <h5>增加责任人属性</h5>
                                        <h5>分离解决方案字段</h5>
                                        <h5>增加严重程度字段</h5>
                                        <h5>增加问题报表显示功能</h5>
                                         &nbsp;
                                        <h3>2013-12-12</h3>
                                         <h5>变更问题管理中的字段标题</h5>
                                         <h5>问题管理界面->编辑问题->现象描述变更为不可更改的属性</h5>
                                         <h5>问题管理界面->编辑问题->分析/解决过程修改为留言板模式</h5>
                                        <h5>系统管理-> 增加权限管理功能</h5>
                                         &nbsp;
                                        <h3>2013-12-04</h3>
                                         <h5>修复bug添加时的异常问题</h5>
                                         <h5>问题管理界面->问题列表增加分页功能,每页15项</h5>
                                         <h5>问题管理界面->人员选择下拉框变更为按部分分类</h5>
                                         <h5>问题管理模块增加问题批量导入功能</h5>
                                         <h5>问题管理界面,增加问题合并的功能.暂时仅合并主题和所属产品</h5>
                                        &nbsp;
                                        <h3>2013-11-30</h3>
                                         <h5>修复上传下载文件的地址映射bug</h5>
                                         <h5>在主界面点击自己的登录名可以修改自己账号的信息/密码等</h5>
                                         <h5>项目管理->代理商管理 功能开通</h5>
                                         <h5>项目管理->客户管理 功能开通</h5>
                                        &nbsp;
                                        <h3>2013-11-29</h3>
                                         <h5>1.问题追踪->问题管理->问题编辑->附件上传下载功能开通</h5>
                                         <h5>2.功能目录树变更,项目管理->代理商管理,客户管理功能开通</h5>
                                         <h5>3.系统管理->用户管理 功能开通</h5>
                                         &nbsp;
                                        <h3>2013-11-21</h3>
                                            <h5>1.问题追踪->问题管理->问题编辑查看功能开通</h5>
                                            &nbsp;
                                        <h3>2013-11-20</h3>
                                            <h5>1.问题追踪->问题管理->新增问题功能开通</h5>
                &nbsp;
                                        <h3>2013-11-19</h3>
                                            <h5>1.功能列表调整</h5>
                                            <h5>2.组织架构功能 开通</h5>
                                            <h5>3.问题追踪->问题管理功能 开通</h5>
                                            <h5>4.登录验证功能实现</h5>
                                            <h5>5.样式功能实现</h5>
                                    </ext:ContentPanel>
                                </Items>
                            </ext:Tab>
                        </Tabs>
                    </ext:TabStrip>
                </Items>
            </ext:Region>
        </Regions>
    </ext:RegionPanel>
    <ext:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="源代码" Popup="false"
        EnableIFrame="true" runat="server" IsModal="true" Width="900px" Height="550px"
        EnableClose="true" EnableMaximize="true" EnableResize="true">
    </ext:Window>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/menu.xml"></asp:XmlDataSource>
     <ext:Window ID="Window1" Title="编辑" Popup="false" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" EnableConfirmOnClose="true" IFrameUrl="about:blank"
        EnableMaximize="true" EnableResize="true"  Target="Top"
        IsModal="True" Width="400px" Height="450px">
    </ext:Window>
    <ext:Window ID="Window2" Title="我的站内信" Popup="false" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" EnableConfirmOnClose="true" IFrameUrl="about:blank"
        EnableMaximize="true" EnableResize="true"  Target="Top"
        IsModal="True" Width="900px" Height="550px">
    </ext:Window>
    </form>
    <img src="images/logo/rdislogo2.png" alt="瑞驰 图标" id="logo" />
    <script src="./js/default.js" type="text/javascript"></script>
</body>
</html>
