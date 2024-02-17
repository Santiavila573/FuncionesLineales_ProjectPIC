using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace AppFuncionesLineales.Capa__acceso
{
    public class DataAccess
    {   //Microsoft.ACE.OLEDB.10.0
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\bdFunciones.accdb";
        //Provider=Microsoft.Mashup.OleDb.1;Data Source=$Workbook$;Location=Funciones;Extended Properties=""


        //private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;User ID = Admin; Data Source = C:\Users\santi\OneDrive\Documentos\Casos de estudio\AppFuncionesLineales\AppFuncionesLineales\bin\Debug\bdFunciones.accdb;Mode=ReadWrite;Extended Properties = ""; Jet OLEDB:System database = ""; Jet OLEDB:Registry Path = ""; Jet OLEDB:Engine Type = 6; Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops = 2; Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database = False; Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False;Jet OLEDB:Support Complex Data=False;Jet OLEDB:Bypass UserInfo Validation=False;Jet OLEDB:Limited DB Caching=False;Jet OLEDB:Bypass ChoiceField Validation=False";
        public Form_Login Form_Login
        {
            get => default;
            set
            {
            }
        }

        public Form_Funciones Form_Funciones
        {
            get => default;
            set
            {
            }
        }

        public void GuardarFuncion(double A, double B, double C, List<(double, double)> puntos)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string insertFuncionQuery = "INSERT INTO Funciones (Usuario,A, B, C) VALUES ('Admin',@A, @B, @C)";
                using (OleDbCommand insertFuncionCommand = new OleDbCommand(insertFuncionQuery, connection))
                {
                    insertFuncionCommand.Parameters.AddWithValue("@A", A);
                    insertFuncionCommand.Parameters.AddWithValue("@B", B);
                    insertFuncionCommand.Parameters.AddWithValue("@C", C);
                    insertFuncionCommand.ExecuteNonQuery();
                }

                long funcionID = ObtenerUltimoID(connection);

                //string insertPuntoQuery = "INSERT INTO Puntos (FuncionID, X, Y) VALUES (@FuncionID, @X, @Y)";

                int c = 1;
                string insertPuntoQuery;
                foreach (var punto in puntos)
                {
                    if (c == 1)
                    {
                         insertPuntoQuery = "UPDATE Funciones SET [Punto 1]='"  + "[" + Math.Round(punto.Item1,2).ToString().Replace(',', '.') + "," + Math.Round(punto.Item2,2).ToString().Replace(',', '.') +  "]' WHERE Id=" + funcionID;
                    }
                    else
                    {
                         insertPuntoQuery = "UPDATE Funciones SET [Punto 2]='" + "[" + Math.Round(punto.Item1,2).ToString().Replace(',','.') + "," + Math.Round(punto.Item2,2).ToString().Replace(',', '.') + "]' WHERE Id=" + funcionID;
                    }

                    OleDbCommand insertPuntoCommand = new OleDbCommand(insertPuntoQuery, connection);
                    insertPuntoCommand.ExecuteNonQuery();
                    c ++;
                }
            }
        }

        private long ObtenerUltimoID(OleDbConnection connection)
        {
            string query = "SELECT MAX(ID) FROM Funciones";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                if (result == DBNull.Value)
                {
                    return 0;
                }
                return Convert.ToInt64(result);
            }
        }

        public bool ValidarUsuario(string usuario, string contraseña)
        {
            string query = "SELECT Usuario, [Contraseña] FROM Usuarios WHERE Usuario = @Usuario AND [Contraseña] = @Contraseña";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Añadir parámetros
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    object result = command.ExecuteScalar();
                    // Comprobar si el resultado es nulo
                    return result != null;
                }
            }
        }

        public void EliminarFuncion(int ID)
        {

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE * FROM Funciones WHERE Id=" + ID;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

        }

        public DataTable ObtenerDatos()
        {
            DataTable dataTable = new DataTable();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Funciones";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
    }
}
