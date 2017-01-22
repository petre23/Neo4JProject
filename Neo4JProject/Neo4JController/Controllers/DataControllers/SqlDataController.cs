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
        SqlOperations _sqlOperations;

        public SqlDataController()
        {
            _sqlOperations = new SqlOperations();
        }

        public List<Locatie> GetAllLocations()
        {
            return _sqlOperations.GetAllLocations();
        }

        public List<User> GetAllUsers()
        {
            return _sqlOperations.GetAllUsers();
        }

        public List<Comment> GetAllComments()
        {
            return _sqlOperations.GetAllComments();
        }

        public List<Locatie> GetAllLocationsWherNameStartsWith(string nameStart)
        {
            return _sqlOperations.GetAllLocationsThatStartsWith(nameStart);
        }

        public List<Locatie> GetAllLocationsWithMoreThanTenPositiveComments()
        {
            return _sqlOperations.GetAllLocationsWithMoreThanTenPositiveComments();
        }

        public List<Locatie> GetAllLocationsWithMoreThanTenNegativeComments()
        {
            return _sqlOperations.GetAllLocationsWithMoreThanTenNegativeComments();
        }

        public List<User> GetAllUsersWhereNameStartsWith(string nameStart)
        {
            return _sqlOperations.GetAllUsersWhereNamesStartsWith(nameStart);
        }

        public List<User> GetAllUsersForLocation(Locatie location)
        {
            return _sqlOperations.GetAllUsersForLocation(location);
        }

        public List<Comment> GetAllCommentsForUser(User user)
        {
            return _sqlOperations.GetAllCommentsForUser(user);
        }

        public List<Comment> GetAllPositiveComments()
        {
            return _sqlOperations.GetAllCommentsWithPositiveReviews();
        }

        public List<Comment> GetAllNegativeComments()
        {
            return _sqlOperations.GetAllCommentsWithNegativeReviews();
        }

        public float GetUsersAvarageGrade()
        {
            return _sqlOperations.GetUserGradesAvarage();
        }

        public void Dispose()
        {
            _sqlOperations.Dispose();
        }
    }
}
