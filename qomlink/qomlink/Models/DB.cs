using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace userCall.Models
{
    class DB
    {
        private static string filename = "connectionfielduserconnectedtointernet";
        public static bool savefile(string data)
        {
            try
            {
                using (var fs = new FileStream(filename + ".data", FileMode.OpenOrCreate))
                {
                    using (TextWriter tw = new StreamWriter(fs))
                    {
                        tw.WriteLine(data);
                        // Flush the writer in order to get a correct stream position for truncating
                        tw.Flush();
                        // Set the stream length to the current position in order to truncate leftover text
                        fs.SetLength(fs.Position);
                    }

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string readfile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename + ".data"))
                {
                    // Read the stream to a string.
                    string line = sr.ReadToEnd();
                    return line;
                }
            }
            catch (Exception)
            {
                //console.log(string.Format("The file could not be read:{0}", e.Message));
                return null;
            }
        }
        public static bool makesqldb()
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "CREATE DATABASE MyDatabase ON PRIMARY " +
                "(NAME = MyDatabase_Data, " +
                "FILENAME = 'C:\\MyDatabaseData.mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = MyDatabase_Log, " +
                "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                console.log("DataBase is Created Successfully");
                //MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                console.log(ex.ToString());
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            return true;
        }
    }
}
