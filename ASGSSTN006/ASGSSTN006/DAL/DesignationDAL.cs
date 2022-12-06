using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASGSSTN006.DAL
{
    public class DesignationDAL
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public DesignationDAL()
        {
            string conn = ConfigurationManager.ConnectionStrings["rose"].ConnectionString;
            con = new SqlConnection(conn);
            cmd.Connection = con;
        }
        public SqlConnection Getcon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public DataTable Designation_list()
        {

            string qry = "select  * from Department";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }

        public int insert_Designation(BAL.DesignationBAL obj)
        {
            string qry = "insert into Designation values('" + obj.desig + "','" + obj.deptid + "')";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            return cmd.ExecuteNonQuery();
        }

        public DataTable view_Designation()
        {
            string qry = "select d.dept_name,c.desigId,c.desigName from Designation c inner join Department d on d.dept_id=c.dept_id";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int Update_Designation(BAL.DesignationBAL obj)
        {
            string s = "update Designation set desigName='" + obj.desig + "' where desigId='" + obj.desigid + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }

        public int Delete_Designation(BAL.DesignationBAL obj)
        {
            string s = "Delete from Designation  where desigId='" + obj.desigid + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }

        public int Delete_all(BAL.DesignationBAL obj)
        {
            string s = "delete from Designation where desigId='" + obj.chk + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }
    }
}