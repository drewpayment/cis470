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
        /**
         * Gets the connection string for database
         * 
         * @var string
         * @return string
         */
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            }
        }

                 
        
    }
}