using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ExtAspNet;
using System.Data.SqlClient;
using RSSMWeb.Code;
using System.Configuration;
using System.IO;
using System.Collections;


namespace RSSMWeb
{
    public class PageBase : System.Web.UI.Page
    {
        public class AuthorityClass
        {
            public bool p001;
            public bool p002;
            public bool p003;
            public bool p004;
            public bool p005;
            public bool p006;
            public bool b001;
            public bool b002;
            public bool b003;
            public bool b004;
            public bool d001;
            public bool s001;
            public bool s002;
            public bool s003;
            public bool s004;
            public bool s005;
            public bool s006;
            public bool s007;
            public bool m001;
            public bool m002;
            public bool m003;
            public bool m004;

            public AuthorityClass()
            {
                //p
                p001=false;
                p002 = false;
                p003 = false;
                p004 = false;
                p005 = false;
                p006 = false;
                //b
                b001 = false;
                b002 = false;
                b003 = false;
                b004 = false;
                //d
                d001 = false;
                //s
                s001 = false;
                s002 = false;
                s003 = false;
                s004 = false;
                s005 = false;
                s006 = false;
                s007 = false;
                m001 = false;
                m002 = false;
                m003 = false;
                m004 = false;
            }
        }
        //返回权限列表模拟树结点的位子以及深度
        public static string GetAuthorityTreeLoc(string str)
        {
            switch (str)
             {
                case "A":
                     return "0";
                case "p":
                    return "1";
                case "b":
                    return "8";
                case "d":
                    return "13";
                case "s":
                    return "15";
                case "m":
                    return "23";
             } return "-1";
        }
        public static string GetAuthorityTreeDepth(string str)
        {
            switch (str)
            {
                case "A":
                    return "27";
                case "p":
                    return "6";
                case "b":
                    return "4";
                case "d":
                    return "1";
                case "s":
                    return "7";
                case "m":
                    return "4";
            } return "-1";
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!IsPostBack)
            {
                if (PageManager.Instance != null)
                {
                    HttpCookie themeCookie = Request.Cookies["Theme"];
                    if (themeCookie != null)
                    {
                        string themeValue = themeCookie.Value;

                        if (IsSystemTheme(themeValue))
                        {
                            PageManager.Instance.Theme = (Theme)Enum.Parse(typeof(Theme), themeValue, true);
                        }
                        else
                        {
                            PageManager.Instance.CustomTheme = themeValue;
                        }
                    }

                    HttpCookie langCookie = Request.Cookies["Language"];
                    if (langCookie != null)
                    {
                        string langValue = langCookie.Value;
                        PageManager.Instance.Language = (Language)Enum.Parse(typeof(Language), langValue, true);
                    }
                }
            }

        }

        private bool IsSystemTheme(string themeName)
        {
            string[] themes = Enum.GetNames(typeof(Theme));
            foreach (string theme in themes)
            {
                if (theme.ToLower() == themeName)
                {
                    return true;
                }
            }
            return false;
        }
        #region Grid Related

