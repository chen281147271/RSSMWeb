using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace RSSMWeb.projectsmanage
{
    public partial class projectmanage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateAuth("p002");
            if (!IsPostBack)
            {
                // 绑定 XML 数据源到树控件
                treeMenu.DataSource = XmlDataSource1;
                treeMenu.DataBind();

                ResolveTreeNode(treeMenu.Nodes);

                tree1.DataSource = XmlDataSource1;
                tree1.DataBind();

                ResolveTreeNode(tree1.Nodes);
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