using Neo4JModel.BO;
using Neo4JModel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JController.Controllers
{
    public class Neo4JDataController
    {
        LocatieDAO _locatieDAO;
        UserDAO _userDAO;
        CommentDAO _commentDAO;
        CameraDAO _roomDAO;
        CommentUserDAO _commentUserDAO;
        LocationUserDAO _locationUserDAO;

        public Neo4JDataController()
        {
            InitLocals();
        }

        private void InitLocals()
        {
            _locatieDAO = new LocatieDAO();
            _userDAO = new UserDAO();
            _commentDAO = new CommentDAO();
            _roomDAO = new CameraDAO();
            _commentUserDAO = new CommentUserDAO();
            _locationUserDAO = new LocationUserDAO();
        }

        public List<Locatie> GetAllLocations()
        {
            return _locatieDAO.GetAllLocationsFromDB();
        }

        public List<User> GetAllUsers() 
        {
            return _userDAO.GetAllUsersFromDB();
        }

        public List<Comment> GetAllComments() 
        {
            return _commentDAO.GetAllCommetsFromDB();
        }

        public List<Camera> GetAllRooms() 
        {
            return _roomDAO.GetAllRoomsFromDB();
        }

        public List<Locatie> GetAllLocationsWherNameStartsWith(string nameStart) 
        {
            return _locatieDAO.GetLocationThatStartsWith(nameStart);
        }

        public List<User> GetAllUsersWhereNameStartsWith(string nameStart) 
        {
            return _userDAO.GetUserWhereNameStartsWith(nameStart);
        }

        public List<User> GetAllUsersForLocation(Locatie location) 
        {
            return _locationUserDAO.GetUserForLocationWithName(location.Nume);
        }

        public List<Comment> GetAllCommentsForUser(User user) 
        {
            return _commentUserDAO.GetCommentsForUser(user);
        }

        public List<User> GetAllUsersForLocationWhereNameStartsWith(Locatie location) 
        {
            return _locationUserDAO.GetUserForLocationWithName(location.Nume);
        }

        public List<Comment> GetAllPositiveComments() 
        {
            return _commentDAO.GetAllPositiveComments();
        }

        public List<Comment> GetAllNegativeComments()
        {
            return _commentDAO.GetAllNegativeComments();
        }

        public float GetUsersAvarageGrade() 
        {
            return _commentDAO.GetAvarageUserGrades();
        }

        public List<Locatie> GetLocationsWhereDescriptionContains(string descriptionWord)
        {
            return _locatieDAO.GetLocationWhereDescriptionContains(descriptionWord);          
        }

        public List<Locatie> GetAllLocationsWithMoreThanTenPositiveComments() 
        {
            return _locationUserDAO.GetLocationsThatHaveTenPositiveComments();
        }

        public List<Locatie> GetAllLocationsWithMoreThanTenNegativeComments()
        {
            return _locationUserDAO.GetLocationsThatHaveTenNegativeComments();
        }
    }
}
