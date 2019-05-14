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
using System.Data.OleDb;
namespace RSSMWeb.projectsmanage
{
    public partial class IntroductionExcel : PageBase
    {
        DataTable dt= new DataTable();
        List<RSSMWeb.Code.Utils.CustomClass> mylist_user;
        List<RSSMWeb.Code.Utils.CustomClass> mylist_code;
        List<RSSMWeb.Code.Utils.CustomClass> mylist_pjm_project_info;
        List<RSSMWeb.Code.Utils.CustomClass> mylist_pjm_product_info;
       // DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateAuth("b003");
        }

        protected void Btn_Introduction_Click(object sender, EventArgs e)
        {
            highlightRows.Text = "";
            string filePath = "";
           // dt = new DataTable();
            DataSet ds = new DataSet();
            if (!fuFile.HasFile && fuFile.FileName != "")
            {
                Alert.Show("请选择你要导入的Excel文件");
                return;
            }
            //获取文件的后缀名
            string fileExt = System.IO.Path.GetExtension(fuFile.FileName);
            if (fileExt != ".xls")
            {
                Alert.Show("文件类型错误");
                return;
            }
            //获取绝对路径
            HttpPostedFile file = fuFile.PostedFile;
            HttpPostedFile fi = file;
            string filename = Path.GetExtension(file.FileName);
            filePath = "~/UploadFiles/" + filename;
            HttpServerUtility server = System.Web.HttpContext.Current.Server;
            if (!Directory.Exists(server.MapPath("~/UploadFiles/")))
                Directory.CreateDirectory(server.MapPath("~/UploadFiles/"));
            try
            {
                file.SaveAs(Server.MapPath(filePath));//这时候的excel文件才能真正完成你上传的需求
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
            //string conn = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=\"dBASE IV;HDR=Yes;IMEX=1\";Data Source = " + filePath + "";
           // C:\\Users\\Administrator\\Desktop\\123456.xls
            string conn = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";Data Source=" + Server.MapPath(filePath);
            OleDbConnection excelCon = new OleDbConnection(conn);
            //output是Excel文件里面工作表名 默认为Sheet1,后面需要加上$符号
            OleDbDataAdapter odda = new OleDbDataAdapter("SELECT * FROM [output$]", excelCon);
            try
            {
                odda.Fill(ds, "Props_Type");
                
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                excelCon.Close();
                excelCon.Dispose();
                return;
            }
            finally
            {
                excelCon.Close();
                excelCon.Dispose();
            }

               
             



            DataRow dr = dt.NewRow();
            dt.Columns.Add("问题标题");
            dt.Columns.Add("提出人");
            dt.Columns.Add("所属产品");
            dt.Columns.Add("优先级");
            dt.Columns.Add("是否已处理");
            dt.Columns.Add("发生日期");
            dt.Columns.Add("处理日期");
            dt.Columns.Add("现象描述");
            dt.Columns.Add("问题分类");
            dt.Columns.Add("处理过程");
            dt.Columns.Add("过程分类");
            dt.Columns.Add("转发对象");
            dt.Columns.Add("处理人");
            dt.Columns.Add("所属项目");
            dt.Columns.Add("是否上传");


            if (ds.Tables[0].Rows.Count != 0)
            {

                dt.Clear();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            dr["问题标题"] = ds.Tables[0].Rows[i]["问题标题"].ToString();
                            string aaa = dr["问题标题"].ToString();
                            if (dr["问题标题"].ToString() == "")
                            {
                                continue;
                            }
                            dr["提出人"] = ds.Tables[0].Rows[i]["提出人"].ToString();
                            dr["所属产品"] = ds.Tables[0].Rows[i]["所属产品"].ToString();
                            dr["优先级"] = ds.Tables[0].Rows[i]["优先级"].ToString();
                            dr["是否已处理"] = ds.Tables[0].Rows[i]["是否已处理"].ToString();
                            dr["发生日期"] = ds.Tables[0].Rows[i]["发生日期"].ToString();
                            dr["处理日期"] = ds.Tables[0].Rows[i]["处理日期"].ToString();
                            dr["现象描述"] = ds.Tables[0].Rows[i]["现象描述"].ToString();
                            dr["处理过程"] = ds.Tables[0].Rows[i]["处理过程"].ToString();
                            dr["问题分类"] = ds.Tables[0].Rows[i]["问题分类"].ToString();
                            dr["过程分类"] = ds.Tables[0].Rows[i]["过程分类"].ToString();
                            dr["转发对象"] = ds.Tables[0].Rows[i]["转发对象"].ToString();
                            dr["处理人"] = ds.Tables[0].Rows[i]["处理人"].ToString();
                            dr["所属项目"] = ds.Tables[0].Rows[i]["所属项目"].ToString();
                            dr["是否上传"] = true;
                            dt.Rows.Add(dr);
                            dr = dt.NewRow();
                        }
                        catch
                        {
                            continue;
                        }


                    }

                }
            //  Page.Session.Add("ExcelDateTabel", dt);
              Grid1.DataSource = dt.DefaultView.Table;
              Grid1.DataBind();

             
             

            

        

            }



        protected void btn_SaveTable_Click(object sender, EventArgs e)
        {
            try
            {
                
                ExtAspNet.CheckBoxField cbxUpload = (ExtAspNet.CheckBoxField)Grid1.FindColumn("cbxUpload");//是否上传
                
                if (CheckData(1) != 0)
                {
                    return;
                }
             //   inilist();
                string sql;
              //  DataTable dt = new DataTable();
              //  dt = (DataTable) Page.Session["ExcelDateTabel"];
                if (Grid1.Rows.Count == 0)
                {
                    Alert.Show("表格无数据");
                    return;
                }
                for (int i = 0; i < Grid1.Rows.Count; i++)
                {
                    if (!cbxUpload.GetCheckedState(i))
                    {
                        continue;
                    }

                  //  string aaa = Grid1.Rows[i].States[1].ToString();
                   // Alert.Show(aaa);

                    sql = "INSERT INTO bug_main_info (bug_title,bug_type,sub_bug_count)  ";
                    sql += "VALUES   ('" + Grid1.Rows[i].Values[1].ToString() + "', '" + Utils.GetStrNameToCode(mylist_code, Grid1.Rows[i].Values[4].ToString()) + "', 1 ) ";

                    //Alert.ShowInTop(sql);

                    int rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                    if (rst != 1)
                    {
                        Alert.ShowInTop("save error！");
                        continue;
                    }
                    string sIsResolved = "0";
                    if (Grid1.Rows[i].Values[10].ToString() == "是")
                    {
                        sIsResolved = "1";
                    }
                    sql = "select IDENT_CURRENT('bug_main_info') ";
                    SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                    string newId = "0";
                    while (reader.Read())
                    {
                        newId = reader.GetValue(0).ToString();
                    }
                    string resolveUser = "0";
                    if (Grid1.Rows[i].Values[7].ToString() != null)
                    {
                        resolveUser = Grid1.Rows[i].Values[7].ToString();
                    }
                    sql = "INSERT INTO bug_detail_info (bug_id,process_type,is_resolved,phenomenon,create_time,occur_time,create_user_id,bug_state, ";
                    sql += "pj_id,PRI,rsolve_time,resolve_user_id,solution,cur_user_id,next_user_id,pd_id) ";
                    sql += "VALUES (" + newId + "," + Utils.GetStrNameToCode(mylist_code, Grid1.Rows[i].Values[5].ToString()) + "," + sIsResolved + ",'" + Grid1.Rows[i].Values[13].ToString() + "',GETDATE(),cast('" + Grid1.Rows[i].Values[11].ToString() + "' as datetime),";
                    sql += Utils.GetStrNameToCode(mylist_user, Grid1.Rows[i].Values[2].ToString()) + ",6001," + Utils.GetStrNameToCode(mylist_pjm_project_info, Grid1.Rows[i].Values[8].ToString()) + "," + Utils.GetStrNameToCode(mylist_code, Grid1.Rows[i].Values[9].ToString()) + ", ";
                    sql += "cast('" + Grid1.Rows[i].Values[12].ToString() + "' as datetime)," + Utils.GetStrNameToCode(mylist_user, resolveUser) + ",'" + Grid1.Rows[i].Values[14].ToString() + "'," + Utils.GetStrNameToCode(mylist_user, Grid1.Rows[i].Values[2].ToString()) + "," + Utils.GetStrNameToCode(mylist_user, Grid1.Rows[i].Values[6].ToString());
                    sql += ", " + Utils.GetStrNameToCode(mylist_pjm_product_info, Grid1.Rows[i].Values[3].ToString()) + ");";

                    rst = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                    if (rst != 1)
                    {
                        Alert.ShowInTop("save error !");
                        continue;
                    }

                }
                Alert.Show("OK");
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }
        
        }
        public bool IsDate(string str)
        { 
            try 
            {  
                DateTime.Parse(str);   
                return true; 
            } 
            catch 
            {    return false; 
            }
        }
        protected void inilist()
        {
            mylist_user = Utils.NameToUserList();
            mylist_code = Utils.NameToCodeList();
            mylist_pjm_project_info = Utils.NameToPjm_project_infoList();
            mylist_pjm_product_info = Utils.NameToPjm_product_infoList();

            
        }
        //CheckType 0失败弹框 且全部检测 其他值不弹框 且只检测上传项打勾的
        protected int CheckData(int CheckType)
        {
            try
            {

                ExtAspNet.CheckBoxField cbxUpload = (ExtAspNet.CheckBoxField)Grid1.FindColumn("cbxUpload");
                string errormessage = "";
                string erroershow = "";
                highlightRows.Text = "";
              //  DataTable dt = new DataTable();
                inilist();
              //  dt = (DataTable)Page.Session["ExcelDateTabel"];
                for (int i = 0; i < Grid1.Rows.Count; i++)
                {
                    if (!cbxUpload.GetCheckedState(i)&&CheckType!=0)
                    {
                        continue;
                    }
                    errormessage = "";

                    if (Utils.GetStrNameToCode(mylist_code, Grid1.Rows[i].Values[4].ToString()) == "")
                    {
                        errormessage += "问题分类,";
                    }
                    if (Utils.GetStrNameToCode(mylist_code, Grid1.Rows[i].Values[5].ToString()) == "")
                    {
                        errormessage += "过程分类,";
                    }
                    if (!IsDate(Grid1.Rows[i].Values[11].ToString()))
                    {
                        errormessage += "发生日期,";
                    }
                    if (Utils.GetStrNameToCode(mylist_user, Grid1.Rows[i].Values[6].ToString()) == "")
                    {
                        errormessage += "转发对象,";
                    }
                    if (Utils.GetStrNameToCode(mylist_pjm_project_info, Grid1.Rows[i].Values[8].ToString()) == "")
                    {
                        errormessage += "所属项目,";
                    }
                    if (Utils.GetStrNameToCode(mylist_code, Grid1.Rows[i].Values[9].ToString()) == "")
                    {
                        errormessage += "优先级,";
                    }
                    if (!IsDate(Grid1.Rows[i].Values[12].ToString()))
                    {
                        errormessage += "处理日期,";
                    }
                    if (Utils.GetStrNameToCode(mylist_user, Grid1.Rows[i].Values[2].ToString()) == "")
                    {
                        errormessage += "提出人,";
                    }
                    if (Utils.GetStrNameToCode(mylist_user, Grid1.Rows[i].Values[7].ToString()) == "")
                    {
                        errormessage += "处理人,";
                    }
                    if (Utils.GetStrNameToCode(mylist_pjm_product_info, Grid1.Rows[i].Values[3].ToString()) == "")
                    {
                        errormessage += "所属产品,";
                    }
                    if (Grid1.Rows[i].Values[10].ToString().Trim() != "是" && Grid1.Rows[i].Values[10].ToString().Trim() != "否")
                    {
                        errormessage += "是否已处理,";
                    }

                    if (errormessage != "")
                    {
                        highlightRows.Text += Convert.ToString(i) + ",";

                        //  Grid1.Rows[i].s = System.Drawing.Color.Red;
                        cbxUpload.SetCheckedState(i, false);
                        string[] aa = Grid1.Rows[0].Values;
                        erroershow += "第" + Convert.ToString(i + 1) + "行数据 以下字段发生错误:" + errormessage;
                    }



                }
                if (erroershow == "")
                {
                    if (CheckType == 0)
                    {
                        Alert.Show("Success！");
                    }
                    return 0;
                }
                else
                {
                    Alert.Show(erroershow);
                    return -1;
                }
            }catch
            {
                return -1;
                
            }
        }
        
        protected void btn_CheckData_Click(object sender, EventArgs e)
        {
            if (Grid1.Rows.Count == 0)
            {
                Alert.Show("表格无数据");
                return;
            }
            CheckData(0);
           
        }

        protected void Grid1_RowClick(object sender, GridRowClickEventArgs e)
        {
            Grid1.Rows[e.RowIndex].BackColor = System.Drawing.Color.Red;
        }

        protected void btn_Download_Click(object sender, EventArgs e)
        {
            string rsl = Request.Url.Authority;
            rsl = "http://" + rsl;
            rsl += "/rss/UploadDemo/demo.xls";
            PageContext.Redirect(rsl, "_blank");

        }

        protected void btn_Up_Click(object sender, EventArgs e)
        {
            string filePath = "";
            // dt = new DataTable();
            DataSet ds = new DataSet();
            if (!fuFile.HasFile && fuFile.FileName != "")
            {
                Alert.Show("请选择你要导入的Excel文件");
                return;
            }
            //获取文件的后缀名
            string fileExt = System.IO.Path.GetExtension(fuFile.FileName);
            if (fileExt != ".xls")
            {
                Alert.Show("文件类型错误");
                return;
            }
            //获取绝对路径
            HttpPostedFile file = fuFile.PostedFile;
            HttpPostedFile fi = file;
            string filename = Path.GetExtension(file.FileName);
            filePath = "~/UploadDemo/Demo" + filename;
            HttpServerUtility server = System.Web.HttpContext.Current.Server;
            if (!Directory.Exists(server.MapPath("~/UploadDemo/")))
                Directory.CreateDirectory(server.MapPath("~/UploadDemo/"));
            try
            {
                file.SaveAs(Server.MapPath(filePath));//这时候的excel文件才能真正完成你上传的需求
                Alert.Show("上传成功");
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
            
        }




        }
}