using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace WSC
{
    public class ClsDataLayer
    {
        //Method to get the connectionstring
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            }
        }

                 
        
    }
}