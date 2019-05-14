﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bug_details.aspx.cs" Inherits="RSSMWeb.bugTracer.bug_details" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
<script type="text/javascript" language="javascript">
　　    function replace() {
        var aa = document.getElementById("<%=TextArea1.ClientID %>").value;
        //return "true";
        aa = aa.replace(/</g, '&ltl');
        aa = aa.replace(/>/g, '&ltr');
        aa = aa.replace(/'/g, '&ltd');
        aa = aa.replace(/"/g, '&lts');
        document.getElementById("<%=TextArea1.ClientID %>").value = aa;


        aa = document.getElementById("<%=Solution.ClientID %>").value;
        //return "true";
        aa = aa.replace(/</g, "&ltl");
        aa = aa.replace(/>/g, "&ltr");
        aa = aa.replace(/'/g, '&ltd');
        aa = aa.replace(/"/g, '&lts');
        document.getElementById("<%=Solution.ClientID %>").value = aa;

        aa = document.getElementById("<%=RunningRecord.ClientID %>").value;
        //return "true";
        aa = aa.replace(/</g, "&ltl");
        aa = aa.replace(/>/g, "&ltr");
        aa = aa.replace(/'/g, '&ltd');
        aa = aa.replace(/"/g, '&lts');
        document.getElementById("<%=RunningRecord.ClientID %>").value = aa;


        aa = document.getElementById("<%=Phenomenon.ClientID %>").value;
        //return "true";
        aa = aa.replace(/</g, "&ltl");
        aa = aa.replace(/>/g, "&ltr");
        aa = aa.replace(/'/g, '&ltd');
        aa = aa.replace(/"/g, '&lts');
        document.getElementById("<%=Phenomenon.ClientID %>").value = aa;

         aa = document.getElementById("<%=Analysis.ClientID %>").value;
        //return "true";
        aa = aa.replace(/</g, "&ltl");
        aa = aa.replace(/>/g, "&ltr");
        aa = aa.replace(/'/g, '&ltd');
        aa = aa.replace(/"/g, '&lts');
        document.getElementById("<%=Analysis.ClientID %>").value = aa;

        if (window.confirm('你确定要保存吗？')) {
        //    alert("确定");
            return true;
        } else {
            //    alert("取消");
             aa = document.getElementById("<%=TextArea1.ClientID %>").value;
            //return "true";
            aa = aa.replace(/&ltl/g, '<');
            aa = aa.replace(/&ltr/g, '>');
            aa = aa.replace(/&ltd/g, '\'');
            aa = aa.replace(/&lts/g, '"');
            document.getElementById("<%=TextArea1.ClientID %>").value = aa;


            aa = document.getElementById("<%=Solution.ClientID %>").value;
            //return "true";
            aa = aa.replace(/&ltl/g, '<');
            aa = aa.replace(/&ltr/g, '>');
            aa = aa.replace(/&ltd/g, '\'');
            aa = aa.replace(/&lts/g, '"');
            document.getElementById("<%=Solution.ClientID %>").value = aa;

            aa = document.getElementById("<%=RunningRecord.ClientID %>").value;
            //return "true";
            aa = aa.replace(/&ltl/g, '<');
            aa = aa.replace(/&ltr/g, '>');
            aa = aa.replace(/&ltd/g, '\'');
            aa = aa.replace(/&lts/g, '"');
            document.getElementById("<%=RunningRecord.ClientID %>").value = aa;


            aa = document.getElementById("<%=Phenomenon.ClientID %>").value;
            //return "true";
            aa = aa.replace(/&ltl/g, '<');
            aa = aa.replace(/&ltr/g, '>');
            aa = aa.replace(/&ltd/g, '\'');
            aa = aa.replace(/&lts/g, '"');
            document.getElementById("<%=Phenomenon.ClientID %>").value = aa;

            aa = document.getElementById("<%=Analysis.ClientID %>").value;
            //return "true";
            aa = aa.replace(/&ltl/g, '<');
            aa = aa.replace(/&ltr/g, '>');
            aa = aa.replace(/&ltd/g, '\'');
            aa = aa.replace(/&lts/g, '"');
            document.getElementById("<%=Analysis.ClientID %>").value = aa;

            return false;
        }

        
        
       // alert(aa);
    }
    function replace1() {
       
        var bb = document.getElementById("<%=Analysis.ClientID %>").value;
        //return "true";
        bb = bb.replace(/</g, "&ltl");
        bb = bb.replace(/>/g, "&ltr");
        bb = bb.replace(/'/g, '&ltd');
        bb = bb.replace(/"/g, '&lts');
        document.getElementById("<%=Analysis.ClientID %>").value = bb;
        if (window.confirm('你确定要添加留言吗？')) {
            //    alert("确定");
            return true;
        } else {
            bb = document.getElementById("<%=Analysis.ClientID %>").value;
            //return "true";
            bb = bb.replace(/&ltl/g, '<');
            bb = bb.replace(/&ltr/g, '>');
            bb = bb.replace(/&ltd/g, '\'');
            bb = bb.replace(/&lts/g, '"');
            document.getElementById("<%=Analysis.ClientID %>").value = bb;
            return false;
        }
    }
</script>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server"   />
    <ext:Panel ID="Panel1" runat="server" Layout="Form" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true" AutoScroll="True">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </ext:Button>
                    <ext:Button ID="btnSaveContinue" Text="保存回发" runat="server" Icon="SystemSaveNew"
                        OnClick="btnSaveContinue_Click" Visible="false">
                    </ext:Button>
                    <ext:Button ID="btnSaveRefresh" Text="保存变更" runat="server" Icon="SystemSaveNew" OnClientClick="if(replace()== false){return false} ;" OnClick="btnSaveRefresh_Click"
                     ValidateForms="Form2" ValidateTarget="Self"   >
                    </ext:Button>
                    
                    <ext:ToolbarFill ID="ToolbarFill1" runat="server">
                    </ext:ToolbarFill>
                    <ext:ToolbarText ID="ToolbarText1" Text="附件请打包后上传" runat="server">
                    </ext:ToolbarText>
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:ToolbarText ID="ToolbarText2" Text="限制上传文件后缀.zip,.rar,.dox,.ppt,.txt,.jpg,.gif&nbsp;&nbsp;" runat="server">
                    </ext:ToolbarText>
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
                                    <ext:TextBox ID="TextBox5" Label="问题标题" runat="server" Enabled="False" />
                                    
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:CheckBox ID="CheckBox1" runat="server" Text="" Label="是否解决">
                                    <ext:TextBox ID="Star_Time" Label="问题开启时间" runat="server" Enabled="False" Hidden="true" />
                                    <ext:TextBox ID="Finish_Time" Label="问题已解决时间" runat="server" Enabled="False" Hidden="true" />
                                    </ext:CheckBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:RadioButton ID="rbtnSecond" GroupName="MyRadioGroup1"  Label="属性" LabelSeparator="" Text="需求" runat="server">
                                    </ext:RadioButton>
                                    <ext:RadioButton ID="rbtnThird" GroupName="MyRadioGroup1" Label="&nbsp;" LabelSeparator="" Text="问题" runat="server">
                                    </ext:RadioButton>
                                    <ext:RadioButton ID="rbtnFirst" GroupName="MyRadioGroup1" Label="&nbsp;" LabelSeparator="" Text="系统" runat="server" Checked="true">
                                    </ext:RadioButton>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="Label3" Label="提出人" runat="server" />
                                    <ext:Label ID="Label1" Label="提出时间" runat="server" />
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="DropDownList8" runat="server" Label="状态" Required="true" ShowRedStar="true" >
                                        <ext:ListItem Text="新增" Value="6001" Selected="true" />
                                        <ext:ListItem Text="开启" Value="6002" />
                                        <ext:ListItem Text="修复" Value="6003" />
                                        <ext:ListItem Text="关闭" Value="6004" />
                                        <ext:ListItem Text="待优化" Value="6005" />
                                        <ext:ListItem Text="废弃" Value="6006" />
                                        <ext:ListItem Text="已解决" Value="6007" />
                                    </ext:DropDownList>
                                    
                                    <ext:DropDownList ID="DropDownList3" runat="server" Label="问题分类" Required="true"
                                        ShowRedStar="true" Enabled="False">
                                        <ext:ListItem Text="机械结构" Value="9001" />
                                        <ext:ListItem Text="电气控制" Value="9002" />
                                        <ext:ListItem Text="软件" Value="9003" />
                                        <ext:ListItem Text="电子" Value="9004" />
                                        <ext:ListItem Text="流程及操作" Value="9005" />
                                        <ext:ListItem Text="其他" Value="9006" />
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="DropDownList1" runat="server" Label="过程分类" Required="true" Hidden="true"
                                        ShowRedStar="true">
                                        <ext:ListItem Text="研发设计发现问题" Value="5001" />
                                        <ext:ListItem Text="生产装配发现问题" Value="5002" />
                                        <ext:ListItem Text="品质测试发现问题" Value="5003" />
                                        <ext:ListItem Text="项目实施发现问题" Value="5004" />
                                        <ext:ListItem Text="售后服务发现问题" Value="5005" />
                                        <ext:ListItem Text="流程运行发现问题" Value="5006" />
                                        <ext:ListItem Text="其他" Value="5007" />
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="DropDownList2" runat="server" Label="所属产品" Required="true"
                                        ShowRedStar="true">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="DropDownList4" runat="server" Label="所属项目" Required="true" Hidden="true"
                                        ShowRedStar="true">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="DropDownList5" runat="server" Label="优先级" Required="true" ShowRedStar="true">
<%--                                        <ext:ListItem Text="低" Value="7002" />
                                        <ext:ListItem Text="中" Value="7003" Selected="true" />
                                        <ext:ListItem Text="高" Value="7004" />--%>
                                        <ext:ListItem Text="一般" Value="7003"  Selected="true"/>
                                        <ext:ListItem Text="紧急" Value="7004" />
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="DropDownList7" runat="server" Label="当前对象" Enabled="False">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="DropDownList6" runat="server" Label="转发对象">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DatePicker ID="DatePicker1"  runat="server"
                                        Label="发生日期">
                                    </ext:DatePicker>
                                    <ext:DropDownList ID="DropDownList11" runat="server" Label="严重程度" Required="true" ShowRedStar="true">
<%--                                        <ext:ListItem Text="低" Value="7002" />
                                        <ext:ListItem Text="中" Value="7003" Selected="true" />
                                        <ext:ListItem Text="高" Value="7004" />--%>
                                         <ext:ListItem Text="一般" Value="7003"  Selected="true"/>
                                        <ext:ListItem Text="紧急" Value="7004" />
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DatePicker ID="DatePicker2" runat="server" Label="现场解决日期" Hidden="true">
                                    </ext:DatePicker>
                                    <ext:DropDownList ID="DropDownList9" runat="server" Label="现场解决人" Hidden="true">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DatePicker ID="DatePicker3" runat="server" Label="预期解决日期">
                                    </ext:DatePicker>
                                    <ext:DropDownList ID="DropDownList10" runat="server" Label="责任人">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="DropDownList12" runat="server" Label="测试负责人">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>                        
                            <ext:FormRow>
                                <Items>
                                    <ext:NumberBox  ID="NumBox2" Label="绩效分值" runat="server"  MinValue="0" NoDecimal="true" NoNegative="True" />
                                    <ext:NumberBox  ID="NumBox3" Label="获得分值" runat="server"  MinValue="0" NoDecimal="true" NoNegative="True"/>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea ID="Phenomenon" Label="现象描述/建议" Height="60px" runat="server" Enabled="True" AutoGrowHeight="true" AutoGrowHeightMin="50" AutoGrowHeightMax="200">
                                    </ext:TextArea>
                                    <%--<ext:HtmlEditor ID="Phenomenon" Label="处理过程" Height="80px" runat="server" ></ext:HtmlEditor>--%>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea ID="Solution" Label="现场处理过程" Height="60px" runat="server"  AutoGrowHeight="true" AutoGrowHeightMin="50" AutoGrowHeightMax="200" Hidden="true">
                                    </ext:TextArea>
                                   <%-- <ext:HtmlEditor ID="Solution" Label="处理过程" Height="80px" runat="server" EnableAlignments="false" EnableColors="false" EnableFont ="false" EnableFontSize ="false" EnableFormat="false" EnableLinks ="false" EnableLists ="false" EnableSourceEdit ="false" EnableTheming="false" ></ext:HtmlEditor>--%>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea ID="TextArea1" Label="解决方案" Height="60px" runat="server"  Enabled="True" AutoGrowHeight="true" AutoGrowHeightMin="50" AutoGrowHeightMax="200">
                                    </ext:TextArea>
                                    <%--<ext:HtmlEditor ID="TextArea1" Label="处理过程" Height="80px" runat="server" EnableAlignments="false" EnableColors="false" EnableFont ="false" EnableFontSize ="false" EnableFormat="false" EnableLinks ="false" EnableLists ="false" EnableSourceEdit ="false" EnableTheming="false" ></ext:HtmlEditor>--%>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                <%--<ext:HtmlEditor ID="RunningRecord" Label="处理过程" Height="80px" runat="server"  Enabled="True"  ></ext:HtmlEditor>--%>
                                    <ext:TextArea ID="RunningRecord" Label="处理过程" Height="80px" runat="server"  Enabled="True" AutoGrowHeight="true" AutoGrowHeightMin="50" AutoGrowHeightMax="200">
                                    </ext:TextArea>
                                   <%-- <ext:HtmlEditor ID="RunningRecord" Label="处理过程" Height="80px" runat="server" EnableAlignments="false" EnableColors="false" EnableFont ="false" EnableFontSize ="false" EnableFormat="false" EnableLinks ="false" EnableLists ="false" EnableSourceEdit ="false" EnableTheming="false" ></ext:HtmlEditor>--%>
                                </Items>
                            </ext:FormRow>                       
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea ID="Analysis" Label="分析过程" Height="20px" runat="server" AutoGrowHeight="true" AutoGrowHeightMin="50" AutoGrowHeightMax="200">
                                    </ext:TextArea>
                                    <ext:Button ID="Button2" Icon="BugEdit" Text="添加留言" runat="server" OnClientClick="if(replace()== false){return false} ;" OnClick="btnAddCommit"  >
                                    </ext:Button>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:Panel>
            <ext:Panel ID="Panel3" Layout="Form" runat="server" ShowBorder="false" ShowHeader="false">
            <Toolbars>
                    <ext:Toolbar ID="Toolbar2" runat="server">
                        <Items>
                            <ext:Button ID="Button3" Icon="Delete"  OnClick="btnDelete_Click" Text="删除" ToolTip="删除附件" 
                             ConfirmText='"确定要执行删除操作?"' ConfirmTitle="删除确认" 
                                 runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="Grid1" Title="附件" PageSize="3" ShowBorder="true" ShowHeader="False"
                        runat="server" EnableCheckBoxSelect="true" DataKeyNames="file_id" EnableRowNumber="true" >
                        <Columns>
                            <ext:BoundField Width="60px" DataField="file_id" DataFormatString="{0}" HeaderText="附件编号" />
                            <ext:BoundField Width="180px" DataField="file_name" DataFormatString="{0}" HeaderText="附件名" />
                            <ext:BoundField Width="180px" DataField="file_hint" DataFormatString="{0}" HeaderText="附件备注" />
                            <ext:BoundField Width="120px" DataField="file_upload_time" DataFormatString="{0}" HeaderText="上传时间" />
                            <ext:BoundField Width="100px" DataField="user_name_full" HeaderText="上传者" />
                            <ext:TemplateField HeaderText="操作" Width="60px">
                                <ItemTemplate>
                                    <a href="<%# GetEditUrl(Eval("file_url")) %>" target="_blank">下载</a>                                    
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                    <ext:FileUpload runat="server" ID="FileUpload1" EmptyText="限制上传文件后缀.zip,.rar,.doc,.xsl,.ppt,.txt,.jpg,.gif" Label="上传附件"  >
                    </ext:FileUpload>
                    <ext:TextBox ID="TextBox1" Label="附件备注" runat="server" />
                    <ext:Button ID="Button1" Icon="FolderUp" Text="上传" ToolTip="上传附件" EnablePostBack="true" ConfirmText='"确定要上传附件?"' ConfirmTitle="上传确认"
                                runat="server" OnClick="btnUploadFile" >
                    </ext:Button>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Label ID="PreState" Label="tt" runat="server"  Visible ="true" Text=" " />
    </form>
     
</body>
</html>
