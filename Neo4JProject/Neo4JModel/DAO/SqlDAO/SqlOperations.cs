using Neo4JModel.BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.DAO.SqlDAO
{
    public class SqlOperations
    {
        private SqlConnection _connection ;
        private string _connectionString
        {
            get { return Neo4JModel.Properties.Settings.Default.ConnectionString; }
        }

        public SqlOperations() 
        {
            _connection = new SqlConnection(_connectionString);
        }

        public List<Locatie> GetAllLocations() 
        {
            try
            {
                _connection.Open();
                var locationList = new List<Locatie>();
                using (var command = new SqlCommand(SqlConstants.GET_ALL_LOCATIONS_QUERY, _connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            var location = new Locatie();
                            location.Nume = reader[SqlConstants.LOCATION_NAME_COLUMN].ToString();
                            location.Description = reader[SqlConstants.LOCATION_DESCRIPTION_COLUMN].ToString();
                            locationList.Add(location);
                        }
                    }
                    reader.Close();
                    _connection.Close();
                }
                return locationList;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public List<Locatie> GetAllLocationsThatStartsWith(string name)
        {
            try
            {
                _connection.Open();
                var locationList = new List<Locatie>();
                using (var command = new SqlCommand(SqlConstants.GET_ALL_LOCATIONS_THAT_START_WITH_QUERY, _connection))
                {
                    command.Parameters.Add(SqlConstants.LOCATION_NAME_PARAMETER,name+"%");

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            var location = new Locatie();
                            location.Nume = reader[SqlConstants.LOCATION_NAME_COLUMN].ToString();
                            location.Description = reader[SqlConstants.LOCATION_DESCRIPTION_COLUMN].ToString();
                            locationList.Add(location);
                        }
                    }
                    reader.Close();
                    _connection.Close();
                }
                return locationList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                _connection.Open();
                var userList = new List<User>();
                using (var command = new SqlCommand(SqlConstants.GET_ALL_USERS_QUERY, _connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            var user = new User();
                            user.UserName = reader[SqlConstants.USER_NAME_COLUMN].ToString();
                            user.PerioadaSejur = reader[SqlConstants.USER_PERIOD_COLUMN].ToString();
                            userList.Add(user);
                        }
                    }
                    reader.Close();
                    _connection.Close();
                }
                return userList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<User> GetAllUsersWhereNamesStartsWith(string name)
        {
            try
            {
                _connection.Open();
                var userList = new List<User>();
                using (var command = new SqlCommand(SqlConstants.GET_USER_WHERE_NAME_STARTS_WITH_QUERY, _connection))
                {
                    command.Parameters.Add(SqlConstants.USER_NAME_PARAMETER,name+"%");

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            var user = new User();
                            user.UserName = reader[SqlConstants.USER_NAME_COLUMN].ToString();
                            user.PerioadaSejur = reader[SqlConstants.USER_PERIOD_COLUMN].ToString();
                            userList.Add(user);
                        }
                    }
                    reader.Close();
                    _connection.Close();
                }
                return userList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Comment> GetAllComments()
        {
            try
            {
                _connection.Open();
                var commentList = new List<Comment>();
                using (var command = new SqlCommand(SqlConstants.GET_ALL_COMMENTS_QUERY, _connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            var comment = new Comment();
                            comment.PositiveComment = reader[SqlConstants.COMMENT_POSITIVE_COMMENT_COLUMN].ToString();
                            comment.NegativeComment = reader[SqlConstants.COMMENT_NEGATIVE_COMMENT_COLUMN].ToString();
                            comment.UserGrade = Convert.ToDecimal(reader[SqlConstants.COMMENT_USER_GRADE_COLUMN].ToString());
                            commentList.Add(comment);
                        }
                    }
                    reader.Close();
                    _connection.Close();
                }
                return commentList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public float GetUserGradesAvarage()
        {
            try
            {
                _connection.Open();
                using (var command = new SqlCommand(SqlConstants.GET_USER_GRADES_AVARAGE_QUERY, _connection))
                {
                    _connection.Close();
                    return (float)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<User> GetAllUsersForLocation(Locatie location)
        {
            var usersList = new List<User>();
            try
            {
                _connection.Open();
                using (var command = new SqlCommand(SqlConstants.GET_ALL_USER_FOR_LOCATION_QUERY, _connection))
                {
                    command.Parameters.Add(SqlConstants.LOCATION_NAME_PARAMETER,location.Nume);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            var user = new User();
                            user.UserName = reader[SqlConstants.USER_NAME_COLUMN].ToString();
                            user.PerioadaSejur = reader[SqlConstants.USER_PERIOD_COLUMN].ToString();
                            usersList.Add(user);
                        }
                    }
                    _connection.Close();
                    return usersList;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Comment> GetAllCommentsForUser(User user)
        {
            try
            {
                _connection.Open();
                var commentList = new List<Comment>();
                using (var command = new SqlCommand(SqlConstants.GET_ALL_COMMENTS_FOR_USER_QUERY, _connection))
                {
                    command.Parameters.Add(SqlConstants.USER_NAME_PARAMETER,user.UserName);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            var comment = new Comment();
                            comment.PositiveComment = reader[SqlConstants.COMMENT_POSITIVE_COMMENT_COLUMN].ToString();
                            comment.NegativeComment = reader[SqlConstants.COMMENT_NEGATIVE_COMMENT_COLUMN].ToString();
                            comment.UserGrade = Convert.ToDecimal(reader[SqlConstants.COMMENT_USER_GRADE_COLUMN].ToString());
                            commentList.Add(comment);
                        }
                    }
                    reader.Close();
                    _connection.Close();
                }
                return commentList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Comment> GetAllCommentsWithPositiveReviews()
        {
            try
            {
                _connection.Open();
                var commentList = new List<Comment>();
                using (var command = new SqlCommand(SqlConstants.GET_ALL_COMMENTS_WITH_POSITIVE_FEEDBACK_QUERY, _connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            var comment = new Comment();
                            comment.PositiveComment = reader[SqlConstants.COMMENT_POSITIVE_COMMENT_COLUMN].ToString();
                            comment.NegativeComment = reader[SqlConstants.COMMENT_NEGATIVE_COMMENT_COLUMN].ToString();
                            comment.UserGrade = Convert.ToDecimal(reader[SqlConstants.COMMENT_USER_GRADE_COLUMN].ToString());
                            commentList.Add(comment);
                        }
                    }
                    reader.Close();
                    _connection.Close();
                }
                return commentList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Comment> GetAllCommentsWithNegativeReviews()
        {
            try
            {
                _connection.Open();
                var commentList = new List<Comment>();
                using (var command = new SqlCommand(SqlConstants.GET_ALL_COMMENTS_WITH_NEGATIVE_FEEDBACK_QUERY, _connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            var comment = new Comment();
                            comment.PositiveComment = reader[SqlConstants.COMMENT_POSITIVE_COMMENT_COLUMN].ToString();
                            comment.NegativeComment = reader[SqlConstants.COMMENT_NEGATIVE_COMMENT_COLUMN].ToString();
                            comment.UserGrade = Convert.ToDecimal(reader[SqlConstants.COMMENT_USER_GRADE_COLUMN].ToString());
                            commentList.Add(comment);
                        }
                    }
                    reader.Close();
                    _connection.Close();
                }
                return commentList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Locatie> GetAllLocationsWithMoreThanTenPositiveComments() 
        {
            try
            {
                _connection.Open();
                var locationList = new List<Locatie>();
                using (var command = new SqlCommand(SqlConstants.GET_LOCATIONS_WITH_MORE_THAN_TEN_POSITIVE_COMMENTS, _connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            var location = new Locatie();
                            location.Nume = reader[SqlConstants.LOCATION_NAME_COLUMN].ToString();
                            locationList.Add(location);
                        }
                    }
                    reader.Close();
                    _connection.Close();
                }
                return locationList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Locatie> GetAllLocationsWithMoreThanTenNegativeComments()
        {
            try
            {
                _connection.Open();
                var locationList = new List<Locatie>();
                using (var command = new SqlCommand(SqlConstants.GET_LOCATIONS_WITH_MORE_THAN_TEN_NEGATIVE_COMMENTS, _connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            var location = new Locatie();
                            location.Nume = reader[SqlConstants.LOCATION_NAME_COLUMN].ToString();
                            locationList.Add(location);
                        }
                    }
                    reader.Close();
                    _connection.Close();
                }
                return locationList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
