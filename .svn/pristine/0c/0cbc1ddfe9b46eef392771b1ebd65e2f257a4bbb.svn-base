
function onReady() {
    var btnExpandAll = Ext.getCmp(IDS.btnExpandAll);
    var btnCollapseAll = Ext.getCmp(IDS.btnCollapseAll);
    var mainMenu = Ext.getCmp(IDS.mainMenu);
    var mainTabStrip = Ext.getCmp(IDS.mainTabStrip);
    var windowSourceCode = Ext.getCmp(IDS.windowSourceCode);

    function getExpandedPanel() {
        var panel = null;
        mainMenu.items.each(function (item) {
            if (!item.collapsed) {
                panel = item;
            }
        });
        return panel;
    }
/*
    // 点击全部展开按钮
    btnExpandAll.on('click', function () {
        if (IDS.menuType == "menu") {
            mainMenu.expandAll();
        } else {
            var expandedPanel = getExpandedPanel();
            if (expandedPanel) {
                expandedPanel.items.itemAt(0).expandAll();
            }
        }
    });

    // 点击全部折叠按钮
    btnCollapseAll.on('click', function () {
        if (IDS.menuType == "menu") {
            mainMenu.collapseAll();
        } else {
            var expandedPanel = getExpandedPanel();
            if (expandedPanel) {
                expandedPanel.items.itemAt(0).collapseAll();
            }
        }
    });
*/
    function createToolbar() {

        // 由工具栏上按钮获得当前标签页中的iframe节点
        function getCurrentIframeNode(button) {
            // 注意：button.ownerCt 是工具栏，button.ownerCt.ownerCt 就是当前激活的标签页。
            return Ext.DomQuery.selectNode('iframe', button.ownerCt.ownerCt.el.dom);
        }
        /*
        // 动态创建按钮
        var sourcecodeButton = new Ext.Button({
            text: "源代码",
            type: "button",
            cls: "x-btn-text-icon",
            icon: "./res.axd?icon=PageWhiteCode",
            visiable: "false",
            listeners: {
                click: function (button, e) {
                    windowSourceCode.box_show('./source.aspx?files=' + getCurrentIframeNode(button).attributes['src'].value, '源代码');
                    e.stopEvent();
                }
            }
        });
        */
        var openNewWindowButton = new Ext.Button({
            text: '新标签页中打开',
            type: "button",
            cls: "x-btn-text-icon",
            icon: "./res.axd?icon=TabGo",
            listeners: {
                click: function (button, e) {
                    window.open(getCurrentIframeNode(button).src, "_blank");
                    e.stopEvent();
                }
            }
        });

        var refreshButton = new Ext.Button({
            text: '刷新',
            type: "button",
            cls: "x-btn-text-icon",
            icon: "./res.axd?icon=Reload",
            listeners: {
                click: function (button, e) {
                    getCurrentIframeNode(button).contentWindow.location.reload(); //.replace(href);
                    e.stopEvent();
                }
            }
        });

        return new Ext.Toolbar({
            items: ['->', refreshButton, '-', openNewWindowButton]
        });
    }


    // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
    X.util.initTreeTabStrip(mainMenu, mainTabStrip, createToolbar);


    // 公开添加示例标签页的方法
    window.addExampleTab = function (id, url, text, icon) {
        X.util.addMainTab(mainTabStrip, id, url, text, icon);
    };

}