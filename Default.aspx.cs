using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ExtAspNet;
using Newtonsoft.Json.Linq;
using System.Xml;
using Newtonsoft.Json;
using RSSMWeb.Code;



namespace RSSMWeb
{
    public partial class _Default : PageBase
    {
      
        #region Page_Init

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Page.Session["user_id"] == null)
            {
                Alert.ShowInTop("未登录");

                Response.Redirect("login.aspx");
            }
           // string user_id = Page.Session["user_id"].ToString();
            string userName_full = Page.Session["user_name_full"].ToString();

            Timer1.Enabled = true;

            //lgTag.value = userName_full;
            //Alert.ShowInTop(user_id);

            string menuType = "menu";
            HttpCookie menuCookie = Request.Cookies["Menu"];
            if (menuCookie != null)
            {
                menuType = menuCookie.Value;
            }

            // 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
            JObject ids = GetClientIDS(windowSourceCode, mainTabStrip);

            if (menuType == "accordion")
            {
                Accordion accordionMenu = InitAccordionMenu();
                ids.Add("mainMenu", accordionMenu.ClientID);
                ids.Add("menuType", "accordion");
            }
            else
            {
                Tree treeMenu = InitTreeMenu();
                ids.Add("mainMenu", treeMenu.ClientID);
                ids.Add("menuType", "menu");
            }

            string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
            PageContext.RegisterStartupScript(idsScriptStr);

