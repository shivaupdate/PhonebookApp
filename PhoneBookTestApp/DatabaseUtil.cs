using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class DatabaseUtil
    {
        static readonly string _connectionString = "Data Source= MyDatabase.sqlite;Version=3;";
        public static void initializeDatabase()
        {
            var dbConnection = new SQLiteConnection(_connectionString);
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                   new SQLiteCommand(
                       "SELECT name FROM sqlite_master WHERE type='table' AND name='PHONEBOOK';",
                       dbConnection);
                var tableExist = command.ExecuteScalar() != null;
                if (!tableExist)
                {

                    command =
                         new SQLiteCommand(
                             "create table PHONEBOOK (NAME varchar(255), PHONENUMBER varchar(255), ADDRESS varchar(255))",
                             dbConnection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        /// <summary>
        /// Save New contacts to DB
        /// </summary>
        /// <param name="objPersonlist"> List of contacts to save in DB</param>
        public static void Savecontacts(IList<Person> objPersonlist)
        {
            var dbConnection = new SQLiteConnection(_connectionString);
            dbConnection.Open();

            try
            {
                foreach (var item in objPersonlist)
                {
                    SQLiteCommand cmd = dbConnection.CreateCommand();
                    cmd.CommandText = "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES(@name, @phonenumber,@address)";
                    cmd.Parameters.Add("@name", DbType.String).Value = item.name;
                    cmd.Parameters.Add("@phonenumber", DbType.String).Value = item.phoneNumber;
                    cmd.Parameters.Add("@address", DbType.String).Value = item.address;
                    cmd.ExecuteNonQuery();
                }
                



            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static SQLiteConnection GetConnection()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            return dbConnection;
        }

        public static void CleanUp()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(
                        "DROP table PHONEBOOK",
                        dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}