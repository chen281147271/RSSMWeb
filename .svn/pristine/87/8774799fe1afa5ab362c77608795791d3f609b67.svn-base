using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace RSSMWeb.bugTracer
{
    public partial class Bug_Report : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateAuth("b002");
            if (!IsPostBack)
            {
                // 绑定 XML 数据源到树控件
                treeMenu.DataSource = XmlDataSource1;
                treeMenu.DataBind();
                treeMenu.ExpandAllNodes();
                ResolveTreeNode(treeMenu.Nodes);

                //tree1.DataSource = XmlDataSource1;
                //tree1.DataBind();

                //ResolveTreeNode(tree1.Nodes);
            }
        }
        private void ResolveTreeNode(ExtAspNet.TreeNodeCollection nodes)
        {
            foreach (ExtAspNet.TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    if (!String.IsNullOrEmpty(node.NavigateUrl))
                    {
                        node.Target = "main";
                    }
                }
                else
                {
                    ResolveTreeNode(node.Nodes);
                }
            }

        }
    }
}