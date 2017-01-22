using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neo4JController.Controllers;

namespace Neo4J.UnitTest
{
    [TestClass]
    public class SQLControllerShould
    {

        [TestMethod]
        public void ReturnAllLocations()
        {
            using (var sqlDataController = new SqlDataController())
            {
                var locations = sqlDataController.GetAllLocations();
                Assert.IsNotNull(locations);
            }
        }

        [TestMethod]
        public void ReturnAllComments()
        {
            using (var sqlDataController = new SqlDataController())
            {
                var comments = sqlDataController.GetAllComments();
                Assert.IsNotNull(comments);
            }
        }

        [TestMethod]
        public void ReturnAllUsers()
        {
            using (var sqlDataController = new SqlDataController())
            {
                var user = sqlDataController.GetAllUsers();
                Assert.IsNotNull(user);
            }
        }

        [TestMethod]
        public void ReturnAllNegativeComments()
        {
            using (var sqlDataController = new SqlDataController())
            {
                var comments = sqlDataController.GetAllNegativeComments();
                Assert.IsNotNull(comments);
            }
        }

        [TestMethod]
        public void ReturnAllPositiveComments()
        {
            using (var sqlDataController = new SqlDataController())
            {
                var comments = sqlDataController.GetAllPositiveComments();
                Assert.IsNotNull(comments);
            }
        }
    }
}
