using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCDemoApplication.Models
{
    public class PropertyMaster
    {
        [Required(ErrorMessage = "Please enter Property Name")] 
        public string PropertyName {get;set;}

        [Required(ErrorMessage = "Please enter Property Description")] 
        public string PropertyDescription { get; set; }


        public static List<PropertyMaster> GetList(string sorton="", string sortdirection="")
        {
             List<PropertyMaster> _PropertyList = new List<PropertyMaster>();
            string connectionString = ConfigurationManager.ConnectionStrings["DemoMVC_DB"].ConnectionString; ;// "Persist Security Info=False;User ID=sa;Password=sa@123;Initial Catalog=MVCDemoDB;Server=Bilal-PC";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                string sQuery = "Select PropertyName, PropertyDescription From PropertyMaster Order By LastModifiedDateTime Desc";
                if (sorton.Length > 0 && sortdirection.Length > 0)
                {
                    sQuery = "Select PropertyName, PropertyDescription From PropertyMaster Order By " + sorton + " " + sortdirection;
                }
                cmd.CommandText = sQuery;
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader myDataReader;
                myDataReader = cmd.ExecuteReader();
                if (myDataReader.HasRows)
                {
                    while (myDataReader.Read())
                    {
                        PropertyMaster obj = new PropertyMaster();
                        obj.PropertyName = myDataReader["PropertyName"].ToString();
                        obj.PropertyDescription = myDataReader["PropertyDescription"].ToString();
                        _PropertyList.Add(obj);
                    }
                }
            }

           
            return _PropertyList;
       }

        public bool AddData(PropertyMaster objPropertyMaster)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DemoMVC_DB"].ConnectionString; ;// "Persist Security Info=False;User ID=sa;Password=sa@123;Initial Catalog=MVCDemoDB;Server=Bilal-PC";

          
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "INSERT INTO PropertyMaster (PropertyName, PropertyDescription) VALUES ('" + objPropertyMaster.PropertyName + "','" + objPropertyMaster.PropertyDescription + "')";
               
                cmd.Connection = connection;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        
    }
}