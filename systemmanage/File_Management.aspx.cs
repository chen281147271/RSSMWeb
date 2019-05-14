using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ExtAspNet;
using RSSMWeb.Code;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace RSSMWeb.systemmanage
{
    public partial class File_Management : PageBase
    {
        //List<RSSMWeb.Code.Utils.CustomClass> mylist_pjm_project_info;
        //List<RSSMWeb.Code.Utils.CustomClass> mylist_user;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateAuth("s002");
            BindGrid();
            
          //  inilist();
        }

        protected string Down_Load(object url)
        {
            string rsl = Request.Url.Authority;
            rsl = "http://" + rsl;
            rsl += "/rss/BugAttachment";
            rsl += Convert.ToString(url);
            return rsl;
        }
        private void BindGrid()
        {
            DataTable table = GetDataTable();

            Grid1.DataSource = table;
            Grid1.DataBind();

        }
        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <returns></returns>
        protected DataTable GetDataTable()
        {
            DataTable table = new DataTable();

            string sql = "  select file_id,file_name,file_hint,file_url,user_name_full,file_upload_time,ref_count,pj_name,detail_id from sys_upload_file a left join pjm_project_info c on a.pj_id=c.pj_id left join sys_user b on  a.file_uploader_id=b.user_id";
            switch (DropDownList2.SelectedItem.Text)
            {
                case "按文件名":
                    sql += " where a.file_name like '%" + txt_username.Text + "%'";
                    break;
                case "按问题ID":
                    sql += " where a.detail_id like '%" + txt_username.Text + "%'";
                    break;
                case "按提出人":
                    sql += " where b.user_name_full like '%" + txt_username.Text + "%'";
                    break;
                case "按项目":
                    sql += " where c.pj_name like '%" + txt_username.Text + "%'";
                    break;
                    
            }
            
            table = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return table;
        }

        //protected void GetBugTitle(object sender)
        //{
            
        //}
        ////type1 username 2 pj
        //protected string GetName(object code,string type)
        //{
        //    if(type=="1")
        //    {
        //      return  Utils.GetStrCodeToName(mylist_user, Convert.ToString(code));
        //    }else if(type=="2")
        //    {
        //        return Utils.GetStrCodeToName(mylist_pjm_project_info, Convert.ToString(code));
        //    } return"";
        //}

        //protected void inilist()
        //{
        //    mylist_pjm_project_info = Utils.NameToPjm_project_infoList();
        //    mylist_user = Utils.NameToUserList();
        //}

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                int startIndex = Grid1.PageIndex * Grid1.PageSize;
                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    sb.Append(Grid1.DataKeys[row + startIndex][0].ToString());
                    sb.Append(",");
                }

                sql = "delete from sys_upload_file where file_id in (" + sb.ToString().TrimEnd(',') + ");";
                int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                if (rst < 0)
                {
                    Alert.ShowInTop("save error！");
                    return;
                }
                Alert.ShowInTop("已删除：" + sb.ToString().TrimEnd(','), "删除成功", MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                Alert.ShowInTop(ex.Message + " : sql = " + sql);
            }
            BindGrid();
        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }
    }
}