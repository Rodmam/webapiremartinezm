using adventureworksEntities;
using adventureworksEntities.Runtime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventureworksDOL
{
    public class AddressTypeDOL
    {
        public static List<AddressType> Get(int id)
        {
            DataTable dt = new DataTable();
            using(var con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["AdventureWorksAPI"].ConnectionString))
            {
                using(var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Person.GetAddressType_SP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ADDRESS_ID", id);
                    using(var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);    
                    }
                }
            }
            var addressTypeResult = from item in dt.AsEnumerable()
                                    select new AddressType
                                    {
                                        AddressTypeID = Convert.ToInt32(item["AddressTypeID"]),
                                        Name = Convert.ToString(item["Name"]),
                                        rowguid = new Guid(Convert.ToString(item["rowguid"])),
                                        ModifiedDate = Convert.ToDateTime(item["ModifiedDate"])
                                    };
            return addressTypeResult.ToList();
        }//Get end

        public static Results Insert(AddressType addressType)
        {
            Results rs = new Results();
            try
            {
                using (var con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["AdventureWorksAPI"].ConnectionString))
                {
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "Person.PostAddressType_SP";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ADDRESS_NAME", addressType.Name);
                        cmd.ExecuteNonQuery(); 
                    }
                }
            }
            catch (Exception ex)
            {

                rs.Message = ex.Message;
            }
            return rs;
        }//end Insert

        public static Results Update(AddressType addressType)
        {
            Results rs = new Results();
            try
            {
                using (var con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["AdventureWorksAPI"].ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "Person.PutAddressType";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AddressID", addressType.AddressTypeID);
                        cmd.Parameters.AddWithValue("AddressName", addressType.Name);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                rs.Message = ex.Message;
            }
            return rs;
        }//end Update

        public static Results Delete(int id)
        {
            Results rs = new Results();
            try
            {
                using (var con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["AdventureWorksAPI"].ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "Person.DeleteAddressType";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@@AddressTypeID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                rs.Message = ex.Message;
            }
            return rs;
        }//end Delete
    }
}