        /// <summary>
        /// 选中的行
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        protected string HowManyRowsAreSelected(Grid grid)
        {
            StringBuilder sb = new StringBuilder();
            int selectedCount = grid.SelectedRowIndexArray.Length;
            if (selectedCount > 0)
            {
                sb.AppendFormat("共选中了 {0} 行：", selectedCount);
                sb.Append("<table style=\"width:500px;\">");

                sb.Append("<tr><th>行号</th>");
                foreach (string datakey in grid.DataKeyNames)
                {
                    sb.AppendFormat("<th>{0}</th>", datakey);
                }
                sb.Append("</tr>");


                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = grid.SelectedRowIndexArray[i];
                    sb.Append("<tr>");

                    sb.AppendFormat("<td>{0}</td>", rowIndex + 1);

                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (grid.AllowPaging && !grid.IsDatabasePaging)
                    {
                        rowIndex = grid.PageIndex * grid.PageSize + rowIndex;
                    }

                    object[] dataKeys = grid.DataKeys[rowIndex];
                    for (int j = 0; j < dataKeys.Length; j++)
                    {
                        sb.AppendFormat("<td>{0}</td>", dataKeys[j]);
                    }

                    sb.Append("</tr>");
                }
                sb.Append("</table>");
            }
            else
            {
                sb.Append("<strong>没有选中任何一行！</strong>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// 获取code字面值，在 ASPX 中调用
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        protected string GetSysCode(object code)
        {
            if (code == DBNull.Value || code == null)
            {
                return "未指定";
            }
            return GetSysCode2(Convert.ToString(code));
        }

        protected string GetSysCode2(string code)
        {
            if (code == "")
            {
                return "";
            }
            switch (Convert.ToInt32(code))
            {
                case 1001:
                    return "目录功能";
                case 1002:
                    return "节点功能";
                case 2001:
                    return "正常";
                case 2002:
                    return "停用";
                case 3001:
                    return "用户";
                case 3002:
                    return "用户组";
                case 3003:
                    return "全部";
                case 3004:
                    return "角色";
                case 4001:
                    return "普通";
                case 4002:
                    return "经理 ";
                case 4003:
                    return "协助";
                case 5001:
                    return "研发设计问题";
                case 5002:
                    return "生产装配问题";
                case 5003:
                    return "品质测试问题";
                case 5004:
                    return "项目实施问题";
                case 5005:
                    return "售后服务问题";
                case 5006:
                    return "流程运行问题";
                case 5007:
                    return "其他";
                case 6001:
                    return "新增";
                case 6002:
                    return "开启";
                case 6003:
                    return "修复";
                case 6004:
                    return "关闭";
                case 6005:
                    return "待优化";
                case 6006:
                    return "废弃";
                case 6007:
                    return "已解决";
                case 7001:
                    return "最低";
                case 7002:
                    return "低";
                case 7003:
                    return "中";
                case 7004:
                    return "高";
                case 7005:
                    return "最高";
                case 8001:
                    return "北京市";
                case 8002:
                    return "天津市";
                case 8003:
                    return "河北省";
                case 8004:
                    return "山西省";
                case 8005:
                    return "内蒙古自治区";
                case 8006:
                    return "辽宁省";
                case 8007:
                    return "吉林省";
                case 8008:
                    return "黑龙江省";
                case 8009:
                    return "上海市";
                case 8010:
                    return "江苏省";
                case 8011:
                    return "浙江省";
                case 8012:
                    return "安徽省";
                case 8013:
                    return "福建省";
                case 8014:
                    return "江西省";
                case 8015:
                    return "山东省";
                case 8016:
                    return "河南省";
                case 8017:
                    return "湖北省";
                case 8018:
                    return "湖南省";
                case 8019:
                    return "广东省";
                case 8020:
                    return "广西壮族自治区";
                case 8021:
                    return "海南省";
                case 8022:
                    return "重庆市";
                case 8023:
                    return "四川省";
                case 8024:
                    return "贵州省";
                case 8025:
                    return "云南省";
                case 8026:
                    return "西藏自治区";
                case 8027:
                    return "陕西省";
                case 8028:
                    return "甘肃省";
                case 8029:
                    return "青海省";
                case 8030:
                    return "宁夏回族自治区";
                case 8031:
                    return "新疆维吾尔自治区";
                case 8032:
                    return "香港特别行政区";
                case 8033:
                    return "澳门特别行政区";
                case 8034:
                    return "台湾省";
                case 8035:
                    return "全部";
                case 9001:
                    return "机械结构";
                case 9002:
                    return "电气控制";
                case 9003:
                    return "软件";
                case 9004:
                    return "电子";
                case 9005:
                    return "流程及操作";
                case 9006:
                    return "其他";
            }
            return "未知";
        }
        public string GetUserName(object code)
        {
            if (code == null || code == DBNull.Value)
            {
                return "";
            }
            string sId = Convert.ToString(code);
            string sName = "";
            sName = GetUserName2(sId);
            return sName;
        }
        public string GetUserName2(string sId)
        {
            string sName = "";

            string sql = "select user_name_full from sys_user ";
            sql += " where user_id =" + sId;

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                sName = reader.GetSqlValue(0).ToString();
            }
            return sName;
        }
        //附件是否已存在
        public static string exist_fujian(object flag)
        {
            if (flag.ToString().Length == 0)
            {
                return "~/images/16/0.png";
            }
            // Alert.Show(false.ToString());
            if (Convert.ToInt32(flag.ToString())==0)
            {
                return "~/images/16/0.png";
            }
            else
                return "~/images/16/1.png"; ;
        }
        //是否已读
        public static string isread(object flag)
        {
           // Alert.Show(false.ToString());
            if (flag.ToString() == "False")
            {
                return "未读";
            }
            else
                return "已读";
        }
        //DES解密
        public static string DESDecrypt(object decryptString)
        {
            try
            {
                return Md5Helper.DESDecrypt(decryptString.ToString()).Substring(0, 10);
            }
            catch (Exception e)
            {
                return "";
                //Alert.ShowInTop(e.Message);
            }
        }
         #endregion

        public void InitFileList()
        {
            //从config中读取文件上传路径
            string strFileUploadPath = ConfigurationManager.AppSettings["FileUploadPath"].ToString();
            //组合成物理路径
            string strFilePath = Server.MapPath(strFileUploadPath);
            //读取文件夹下所有文件
            FileInfo[] arrFiles = new DirectoryInfo(strFilePath).GetFiles();
            //把文件名逐一添加到列表框控件控件
      //      foreach (FileInfo fi in arrFiles)
     //           lb_FileList.Items.Add(fi.Name);
        }
        public bool IsAllowableFileSize(int contentLength)
        {
            //从config中读取上传文件大小限制
            double iFileSizeLimit = Convert.ToInt32(ConfigurationManager.AppSettings["FileSizeLimit"]) * 1024;
            //文件大小是否超出了大小限制？
            if (iFileSizeLimit > contentLength)
                return true;
            else
                return false;
        }
        public bool IsAllowableFileType(string extName)
        {
            //从config中读取上传文件类型限制
            string strFileTypeLimit = ConfigurationManager.AppSettings["FileTypeLimit"].ToString();
            //当前文件扩展名是否能在这个字符串中找到？
            if (strFileTypeLimit.IndexOf(extName.ToLower()) > -1)
                return true;
            else
                return false;
        }
        #region 取得文件后缀
        /// <summary>
        /// 取得文件后缀
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <returns></returns>
        public static string GetFileExtends(string filename)
        {
            string ext = null;
            if (filename.IndexOf('.') > 0)
            {
                string[] fs = filename.Split('.');
                ext = fs[fs.Length - 1];
            }
            return ext;
        }
        #endregion

        #region 权限认证
        /// <summary>
        /// 权限认证
        /// </summary>
        /// <param name="funcCode">功能代码</param>
        /// <returns></returns>
        public void ValidateAuth(string funcCode)
        {
            if (ConfigurationManager.AppSettings["EnableAuthentication"].ToString().ToLower() == "false")
            {
                return;
            }
            if (Page.Session.Count == 0 || Page.Session["auth"] == null )
            {
                Response.Redirect("login.aspx");
            }
            Hashtable hAuth = new Hashtable();
            hAuth =  (Hashtable)Page.Session["auth"];
            foreach (DictionaryEntry de in hAuth)
            {
                if (de.Key.ToString() == funcCode)
                {
                   // return (bool)de.Value;
                    if ((string)de.Value== "True")
                    {
                        return;
                    }
                    else
                    {
                        Response.Redirect("~/forbidden.htm");
                        return;
                    }
                    
                }
            }
            Response.Redirect("~/forbidden.htm");
        }
        #endregion

        protected void AddBugRecord(string detailId,string  content)
        {

            string sql = "INSERT INTO bug_running_record (detail_id,deal_user_id,deal_time,deal_content)";
            sql += " VALUES (" + detailId + "," + Page.Session["user_id"].ToString() + ",getdate(),'" + content + "')";

            int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            if (rst < 0)
            {
                Alert.ShowInTop("save error !");
            }
        }
    }

}
