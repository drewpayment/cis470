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
            string orderID = txtQAOrderID.Text;
            string jobID = txtQAJobID.Text;
            string QAEmpID = txtQAEmpID.Text;
            string SpecialistID = txtQASpecialID.Text;
            string QAID = txtQAID.Text;
            string QANotes = txtQANotes.Text;
            string QAStatus = rblQAStatus.SelectedValue;

            string query = "INSERT INTO purchase_item(orderID,jobID,specialistID, qualityAssuranceID)" + "Values(' " + orderID + " ', ' " + jobID + " ' , ' " + SpecialistID + "' , ' " + QAID + " ' )";
            string Query = "INSERT INTO quality_assurance(QAEmpID,QADescription,QAStatus)" + "Values(' " + QAEmpID + " ' , ' " + QANotes + " ' , ' " + QAStatus + " ')";

            using (MySqlConnection myConn = new MySqlConnection(myConnection))
            {
                using (MySqlCommand command = new MySqlCommand(query, myConn))
                {    myConn.Open();
                    command.CommandText ="INSERT INTO purchase_item(orderID,jobID,specialistID, qualityAssuranceID)" + "Values(' " + orderID + " ', ' " + jobID + " ' , ' " + SpecialistID + "' , ' " + QAID + " ' )";
                    command.ExecuteNonQuery();
                    myConn.Close();
                }
                using (MySqlCommand Command = new MySqlCommand(Query,myConn))
                {
                    myConn.Open();
                    Command.CommandText = "INSERT INTO quality_assurance(QAEmpID,QADescription,QAStatus)" + "Values(' " + QAEmpID + " ' , ' " + QANotes + " ' , ' " + QAStatus + " ')";
                    Command.ExecuteNonQuery();
                    myConn.Close();
                } 
                
            
            }
        }
    }
}