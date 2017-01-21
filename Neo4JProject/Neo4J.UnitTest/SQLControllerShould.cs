using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neo4JController.Controllers;

namespace Neo4J.UnitTest
{
    [TestClass]
    public class SQLControllerShould
    {
        private SqlDataController _controller = new SqlDataController();

        [TestMethod]
        public void ReturnAllLocations()
        {
            var locations = _controller.GetAllLocations();
            Assert.IsNotNull(locations);
        }

        [TestMethod]
        public void ReturnAllComments()
        {
            var comments = _controller.GetAllComments();
            Assert.IsNotNull(comments);
        }

        [TestMethod]
        public void ReturnAllUsers()
        {
            var user = _controller.GetAllUsers();
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void ReturnAllNegativeComments()
        {
            var comments = _controller.GetAllNegativeComments();
            Assert.IsNotNull(comments);
        }

        [TestMethod]
        public void ReturnAllPositiveComments()
        {
            var comments = _controller.GetAllPositiveComments();
            Assert.IsNotNull(comments);
        }
    }
}
