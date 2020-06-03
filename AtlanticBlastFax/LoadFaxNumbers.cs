using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AtlanticBlastFax
{
    class LoadFaxNumbers
    {
        private SqlConnection connection;
        //private string sConnectionString;
        private string server;
        private string database;
        private string uid;
        private string password;
        public List<PhoneNumbers> faxNumbers = new List<PhoneNumbers>();
        public LoadFaxNumbers(string Comp)
        {
            if (ConnectToDatabase() == 1)
            {
                //faxNumbers = new List<PhoneNumbers>();
                // this is from pmas
                string sql = "SELECT FAX FROM  CUSTOMER AS c," +
                              "[dbo].[COMPANY_CUSTOMERS]  cc " +
                              $" WHERE   cc.company_id = '{Comp}' " +
                              " and c.customer_id = cc.Customer_id " +
                              "and(LEN(c.FAX) = 10) " +
                              "and cc.mas_customer_no is not null ";


                using (var cmd = new SqlCommand(sql, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Get ordinal from the customers table
                    int faxOrdinal = reader.GetOrdinal("Fax");

                    while (reader.Read())
                    {
                        var fax = new PhoneNumbers();
                        fax.PhoneNumber = reader.GetString(faxOrdinal);

                        faxNumbers.Add(fax);
                    }
                }
            }

        }
        private void Initialize()
        {
            try
            {
                server = "Xensql3";
                database = "atlanticbio";
                uid = "PMCALL";
                password = "AbcPowermas@!";

                string connectionstring;
                connectionstring = "SERVER=" + server + ";" + "Database=" + database + ";" +
                    "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new SqlConnection(connectionstring);

                //OpenConnection();
            }
            catch (Exception ex)
            {
                throw ex;
                // ClsPMSystem.AddToFile("ms sql " + ex.Message);

            }

        }



        public int ConnectToDatabase()
        {
            try
            {
                Initialize();
            }
            catch (Exception ex)
            {
                return -1;

                throw ex;

            }
            try
            {
                //ClsPMSystem.AddToFile("opening  Connection MSSQL");
                connection.Open();
                //   ClsPMSystem.AddToFile("opened Connection MSSQL");

            }
            catch (Exception ex)

            {
                throw ex;
                //ClsPMSystem.AddToFile("ms sql " + ex.Message + connection.ConnectionString);
                //return -1;
            }


            return 1;
        }




    }
    public class PhoneNumbers
    {
        public string PhoneNumber { get; set; }



    }


}
