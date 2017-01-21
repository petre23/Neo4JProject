using Neo4JModel.BO;
using Neo4JModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.DAO
{
    public class UserDAO : BaseDAO
    {
        public UserDAO() : base() 
        {
        }

        public List<User> GetAllUsersFromDB()
        {
            var users = _client.Cypher
                        .Match("(type:User)")
                        .Return(type => type.As<User>())
                        .Results;

            return users.ToList();
        }

        public User GetUserByUniqueKey(string uniqueKey)
        {
            var users = _client.Cypher
                            .Match("(user:User)")
                            .Where((User user) => user.UniqueKey == uniqueKey)
                            .Return(user => user.As<User>())
                            .Results;
            return users.ToList().FirstOrDefault();
        }

        public User GetUserByUserName(string userName)
        {
            var users = _client.Cypher
                            .Match("(user:User)")
                            .Where((User user) => user.UserName == userName)
                            .Return(user => user.As<User>())
                            .Results;
            return users.ToList().FirstOrDefault();
        }

        public List<User> GetUserWhereNameStartsWith(string userName)
        {
            var users = _client.Cypher
                            .Match("(user:User)")
                            .Where((User user) => user.UserName.StartsWith(userName))
                            .Return(user => user.As<User>())
                            .Results;
            return users.ToList();
        }

        public List<User> GetUserFromLocation(string homeLocation)
        {
            var users = _client.Cypher
                            .Match("(user:User)")
                            .Where((User user) => user.UserName.Contains(homeLocation))
                            .Return(user => user.As<User>())
                            .Results;
            return users.ToList();
        }
    }
}
