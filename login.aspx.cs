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
using System.Text;
using ExtAspNet;
using RSSMWeb.Code;
using System.Data.SqlClient;

namespace RSSMWeb
{
    public partial class login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Page.Session.RemoveAll();
            //tbxPassword.Text = "1428";
           // tbxUserName.Text = "magl";
           // tbxUserName.Text = "ckl";
            string pwd = Md5Helper.Encrypt(tbxPassword.Text);
            string sql = "";
            string userId ="0";
            string orgId = "0";
            sql = "select user_id,user_name,user_name_full,user_state,pwd_validate_time ,org_id from sys_user where user_name='";
            sql += tbxUserName.Text + "' and user_password ='" + pwd + "'; ";

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            if ( !reader.HasRows)
            {
                Alert.ShowInTop("用户名或密码输入错误!", "验证失败");
                return ;
            }
            while (reader.Read())
            {
                Page.Session.RemoveAll();
                string userState = reader["user_state"].ToString();
                string pwdVali = reader["pwd_validate_time"].ToString();
                if (userState != "2001")
                {
                    Alert.ShowInTop("用户已停用!");
                    return ;
                }
                userId = reader["user_id"].ToString();
                orgId = reader["org_id"].ToString();
                Page.Session.Add("user_id", userId);
                Page.Session.Add("user_name", reader["user_name"].ToString());
                Page.Session.Add("user_name_full", reader["user_name_full"].ToString());
                Page.Session.Add("org_id", orgId);
            }
            sql = "select * from sys_func_authority where (og_id = " + userId + " and og_type = 3001) or ( og_id= "+orgId+" and og_type = 3002) ;";
           // AuthorityClass auth = new AuthorityClass();
            Hashtable hAuth = new Hashtable();
            SqlDataReader reader1 = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader1.Read())
            {
                if (hAuth.Contains("p001"))
                {
                    if (hAuth["p001"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["p001"] = reader1["p001"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("p001", reader1["p001"].ToString());
                }
                if (hAuth.Contains("p002"))
                {
                    if (hAuth["p002"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["p002"] = reader1["p002"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("p002", reader1["p002"].ToString());
                }
                if (hAuth.Contains("p003"))
                {
                    if (hAuth["p003"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["p003"] = reader1["p003"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("p003", reader1["p003"].ToString());
                }
                if (hAuth.Contains("p004"))
                {
                    if (hAuth["p004"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["p004"] = reader1["p004"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("p004", reader1["p004"].ToString());
                }
                if (hAuth.Contains("p005"))
                {
                    if (hAuth["p005"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["p005"] = reader1["p005"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("p005", reader1["p005"].ToString());
                }
                if (hAuth.Contains("p006"))
                {
                    if (hAuth["p006"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["p006"] = reader1["p006"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("p006", reader1["p006"].ToString());
                }
               
                if (hAuth.Contains("b001"))
                {
                    if (hAuth["b001"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["b001"] = reader1["b001"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("b001", reader1["b001"].ToString());
                }
                if (hAuth.Contains("b002"))
                {
                    if (hAuth["b002"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["b002"] = reader1["b002"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("b002", reader1["b002"].ToString());
                }
                if (hAuth.Contains("b003"))
                {
                    if (hAuth["b003"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["b003"] = reader1["b003"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("b003", reader1["b003"].ToString());
                }
                if (hAuth.Contains("b004"))
                {
                    if (hAuth["b004"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["b004"] = reader1["b004"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("b004", reader1["b004"].ToString());
                }
                if (hAuth.Contains("d001"))
                {
                    if (hAuth["d001"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["d001"] = reader1["d001"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("d001", reader1["d001"].ToString());
                }
                if (hAuth.Contains("d002"))
                {
                    if (hAuth["d002"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["d002"] = reader1["d002"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("d002", reader1["d002"].ToString());
                }
                if (hAuth.Contains("d003"))
                {
                    if (hAuth["d003"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["d003"] = reader1["d003"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("d003", reader1["d003"].ToString());
                }
                if (hAuth.Contains("s001"))
                {
                    if (hAuth["s001"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["s001"] = reader1["s001"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("s001", reader1["s001"].ToString());
                }
                if (hAuth.Contains("s002"))
                {
                    if (hAuth["s002"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["s002"] = reader1["s002"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("s002", reader1["s002"].ToString());
                }
                if (hAuth.Contains("s003"))
                {
                    if (hAuth["s003"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["s003"] = reader1["s003"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("s003", reader1["s003"].ToString());
                }
                if (hAuth.Contains("s004"))
                {
                    if (hAuth["s004"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["s004"] = reader1["s004"].ToString();
                    }
                }
                else
                { 
                    hAuth.Add("s004", reader1["s004"].ToString());
                }
                if (hAuth.Contains("s005"))
                {
                    if (hAuth["s005"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["s005"] = reader1["s005"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("s005", reader1["s005"].ToString());
                }
                if (hAuth.Contains("s006"))
                {
                    if (hAuth["s006"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["s006"] = reader1["s006"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("s006", reader1["s006"].ToString());
                }
                if (hAuth.Contains("s007"))
                {
                    if (hAuth["s007"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["s007"] = reader1["s007"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("s007", reader1["s007"].ToString());
                }
                if (hAuth.Contains("s008"))
                {
                    if (hAuth["s008"].ToString().ToUpper() == "FALSE")
                    {
                        hAuth["s008"] = reader1["s008"].ToString();
                    }
                }
                else
                {
                    hAuth.Add("s008", reader1["s008"].ToString());
                }
            }
            /*
            if (reader1.HasRows)
            {
                reader1.Read();
                hAuth.Add("p001", reader1["p001"].ToString());
                hAuth.Add("p002", reader1["p002"].ToString());
                hAuth.Add("p003", reader1["p003"].ToString());
                hAuth.Add("p004", reader1["p004"].ToString());
                hAuth.Add("p005", reader1["p005"].ToString());
                hAuth.Add("p006", reader1["p006"].ToString());
                hAuth.Add("b001", reader1["b001"].ToString());
                hAuth.Add("b002", reader1["b002"].ToString());
                hAuth.Add("b003", reader1["b003"].ToString());
                hAuth.Add("b004", reader1["b004"].ToString());
                hAuth.Add("d001", reader1["d001"].ToString());
                hAuth.Add("s001", reader1["s001"].ToString());
                hAuth.Add("s002", reader1["s002"].ToString());
                hAuth.Add("s003", reader1["s003"].ToString());
                hAuth.Add("s004", reader1["s004"].ToString());
                hAuth.Add("s005", reader1["s005"].ToString());
                hAuth.Add("s006", reader1["s006"].ToString());
                hAuth.Add("s007", reader1["s007"].ToString());
                hAuth.Add("m001", reader1["m001"].ToString());
                hAuth.Add("m002", reader1["m002"].ToString());
                hAuth.Add("m003", reader1["m003"].ToString());
                hAuth.Add("m004", reader1["m004"].ToString());
            }
             * */
            Page.Session.Add("auth", hAuth);
            //问题管理
            Page.Session.Add("iniGrid", 0);
            Response.Redirect("Default.aspx");
            

        }
    }
}
