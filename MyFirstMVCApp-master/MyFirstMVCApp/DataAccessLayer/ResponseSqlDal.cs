using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFirstMVCApp.Web.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCApp.DataAccessLayer
{
    public class ResponseSqlDal : IResponseDAL
    {
        private const string SQL_GetAllLibs = @"Select *
        From Responses;";
        private const string SQL_GetLibById = @"Select *
        From responses
        Where responseId = @id;";
        private const string SQL_CreateLib = @"Insert into Responses
        Values(@name, @inputOne, @inputTwo, @inputThree, @inputFour, @inputFive);";
        
        private string connectionString;

        public ResponseSqlDal()
            : this(ConfigurationManager.ConnectionStrings["CrazyLibsDB"].ConnectionString)
        {

        }

        public ResponseSqlDal(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public List<Libs> GetAllLibs()
        {
            List<Libs> output = new List<Libs>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllLibs, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Libs l = new Libs();
                        l.responseId = Convert.ToInt32(reader["responseId"]);
                        l.Name = Convert.ToString(reader["name"]);
                        l.InputOne = Convert.ToString(reader["inputOne"]);
                        l.InputTwo = Convert.ToString(reader["inputTwo"]);
                        l.InputThree = Convert.ToString(reader["inputThree"]);
                        l.InputFour = Convert.ToString(reader["inputFour"]);
                        l.InputFive = Convert.ToString(reader["inputFive"]);

                        output.Add(l);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;
        }
        public Libs GetLibById(int id)
        {
            Libs output = new Libs();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetLibById, connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Libs l = new Libs();
                        l.responseId = Convert.ToInt32(reader["responseId"]);
                        l.Name = Convert.ToString(reader["name"]);
                        l.InputOne = Convert.ToString(reader["inputOne"]);
                        l.InputTwo = Convert.ToString(reader["inputTwo"]);
                        l.InputThree = Convert.ToString(reader["inputThree"]);
                        l.InputFour = Convert.ToString(reader["inputFour"]);
                        l.InputFive = Convert.ToString(reader["inputFive"]);

                        output = l;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;
        }
        public bool CreateLib(Libs newProject)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_CreateLib, conn);
                    cmd.Parameters.AddWithValue("@name", newProject.Name);
                    cmd.Parameters.AddWithValue("@inputOne", newProject.InputOne);
                    cmd.Parameters.AddWithValue("@inputTwo", newProject.InputTwo);
                    cmd.Parameters.AddWithValue("@inputThree", newProject.InputThree);
                    cmd.Parameters.AddWithValue("@inputFour", newProject.InputFour);
                    cmd.Parameters.AddWithValue("@inputFive", newProject.InputFive);

                    int result = cmd.ExecuteNonQuery();

                    return result > 0;
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
        }
    }
}