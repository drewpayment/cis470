/*
Module Name: Quality Assurance  
Program Name: WSC eCommerce
Author: Rebecca Kolb
CoAuthor: Sarah Barreca
Date: 3/28/16 - 4/15/16
Purpose: This form is used by employees of WSC to perform and track QA tests on printing and engraving jobs. 
System Functions & Processes: 
	Page_Load: initializes page components & displays links
	btnSubmitQA_Click: gets the user input and saves it to the Quality Assurance table in the database. 		

Change Log:	4/2/16 Page creation and design completed 
		4/9/12 Processes and functions completed 	
*/
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC
{
    public partial class QualityAssurance : System.Web.UI.Page
    {

        /**
          * Set connection string
          * 
          * @var string
          */
        //creating mySQL connection string below
        string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /**
         * Quality assurance form button event code
         * 
         * @param object, EventArgs
         * @var string
         * @return void
         */
        protected void btnSubmitQA_Click(object sender, EventArgs e)
        {
            string orderID = txtQAOrderID.Text;//grabs text from the orderID text box
            string jobID = txtQAJobID.Text;//grabs text from the job id text box
            string QAEmpID = txtQAEmpID.Text;//grabs text from the quality assurance inspecting employee text box
            string SpecialistID = txtQASpecialID.Text;//grabs text from the specialist ID text box
            string QAID = txtQAID.Text;//grabs text from the grabs the QA number text box
            string QANotes = txtQANotes.Text;//grabs text from the description text box
            string QAStatus = rblQAStatus.SelectedValue;//grabs text from the status radio buttons

            //creating two strings to hold the SQL insert statements for the two tables we will be using in this form
            string query = "INSERT INTO purchase_item(orderID,jobID,specialistID, qualityAssuranceID)" + "Values(' " + orderID + " ', ' " + jobID + " ' , ' " + SpecialistID + "' , ' " + QAID + " ' )";
            string Query = "INSERT INTO quality_assurance(QAEmpID,QADescription,QAStatus)" + "Values(' " + QAEmpID + " ' , ' " + QANotes + " ' , ' " + QAStatus + " ')";

            using (MySqlConnection myConn = new MySqlConnection(myConnection))
            {
                using (MySqlCommand command = new MySqlCommand(query, myConn))
                {
                    myConn.Open();//opening the SQL connection
                    command.CommandText ="INSERT INTO purchase_item(orderID,jobID,specialistID, qualityAssuranceID)" + "Values(' " + orderID + " ', ' " + jobID + " ' , ' " + SpecialistID + "' , ' " + QAID + " ' )";
                    //creating the insert command above and executing it below on the next line
                    command.ExecuteNonQuery();
                    myConn.Close();//closing the connection
                }
                using (MySqlCommand Command = new MySqlCommand(Query,myConn))
                {
                    myConn.Open();//opening the SQL connection
                    Command.CommandText = "INSERT INTO quality_assurance(QAEmpID,QADescription,QAStatus)" + "Values(' " + QAEmpID + " ' , ' " + QANotes + " ' , ' " + QAStatus + " ')";
                    //creating the insert command above and executing it below on the next line
                    Command.ExecuteNonQuery();
                    myConn.Close();//closing the connection
                } 
                
            
            }
        }
    }
}