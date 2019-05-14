<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntroductionExcel.aspx.cs" Inherits="RSSMWeb.projectsmanage.IntroductionExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
       .highlight
        {
            background-color: lightgreen;
        }
        .highlight .x-grid3-col
        {
            background-image: none;
        }
        
        .x-grid3-row-selected .highlight
        {
            background-color: yellow;
        }
        .x-grid3-row-selected .highlight .x-grid3-col
        {
            background-image: none;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
      <ext:PageManager ID="PageManager1" runat="server"/>
    <ext:Panel ID="Panel2" Title="选择EXCEL" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
         ShowBorder="True" ShowHeader="True" EnableCollapse="true" Layout=Form>  
         <Items>
              <ext:FileUpload ID="fuFile" runat="server" Label="请选择Excel" EmptyText="请选择相关附件">
              </ext:FileUpload>
          </Items>
            
       </ext:Panel>
            <ext:Panel ID="Panel6" ShowBorder="True" ShowHeader="false" runat="server" >
             <Toolbars>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="Btn_Introduction" Icon="Add" Text="导入Excel到表格" ToolTip="导入Excel到表格" EnablePostBack="true"  OnClick="Btn_Introduction_Click" runat="server">
                            </ext:Button>
                            <ext:Button ID="btn_SaveTable" Icon="accept" Text="提交表格数据至数据库" ToolTip="只提交勾选的数据" runat="server" EnablePostBack="true" OnClick="btn_SaveTable_Click" ConfirmText='"确定提交表格?"' >
                            </ext:Button>
                            <ext:Button ID="btn_CheckData" Icon="CheckError" Text="检查数据有效性" ToolTip="检查整个表格数据有效性" runat="server" EnablePostBack="true" OnClick="btn_CheckData_Click" >
                            </ext:Button>
                              <ext:Button ID="btn_Download" Icon="ArrowDown" Text="下载最新Excel模版" ToolTip="下载最新EXCELDEMO" runat="server" EnablePostBack="true" OnClick="btn_Download_Click" >
                            </ext:Button>
                              <ext:Button ID="btn_Up" Icon="ArrowUp" Text="上传最新Excel模版" ToolTip="上传最新EXCELDEMO" runat="server" EnablePostBack="true" OnClick="btn_Up_Click" ConfirmText='"确定要上传新的Excel模版?"'>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                    </Toolbars>
        </ext:Panel>
          <ext:Panel runat="server" ShowHeader="false" ShowBorder="false" AutoWidth="true" AutoHeight="true" AutoScroll="true">
            <Items>
                 <ext:Grid ID="Grid1" Title="项目表格"  ShowBorder="true" ShowHeader="False"
                        runat="server"  Height="500px" 
                         EnableRowNumber="true" 
                     EnableBackgroundColor="true"  EnableAlternateRowColor="true"
                     OnRowClick="Grid1_RowClick"   >
                       
                   <Columns>
                            <ext:CheckBoxField ColumnID="cbxUpload" TextAlign="Center" Width="60px"  DataField="是否上传" RenderAsStaticField="false" HeaderText="是否上传" />
                            <ext:BoundField Width="60px" DataField="问题标题" DataFormatString="{0}" HeaderText="问题标题" />
                            <ext:BoundField Width="180px" DataField="提出人" DataFormatString="{0}" HeaderText="提出人" />
                            <ext:BoundField Width="100px" DataField="所属产品" HeaderText="所属产品" />
                            <ext:BoundField Width="100px" DataField="问题分类" HeaderText="问题分类" />
                            <ext:BoundField Width="100px" DataField="过程分类" HeaderText="过程分类" />
                            <ext:BoundField Width="100px" DataField="转发对象" HeaderText="转发对象" />
                            <ext:BoundField Width="100px" DataField="处理人" HeaderText="处理人" />
                            <ext:BoundField Width="100px" DataField="所属项目" HeaderText="所属项目" />
                            <ext:BoundField Width="100px" DataField="优先级" HeaderText="优先级" />
                            <ext:BoundField Width="100px" DataField="是否已处理" HeaderText="是否已处理" />
                            <ext:BoundField Width="100px" DataField="发生日期" HeaderText="发生日期" />
                            <ext:BoundField Width="100px" DataField="处理日期" HeaderText="处理日期" />
                            <ext:BoundField Width="100px" DataField="现象描述" HeaderText="现象描述" />
                            <ext:BoundField Width="100px" DataField="处理过程" HeaderText="处理过程" />
                            
                     </Columns>

              
              </ext:Grid>
                    
             
          </Items>
          </ext:Panel>
      
      <ext:HiddenField ID="highlightRows" runat="server">
    </ext:HiddenField>
    </form>

     <script type="text/javascript">
         var highlightRowsClientID = '<%= highlightRows.ClientID %>';
         var gridClientID = '<%= Grid1.ClientID %>';

         function highlightRows() {
             var highlightRows = X(highlightRowsClientID);
             var grid = X(gridClientID);

             grid.el.select('.x-grid3-row table.highlight').removeClass('highlight');

             Ext.each(highlightRows.getValue().split(','), function (item, index) {
                 if (item !== '') {
                     var row = grid.getView().getRow(parseInt(item, 10));
                     Ext.get(row).first().addClass('highlight');
                 }
             });

         }

         // 页面第一个加载完毕后执行的函数
         function onReady() {
             var grid = X(gridClientID);
             grid.addListener('viewready', function () {
                 highlightRows();
             });
         }

         // 页面AJAX回发后执行的函数
         function onAjaxReady() {
             highlightRows();
         }


    </script>

</body>
</html>
