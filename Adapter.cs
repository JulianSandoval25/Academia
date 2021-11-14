using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        //string conection = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;

        protected void OpenConnection()
        {
            string conection = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn = new SqlConnection(conection);
            sqlConn.Open();
            //Console.WriteLine(conection);
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }

        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";

        /*public SqlConnection _sqlConn;
        public SqlConnection SqlConn
        {
            get { return _sqlConn}
        }*/
        public SqlConnection sqlConn { get; set; }
        //SqlConnection sqlConn = new SqlConnection();
    }
}
