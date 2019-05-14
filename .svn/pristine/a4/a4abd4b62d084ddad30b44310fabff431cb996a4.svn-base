<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectmanage.aspx.cs" Inherits="RSSMWeb.projectsmanage.projectmanage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server">
    </ext:PageManager>
    <ext:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <ext:Region ID="Region2" Split="true" Width="200px" Margins="0 0 0 0" ShowHeader="false"
                Title="目录" EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                <Items>
                    <ext:Accordion runat="server" ShowBorder="false" ShowHeader="false" ShowCollapseTool="true">
                        <Panes>
                            <ext:AccordionPane runat="server" Title="正在进行中" IconUrl="~/images/16/1.png" BodyPadding="2px 5px"
                                Layout="Fit" ShowBorder="false">
                                <Items>
                                    <ext:Tree runat="server" EnableArrows="true" ShowBorder="false" ShowHeader="false"
                                        AutoScroll="true" ID="treeMenu">
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane runat="server" Title="已完结项目" IconUrl="~/images/16/4.png" BodyPadding="2px 5px"
                                ShowBorder="false">
                                <Items>
                                    <ext:Tree runat="server" EnableArrows="true" ShowBorder="false" ShowHeader="false"
                                        AutoScroll="true" ID="tree1">
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                        </Panes>
                    </ext:Accordion>
                </Items>
            </ext:Region>
            <ext:Region ID="Region3" ShowHeader="false" EnableIFrame="true" IFrameUrl="~/projectsmanage/blank.htm"
                IFrameName="main" Margins="0 0 0 0" Position="Center" runat="server">
            </ext:Region>
        </Regions>
    </ext:RegionPanel>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/projectsmanage/pjm_map.xml"></asp:XmlDataSource>
    </form>
</body>
</html>
