using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtCrawler.Model;

namespace TxtCrawler.Common.Controller.SQL
{
    public class SqlController
    {
        private SqlConnection _connection;
        private string _connectionString = TxtCrawler.Common.Properties.Settings.Default.ConnectionString;

        public SqlController() 
        {
            _connection = new SqlConnection(_connectionString);
        }


        public void InsertLocation(Locatie locatie)
        {
            string insertQuery = "INSERT INTO Locatie(Nume,Description) values(@Nume,@Description)";
            OpenCloseConnection();
            using (var command = new SqlCommand(insertQuery, _connection)) 
            {
                command.Parameters.AddWithValue("@Nume", locatie.Nume);
                command.Parameters.AddWithValue("@Description", locatie.Description);
                command.ExecuteNonQuery();
                OpenCloseConnection();
            }
        }

        private void OpenCloseConnection() 
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            else if (_connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }

        public void InsertOrUpdateLocatie(Locatie locatie)
        {
            try
            {
                if (LocationExists(locatie) > 0)
                {
                    UpdateLocation(locatie);
                }
                else
                    InsertLocation(locatie);
            }
            catch (Exception ex)
            { }
        }

        public void UpdateLocation(Locatie locatie)
        {
            string insertQuery = "Update Locatie Set Description = @Description where Nume=@Nume)";
            OpenCloseConnection();
            using (var command = new SqlCommand(insertQuery, _connection))
            {
                command.Parameters.AddWithValue("@Nume", locatie.Nume);
                command.Parameters.AddWithValue("@Description", locatie.Description);
                command.ExecuteNonQuery();
                OpenCloseConnection();
            }
        }

        private int LocationExists(Locatie locatie)
        {
            var query = "SELECT Count(*) from Locatie where Nume = @Nume";
            OpenCloseConnection();
            using (var command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Nume", locatie.Nume);
                var result = Convert.ToInt32(command.ExecuteScalar());
                OpenCloseConnection();
                return result;
                
            }
        }

        public void InsertOrUpdateUser(User user, string locationID)
        {
            try
            {
                if (UserExists(user) > 0)
                {
                    UpdateUser(user, locationID);
                }
                else
                    InsertUser(user, locationID);
            }
            catch (Exception ex) { }
        }

        public void InsertUser(User user, string locationID)
        {
            string insertQuery = "INSERT INTO SYS_User values(@UserName,@PerioadaSejur,@LocationID)";
            OpenCloseConnection();
            using (var command = new SqlCommand(insertQuery, _connection))
            {
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@PerioadaSejur", user.PerioadaSejur);
                command.Parameters.AddWithValue("@LocationID", locationID);
                command.ExecuteNonQuery();
                OpenCloseConnection();
            }
        }

        public void InsertUserWithoutLocation(User user)
        {
            try
            {
                string insertQuery = "INSERT INTO SYS_User(UserName,PerioadaSejur) values(@UserName,@PerioadaSejur)";
                if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                using (var command = new SqlCommand(insertQuery, _connection))
                {
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@PerioadaSejur", user.PerioadaSejur);
                    command.ExecuteNonQuery();
                    OpenCloseConnection();
                }
            }
            catch(Exception ex){}
        }

        private int UserExists(User user) 
        {
            var query = "SELECT Count(*) FROM SYS_User where UserName = @Username";
            OpenCloseConnection();
            using (var command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@UserName", user.UserName);
                var result = Convert.ToInt32(command.ExecuteScalar());
                OpenCloseConnection();
                return result;
            }
        }

        public void UpdateUser(User user,string locationID)
        {
            string updateQuery = "UPDATE SYS_User SET PerioadaSejur = @PerioadaSejur,LocationID = @LocationID WHERE UserName=@UserName";
            OpenCloseConnection();
            using (var command = new SqlCommand(updateQuery, _connection))
            {
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@PerioadaSejur", user.PerioadaSejur);
                command.Parameters.AddWithValue("@LocationID", locationID);
                command.ExecuteNonQuery();
                OpenCloseConnection();
            }
        }

        public void InsertComment(Comment comment, string userID)
        {
            string insertQuery = "INSERT INTO Comment values(@PositiveComment,@NegativeComment,@UserGrade,@userID)";
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
            using (var command = new SqlCommand(insertQuery, _connection))
            {
                var positiveComment = comment.PositiveComment == null ? string.Empty : comment.PositiveComment;
                var negativeComment = comment.NegativeComment == null ? string.Empty : comment.NegativeComment;
                command.Parameters.AddWithValue("@PositiveComment", positiveComment);
                command.Parameters.AddWithValue("@NegativeComment", negativeComment);
                command.Parameters.AddWithValue("@UserGrade", comment.UserGrade);
                command.Parameters.AddWithValue("@userID", userID);
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
