using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DBAccess
    {
        public static void GetDataFromDB()
        {
            //var CS = @"Data Source=.\;Initial Catalog=Connect;Integrated Security=SSPI";// ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from tblTenant; Select * from tblUnit;", con);
                //DataSet ds = new DataSet();
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataSet1 ds1 = new DataSet1();
                ds1.tblTenant.Merge(ds.Tables[0]);
                ds1.tblUnit.Merge(ds.Tables[1]);
            }
        } 
    }
}
