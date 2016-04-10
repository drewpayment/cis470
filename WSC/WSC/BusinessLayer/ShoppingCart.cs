using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace WSC.BusinessLayer
{
    public class ShoppingCart
    {
        /**
         * Set mediaID
         * 
         * @var string
         */
        public string mediaID;

        /**
         * Set mediaType
         * 
         * @var string
         */
        public string mediaType;

        /**
         * Set price in shopping cart
         * 
         * @var double
         */
        public double price;

        /**
         * Set quantity for cart
         * 
         * @var int
         */
        public int quantity;

       

       
    }
}