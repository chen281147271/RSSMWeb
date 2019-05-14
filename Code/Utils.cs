using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;
namespace RSSMWeb.Code
{
    public class Utils
    {
        #region CustomClass

        public class CustomClass
        {
            private string _id;

            public string ID
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private string _group;

            public string Group
            {
                get { return _group; }
                set { _group = value; }
            }

            public CustomClass(string id, string name,string group)
            {
                _id = id;
                _name = name;
                _group = group;
            }
        }
        #endregion
        #region CustomClassForDropdownlist

        public class CustomClassForDropdownlist
        {
            private string _id;

            public string ID
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private int _group;

            public int Group
            {
                get { return _group; }
                set { _group = value; }
            }

            private bool _enableselect;

            public bool Enableselect
            {
                get { return _enableselect; }
                set { _enableselect = value; }
            }
            public CustomClassForDropdownlist(string id, string name, int group, bool enableselect)
            {
                _id = id;
                _name = name;
                _group = group;
                _enableselect = enableselect;
            }
        }
        #endregion
        #region GetCodeSource

        public static List<CustomClass> GetCodeSource(int group = 0)
        {
            List<CustomClass> myList = new List<CustomClass>();

            string sql = "select code,code_desp,code_group from sys_code ";
            if (group != 0)
            {
                sql += " where code_group = " + group.ToString() + " ;";
            }

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = reader.GetSqlValue(2).ToString();
                myList.Add(new CustomClass(sId, sName, sGroup));
               
            }
           
            return myList;
        }

        public static List<CustomClass> GetUserList(int departId = 0)
        {
            List<CustomClass> myList = new List<CustomClass>();

            string sql = "select user_id,user_name_full,org_id from sys_user ";
            if (departId != 0)
            {
                sql += " where org_id = " + departId.ToString() + " ;";
            }

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = reader.GetSqlValue(2).ToString();
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
       

            return myList;
        }
        /// <summary>
        /// 显示层级list 按角色
        /// </summary>
        public static List<CustomClassForDropdownlist> GetUserListForDropdownlist()
        {
            List<CustomClassForDropdownlist> myList = new List<CustomClassForDropdownlist>();

            string sql = "select code_desp,code from sys_code where code_group=4";
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            myList.Add(new CustomClassForDropdownlist("0", "请选择姓名", 0, true));
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(1).ToString();
                string sName = reader.GetSqlValue(0).ToString();
               
                myList.Add(new CustomClassForDropdownlist(sId, sName, 1, false));
            }

            sql = "  select user_name_full,code_desp,user_id from sys_user,sys_code where manage_type=code order by  manage_type";

            reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(2).ToString();
                string Comparison_Name = reader.GetSqlValue(1).ToString();
                string sName = reader.GetSqlValue(0).ToString();
                int indexof = myList.FindIndex(templist =>
                {
                    if (templist.Name == Comparison_Name)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                  );
                myList.Insert(indexof+1, new CustomClassForDropdownlist(sId, sName, 2, true));
            }
            return myList;
        }
        /// <summary>
        /// 显示层级list 按部门
        /// </summary>
        public static List<CustomClassForDropdownlist> GetUserListForDropdownlist_dpt()
        {
            List<CustomClassForDropdownlist> myList = new List<CustomClassForDropdownlist>();

            string sql = "  select org_name from sys_organize_info";
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            myList.Add(new CustomClassForDropdownlist("0", "请选择姓名", 0, true));
            while (reader.Read())
            {
                string sName = reader.GetSqlValue(0).ToString();

                myList.Add(new CustomClassForDropdownlist("0", sName, 1, false));
            }

            sql = "select user_name_full,org_name,user_id from sys_user a,sys_organize_info b where a.org_id=b.org_id order by  manage_type";

            reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(2).ToString();
                string Comparison_Name = reader.GetSqlValue(1).ToString();
                string sName = reader.GetSqlValue(0).ToString();
                int indexof = myList.FindIndex(templist =>
                {
                    if (templist.Name == Comparison_Name)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                  );
                myList.Insert(indexof + 1, new CustomClassForDropdownlist(sId, sName, 2, true));
            }
            return myList;
        }
        public static List<CustomClassForDropdownlist> GetUserListForDropdownlist_dpt_Att()
        {
            List<CustomClassForDropdownlist> myList = new List<CustomClassForDropdownlist>();

            string sql = "  select org_name from sys_organize_info";
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            myList.Add(new CustomClassForDropdownlist("0", "请选择姓名", 0, true));
            while (reader.Read())
            {
                string sName = reader.GetSqlValue(0).ToString();

                myList.Add(new CustomClassForDropdownlist("0", sName, 1, false));
            }

            sql = "select user_name_full,org_name,user_id from sys_user a,sys_organize_info b where a.org_id=b.org_id order by  manage_type";

            reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(2).ToString();
                string Comparison_Name = reader.GetSqlValue(1).ToString();
                string sName = reader.GetSqlValue(0).ToString();
                int indexof = myList.FindIndex(templist =>
                {
                    if (templist.Name == Comparison_Name)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                  );
                myList.Insert(indexof + 1, new CustomClassForDropdownlist(sId, sName, 2, true));
            }
            return myList;
        }
        public static string GetItemName(List<CustomClass> mylist, string sId)
        {
            string sName = "";
            CustomClass rlt = mylist.Find(
                delegate(CustomClass bk)
                {
                    return bk.ID == sId;
                }
                );
            if (rlt != null)
            {
                sName = rlt.Name;
            }

            return sName;
        }

        public static List<CustomClass> GetPJList()
        {
            List<CustomClass> myList = new List<CustomClass>();

            string sql = "select pj_id,pj_name from pjm_project_info ";
           
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = "1";
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
            return myList;
        }

        public static List<CustomClass> GetPDList()
        {
            List<CustomClass> myList = new List<CustomClass>();

            string sql = "select pd_id,pd_name from pjm_product_info ";

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = "1";
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
            return myList;
        }

        public static List<CustomClass> GetOIList()
        {
            List<CustomClass> myList = new List<CustomClass>();

            string sql = "select org_id,org_name from sys_organize_info ";

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = "0";
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
            return myList;
        }
        //角色 List
        public static List<CustomClass> GetRIList()
        {
            List<CustomClass> myList = new List<CustomClass>();

            string sql = "select role_id,role_name from sys_role_info ";

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = "0";
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
            return myList;
        }
        public static string GetOIName(int id)
        {
            string sql = "select org_name from sys_organize_info where org_id="+Convert.ToString(id);
            string sName="";
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {

                 sName = reader.GetSqlValue(0).ToString();


            }
            return sName;
        }
        public static string GetUserName(int id)
        {
            string sql = "select user_name_full from sys_user where user_id=" + Convert.ToString(id);
            string sName = "";
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {

                sName = reader.GetSqlValue(0).ToString();


            }
            return sName;
        }

        public static string GetUserCode(string name)
        {
            string sql = "select user_id from sys_user where user_name_full='" + name+"'";
            string sCode = "";
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            if (!reader.HasRows)
            {
                return "-1";
            }
            while (reader.Read())
            {

                sCode = reader.GetSqlValue(0).ToString();


            }
            return sCode;
        }

        public static List<CustomClass> GetCodeSourcebygroup(int group )
        {
            List<CustomClass> myList = new List<CustomClass>();

            string sql = "select code,code_desp,code_group from sys_code ";
            if (group != 0)
            {
                sql += " where code_group = " + group.ToString() + " ;";
            }
            myList.Add(new CustomClass("0", "请选择", "0"));
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = reader.GetSqlValue(2).ToString();
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
            return myList;
        }
        //CODE表转换
      
        public static List<CustomClass> NameToCodeList()
        {
            List<CustomClass> myList = new List<CustomClass>();
            string sql = "select code,code_desp from  sys_code";

          //  SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = "0";
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
            return myList;
        }

         //名称 to code表转换
        public static string GetStrNameToCode(List<CustomClass> mylist, string sName)
        {
            string code = "";
            CustomClass rlt = mylist.Find(
                delegate(CustomClass bk)
                {
                    return bk.Name == sName;
                }
                );
            if (rlt != null)
            {
                code = rlt.ID;
            }

            return code;
        }
        public static string GetStrCodeToName(List<CustomClass> mylist, string sCode)
        {
            string code = "";
            CustomClass rlt = mylist.Find(
                delegate(CustomClass bk)
                {
                    return bk.ID == sCode;
                }
                );
            if (rlt != null)
            {
                code = rlt.Name;
            }

            return code;
        }

        public static List<CustomClass> NameToUserList()
        {
            List<CustomClass> myList = new List<CustomClass>();
            
            string sql = "select user_id,user_name_full from  sys_user";


            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = "0";
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
            return myList;
            
        }

        //pjm_project_info表转换pjm_product_info
        public static List<CustomClass> NameToPjm_project_infoList()
        {
            List<CustomClass> myList = new List<CustomClass>();

            string sql = "select pj_id,pj_name from  pjm_project_info ";
           
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = "0";
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
            return myList;
        }

         //pjm_product_info表转换
        public static List<CustomClass> NameToPjm_product_infoList()
        {

            List<CustomClass> myList = new List<CustomClass>();
            string sql = "select pd_id,pd_name from  pjm_product_info ";

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = "0";
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
            return myList;
        }
        
        //代理商list
        public static List<CustomClass> GetAgentList()
        {
            List<CustomClass> myList = new List<CustomClass>();

            string sql = "select agent_id,agent_name from  sys_agent";

            myList.Add(new CustomClass("0", "请选择", "0"));
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = "0";
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
            return myList;

        }


        public static List<CustomClass> GetCustomerList()
        {
            List<CustomClass> myList = new List<CustomClass>();

            string sql = "select cus_id,cus_name from  sys_customer";

            myList.Add(new CustomClass("0", "请选择", "0"));
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                string sId = reader.GetSqlValue(0).ToString();
                string sName = reader.GetSqlValue(1).ToString();
                string sGroup = "0";
                myList.Add(new CustomClass(sId, sName, sGroup));
            }
            return myList;

        }

        //chart 按过程类型
        public static SqlDataReader Getchart(string type,string startime,string endtime)
        {
            

            //string  sql="select * from ";
            //        sql+="(select ";
            //        sql+="datepart(month,create_time) mm,";
            //        sql += "count(*) 合计  from bug_detail_info a  where process_type='";
            //        sql += type;
            //        sql+="' group by datepart(month,create_time)) m1 ";
            //        sql+=" right join( ";
            //        sql+="select 1 m ";
            //        sql+="union all select 2 ";
            //        sql+="union all select 3 ";
            //        sql+="union all select 4 ";
            //        sql+="union all select 5 ";
            //        sql+="union all select 6 ";
            //        sql+="union all select 7 ";
            //        sql+="union all select 8 ";
            //        sql+="union all select 9 ";
            //        sql+="union all select 10 ";
            //        sql+="union all select 11 ";
            //        sql+="union all select 12 ";
            //        sql+=") aa on(m1.mm = aa.m )";
                    string sql = "  select convert(varchar(7), create_time, 126) m,count(*) 合计 from bug_detail_info a  where process_type='";
                    sql+=type;
                    sql+="' and create_time between '";
                    sql+=startime;
                    sql+="' and '";
                    sql+=endtime;
                    sql+="' group by convert(varchar(7), create_time, 126)";
                    SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
                    return reader;



            //            select * from 
            //(select 
            //datepart(month,create_time) mm,
            //count(*) 合计  from bug_detail_info a  where process_type=5001 group by datepart(month,create_time)) m1 
            // right join( 
            //select 1 m 
            //union all select 2 
            //union all select 3 
            //union all select 4 
            //union all select 5 
            //union all select 6 
            //union all select 7 
            //union all select 8 
            //union all select 9 
            //union all select 10 
            //union all select 11 
            //union all select 12 
            //) aa on(m1.mm = aa.m )
        }
        //按问题分类
        public static SqlDataReader Getchart_bug_type(string type, string startime, string endtime)
        {

            string sql = "  select convert(varchar(7), create_time, 126) m,count(*) 合计 from bug_detail_info a,bug_main_info b where a.bug_id=b.bug_id and b.bug_type='";
            sql += type;
            sql += "' and a.create_time between '";
            sql += startime;
            sql += "' and '";
            sql += endtime;
            sql += "' group by convert(varchar(7), a.create_time, 126)";
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return reader;

        }
        //按产品分类
        public static SqlDataReader Getchart_bug_pd(string type, string startime, string endtime)
        {

            string sql = " select convert(varchar(7), create_time, 126) m,count(*) 合计 from bug_detail_info a  where pd_id='";
            sql += type;
            sql += "' and a.create_time between '";
            sql += startime;
            sql += "' and '";
            sql += endtime;
            sql += "' group by convert(varchar(7), a.create_time, 126)";
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return reader;

        }

        //项目报表 按过程类型
        public static DataTable Getchart_bug_pj1(string pj_id)
        {
            string sql = " select a.合计,b.code,b.code_desp from ";
                   sql+="(select count(*) 合计,process_type from bug_detail_info a,sys_code b  where a.process_type=b.code and ";
                   sql+=" process_type in (5001,5002,5003,5004,5005,5006,5007) and pj_id=";
                   sql += pj_id;
                   sql+=" group by process_type) a right join sys_code b ";
                   sql+="on a.process_type=b.code where  b.code in(5001,5002,5003,5004,5005,5006,5007)";


                   DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return dt;
        }
        public static SqlDataReader Getchart_bug_pd_pjdr1(string pj_id)
        {
            string sql = " select a.合计,b.code,b.code_desp from ";
            sql += "(select count(*) 合计,process_type from bug_detail_info a,sys_code b  where a.process_type=b.code and ";
            sql += " process_type in (5001,5002,5003,5004,5005,5006,5007) and pj_id=";
            sql += pj_id;
            sql += " group by process_type) a right join sys_code b ";
            sql += "on a.process_type=b.code where  b.code in(5001,5002,5003,5004,5005,5006,5007)";


            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return dr;
        }
        //项目报表 按问题子类
        public static DataTable Getchart_bug_pj2(string pj_id)
        {
            string sql = " select a.合计,b.code,b.code_desp from ";
                   sql+="(select count(*) 合计,bug_type from bug_detail_info a,sys_code b,bug_main_info c  where a.process_type=b.code and ";
                   sql+="c.bug_type in (9001,9002,9003,9004,9005,9006) and pj_id=";
                   sql+=pj_id;
                   sql+=" and c.bug_id=a.bug_id group by bug_type) a right join sys_code b ";
                   sql+="on a.bug_type=b.code where  b.code in(9001,9002,9003,9004,9005,9006) ";



            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return dt;
        }
        public static SqlDataReader Getchart_bug_pd_pjdr2(string pj_id)
        {
            string sql = " select a.合计,b.code,b.code_desp from ";
            sql += "(select count(*) 合计,bug_type from bug_detail_info a,sys_code b,bug_main_info c  where a.process_type=b.code and ";
            sql += "c.bug_type in (9001,9002,9003,9004,9005,9006) and pj_id=";
            sql += pj_id;
            sql += " and c.bug_id=a.bug_id group by bug_type) a right join sys_code b ";
            sql += "on a.bug_type=b.code where  b.code in(9001,9002,9003,9004,9005,9006) ";


            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return dr;
        }

        //项目报表 按产品
        public static DataTable Getchart_bug_pj3(string pj_id)
        {
            string sql = " select a.合计,b.pd_id,b.pd_name from ";
                   sql+="(select count(*) 合计,a.pd_id from bug_detail_info a,pjm_product_info b  where a.pd_id=b.pd_id and ";
                   sql+="a.pd_id in (select pd_id from pjm_product_info ) and pj_id=";
                   sql+=pj_id;
                   sql+="  group by a.pd_id) a right join pjm_product_info b ";
                   sql+="on a.pd_id=b.pd_id where  b.pd_id in(select pd_id from pjm_product_info) ";



            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return dt;
        }
        public static SqlDataReader Getchart_bug_pd_pjdr3(string pj_id)
        {
            string sql = " select a.合计,b.pd_id,b.pd_name from ";
            sql += "(select count(*) 合计,a.pd_id from bug_detail_info a,pjm_product_info b  where a.pd_id=b.pd_id and ";
            sql += "a.pd_id in (select pd_id from pjm_product_info ) and pj_id=";
            sql += pj_id;
            sql += "  group by a.pd_id) a right join pjm_product_info b ";
            sql += "on a.pd_id=b.pd_id where  b.pd_id in(select pd_id from pjm_product_info) ";


            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return dr;
        }

        public static DataTable Getchart_pj(string startime,string endtime)
        {
            string sql = "select top 5  b.pj_name ,COUNT(a.pj_id) as 问题总数,b.pj_id from bug_detail_info a right join pjm_project_info b"; 
                   sql+=" on a.pj_id=b.pj_id where LEFT(b.pj_id_erp,4) between ";
                   sql+=startime;
                   sql += " and ";
                   sql+=endtime;
                   sql+=" group by b.pj_id,b.pj_name order by COUNT(a.pj_id) desc";



            DataTable dr = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            return dr;
        }

        //查询站内信条数
        public static string GetMessageNum(string User_id)
        {
            string num="";
            string sql = "select COUNT(*) from  sys_message where msg_tgt_id=";
            sql += User_id;
            sql+=" and msg_read_flag = 0";

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                 num = reader.GetSqlValue(0).ToString();
            }
            return num;
        }

        //查询Email地址
        public static string GetEmail(string User_id)
        {
            string Email = "";
            string sql = "select email_address from sys_user where user_id= '";
            sql += User_id;
            sql += "'";

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql);
            while (reader.Read())
            {
                Email = reader.GetSqlValue(0).ToString();
            }
            return Email;
        }
        //发送Email
        public static int SendEmail(string send_address, string from_address, string title, string concent)
        {
            int nContain = 0;

            ///添加发件人地址
            // string from = "chenkailai@szrss.com";
            string from = from_address;
            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(from);
            nContain += mailMsg.From.Address.Length;

            ///添加收件人地址
            string split = ";";
            //  string[] toList = To.Text.Trim().Split(split.ToCharArray());
            string[] toList = send_address.Trim().Split(split.ToCharArray());
            for (int i = 0; i < toList.Length; i++)
            {
                mailMsg.To.Add(toList[i].Trim());
            }
            nContain += from_address.Length;

            ///添加抄送地址；
            //string[] ccList = CC.Text.Trim().Split(split.ToCharArray());
            //for (int i = 0; i < ccList.Length; i++)
            //{
            //    if (ccList[i].Trim().Length > 0)
            //    {
            //        mailMsg.CC.Add(ccList[i].Trim());
            //    }
            //}
            //nContain += CC.Text.Length;

            ///添加邮件主题
            mailMsg.Subject = title.Trim();
            mailMsg.SubjectEncoding = Encoding.UTF8;
            nContain += mailMsg.Subject.Length;

            ///添加邮件内容
            mailMsg.Body = concent;
            mailMsg.BodyEncoding = Encoding.UTF8;
            mailMsg.IsBodyHtml = true;
            nContain += mailMsg.Body.Length;

            ///添加邮件附件		
            HttpFileCollection fileList = HttpContext.Current.Request.Files;
            for (int i = 0; i < fileList.Count; i++)
            {   ///添加单个附件
                HttpPostedFile file = fileList[i];
                if (file.FileName.Length <= 0 || file.ContentLength <= 0)
                {
                    break;
                }
                Attachment attachment = new Attachment(file.FileName);
                mailMsg.Attachments.Add(attachment);
                nContain += file.ContentLength;
            }

            if (mailMsg.IsBodyHtml == true)
            {
                nContain += 100;
            }

            try
            {   ///发送邮件
                IMail mail = new Mail();
                return mail.SenderMail(mailMsg);
                
                /////保存发送的邮件
                //int nMailID = mail.SaveAsMail(mailMsg.Subject, mailMsg.Body, from,
                //    To.Text.Trim(), CC.Text.Trim(), mailMsg.IsBodyHtml,
                //    nContain, mailMsg.Attachments.Count > 0 ? true : false);

                //if (nMailID > 0)
                //{   ///保存发送邮件的附件
                //    for (int i = 0; i < fileList.Count; i++)
                //    {   ///添加单个附件
                //        HttpPostedFile file = fileList[i];
                //        if (file.FileName.Length <= 0 || file.ContentLength <= 0)
                //        {
                //            break;
                //        }
                //        ///保存附件到硬盘中
                //        file.SaveAs(MapPath("MailAttachments/" + Path.GetFileName(file.FileName)));
                //        ///保存发送邮件的附件
                //        mail.SaveAsMailAttachment(
                //            Path.GetFileName(file.FileName),
                //            "MailAttachments/" + Path.GetFileName(file.FileName),
                //            file.ContentType,
                //            file.ContentLength,
                //            nMailID);
                //    }
                //}
            }
            catch (Exception ex)
            {   ///跳转到异常错误处理页面
                //Alert.Show(ex.Message);
                //Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>", "").Replace("\n", "")
                //    + "&ErrorUrl=" + Request.Url.ToString().Replace("<br>", "").Replace("\n", ""));
                return -1;
            }
            // Response.Redirect("~/MailDesktop.aspx");
        }
        #endregion
        public static string TrimString(string src)
        {
            string rsl;
            rsl = src.Replace("'", "");
            rsl = src.Replace("\"", "");
            rsl = src.Replace(";", "");
            return rsl;
        }
    }
}