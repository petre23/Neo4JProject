using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtCrawler.Model;

namespace TxtCrawler.Common.Controller.SQL
{
    public class SqlProcessor
    {
        private SqlController _controller = new SqlController();

        public void InsertLocation(Locatie locatie) 
        {
            _controller.InsertOrUpdateLocatie(locatie);
        }

        public void InsertUsersForLocation(List<User> users, Locatie locatie) 
        {
            foreach(var user in users)
            {
                _controller.InsertOrUpdateUser(user, locatie.Nume);
            }
        }

        public void InsertUserWithoutLocation(User user) 
        {
            _controller.InsertUserWithoutLocation(user);    
        }

        public void InsertComment(Comment comment, string userID) 
        {
            _controller.InsertComment(comment,userID);
        }
    }
}