            MyMessageNum();
        }

        private Accordion InitAccordionMenu()
        {
            Accordion accordionMenu = new Accordion();
            accordionMenu.ID = "accordionMenu";
            accordionMenu.EnableFill = true;
            accordionMenu.ShowBorder = false;
            accordionMenu.ShowHeader = false;
            Region2.Items.Add(accordionMenu);


            XmlDocument xmlDoc = XmlDataSource1.GetXmlDocument();
            XmlNodeList xmlNodes = xmlDoc.SelectNodes("/Tree/TreeNode");
            foreach (XmlNode xmlNode in xmlNodes)
            {
                if (xmlNode.HasChildNodes)
                {
                    AccordionPane accordionPane = new AccordionPane();
                    accordionPane.Title = xmlNode.Attributes["Text"].Value;
                    accordionPane.Layout = Layout.Fit;
                    accordionPane.ShowBorder = false;
                    accordionPane.BodyPadding = "2px 0 0 0";
                    accordionMenu.Items.Add(accordionPane);

                    Tree innerTree = new Tree();
                    innerTree.EnableArrows = true;
                    innerTree.ShowBorder = false;
                    innerTree.ShowHeader = false;
                    innerTree.EnableIcons = false;
                    innerTree.AutoScroll = true;
                    accordionPane.Items.Add(innerTree);

                    XmlDocument innerXmlDoc = new XmlDocument();
                    innerXmlDoc.LoadXml(String.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><Tree>{0}</Tree>", xmlNode.InnerXml));

                    // 绑定AccordionPane内部的树控件
                    innerTree.DataSource = innerXmlDoc;
                    innerTree.DataBind();

                    // 重新设置每个节点的图标
                    ResolveTreeNode(innerTree.Nodes);
                }
            }

            return accordionMenu;
        }

        private Tree InitTreeMenu()
        {
            Tree treeMenu = new Tree();
            treeMenu.ID = "treeMenu";
            treeMenu.EnableArrows = true;
            treeMenu.ShowBorder = false;
            treeMenu.ShowHeader = false;
            treeMenu.EnableIcons = false;
            treeMenu.AutoScroll = true;
            Region2.Items.Add(treeMenu);

            // 绑定 XML 数据源到树控件
            treeMenu.DataSource = XmlDataSource1;
            treeMenu.DataBind();

            // 重新设置每个节点的图标
            ResolveTreeNode(treeMenu.Nodes);

            return treeMenu;
        }


        private JObject GetClientIDS(params ControlBase[] ctrls)
        {
            JObject jo = new JObject();
            foreach (ControlBase ctrl in ctrls)
            {
                jo.Add(ctrl.ID, ctrl.ClientID);
            }

            return jo;
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 设置样式和语言下拉列表的选中值
                string themeValue = PageManager1.Theme.ToString().ToLower();
                HttpCookie themeCookie = Request.Cookies["Theme"];
                if (themeCookie != null)
                {
                    themeValue = themeCookie.Value;
                }
                ddlTheme.SelectedValue = themeValue;
                ddlLanguage.SelectedValue = PageManager1.Language.ToString().ToLower();

                // 设置菜单下拉列表
                HttpCookie menuCookie = Request.Cookies["Menu"];
                if (menuCookie != null)
                {
                    ddlMenu.SelectedValue = menuCookie.Value;
                }

                // 显示源代码按钮
                //btnSourceCode.OnClientClick = windowSourceCode.GetShowReference("./source.aspx?files=default.aspx;menu.xml;Web.config;Code/PageBase.cs;js/default.js;css/default.css");

            }
        }

        #endregion

        #region Event

        /// <summary>
        /// 修改样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie themeCookie = new HttpCookie("Theme", ddlTheme.SelectedValue);
            themeCookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(themeCookie);

            PageContext.Refresh();
        }

        /// <summary>
        /// 修改语言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie langCookie = new HttpCookie("Language", ddlLanguage.SelectedValue);
            langCookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(langCookie);

            PageContext.Refresh();
        }


        /// <summary>
        /// 修改菜单类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie langCookie = new HttpCookie("Menu", ddlMenu.SelectedValue);
            langCookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(langCookie);

            PageContext.Refresh();
        }
        /// <summary>
        /// 个人信息修改
        /// </summary>
        public string GetEditUrl()
        {
            Page.Session.Add("type", "0");
            return Window1.GetShowReference("~/systemmanage/User_new.aspx?id=" + Page.Session["user_id"].ToString() + "&type=0");
        }
        //public string GetEditUrl1()
        //{
        //   // Page.Session.Add("type", "0");
        //    return Window2.GetShowReference("~/myjob/MyMessage.aspx");
        //}
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            MyMessageNum();
           // lg.Text = DateTime.Now.ToString();
        }
        protected void MyMessageNum()
        {
            int num = Convert.ToInt32(Utils.GetMessageNum(Page.Session["user_id"].ToString()));
            if (num != 0)
            {
                textlab.Text = "新消息 ：" +num.ToString();
            }
            else
            {
                textlab.Text = "";
            }
        }


        #endregion

        #region Tree

        /// <summary>
        /// 重新设置每个节点的图标
        /// </summary>
        /// <param name="nodes"></param>
        private void ResolveTreeNode(ExtAspNet.TreeNodeCollection nodes)
        {
            foreach (ExtAspNet.TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    if (!String.IsNullOrEmpty(node.NavigateUrl))
                    {
                        node.IconUrl = GetIconForTreeNode(node.NavigateUrl);
                    }
                }
                else
                {
                    ResolveTreeNode(node.Nodes);
                }
            }
        }

        /// <summary>
        /// 根据链接地址返回相应的图标
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetIconForTreeNode(string url)
        {
            string iconUrl = "~/images/filetype/vs_unknow.png";
            url = url.ToLower();
            int lastDotIndex = url.LastIndexOf('.');
            string fileType = url.Substring(lastDotIndex + 1);
            if (fileType == "txt")
            {
                iconUrl = "~/images/filetype/vs_txt.png";
            }
            else if (fileType == "aspx" || fileType == "aspx?id=1")
            {
                iconUrl = "~/images/filetype/vs_aspx.png";
            }
            else if (fileType == "htm" || fileType == "html")
            {
                iconUrl = "~/images/filetype/vs_htm.png";
            }

            return iconUrl;
        }

        #endregion
    }
}
