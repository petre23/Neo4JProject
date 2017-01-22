using Neo4JModel.BO;
using Neo4JModel.DAO.SqlDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JController.Controllers
{
    public class SqlDataController : IDisposable
    {
        public SqlDataController()
        {
        }

        public List<Locatie> GetAllLocations()
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetAllLocations();
                }
            }
            catch (Exception ex) 
            {
                return new List<Locatie>();
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetAllUsers();
                }
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        public List<Comment> GetAllComments()
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetAllComments();
                }
            }
            catch (Exception ex)
            {
                return new List<Comment>();
            }
        }

        public List<Locatie> GetAllLocationsWherNameStartsWith(string nameStart)
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetAllLocationsThatStartsWith(nameStart);
                }
            }
            catch (Exception ex)
            {
                return new List<Locatie>();
            }
        }

        public List<Locatie> GetAllLocationsWithMoreThanTenPositiveComments() 
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetAllLocationsWithMoreThanTenPositiveComments();
                }
            }
            catch (Exception ex)
            {
                return new List<Locatie>();
            }
        }

        public List<Locatie> GetAllLocationsWithMoreThanTenNegativeComments()
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetAllLocationsWithMoreThanTenNegativeComments();
                }
            }
            catch (Exception ex)
            {
                return new List<Locatie>();
            }
        }

        public List<User> GetAllUsersWhereNameStartsWith(string nameStart)
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetAllUsersWhereNamesStartsWith(nameStart);
                }
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        public List<User> GetAllUsersForLocation(Locatie location)
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetAllUsersForLocation(location);
                }
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        public List<Comment> GetAllCommentsForUser(User user)
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetAllCommentsForUser(user);
                }
            }
            catch (Exception ex)
            {
                return new List<Comment>();
            }
        }

        public List<Comment> GetAllPositiveComments()
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetAllCommentsWithPositiveReviews();
                }
            }
            catch (Exception ex)
            {
                return new List<Comment>();
            }
        }

        public List<Comment> GetAllNegativeComments()
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetAllCommentsWithNegativeReviews();
                }
            }
            catch (Exception ex)
            {
                return new List<Comment>();
            }
        }

        public float GetUsersAvarageGrade()
        {
            try
            {
                using (var sqlOperations = new SqlOperations())
                {
                    return sqlOperations.GetUserGradesAvarage();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Dispose()
        {

        }
    }
}
