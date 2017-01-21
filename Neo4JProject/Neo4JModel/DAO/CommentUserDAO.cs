using Neo4JModel.BO;
using Neo4JModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.DAO
{
    public class CommentUserDAO: BaseDAO
    {
        public CommentUserDAO() : base() 
        {
        }

        public List<Comment> GetCommentsForUser(User userUnique) 
        {
            var comments = _client.Cypher
                            .Match("(user:User)-[:Commented]->(comment:Comment)")
                            .Where((User user) => user.UniqueKey == userUnique.UniqueKey)
                            .Return(comment => comment.As<Comment>())
                            .Results;
            return comments.ToList();
        }

        public List<User> GetAllUsersWithPositiveComments() 
        {
            var users = _client.Cypher
                .Match("(user:User)-[:Commented]->(comment:Comment)")
                .Where((Comment comment) => comment.PositiveComment != null && comment.PositiveComment != string.Empty)
                .Return(user => user.As<User>())
                .Results;

            return users.ToList();
        }
    }
}
